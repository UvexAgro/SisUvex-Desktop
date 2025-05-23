﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Catalogos.WorkGroup;

namespace SisUvex.Material.MaterialProvider
{
    internal partial class FrmMaterialProviderAdd : Form
    {
        public ClsMaterialProvider cls;
        public FrmMaterialProviderAdd()
        {
            InitializeComponent();
        }

        private void FrmMaterialProviderAdd_Load(object sender, EventArgs e)
        {
            cls ??= new();
            cls._frmAdd ??= this;
            cls.BeginFormAdd();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cls.BtnAccept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
