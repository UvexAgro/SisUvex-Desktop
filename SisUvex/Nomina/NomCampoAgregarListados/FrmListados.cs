using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisUvex.Nomina.NomCuadrillasCampo;

namespace SisUvex.Nomina.NomCampoAgregarListados
{
	public partial class FrmListados : Form
	{
		public ClsListados cls;
		public ClsAsistencia _clsA;
		public FrmListados()
		{
			InitializeComponent();
			cls = new ClsListados();
			cls.frm = this;

			_clsA = new ClsAsistencia();
			_clsA.frm = this;
			cls.CrearColumnasListado();
			cls.EstiloDgvListado();

		}
		private void HasEditCatalogsPermission() //metodo para dar permisos al usuario 
		{
			if (User.HasEditCatalogsPermission())
				return;
			btnMostrar.Enabled = false;
		}
		private void FrmListados_Load(object sender, EventArgs e)
		{
			cls.CargarCuadrillas();
			cls.EstiloDgvCuadrilla();
			cls.CargarSemanas();
			HasEditCatalogsPermission();
		}

		private void btnMostrar_Click(object sender, EventArgs e)
		{
			if (dgvCuadrilla.CurrentRow == null)
			{
				MessageBox.Show(
					"Primero seleccione una cuadrilla.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			// ==========================================
			// OBTENER SEMANA
			// ==========================================

			if (!ObtenerSemanaSeleccionada(
				out string secuenciaSemana,
				out DateTime fechaInicio,
				out DateTime fechaFin))
			{
				return;
			}

			// ==========================================
			// OBTENER ID REAL DE LA CUADRILLA
			// ID = id_workGroup
			// Codigo = c_order
			// ==========================================

			string idCuadrilla =
				dgvCuadrilla.CurrentRow
				.Cells["ID"]
				.Value?
				.ToString()
				.Trim();

			// ==========================================
			// OBTENER NOMBRE
			// ==========================================

			string nombreCuadrilla =
				dgvCuadrilla.CurrentRow
				.Cells["Cuadrilla"]
				.Value?
				.ToString()
				.Trim();

			// ==========================================
			// VALIDAR ID
			// ==========================================

			if (string.IsNullOrWhiteSpace(idCuadrilla))
			{
				MessageBox.Show(
					"No se pudo obtener el ID de la cuadrilla.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// MOSTRAR NOMBRE
			// ==========================================

			lblCuadrilla.Text = nombreCuadrilla;

			// ==========================================
			// CARGAR EMPLEADOS USANDO EL ID REAL
			// ==========================================

			cls.CargarEmpleadosCuadrilla(
				idCuadrilla,
				secuenciaSemana,
				fechaInicio,
				fechaFin);

			// ==========================================
			// ACTUALIZAR
			// ==========================================

			cls.ActualizarTotalEmpleados();

			cls.MostrarEmpleados();
		}


		private void btnAgregar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(lblCuadrilla.Text))
			{
				MessageBox.Show(
					"Primero seleccione una cuadrilla.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			if (!ObtenerSemanaSeleccionada(
				out string secuenciaSemana,
				out DateTime fechaInicio,
				out DateTime fechaFin))
			{
				return;
			}

			string idCuadrilla =
				dgvCuadrilla.CurrentRow
				.Cells["ID"]
				.Value?
				.ToString()
				.Trim();

			if (string.IsNullOrWhiteSpace(idCuadrilla))
			{
				MessageBox.Show(
					"No se pudo obtener el ID de la cuadrilla.",
					"Cuadrilla",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			FrmAgregar frmAgregar = new FrmAgregar();

			// AQUÍ MANDAMOS EL id_workGroup
			frmAgregar.IdCuadrilla = idCuadrilla;

			frmAgregar.FechaInicio = fechaInicio;
			frmAgregar.FechaFin = fechaFin;
			frmAgregar.SecuenciaSemana = secuenciaSemana;

			if (frmAgregar.ShowDialog() == DialogResult.OK)
			{
				pnlSinEmpleados.Visible = false;
				dgvListado.Visible = true;

				cls.CargarEmpleadosCuadrilla(
					idCuadrilla,
					secuenciaSemana,
					fechaInicio,
					fechaFin);

				cls.ActualizarTotalEmpleados();
			}
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			List<string> cuadrillasSeleccionadas =
		cls.ObtenerCuadrillasSeleccionadas();

			if (cuadrillasSeleccionadas.Count == 0)
			{
				MessageBox.Show(
					"Seleccione al menos una cuadrilla.",
					"Imprimir listas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			if (cboSemana.SelectedValue == null)
			{
				MessageBox.Show(
					"Seleccione una semana.",
					"Imprimir listas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string idSemana =
				cboSemana.SelectedValue.ToString();

			try
			{
				Cursor.Current = Cursors.WaitCursor;

				// Cambia ClsJ por el nombre real de tu clase.
				MemoryStream pdf =
					cls.GenerarPdfListasCuadrillas(
						cuadrillasSeleccionadas,
						idSemana);

				string ruta =
					Path.Combine(
						Path.GetTempPath(),
						"ListasCuadrillas.pdf");

				using (FileStream archivo =
					new FileStream(
						ruta,
						FileMode.Create,
						FileAccess.Write))
				{
					pdf.CopyTo(archivo);
				}

				System.Diagnostics.Process.Start(
					new System.Diagnostics.ProcessStartInfo
					{
						FileName = ruta,
						UseShellExecute = true
					});
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al generar las listas:\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnActulizar_Click(object sender, EventArgs e)
		{
			cls.btnCopiarDatosDeLaSemanaAnterior();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FrmAsistencia frm = new FrmAsistencia();

			frm.ShowDialog();
		}
		public bool ObtenerSemanaSeleccionada(out string secuenciaSemana, out DateTime fechaInicio, out DateTime fechaFin)
		{
			secuenciaSemana = "";
			fechaInicio = DateTime.MinValue;
			fechaFin = DateTime.MinValue;

			DataRowView semana = cboSemana.SelectedItem as DataRowView;

			if (semana == null)
			{
				MessageBox.Show(
					"Seleccione una semana.",
					"Semana",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return false;
			}

			secuenciaSemana =
				semana["c_sequence_per"]?.ToString();

			fechaInicio =
				Convert.ToDateTime(semana["d_startDate_per"]);

			fechaFin =
				Convert.ToDateTime(semana["d_endDate_per"]);

			return true;
		}

		private void btnQuitar_Click(object sender, EventArgs e)
		{
			if (dgvListado.SelectedRows.Count == 0)
			{
				MessageBox.Show(
					"Seleccione uno o varios empleados.",
					"Quitar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			if (dgvCuadrilla.CurrentRow == null)
			{
				MessageBox.Show(
					"Seleccione una cuadrilla.",
					"Quitar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			if (!ObtenerSemanaSeleccionada(
				out string secuenciaSemana,
				out DateTime fechaInicio,
				out DateTime fechaFin))
			{
				return;
			}

			string idCuadrilla =
			dgvCuadrilla.CurrentRow.Cells["ID"].Value?.ToString();

			if (string.IsNullOrWhiteSpace(idCuadrilla))
			{
				MessageBox.Show(
					"No se pudo obtener la cuadrilla.",
					"Quitar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// Guardar los códigos de los empleados seleccionados
			List<string> empleadosSeleccionados = new List<string>();

			foreach (DataGridViewRow fila in dgvListado.SelectedRows)
			{
				if (fila.IsNewRow)
					continue;

				string idEmpleado =
					fila.Cells["Codigo"].Value?.ToString();

				if (!string.IsNullOrWhiteSpace(idEmpleado))
				{
					empleadosSeleccionados.Add(idEmpleado);
				}
			}

			if (empleadosSeleccionados.Count == 0)
			{
				MessageBox.Show(
					"No se encontraron empleados seleccionados.",
					"Quitar empleados",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				return;
			}

			DialogResult resultado = MessageBox.Show(
				$"¿Desea quitar {empleadosSeleccionados.Count} empleado(s) seleccionados?",
				"Confirmar eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (resultado != DialogResult.Yes)
				return;

			int eliminados = 0;

			// Eliminar los empleados seleccionados
			foreach (string idEmpleado in empleadosSeleccionados)
			{
				bool eliminado = cls.EliminarEmpleadoCuadrilla(
					idEmpleado,
					idCuadrilla,
					secuenciaSemana,
					fechaInicio,
					fechaFin);

				if (eliminado)
				{
					eliminados++;
				}
			}

			// Recargar la lista
			cls.CargarEmpleadosCuadrilla(
				idCuadrilla,
				secuenciaSemana,
				fechaInicio,
				fechaFin);

			cls.ActualizarTotalEmpleados();

			MessageBox.Show(
				$"Se quitaron {eliminados} empleado(s) correctamente.",
				"Quitar empleados",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void dgvCuadrilla_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex == -1 &&
			e.ColumnIndex >= 0 &&
			dgvCuadrilla.Columns[e.ColumnIndex].Name == "Imprimir")
			{
				e.PaintBackground(e.CellBounds, true);

				Image imagen = Properties.Resources.impresora;

				int tamaño = 25;

				Rectangle destino = new Rectangle(
					e.CellBounds.X + (e.CellBounds.Width - tamaño) / 2,
					e.CellBounds.Y + (e.CellBounds.Height - tamaño) / 2,
					tamaño,
					tamaño);

				e.Graphics.DrawImage(
					imagen,
					destino);

				e.Handled = true;
			}
		}

		private void btnImprimir2_Click(object sender, EventArgs e)
		{
			// ==========================================
			// OBTENER CUADRILLAS SELECCIONADAS
			// ==========================================

			List<string> cuadrillasSeleccionadas =
				cls.ObtenerCuadrillasSeleccionadas();

			if (cuadrillasSeleccionadas.Count == 0)
			{
				MessageBox.Show(
					"Seleccione al menos una cuadrilla.",
					"Imprimir listas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			// ==========================================
			// VALIDAR SEMANA
			// ==========================================

			if (cboSemana.SelectedValue == null)
			{
				MessageBox.Show(
					"Seleccione una semana.",
					"Imprimir listas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			string idSemana =
				cboSemana.SelectedValue.ToString();

			try
			{
				Cursor.Current = Cursors.WaitCursor;

				// ==========================================
				// GENERAR PDF
				// ==========================================

				DialogResult resultado = MessageBox.Show(
					"¿Desea imprimir en horizontal?\n\n" +
					"Sí = Horizontal\n" +
					"No = Vertical",
					"Orientación",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Question);

				if (resultado == DialogResult.Cancel)
					return;

				bool horizontal = resultado == DialogResult.Yes;

				MemoryStream pdf =
					cls.PdfListasCuadrillas(
						cuadrillasSeleccionadas,
						idSemana,
						horizontal);

				// ==========================================
				// GUARDAR PDF TEMPORAL
				// ==========================================

				string ruta =
					Path.Combine(
						Path.GetTempPath(),
						"ListasPorActividad.pdf");

				using (FileStream archivo =
					new FileStream(
						ruta,
						FileMode.Create,
						FileAccess.Write))
				{
					pdf.CopyTo(archivo);
				}

				// ==========================================
				// ABRIR PDF
				// ==========================================

				System.Diagnostics.Process.Start(
					new System.Diagnostics.ProcessStartInfo
					{
						FileName = ruta,
						UseShellExecute = true
					});
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al generar las listas:\n\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnVertical_Click(object sender, EventArgs e)
		{
			List<string> cuadrillasSeleccionadas =
	   cls.ObtenerCuadrillasSeleccionadas();

			if (cuadrillasSeleccionadas.Count == 0)
			{
				MessageBox.Show(
					"Seleccione al menos una cuadrilla.",
					"Imprimir",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}

			if (cboSemana.SelectedValue == null)
			{
				MessageBox.Show(
					"Seleccione una semana.",
					"Imprimir",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				return;
			}


			// ==========================================
			// PREGUNTAR ORIENTACIÓN
			// ==========================================

			DialogResult resultado = MessageBox.Show(
				"¿Desea imprimir en VERTICAL?\n\n" +
				"Sí = Vertical\n" +
				"No = Horizontal",
				"Orientación de impresión",
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Question);

			if (resultado == DialogResult.Cancel)
				return;


			// Sí = Vertical
			// No = Horizontal
			bool horizontal =
				resultado == DialogResult.No;


			string idSemana =
				cboSemana.SelectedValue.ToString();


			try
			{
				Cursor.Current = Cursors.WaitCursor;


				// ==========================================
				// GENERAR PDF
				// ==========================================

				MemoryStream pdf =
					cls.GenerarPdfListasCuadrillas(
						cuadrillasSeleccionadas,
						idSemana,
						horizontal);


				// ==========================================
				// GUARDAR PDF
				// ==========================================

				string nombreArchivo =
					horizontal
						? "ListasCuadrillasHorizontal.pdf"
						: "ListasCuadrillasVertical.pdf";


				string ruta =
					Path.Combine(
						Path.GetTempPath(),
						nombreArchivo);


				using (FileStream archivo =
					new FileStream(
						ruta,
						FileMode.Create,
						FileAccess.Write))
				{
					pdf.CopyTo(archivo);
				}


				// ==========================================
				// ABRIR PDF
				// ==========================================

				System.Diagnostics.Process.Start(
					new System.Diagnostics.ProcessStartInfo
					{
						FileName = ruta,
						UseShellExecute = true
					});
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error al generar el PDF:\n\n" +
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		

		private void btnActividad_Click(object sender, EventArgs e)
		{
			cls.ActividadEmpleadoSemana();
		}
	}
}
