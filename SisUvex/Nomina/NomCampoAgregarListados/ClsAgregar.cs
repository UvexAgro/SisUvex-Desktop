using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office.Word;
using NPOI.SS.Formula.Functions;
using SisUvex.Catalogos.Metods.Values;
using SisUvex.Nomina.Reporte_de_Emp_UVA;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.NomCampoAgregarListados
{

	public class ClsAgregar
	{
		public FrmAgregar frmA;
		public string LugarPago { get; set; }
		public string IdLugarPago { get; set; }
		private DataTable dtActividades = new DataTable();
		public class DiaRegistro
		{
			public string Nombre { get; set; }
			public DateTime Fecha { get; set; }

			public string Texto
			{
				get
				{
					return $"{Nombre} {Fecha:dd/MM/yyyy}";
				}
			}
		}
		public void CargarEmpleadosSeleccionados(List<string> empleados)
		{
			if (empleados == null || empleados.Count == 0)
				return;

			// Pasar los códigos al textbox
			frmA.txbCodigo.Text = string.Join(", ", empleados);

			// Utilizar el mismo método que ya tienes
			// para agregar varios empleados
			btnAgregarVariosEmpleados();

			// Limpiar el textbox después de agregarlos
			frmA.txbCodigo.Clear();
		}
		

		public void btnAgregarVariosEmpleados()
		{
			string textoCodigos = frmA.txbCodigo.Text.Trim();

			// VALIDAR CÓDIGOS

			if (string.IsNullOrWhiteSpace(textoCodigos))
			{
				MessageBox.Show(
					"Ingrese al menos un código de empleado.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				frmA.txbCodigo.Focus();
				return;
			}

			// SEPARAR CÓDIGOS

			string[] codigos = textoCodigos
				.Split(
					new char[] { '\r', '\n', ',', ' ', ';', '\t' },
					StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.Distinct()
				.ToArray();

			if (codigos.Length == 0)
			{
				MessageBox.Show(
					"No se encontraron códigos válidos.",
					"Empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// BUSCAR EMPLEADOS

			foreach (string codigo in codigos)
			{
				DataTable dt =
					BuscarEmpleadoPorCodigo(codigo);

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show(
						"No se encontró el empleado con código: " + codigo,
						"Empleado no encontrado",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					continue;
				}

				DataRow row = dt.Rows[0];

				// EVITAR DUPLICADOS

				bool existe = false;

				foreach (DataGridViewRow fila
					in frmA.dgvListadoAgregar.Rows)
				{
					if (fila.IsNewRow)
						continue;

					if (fila.Cells["Codigo"].Value?.ToString()
						== codigo)
					{
						existe = true;
						break;
					}
				}

				if (existe)
					continue;

				// AGREGAR AL DGV

				frmA.dgvListadoAgregar.Rows.Add(
					codigo,
					row["Empleado"].ToString(),
					row["IdLugarPago"] == DBNull.Value
						? ""
						: row["IdLugarPago"].ToString() + " - " +
						  row["LugarPago"].ToString(),

					row["IdLugarPago"] == DBNull.Value
						? ""
						: row["IdLugarPago"].ToString()
				);
			}

			frmA.txbCodigo.Clear();
			frmA.txbCodigo.Focus();
		}

		private DataTable BuscarEmpleadoPorCodigo(string codigo)
		{
			SQLControl sql = new SQLControl();

			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				string query = @"
			SELECT
				E.id_employee,

				E.v_lastNamePat + ' ' +
				E.v_lastNameMat + ' ' +
				E.v_name AS Empleado,

				RIGHT(
					'0000' + CAST(E.id_paymentPlace AS VARCHAR(4)),
					4
				) AS IdLugarPago,

				P.v_namePlace AS LugarPago

			FROM dbo.Nom_Employees E

			LEFT JOIN dbo.Nom_PlacePayment P
				ON P.id_placePayment = E.id_paymentPlace

			WHERE E.id_employee = @codigo;
		";

				using (SqlCommand cmd =
					new SqlCommand(query, sql.cnn))
				{
					cmd.Parameters.AddWithValue(
						"@codigo",
						codigo);

					using (SqlDataAdapter da =
						new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Error al buscar empleado",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				sql.CloseConectionWrite();
			}

			return dt;
		}


		public void EstiloDgvListadoAgregar()
		{
			DataGridView dgv = frmA.dgvListadoAgregar;

			// GENERAL

			dgv.BackgroundColor = System.Drawing.Color.White;
			dgv.BorderStyle = BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor =
				System.Drawing.Color.FromArgb(225, 228, 235);

			dgv.EnableHeadersVisualStyles = false;

			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;

			dgv.ReadOnly = true;

			dgv.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			dgv.MultiSelect = false;

			dgv.RowHeadersVisible = false;

			// ENCABEZADO

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				System.Drawing.Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor =
				System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				System.Drawing.Color.FromArgb(42, 67, 128);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font(
					"Segoe UI",
					9F,
					FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 36;

			// FILAS

			dgv.DefaultCellStyle.Font =
				new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				System.Drawing.Color.FromArgb(45, 45, 55);

			dgv.DefaultCellStyle.BackColor =
				System.Drawing.Color.White;

			dgv.DefaultCellStyle.SelectionBackColor =
				System.Drawing.Color.FromArgb(220, 229, 250);

			dgv.DefaultCellStyle.SelectionForeColor =
				System.Drawing.Color.FromArgb(30, 45, 80);

			dgv.DefaultCellStyle.Padding =
				new Padding(6, 0, 6, 0);

			dgv.RowTemplate.Height = 32;

			// FILAS ALTERNADAS

			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				System.Drawing.Color.FromArgb(247, 249, 253);

			// COLUMNAS

			dgv.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

			dgv.Columns["Codigo"].FillWeight = 15;

			dgv.Columns["Nombre"].FillWeight = 50;

			dgv.Columns["LugarPago"].FillWeight = 35;

			// ALINEACIÓN

			dgv.Columns["Codigo"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.Columns["Nombre"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;

			dgv.Columns["LugarPago"].DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleLeft;
		}
	}
}
