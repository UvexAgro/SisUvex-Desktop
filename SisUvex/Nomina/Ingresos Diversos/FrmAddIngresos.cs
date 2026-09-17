using System.Data;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.Extentions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using static SisUvex.Catalogos.Metods.ClsObject;



namespace SisUvex.Nomina.Ingresos_Diversos
{
	public partial class FrmAddIngresos : Form
	{
		public string IdAttendence;
		public string IdWorkGroupEmployeeDaily;

		public string IdConcepto = null;
		public decimal? MontoActual = null;
		public bool EsEdicion = false;
		public List<string> IdsAttendence;
		FrmIncomeConcepts frmDia;

		public bool EsCampo { get; set; }
		public DateTime Fecha { get; set; }

		ClsIngresosDiversos cls;


		public FrmAddIngresos(string idAttendence, string idWorkGroupEmployeeDaily, string idConcepto, decimal monto, bool esCampo)
		{
			InitializeComponent();

			IdAttendence = idAttendence;
			IdWorkGroupEmployeeDaily = idWorkGroupEmployeeDaily;
			IdConcepto = idConcepto;
			MontoActual = monto;
			EsEdicion = true;
			EsCampo = esCampo;

			cls = new ClsIngresosDiversos();
			cls.frmAdd = this;

			cls.CboConceptos();

		}
		public FrmAddIngresos(List<string> ids, bool esCampo)
		{
			InitializeComponent();

			IdsAttendence = ids;
			EsCampo = esCampo;
			EsEdicion = false;

			cls = new ClsIngresosDiversos();
			cls.frmAdd = this;

			cls.CboConceptos();
		}
		public FrmAddIngresos(string idAttendence)
		{
			InitializeComponent();

			IdAttendence = idAttendence;
			EsEdicion = false;

			cls = new ClsIngresosDiversos();
			cls.frmAdd = this;

			cls.CboConceptos();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cboConceptos_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboConceptos.SelectedIndex <= 0) return;

			txbMonto.Text = cboConceptos.GetColumnValue("Monto").ToString();
			txbHoras.Text = cboConceptos.GetColumnValue("HorasExtras").ToString();
		}

		private void FrmAddIngresos_Load(object sender, EventArgs e)
		{
			cls ??= new();
			cls.frmAdd ??= this;
			cls.CboConceptos();
			ClsTextBoxes.TxbApplyKeyPressEventNumericWithLimit(txbMmodificar, 9, 2);

			if (EsEdicion)
			{
				this.Text = "Modificar Ingreso";
				btnAccept.Text = "Actualizar";
				lblAdd.Text = "Modificar Ingreso";

				cboConceptos.SelectedValue = IdConcepto;

				cboConceptos_SelectedIndexChanged(null, null);
			}
			else
			{
				this.Text = "Añadir Ingreso";
				btnAccept.Text = "Guardar";
				lblAdd.Text = "Añadir Ingreso";

				if (cboConceptos.Items.Count > 0)
				{
					cboConceptos.SelectedIndex = 0;


					cboConceptos_SelectedIndexChanged(null, null);
				}

			}
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			if (!(cboConceptos.SelectedValue is string))
			{
				MessageBox.Show("Debe seleccionar un concepto válido");
				return;
			}

			if (EsEdicion)
				cls.ActualizarIngreso(Fecha);
			else
				cls.InsertarIngreso(Fecha);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
