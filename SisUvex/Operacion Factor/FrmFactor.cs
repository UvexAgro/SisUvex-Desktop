using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Nomina.Conceptos_Ingresos_Diversos;
using static SisUvex.Catalogos.Metods.ClsObject;


namespace SisUvex.Operacion_Factor
{
	public partial class FrmFactor : Form
	{
		public ClsFactor cls;

		public FrmFactor()
		{
			InitializeComponent();

			cls = new ClsFactor();
			cls.frm = this;
			dtpFecha.ValueChanged += dtpFecha_ValueChanged;
		}

		private void FrmFactor_Load(object sender, EventArgs e)
		{

			cls.CargarPromedioLbs();
		}

		private void dtpFecha_ValueChanged(object sender, EventArgs e)
		{

			cls.CargarPromedioLbs();
			cls.CargarTablaPackingHouse();
		}

		private void btncargar_Click(object sender, EventArgs e)
		{

			DateTime fecha = dtpFecha.Value;

			if (!decimal.TryParse(txbCajasenPiso.Text, out decimal cajasPiso))
			{
				MessageBox.Show("Ingrese un número válido en Cajas en Piso");
				return;
			}

			if (!decimal.TryParse(txbLibras.Text, out decimal libras))
			{
				MessageBox.Show("Las libras no son válidas");
				return;
			}

			for (int i = 0; i < 2; i++)
			{
				cls.GuardarPackingHouse(fecha, cajasPiso, libras);
			}


			cls.CargarTablaPackingHouse();

			MessageBox.Show("Datos guardados correctamente.");

		}

		private void txbCajasenPiso_TextChanged(object sender, EventArgs e)
		{
			if (decimal.TryParse(txbPesodeCaja.Text, out decimal pesoCaja) &&
				decimal.TryParse(txbCajasenPiso.Text, out decimal cajas))
			{
				decimal libras = pesoCaja * cajas;

				txbLibras.Text = libras.ToString("0.00");
			}
		}
	}

}
