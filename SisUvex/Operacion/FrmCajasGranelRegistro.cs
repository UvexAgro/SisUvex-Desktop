﻿using SisUvex.Catalogos.Metods.ComboBoxes;

namespace SisUvex.Operacion
{
    internal partial class FrmCajasGranelRegistro : Form
    {
        public ClsCajasGranelRegistro cls;

        public decimal _KgTotalesNetos, _KgTotales, _KgPorCaja, _TaraTarima, _TaraCaja, _CajasFila, _CajasTotales;

        public FrmCajasGranelRegistro()
        {
            InitializeComponent();
        }

        private void FrmCajasGranelRegistro_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls.frmAdd ??= this;

            cls.FrmAddModifyBegin();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (IsRegistroValido())
                cls.AddItemAlDGV();
        }
        private void btnSacarRegistro_Click(object sender, EventArgs e)
        {
            cls.RemoveItemAlDGV();
        }
        public bool IsRegistroValido()
        {
            if (txbIdLote.Text != string.Empty && txbCajasRegistro.Text != string.Empty && txbPapeleta.Text != string.Empty && txbKgTotales.Text != string.Empty)
                return true;
            else
                return false;
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void txbValoresKilogramos_TextChanged(object sender, EventArgs e)
        {
            
        }                                                                        
    }
}