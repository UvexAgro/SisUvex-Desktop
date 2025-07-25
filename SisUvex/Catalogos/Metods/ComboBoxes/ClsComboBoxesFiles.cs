
using SisUvex.Catalogos.Metods.Querys;

using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
namespace SisUvex.Catalogos.Metods.ComboBoxes
{
    internal class ClsComboBoxFiles
    {
        public static string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string rutaConsultaCbo = Path.Combine(dataDirectory, "querys", "cbo");
        private static Dictionary<string, string> cboFiles = new Dictionary<string, string>();
        private static Dictionary<string, string> lastUpdateDates = new Dictionary<string, string>();

        public static DataTable GetCboCatalogDataTable(string catalogName)
        {
            DataTable dataTable = new DataTable();

            if (!cboFiles.ContainsKey(catalogName)) //SI CBOFILES NO CONTIENE EL NOMBRE DEL CATALOGO, LO AGREGA COMO RUTA
                cboFiles[catalogName] = Path.Combine(rutaConsultaCbo, catalogName + ".dat");

            if (lastUpdateDates.Count == 0) //SI NO HAY NADA EN LASTUPDATEDATES, LO CARGA DEL ARCHIVO
                LoadLastUpdateDates();

            if (!lastUpdateDates.ContainsKey(catalogName)) //SI NO CONTIENE EL NOMBRE DEL CATALOGO EN EL DICCIONARIO, LO AGREGA CON LA FECHA MINIMA
                lastUpdateDates[catalogName] = DateTime.MinValue.ToString();

            string lastUpdateDate = lastUpdateDates[catalogName]; //OBTIENE LA FECHA DE ACTUALIZACION DEL CATALOGO EN EL DICCIONARIO
            string databaseLastUpdateDate = GetDataBaseLastUpdateDate(catalogName); //OBTIENE LA LA FECHA DE LA ULTIMA ACTUALIZACION EN LA BASE DE DATOS DE PARA ESE CATALOGO SEGUN CUALES REFERENCIAS TIENE

            if (lastUpdateDate != databaseLastUpdateDate)
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

                lastUpdateDates[catalogName] = databaseLastUpdateDate; // ACTUALIZA LA ULTIMA FECHA DE ACTUALIZACION EN EL DICCIONARIO
                SaveLastUpdateDates(); // ACTUALIZA LA ULTIMA FECHA DE ACTUALIZACION EN EL ARCHIVO DE LAS FECHAS DE ACTUALIZACIONES
            }
            else if (File.Exists(cboFiles[catalogName])) // SI NO HA HABIDO ACTUALIZACIONES, ENTONCES JALA DIRECTO DEL ARCHIVO DEL CATALOGO
            {
                using (FileStream fileStream = new FileStream(cboFiles[catalogName], FileMode.Open))
                {
                    var serializedData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(fileStream);
                    dataTable = ConvertListToDataTable(serializedData);
                }
            }
            // PARA MOSTRAR LOS NOMBRES DE LAS COLUMNAS DEL DATATABLE
            //string columnNames = string.Join("\n", dataTable.Columns.Cast<DataColumn>().Select(c => $"-{c.ColumnName}-"));
            //MessageBox.Show(columnNames);
            return dataTable;
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
                case ClsObject.GrowFarm.Cbo:
                    queryDataTable = ClsObject.GrowFarm.QueryCbo;
                    break;
                case ClsObject.Season.Cbo:
                    queryDataTable = ClsObject.Season.QueryCbo;
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
                default:
                    // Handle unknown table names
                    break;
            }
            return ClsQuerysDB.GetDataTable(queryDataTable);
        }

        private static string GetDataBaseLastUpdateDate(string catalogName)
        {
            string query = "SELECT MAX(d_update) AS 'd_update' FROM Pack_TablesUpdates WHERE v_nameTable ";
            switch (catalogName) //SI ES UNO DE LAS OPCIONES LE METE EL FILTRO PARA OBTENER LA FECHA MAS RECIENTE DE ESAS DOS
            {
                case ClsObject.Variety.Cbo:
                    query += " IN ('Pack_Variety', 'Pack_Crop')";
                    break;
                case ClsObject.Lot.Cbo:
                    query += " IN ('Pack_Variety', 'Pack_Crop', 'Pack_Lot','Grow_Farm')";
                    break;
                case ClsObject.Presentation.Cbo:
                    query += " IN ('Pack_Category', 'Pack_Presentation') ";
                    break;
                case ClsObject.WorkGroup.Cbo:
                    query += " IN ('Pack_Contractor', 'Pack_WorkGroup') ";
                    break;
                case ClsObject.Gtin.DgvCatalog:
                    query += " IN ('Pack_Gtin', 'Pack_Variety', 'Pack_Container', 'Pack_Distributor', 'Pack_Price', 'Pack_Pti', 'Pack_Presentation') ";
                    break;
                case ClsObject.WorkPlan.DgvCatalog:
                case ClsObject.WorkPlan.CboPresentation:
                    query += " IN ('Pack_WorkPlan', 'Pack_Gtin', 'Pack_Variety', 'Pack_Container', 'Pack_Distributor', 'Pack_Pti', 'Pack_Size', 'Pack_WorkGroup', 'Pack_Contractor', 'Pack_Lot', 'Pack_Presentation', 'Pack_Crop', 'Pack_TypeBox') ";
                    break;
                case ClsObject.ProductionLine.Cbo:
                    query += " IN ('Nom_ProductionLine', 'Pack_WorkGroup') ";
                    break;
                case ClsObject.Season.Cbo:
                    query += " IN ('Pack_Season', 'Pack_Crop') ";
                    break;
                case ClsObject.Consignee.Cbo:
                    query += " IN ('Pack_Consignee', 'Pack_Distributor') ";
                    break;
                case ClsObject.Driver.Cbo:
                    query += " IN ('Pack_TransportLine', 'Pack_Driver') ";
                    break;
                case ClsObject.Truck.Cbo:
                    query += " IN ('Pack_TransportLine', 'Pack_Truck') ";
                    break;
                case ClsObject.FreightContainer.Cbo:
                case ClsObject.FreightContainer.CboTypeContainer:
                    query += " IN ('Pack_TransportLine', 'Pack_FreightContainer') ";
                    break;
                case ClsObject.ManifestTemplate.Cbo:
                    query += " IN ('Pack_ManifestTemplates', 'Pack_Distributor', 'Pack_Grower', 'Pack_Consignee', 'Pack_AgencyTrade', 'Pack_City') ";
                    break;
                case ClsObject.MaterialCatalog.Cbo:
                    query += " IN ('Pack_MaterialCatalog', 'Pack_MaterialType', 'Pack_Distributor', 'Pack_Color', 'Pack_Unit', 'Pack_Category') ";
                    break;
                case ClsObject.MaterialType.Cbo:
                    query += " IN ('Ast_MaterialType', 'Ast_MaterialCatalog') ";
                    break;
                default: //SI NO ES NINGUNO DE ESOS, BUSCA EL NOMBRE DE LA TABLA PARA QUE SEA ESA SOLAMENTE
                    string tableName = GetTableName(catalogName);
                    query += $" = '{tableName}'";
                    break;
            }

            return ClsQuerysDB.GetData(query).ToString();
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
                    return ClsObject.Season.TableName;
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
                default:
                    return string.Empty;// Handle unknown table names
            }
        }

        public static bool IsInfoNeededToUpdate(string catalogName)
        {
            //CONSULTA SI LA INFORMACION DEL CATALOGO NECESITA SER ACTUALIZADA
            if (!lastUpdateDates.ContainsKey(catalogName))
                return false;

            string lastUpdateDate = lastUpdateDates[catalogName];

            string databaseLastUpdateDate = GetDataBaseLastUpdateDate(catalogName);
            if (lastUpdateDate != databaseLastUpdateDate)
                return true;
            else
                return false;
        }
    }
}
