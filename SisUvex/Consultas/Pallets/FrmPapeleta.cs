using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Consultas.Pallets
{
	public partial class FrmPapeleta : Form
	{
		public FrmPalletConsulta frm;
		ClsPalletConsulta cls = new ClsPalletConsulta();

		public FrmPapeleta()
		{
			InitializeComponent();
			cls.frmP = this;
		}

		private void FrmPapeleta_Load(object sender, EventArgs e)
		{
			dgvConsulta.CurrentCellDirtyStateChanged += dgvConsulta_CurrentCellDirtyStateChanged;
		}


		private void btnInvoice_Click(object sender, EventArgs e)
		{
			cls.btnBuscarPapeleta();
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			cls.btnActualizar();
		}

		private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dgvConsulta.Columns["Seleccionar"].Index)
			{
				dgvConsulta.EndEdit();
			}
		}

		private void dgvConsulta_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvConsulta.IsCurrentCellDirty)
			{
				dgvConsulta.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
	}
}
