
using SisUvex.Catalogos.Metods.Querys;

using System.Data;
using System.Text.Json;
using System.Text.RegularExpressions;
namespace SisUvex.Catalogos.Metods.ComboBoxes
{
    internal class ClsComboBoxFiles
    {
        public static string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string rutaConsultaCbo = Path.Combine(dataDirectory, "querys", "cbo");
        private static Dictionary<string, string> cboFiles = new Dictionary<string, string>();
        private static Dictionary<string, string> lastUpdateDates = new Dictionary<string, string>();

        //CACHE EN MEMORIA PARA NO REPETIR ALTER/CHECKS DE CHANGE TRACKING EN LA MISMA SESION
        private static bool dbChangeTrackingReady = false;
        private static readonly HashSet<string> tablesWithChangeTracking = new(StringComparer.OrdinalIgnoreCase);
        private static readonly Regex safeSqlName = new(@"^[A-Za-z_][A-Za-z0-9_]*$", RegexOptions.Compiled);

        public static DataTable GetCboCatalogDataTable(string catalogName)
        {
            DataTable dataTable = new DataTable();

            if (!cboFiles.ContainsKey(catalogName)) //SI CBOFILES NO CONTIENE EL NOMBRE DEL CATALOGO, LO AGREGA COMO RUTA
                cboFiles[catalogName] = Path.Combine(rutaConsultaCbo, catalogName + ".dat");

            if (lastUpdateDates.Count == 0) //SI NO HAY NADA EN LASTUPDATEDATES, LO CARGA DEL ARCHIVO
                LoadLastUpdateDates();

            if (!lastUpdateDates.ContainsKey(catalogName)) //SI NO CONTIENE EL NOMBRE DEL CATALOGO EN EL DICCIONARIO, LO AGREGA CON LA FECHA MINIMA
                lastUpdateDates[catalogName] = DateTime.MinValue.ToString();

            string lastUpdateDate = lastUpdateDates[catalogName]; //OBTIENE EL WATERMARK LOCAL DEL CATALOGO EN EL DICCIONARIO
            //OBTIENE EL WATERMARK DE CHANGE TRACKING EN BD PARA LAS TABLAS QUE USA ESE CATALOGO
            string databaseLastUpdateDate = GetDataBaseLastUpdateDate(catalogName, out bool forceRefresh);

            if (forceRefresh) //HUBO CAMBIOS EN EL GRUPO DE TABLAS O SE HABILITO CT POR PRIMERA VEZ
            {
                dataTable = GetDataTableForFile(catalogName); //OBTIENE EL DATATABLE SEGUN EL NOMBRE DEL CATALOGO

                string directoryPath = Path.GetDirectoryName(cboFiles[catalogName]); //OBTIENE LA DIRECCION DEL ARCHIVO DE ESE CATALOGO
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                using (FileStream fileStream = new FileStream(cboFiles[catalogName], FileMode.Create)) //LE AGREGA EL DATATABLE A ESE ARCHIVO
                {
                    var serializedData = ConvertDataTableToList(dataTable);    //////////////////////////////////////////
                    JsonSerializer.Serialize(fileStream, serializedData);
                }

                lastUpdateDates[catalogName] = databaseLastUpdateDate; // ACTUALIZA EL WATERMARK EN EL DICCIONARIO
                SaveLastUpdateDates(); // ACTUALIZA EL WATERMARK EN EL ARCHIVO DE LAS FECHAS/VERSIONES DE ACTUALIZACIONES
            }
            else
            {
                //SI SOLO SUBIO LA VERSION GLOBAL POR OTRA TABLA, AVANZA EL WATERMARK LOCAL SIN RECONSULTAR
                if (lastUpdateDate != databaseLastUpdateDate)
                {
                    lastUpdateDates[catalogName] = databaseLastUpdateDate;
                    SaveLastUpdateDates();
                }

                if (File.Exists(cboFiles[catalogName])) // SI NO HA HABIDO ACTUALIZACIONES DEL GRUPO, JALA DIRECTO DEL ARCHIVO
                {
                    using (FileStream fileStream = new FileStream(cboFiles[catalogName], FileMode.Open))
                    {
                        var serializedData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(fileStream);
                        dataTable = ConvertListToDataTable(serializedData);
                    }
                }
                else //SI NO HAY ARCHIVO LOCAL, CONSULTA BD UNA VEZ
                {
                    dataTable = GetDataTableForFile(catalogName);
                    string directoryPath = Path.GetDirectoryName(cboFiles[catalogName]);
                    if (!Directory.Exists(directoryPath))
                        Directory.CreateDirectory(directoryPath);
                    using (FileStream fileStream = new FileStream(cboFiles[catalogName], FileMode.Create))
                    {
                        var serializedData = ConvertDataTableToList(dataTable);
                        JsonSerializer.Serialize(fileStream, serializedData);
                    }
                }
            }
            // PARA MOSTRAR LOS NOMBRES DE LAS COLUMNAS DEL DATATABLE
            //string columnNames = string.Join("\n", dataTable.Columns.Cast<DataColumn>().Select(c => $"-{c.ColumnName}-"));
            //MessageBox.Show(columnNames);
            return dataTable;
        }

        /// <summary>
        /// Fuerza que la próxima llamada a <see cref="GetCboCatalogDataTable"/> para <paramref name="catalogName"/>
        /// vuelva a consultar la base de datos, ignorando el archivo cacheado en disco.
        /// Útil después de un alta/modificación/estatus hecho desde la aplicación, si se quiere
        /// refrescar de inmediato sin esperar a que Change Tracking marque un watermark distinto.
        /// </summary>
        public static void InvalidateCache(string catalogName)
        {
            if (lastUpdateDates.Count == 0)
                LoadLastUpdateDates();

            lastUpdateDates[catalogName] = DateTime.MinValue.ToString();
            SaveLastUpdateDates();
        }

        public static void SaveLastUpdateDates()
        {
            //GUARDAR EL ARCHIVO DE LAS FECHAS DE ACTUALIZACIONES
            string filePath = Path.Combine(rutaConsultaCbo, "lastUpdateDates.dat");

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, lastUpdateDates);
            }
        }

        public static void LoadLastUpdateDates()
        {
            //CARGAR EL ARCHIVO DE LAS FECHAS DE ACTUALIZACIONES
            string filePath = Path.Combine(rutaConsultaCbo, "lastUpdateDates.dat");
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    lastUpdateDates = JsonSerializer.Deserialize<Dictionary<string, string>>(fileStream);
                }
            }
        }

        private static List<Dictionary<string, object>> ConvertDataTableToList(DataTable table)
        {
            //CONVIERTE EL DATATABLE A UNA LISTA DE DICCIONARIOS INCLUYENDO NULLS
            var result = new List<Dictionary<string, object>>();
            foreach (DataRow row in table.Rows)
            {
                var rowDict = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                {
                    // Reemplazar DBNull.Value por null
                    rowDict[column.ColumnName] = row[column] == DBNull.Value ? null : row[column];
                }
                result.Add(rowDict);
            }
            return result;
        }


        private static DataTable ConvertListToDataTable(List<Dictionary<string, object>> list)
        {
            //CONVIERTE LA LISTA DE DICCIONARIOS A UN DATATABLE INCLUYENDO NULLS
            DataTable table = new DataTable();
            if (list.Count > 0)
            {
                foreach (var column in list[0].Keys)
                {
                    table.Columns.Add(column);
                }

                foreach (var rowDict in list)
                {
                    var row = table.NewRow();
                    foreach (var column in rowDict.Keys)
                    {
                        // Reemplazar null por DBNull.Value
                        row[column] = rowDict[column] ?? DBNull.Value;
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }


        private static DataTable GetDataTableForFile(string catalogName)
        {// OBTIENE EL DATATABLE SEGUN LA QUERY SEGUN QUE OBJETO SEA
            string queryDataTable = string.Empty;
            switch (catalogName)
            {
                case ClsObject.Category.Cbo:
                    queryDataTable = ClsObject.Category.QueryCbo;
                    break;
                case ClsObject.Crop.Cbo:
                    queryDataTable = ClsObject.Crop.QueryCbo;
                    break;
                case ClsObject.Color.Cbo:
                    queryDataTable = ClsObject.Color.QueryCbo;
                    break;
                case ClsObject.Variety.Cbo:
                    queryDataTable = ClsObject.Variety.QueryCbo;
                    break;
                case ClsObject.Lot.Cbo:
                    queryDataTable = ClsObject.Lot.QueryCbo;
                    break;
                case ClsObject.Lot.CboOnlyNameLot:
                    queryDataTable = ClsObject.Lot.QueryCboOnlyNameLot;
                    break;
                case ClsObject.Lot.CboOnlyNameLotFacility:
                    queryDataTable = ClsObject.Lot.QueryCboOnlyNameLotFacility;
                    break;
                case ClsObject.Lot.CboOnlyNameLotPlantTracking:
                    queryDataTable = ClsObject.Lot.QueryOnlyNameLotPlantTracking;
                    break;
                case ClsObject.Distributor.Cbo:
                    queryDataTable = ClsObject.Distributor.QueryCbo;
                    break;
                case ClsObject.Container.Cbo:
                    queryDataTable = ClsObject.Container.QueryCbo;
                    break;
                case ClsObject.Presentation.Cbo:
                    queryDataTable = ClsObject.Presentation.QueryCbo;
                    break;
                case ClsObject.Pti.Cbo:
                    queryDataTable = ClsObject.Pti.QueryCbo;
                    break;
                case ClsObject.Price.Cbo:
                    queryDataTable = ClsObject.Price.QueryCbo;
                    break;
                case ClsObject.WorkGroup.Cbo:
                    queryDataTable = ClsObject.WorkGroup.QueryCbo;
                    break;
                case ClsObject.Size.Cbo:
                    queryDataTable = ClsObject.Size.QueryCbo;
                    break;
                case ClsObject.Gtin.DgvForWorkPlan:
                    queryDataTable = ClsObject.Gtin.QueryDgvForWorkPlan;
                    break;
                case ClsObject.WorkPlan.DgvCatalog:
                    queryDataTable = ClsObject.WorkPlan.QueryDgvCatalog;
                    break;
                case ClsObject.WorkPlan.CboPresentation:
                    queryDataTable = ClsObject.WorkPlan.QueryCboPresentation;
                    break;
                case ClsObject.Grower.Cbo:
                    queryDataTable = ClsObject.Grower.QueryCbo;
                    break;
                case ClsObject.ProductionLine.Cbo:
                    queryDataTable = ClsObject.ProductionLine.QueryCbo;
                    break;
                case ClsObject.Contractor.Cbo:
                    queryDataTable = ClsObject.Contractor.QueryCbo;
                    break;
                case ClsObject.Season.Cbo:
                    queryDataTable = ClsObject.Season.QueryCbo;
                    break;
                case ClsObject.Season.CboWithDates:
                    queryDataTable = ClsObject.Season.QueryCboWithDates;
                    break;
                case ClsObject.SeasonType.Cbo:
                    queryDataTable = ClsObject.SeasonType.QueryCbo;
                    break;
                case ClsObject.PlacePayment.Cbo:
                    queryDataTable = ClsObject.PlacePayment.QueryCbo;
                    break;
                case ClsObject.Payroll_AttendancePeriod.Cbo:
                    queryDataTable = ClsObject.Payroll_AttendancePeriod.QueryCbo;
                    break;
                case ClsObject.City.Cbo:
                    queryDataTable = ClsObject.City.QueryCbo;
                    break;
                case ClsObject.Consignee.Cbo:
                    queryDataTable = ClsObject.Consignee.QueryCbo;
                    break;
                case ClsObject.AgencyTradeMX.Cbo:
                    queryDataTable = ClsObject.AgencyTradeMX.QueryCbo;
                    break;
                case ClsObject.AgencyTradeUS.Cbo:
                    queryDataTable = ClsObject.AgencyTradeUS.QueryCbo;
                    break;
                case ClsObject.Truck.Cbo:
                    queryDataTable = ClsObject.Truck.QueryCbo;
                    break;
                case ClsObject.Driver.Cbo:
                    queryDataTable = ClsObject.Driver.QueryCbo;
                    break;
                case ClsObject.TransportLine.Cbo:
                    queryDataTable = ClsObject.TransportLine.QueryCbo;
                    break;
                case ClsObject.FreightContainer.Cbo:
                    queryDataTable = ClsObject.FreightContainer.QueryCbo;
                    break;
                case ClsObject.FreightContainer.CboTypeContainer:
                    queryDataTable = ClsObject.FreightContainer.QueryCboTypeContainer;
                    break;
                case ClsObject.ManifestTemplate.Cbo:
                    queryDataTable = ClsObject.ManifestTemplate.QueryCbo;
                    break;
                case ClsObject.Unit.Cbo:
                    queryDataTable = ClsObject.Unit.QueryCbo;
                    break;
                case ClsObject.MaterialType.Cbo:
                    queryDataTable = ClsObject.MaterialType.QueryCbo;
                    break;
                case ClsObject.MaterialProvider.Cbo:
                    queryDataTable = ClsObject.MaterialProvider.QueryCbo;
                    break;
                case ClsObject.MaterialWarehouse.Cbo:
                    queryDataTable = ClsObject.MaterialWarehouse.QueryCbo;
                    break;
                case ClsObject.MaterialCatalog.Cbo:
                    queryDataTable = ClsObject.MaterialCatalog.QueryCbo;
                    break;
                case ClsObject.ForeignDest.Cbo:
                    queryDataTable = ClsObject.ForeignDest.QueryCbo;
                    break;
                case ClsObject.Farm.Cbo:
                    queryDataTable = ClsObject.Farm.QueryCbo;
                    break;
                case ClsObject.VehicleType.Cbo:
                    queryDataTable = ClsObject.VehicleType.QueryCbo;
                    break;
                case ClsObject.Vehicle.Cbo:
                    queryDataTable = ClsObject.Vehicle.QueryCbo;
                    break;
                case ClsObject.Market.Cbo:
                    queryDataTable = ClsObject.Market.QueryCbo;
                    break;
                case ClsObject.TypeBox.Cbo:
                    queryDataTable = ClsObject.TypeBox.QueryCbo;
                    break;
                case ClsObject.LabelLegend.Cbo:
                    queryDataTable = ClsObject.LabelLegend.QueryCbo;
                    break;
                case ClsObject.AttendanceType.Cbo:
                    queryDataTable = ClsObject.AttendanceType.QueryCbo;
                    break;
                case ClsObject.Nom_WorkGroup.Cbo:
                    queryDataTable = ClsObject.Nom_WorkGroup.QueryCbo;
                    break;
                case ClsObject.Nom_AgriculturalCycle.Cbo:
                    queryDataTable = ClsObject.Nom_AgriculturalCycle.QueryCbo;
                    break;
                default:
                    // Handle unknown table names
                    break;
            }
            return ClsQuerysDB.GetDataTable(queryDataTable);
        }

        /// <summary>
        /// OBTIENE EL WATERMARK DE CHANGE TRACKING PARA EL CATALOGO.
        /// SI FALTA CT EN LA BD O EN ALGUNA TABLA DEL GRUPO, LO HABILITA Y FUERZA REFRESCO ESA PRIMERA VEZ.
        /// </summary>
        private static string GetDataBaseLastUpdateDate(string catalogName, out bool forceRefresh)
        {
            forceRefresh = false;

            List<string> tables = GetCatalogTables(catalogName); //TABLAS QUE AFECTAN ESTE CATALOGO (1 O VARIAS)
            if (tables.Count == 0)
                return string.Empty;

            //SI LA BD NO TIENE CHANGE TRACKING, LO ACTIVA UNA SOLA VEZ
            if (!EnsureDatabaseChangeTracking())
                return DateTime.UtcNow.Ticks.ToString(); //SI FALLA EL ENSURE, FUERZA REFRESCO PARA NO QUEDAR CON CACHE VIEJO

            bool newlyEnabled = false;
            foreach (string tableName in tables) //REVISA CADA TABLA DEL GRUPO; SI NO TIENE CT, LO CREA
            {
                if (EnsureTableChangeTracking(tableName))
                    newlyEnabled = true;
            }

            string currentVersion = GetChangeTrackingCurrentVersion(); //VERSION ACTUAL DE CT EN LA BD
            if (string.IsNullOrEmpty(currentVersion))
                currentVersion = "0";

            //SI SE ACABA DE HABILITAR CT EN ALGUNA TABLA, NO HAY HISTORIAL PREVIO: HAY QUE REFRESCAR EL .DAT
            if (newlyEnabled)
            {
                forceRefresh = true;
                return currentVersion;
            }

            //SI EL WATERMARK LOCAL NO ES NUMERICO (CACHE VIEJO DE Pack_TablesUpdates / MinValue), FUERZA REFRESCO
            if (!long.TryParse(lastUpdateDates.GetValueOrDefault(catalogName), out long lastVersion))
            {
                forceRefresh = true;
                return currentVersion;
            }

            if (long.TryParse(currentVersion, out long current) && current > lastVersion)
            {
                //SI LA VERSION SUBIO, REVISA SI ALGUNA TABLA DEL GRUPO TUVO CAMBIOS DESDE LA VERSION LOCAL
                forceRefresh = CatalogTablesHaveChanges(tables, lastVersion);
            }

            return currentVersion;
        }

        /// <summary>
        /// LISTA DE TABLAS CUYOS CAMBIOS INVALIDAN EL CACHE DEL CATALOGO.
        /// SI EL CATALOGO DEPENDE DE JOINS/COMBOS RELACIONADOS, SE PONEN VARIAS.
        /// </summary>
        private static List<string> GetCatalogTables(string catalogName)
        {
            switch (catalogName) //SI ES UNO DE LOS QUE DEPENDEN DE VARIAS TABLAS, DEVUELVE EL GRUPO
            {
                case ClsObject.Variety.Cbo:
                    return new List<string> { "Pack_Variety", "Pack_Crop" };
                case ClsObject.Lot.Cbo:
                case ClsObject.Lot.CboOnlyNameLot:
                case ClsObject.Lot.CboOnlyNameLotPlantTracking:
                case ClsObject.Lot.CboOnlyNameLotFacility:
                    return new List<string> { "Pack_Variety", "Pack_Crop", "Pack_Lot", "Grow_Farm" };
                case ClsObject.Presentation.Cbo:
                    return new List<string> { "Pack_Category", "Pack_Presentation" };
                case ClsObject.WorkGroup.Cbo:
                    return new List<string> { "Pack_Contractor", "Pack_WorkGroup", "Pack_Season", "Pack_SeasonType" };
                case ClsObject.Gtin.DgvCatalog:
                case ClsObject.Gtin.DgvForWorkPlan:
                    return new List<string> { "Pack_GTIN", "Pack_Variety", "Pack_Container", "Pack_Distributor", "Pack_Price", "Pack_PtiType", "Pack_Presentation" };
                case ClsObject.WorkPlan.DgvCatalog:
                case ClsObject.WorkPlan.CboPresentation:
                    return new List<string>
                    {
                        "Pack_WorkPlan", "Pack_GTIN", "Pack_Variety", "Pack_Container", "Pack_Distributor",
                        "Pack_PtiType", "Pack_Size", "Pack_WorkGroup", "Pack_Contractor", "Pack_Lot",
                        "Pack_Presentation", "Pack_Crop", "Pack_TypeBox", "Pack_LabelLegend"
                    };
                case ClsObject.ProductionLine.Cbo:
                    return new List<string> { "Nom_ProductionLine", "Pack_WorkGroup" };
                case ClsObject.Season.Cbo:
                case ClsObject.Season.CboWithDates:
                    return new List<string> { "Pack_Season", "Pack_Crop", "Pack_SeasonType" };
                case ClsObject.PlacePayment.Cbo:
                    return new List<string> { "Nom_PlacePayment", "Pack_Grower", "Pack_Contractor", "Pack_WorkGroup" };
                //case ClsObject.Payroll_AttendancePeriod.Cbo:
                //    return new List<string> { "Payroll_AttendancePeriod" };
                case ClsObject.Consignee.Cbo:
                    return new List<string> { "Pack_Consignee", "Pack_Distributor" };
                case ClsObject.Driver.Cbo:
                    return new List<string> { "Pack_TransportLine", "Pack_Driver" };
                case ClsObject.Truck.Cbo:
                    return new List<string> { "Pack_TransportLine", "Pack_Truck" };
                case ClsObject.FreightContainer.Cbo:
                case ClsObject.FreightContainer.CboTypeContainer:
                    return new List<string> { "Pack_TransportLine", "Pack_FreightContainer" };
                case ClsObject.ManifestTemplate.Cbo:
                    return new List<string> { "Pack_ManifestTemplates", "Pack_Distributor", "Pack_Grower", "Pack_Consignee", "Pack_AgencyTrade", "Pack_City" };
                case ClsObject.MaterialCatalog.Cbo:
                    return new List<string> { "Pack_MaterialCatalog", "Pack_MaterialType", "Pack_Distributor", "Pack_Color", "Pack_Unit", "Pack_Category" };
                case ClsObject.MaterialType.Cbo:
                    return new List<string> { "Pack_MaterialType", "Pack_MaterialCatalog" };
                default: //SI NO ES NINGUNO DE ESOS, BUSCA EL NOMBRE DE LA TABLA PARA QUE SEA ESA SOLAMENTE
                    string tableName = GetTableName(catalogName);
                    return string.IsNullOrEmpty(tableName)
                        ? new List<string>()
                        : new List<string> { tableName };
            }
        }

        private static string GetTableName(string catalogName)
        {
            switch (catalogName)
            {
                case ClsObject.Category.Cbo:
                    return ClsObject.Category.TableName;
                case ClsObject.Crop.Cbo:
                    return ClsObject.Crop.TableName;
                case ClsObject.Color.Cbo:
                    return ClsObject.Color.TableName;
                case ClsObject.Variety.Cbo:
                    return ClsObject.Variety.TableName;
                case ClsObject.Lot.Cbo:
                case ClsObject.Lot.CboOnlyNameLot:
                case ClsObject.Lot.CboOnlyNameLotPlantTracking:
                case ClsObject.Lot.CboOnlyNameLotFacility:
                    return ClsObject.Lot.TableName;
                case ClsObject.Distributor.Cbo:
                    return ClsObject.Distributor.TableName;
                case ClsObject.Container.Cbo:
                    return ClsObject.Container.TableName;
                case ClsObject.Presentation.Cbo:
                    return ClsObject.Presentation.TableName;
                case ClsObject.Pti.Cbo:
                    return ClsObject.Pti.TableName;
                case ClsObject.Price.Cbo:
                    return ClsObject.Price.TableName;
                case ClsObject.WorkGroup.Cbo:
                    return ClsObject.WorkGroup.TableName;
                case ClsObject.Size.Cbo:
                    return ClsObject.Size.TableName;
                case ClsObject.Gtin.DgvForWorkPlan:
                    return ClsObject.Gtin.TableName;
                case ClsObject.WorkPlan.DgvCatalog:
                case ClsObject.WorkPlan.CboPresentation:
                    return ClsObject.WorkPlan.TableName;
                case ClsObject.Grower.Cbo:
                    return ClsObject.Grower.TableName;
                case ClsObject.ProductionLine.Cbo:
                    return ClsObject.ProductionLine.TableName;
                case ClsObject.Contractor.Cbo:
                    return ClsObject.Contractor.TableName;
                case ClsObject.Season.Cbo:
                case ClsObject.Season.CboWithDates:
                    return ClsObject.Season.TableName;
                case ClsObject.SeasonType.Cbo:
                    return ClsObject.SeasonType.TableName;
                case ClsObject.PlacePayment.Cbo:
                    return ClsObject.PlacePayment.TableName;
                case ClsObject.Payroll_AttendancePeriod.Cbo:
                    return ClsObject.Payroll_AttendancePeriod.TableName;
                case ClsObject.City.Cbo:
                    return ClsObject.City.TableName;
                case ClsObject.Consignee.Cbo:
                    return ClsObject.Consignee.TableName;
                case ClsObject.AgencyTradeMX.Cbo:
                    return ClsObject.AgencyTradeMX.TableName;
                case ClsObject.AgencyTradeUS.Cbo:
                    return ClsObject.AgencyTradeUS.TableName;
                case ClsObject.TransportLine.Cbo:
                    return ClsObject.TransportLine.TableName;
                case ClsObject.Driver.Cbo:
                    return ClsObject.Driver.TableName;
                case ClsObject.Truck.Cbo:
                    return ClsObject.Truck.TableName;
                case ClsObject.FreightContainer.Cbo:
                case ClsObject.FreightContainer.CboTypeContainer:
                    return ClsObject.FreightContainer.TableName;
                case ClsObject.ManifestTemplate.Cbo:
                    return ClsObject.ManifestTemplate.TableName;
                case ClsObject.Unit.Cbo:
                    return ClsObject.Unit.TableName;
                case ClsObject.MaterialType.Cbo:
                    return ClsObject.MaterialType.TableName;
                case ClsObject.MaterialProvider.Cbo:
                    return ClsObject.MaterialProvider.TableName;
                case ClsObject.MaterialWarehouse.Cbo:
                    return ClsObject.MaterialWarehouse.TableName;
                case ClsObject.MaterialCatalog.Cbo:
                    return ClsObject.MaterialCatalog.TableName;
                case ClsObject.ForeignDest.Cbo:
                    return ClsObject.ForeignDest.TableName;
                case ClsObject.Farm.Cbo:
                    return ClsObject.Farm.TableName;
                case ClsObject.VehicleType.Cbo:
                    return ClsObject.VehicleType.TableName;
                case ClsObject.Vehicle.Cbo:
                    return ClsObject.Vehicle.TableName;
                case ClsObject.Market.Cbo:
                    return ClsObject.Market.TableName;
                case ClsObject.TypeBox.Cbo:
                    return ClsObject.TypeBox.TableName;
                case ClsObject.LabelLegend.Cbo:
                    return ClsObject.LabelLegend.TableName;
                case ClsObject.AttendanceType.Cbo:
                    return ClsObject.AttendanceType.TableName;
                case ClsObject.Nom_WorkGroup.TableName:
                    return ClsObject.Nom_WorkGroup.Cbo;
                case ClsObject.Nom_AgriculturalCycle.TableName:
                    return ClsObject.Nom_AgriculturalCycle.Cbo;
                default:
                    return string.Empty;// Handle unknown table names
            }
        }

        /// <summary>
        /// ACTIVA CHANGE TRACKING A NIVEL DE BASE DE DATOS SI AUN NO ESTA ACTIVO.
        /// </summary>
        private static bool EnsureDatabaseChangeTracking()
        {
            if (dbChangeTrackingReady)
                return true;

            //REVISA SI YA ESTA ACTIVO EN LA BD ACTUAL
            string exists = ClsQuerysDB.GetData("SELECT 1 FROM sys.change_tracking_databases WHERE database_id = DB_ID()");

            if (exists == "1")
            {
                dbChangeTrackingReady = true;
                return true;
            }

            //LO ACTIVA EN LA BD ACTUAL (REQUIERE PERMISOS DE ALTER DATABASE)
            string enableDb = @"DECLARE @db sysname = DB_NAME();
                                DECLARE @sql nvarchar(max) = N'ALTER DATABASE ' + QUOTENAME(@db)
                                    + N' SET CHANGE_TRACKING = ON (CHANGE_RETENTION = 7 DAYS, AUTO_CLEANUP = ON)';
                                EXEC sys.sp_executesql @sql;";

            if (!ClsQuerysDB.ExecuteQuery(enableDb))
                return false;

            dbChangeTrackingReady = true;
            return true;
        }

        /// <summary>
        /// ACTIVA CHANGE TRACKING EN LA TABLA SI AUN NO LO TIENE.
        /// DEVUELVE TRUE SI LO HABILITO EN ESTE MOMENTO (PRIMERA VEZ).
        /// </summary>
        private static bool EnsureTableChangeTracking(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName) || !safeSqlName.IsMatch(tableName))
                return false;

            if (tablesWithChangeTracking.Contains(tableName)) //YA SE VERIFICO EN ESTA SESION
                return false;

            //REVISA SI LA TABLA YA TIENE CT
            string exists = ClsQuerysDB.GetData($@" SELECT 1
                                                    FROM sys.change_tracking_tables ct
                                                    INNER JOIN sys.tables t ON t.object_id = ct.object_id
                                                    INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
                                                    WHERE s.name = 'dbo' AND t.name = '{tableName}'");

            if (exists == "1")
            {
                tablesWithChangeTracking.Add(tableName);
                return false; //YA EXISTIA: NO ES PRIMERA VEZ
            }

            //SI LA TABLA NO EXISTE, NO INTENTA ALTER
            string tableExists = ClsQuerysDB.GetData(
                $"SELECT 1 FROM sys.tables t INNER JOIN sys.schemas s ON s.schema_id = t.schema_id WHERE s.name = 'dbo' AND t.name = '{tableName}'");
            if (tableExists != "1")
                return false;

            //HABILITA CT EN LA TABLA (REQUIERE PK Y PERMISOS DE ALTER TABLE)
            string enableTable =
                $"ALTER TABLE [dbo].[{tableName}] ENABLE CHANGE_TRACKING WITH (TRACK_COLUMNS_UPDATED = OFF);";

            if (!ClsQuerysDB.ExecuteQuery(enableTable))
                return false;

            tablesWithChangeTracking.Add(tableName);
            return true; //SE CREO AHORA: LA PRIMERA VEZ HAY QUE REFRESCAR CACHE
        }

        private static string GetChangeTrackingCurrentVersion()
        {
            //VERSION GLOBAL DE CHANGE TRACKING EN LA BD (SUBE CON CUALQUIER CAMBIO EN TABLAS CON CT)
            return ClsQuerysDB.GetData("SELECT CAST(CHANGE_TRACKING_CURRENT_VERSION() AS varchar(30))");
        }

        /// <summary>
        /// REVISA SI ALGUNA DE LAS TABLAS DEL GRUPO TUVO CAMBIOS DESDE @lastVersion.
        /// ASI NO SE INVALIDA EL CACHE POR CAMBIOS DE TABLAS AJENAS AL CATALOGO.
        /// </summary>
        private static bool CatalogTablesHaveChanges(List<string> tables, long lastVersion)
        {
            foreach (string tableName in tables)
            {
                if (string.IsNullOrWhiteSpace(tableName) || !safeSqlName.IsMatch(tableName))
                    continue;

                //SI LA VERSION LOCAL ES MENOR A LA MINIMA VALIDA, CT YA LIMPIO EL HISTORIAL: HAY QUE REFRESCAR
                string minValid = ClsQuerysDB.GetData(
                    $"SELECT CAST(CHANGE_TRACKING_MIN_VALID_VERSION(OBJECT_ID('dbo.{tableName}')) AS varchar(30))");
                if (long.TryParse(minValid, out long minVersion) && lastVersion < minVersion)
                    return true;

                //BUSCA CAMBIOS EN ESA TABLA DESDE LA VERSION LOCAL
                string hasChanges = ClsQuerysDB.GetData($@"SELECT TOP (1) 1 FROM CHANGETABLE(CHANGES [dbo].[{tableName}], {lastVersion}) AS CT");

                if (hasChanges == "1")
                    return true;
            }

            return false;
        }

        public static bool IsInfoNeededToUpdate(string catalogName)
        {
            //CONSULTA SI LA INFORMACION DEL CATALOGO NECESITA SER ACTUALIZADA (CAMBIOS EN SU GRUPO DE TABLAS)
            if (lastUpdateDates.Count == 0)
                LoadLastUpdateDates();

            if (!lastUpdateDates.ContainsKey(catalogName))
                return false;

            GetDataBaseLastUpdateDate(catalogName, out bool forceRefresh);
            return forceRefresh;
        }
    }
}
