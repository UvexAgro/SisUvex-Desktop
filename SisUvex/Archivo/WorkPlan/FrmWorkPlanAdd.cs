﻿using SisUvex.Catalogos.Metods.ComboBoxes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Archivo.WorkPlan
{
    internal partial class FrmWorkPlanAdd : Form
    {
        FrmWorkPlanCat frmCat;
        ClsWorkPlan cls;
        public bool IsAddModify = true, AddIsUpdate = false;
        public string? idModify;
        public FrmWorkPlanAdd(FrmWorkPlanCat frmCatalog, ClsWorkPlan clsClass)
        {
            InitializeComponent();
            frmCat = frmCatalog;
            cls = clsClass;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.btnAcceptAddModify();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmWorkPlanAdd_Load(object sender, EventArgs e)
        {
            cls.BeginFormAdd();
        }

        private void btnIdGTINSelect_Click(object sender, EventArgs e)
        {
            cls.SelectGTIN();
        }

        private void dgvGTIN_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cls.SelectGTIN();
        }
    }
}