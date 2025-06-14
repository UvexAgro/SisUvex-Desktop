﻿using DocumentFormat.OpenXml.Drawing;
using Microsoft.IdentityModel.Tokens;
using SisUvex.Archivo.Manifiesto.ConfManifest;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Forms.SelectionForms;
using SisUvex.Catalogos.WorkGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.Manifiesto
{
    internal partial class FrmManifestAdd : Form
    {
        public ClsManifest cls;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;
        public FrmManifestAdd()
        {
            InitializeComponent();

            cls ??= new ClsManifest();
            cls._frmAdd ??= this;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void FrmManifestAdd_Load(object sender, EventArgs e)
        {
            cls.BeginFormAdd();

        }

        private void chbRemovedDistributor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPallet_Click(object sender, EventArgs e)
        {
            AddPalletToList();
        }

        private void btnRemovePallet_Click(object sender, EventArgs e)
        {
            cls.BtnRemovePallet();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.btnAcceptAddModify();
        }

        private void txbIdPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddPalletToList();
                e.Handled = true;
            }
        }
        private void txbPalletPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddPalletToList();
                e.Handled = true;
            }
        }

        private void AddPalletToList()
        {
            if (int.TryParse(txbPalletPosition.Text, out int Position))

                if (txbIdPallet.Text.IsNullOrEmpty())
                    System.Media.SystemSounds.Hand.Play();
                else
                    cls.BtnAddPallet();
        }

        private void btnMovePalletUp_Click(object sender, EventArgs e)
        {
            cls.BtnMovePalletUp();
        }

        private void btnMovePalletDown_Click(object sender, EventArgs e)
        {
            cls.BtnMovePalletDown();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintManifest_Click(object sender, EventArgs e)
        {
            cls.BtnPrintManifestFrmAdd();
        }

        private void txbDieselLiters_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnConfManifest_Click(object sender, EventArgs e)
        {
            FrmConfManifest frm = new FrmConfManifest();
            frm.ShowDialog();
        }

        private void btnSearchTransportLine_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("TransportLine", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboTransportLine, sel.SelectedValue);
            }
        }

        private void btnSearchDriver_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("Driver", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboDriver, sel.SelectedValue);
            }
        }

        private void btnSearchTruck_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("Truck", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboTruck, sel.SelectedValue);
            }
        }

        private void btnSearchFreightContainer_Click(object sender, EventArgs e)
        {
            ClsSelectionForm sel = new ClsSelectionForm();

            sel.OpenSelectionForm("FreightContainer", "Código");

            if (!sel.SelectedValue.IsNullOrEmpty())
            {
                ClsComboBoxes.CboSelectIndexWithTextInValueMemberKeepingFilter(cboFreightContainer, sel.SelectedValue);
            }
        }

        private void txbIdMarket_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
