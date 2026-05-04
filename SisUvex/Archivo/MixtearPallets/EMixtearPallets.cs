/*
 * EMixtearPallets.cs
 * ====================================================================================
 * Entidades y modelos de datos para el módulo de Mixtear Pallets en Estiba.
 *
 * RELACIONES ENTRE ENTIDADES:
 *   - PalletInfo   → refleja vw_PackPalletCon + gtn.i_palletBoxes.
 *                    Usado en ClsMixtearPallets, FrmMixtearPallets y FrmReestibaPallet.
 *   - TipoReestiba → refleja Pack_PalletUnstowType.
 *                    Usado en ClsMixtearPallets y FrmReestibaPallet.
 *   - ResultadoReestiba → resultado de sp_PackPalletReestiba.
 *                         Devuelto por ClsMixtearPallets.EjecutarReestiba().
 *
 * ESCALABILIDAD:
 *   Para agregar nuevos campos al pallet:
 *     1. Añadir propiedad aquí en PalletInfo.
 *     2. Actualizar la query base en ClsMixtearPallets.QUERY_PALLET_BASE.
 *     3. Actualizar ClsMixtearPallets.MapearFilaAPalletInfo().
 *     4. Agregar DefinicionColumna en ClsMixtearPallets.ObtenerDefinicionColumnas().
 *     5. Agregar valor en ClsMixtearPallets.AgregarPalletAlGrid().
 *
 *   Para agregar un nuevo tipo de reestiba: insertar fila en Pack_PalletUnstowType
 *   y agregar el mapeo de CodigoHeredado si es necesario.
 * ====================================================================================
 */

namespace SisUvex.Archivo.MixtearPallets
{
    /// <summary>
    /// Modelo completo de un pallet con todos sus datos de contexto.
    /// Refleja las columnas de vw_PackPalletCon más i_palletBoxes del GTIN.
    /// </summary>
    internal class PalletInfo
    {
        /* === IDENTIFICADORES === */
        /// <summary>Pack_Pallet.id_pallet</summary>
        public string IdPallet { get; set; } = string.Empty;

        /// <summary>Pack_Pallet.c_mixPallet — posición dentro de la estiba</summary>
        public string Mix { get; set; } = string.Empty;

        /// <summary>Pack_Pallet.c_stowage — estiba a la que pertenece actualmente</summary>
        public string Estiba { get; set; } = string.Empty;

        /* === PROGRAMA / GTIN === */
        /// <summary>Pack_WorkPlan.id_GTIN — identificador del programa de empaque</summary>
        public string Programa { get; set; } = string.Empty;

        /// <summary>Pack_GTIN.n_lbs — libras por caja según el GTIN</summary>
        public decimal LibrasPorCaja { get; set; }

        /// <summary>Pack_GTIN.i_palletBoxes — capacidad estándar de cajas por pallet para este GTIN</summary>
        public int CajasPorPallet { get; set; }

        /* === CANTIDADES DEL PALLET === */
        /// <summary>Pack_Pallet.i_boxes — total de cajas actuales en el pallet</summary>
        public int Cajas { get; set; }

        /// <summary>Pack_Pallet.n_lbs — libras totales del pallet</summary>
        public decimal LibrasPallet { get; set; }

        /* === CARACTERÍSTICAS DEL PRODUCTO === */
        /// <summary>Pack_Size.v_sizeValue</summary>
        public string Tamaño { get; set; } = string.Empty;

        /// <summary>Pack_Presentation.v_namePresentation</summary>
        public string Presentacion { get; set; } = string.Empty;

        /// <summary>Pack_Variety.v_nameComercial</summary>
        public string Variedad { get; set; } = string.Empty;

        /// <summary>Pack_Distributor.v_nameDistShort</summary>
        public string Distribuidor { get; set; } = string.Empty;

        /// <summary>Pack_Container.v_nameContainer</summary>
        public string Contenedor { get; set; } = string.Empty;

        /// <summary>Pack_Crop.v_nameCrop — cultivo al que pertenece la variedad</summary>
        public string Cultivo { get; set; } = string.Empty;

        /* === TRAZABILIDAD === */
        /// <summary>Pack_Lot.v_nameLot + id_lot (formato vista)</summary>
        public string Lote { get; set; } = string.Empty;

        /// <summary>Pack_Pallet.id_manifest</summary>
        public string Manifiesto { get; set; } = string.Empty;

        /// <summary>Pack_Pallet.id_rack</summary>
        public string Rack { get; set; } = string.Empty;

        /// <summary>Pack_Pallet.d_packed (solo fecha, sin hora)</summary>
        public string Fecha { get; set; } = string.Empty;

        /// <summary>Pack_Pallet.v_invoice — papeleta de empaque</summary>
        public string Papeleta { get; set; } = string.Empty;

        /// <summary>Pack_WorkGroup.id_workGroup + Pack_Contractor.v_nameContractor</summary>
        public string Cuadrilla { get; set; } = string.Empty;

        /* === ETIQUETA / EMPAQUE === */
        /// <summary>Pack_GTIN.v_preLabel — prefijo de etiqueta</summary>
        public string Pre { get; set; } = string.Empty;

        /// <summary>Pack_GTIN.v_postLabel — sufijo de etiqueta</summary>
        public string Pos { get; set; } = string.Empty;

        /// <summary>Pack_TypeBox.v_shortNameTypeBox — tipo de caja física</summary>
        public string TipoCaja { get; set; } = string.Empty;
    }

    /// <summary>
    /// Tipo de reestiba de pallets.
    /// Refleja la tabla Pack_PalletUnstowType.
    /// Los códigos heredados ('SO', 'SI', etc.) se usan para llamar al
    /// procedimiento legacy sp_PackPalletReestiba.
    /// </summary>
    internal class TipoReestiba
    {
        /// <summary>Pack_PalletUnstowType.id_unstowType (ej. '01', '02')</summary>
        public string IdTipo { get; set; } = string.Empty;

        /// <summary>Pack_PalletUnstowType.v_unstowTypeName (ej. 'SOBRANTE')</summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>Pack_PalletUnstowType.v_description</summary>
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>Pack_PalletUnstowType.c_active = '1'</summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Mapeo al código del procedure heredado sp_PackPalletReestiba.
        /// SOBRANTE('01')→'SO', SINIESTRADO('02')→'SI', ERROR('03')→'RE', CORTESÍA('04')→'CO'.
        /// Agregar entradas al agregar nuevos tipos en Pack_PalletUnstowType.
        /// </summary>
        public string CodigoHeredado => IdTipo switch
        {
            "01" => "SO",
            "02" => "SI",
            "03" => "RE",
            "04" => "CO",
            _ => "SO"
        };

        /// <summary>
        /// Solo SOBRANTE ('01') crea el nuevo pallet como activo (c_active = '1').
        /// Los demás tipos crean el pallet como inactivo.
        /// </summary>
        public bool NuevoPalletActivo => IdTipo == "01";

        /// <summary>Representación de texto para ComboBox</summary>
        public override string ToString() => Nombre;
    }

    /// <summary>
    /// Resultado devuelto por ClsMixtearPallets.EjecutarReestiba().
    /// Contiene los IDs y cajas de ambos pallets: el original (modificado)
    /// y el nuevo (creado con las cajas sobrantes).
    /// </summary>
    internal class ResultadoReestiba
    {
        public bool Exito { get; set; }

        /// <summary>ID del pallet original (sus cajas fueron reducidas)</summary>
        public string IdPalletOriginal { get; set; } = string.Empty;

        /// <summary>Cajas resultantes del pallet original</summary>
        public int CajasOriginal { get; set; }

        /// <summary>ID del nuevo pallet creado con las cajas sobrantes</summary>
        public string IdPalletNuevo { get; set; } = string.Empty;

        /// <summary>Cajas del nuevo pallet (sobrantes)</summary>
        public int CajasNuevo { get; set; }

        /// <summary>Mensaje descriptivo del resultado de la operación</summary>
        public string Mensaje { get; set; } = string.Empty;
    }
}
