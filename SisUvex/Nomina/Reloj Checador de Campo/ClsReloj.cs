using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Nomina.Reloj_Checador_de_Campo
{
	internal class ClsReloj
	{
		public FrmReloj frm;
		public (bool, string?) ObtenerEmpleado(string codigo)
		{
			SQLControl sql = new SQLControl();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(@"
            SELECT LTRIM(RTRIM(CONCAT(
                v_name, ' ',
                v_lastNamePat, ' ',
                v_lastNameMat
            )))
            FROM dbo.Nom_Employees
            WHERE id_employee = @Codigo;", sql.cnn))
				{
					cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 6)
						.Value = codigo.Trim().PadLeft(6, '0');

					object result = cmd.ExecuteScalar();

					if (result != null && result != DBNull.Value)
						return (true, result.ToString());

					return (false, null);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Buscar empleado");
				return (false, null);
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public DataTable ObtenerChecadas(string? codigoEmpleado, DateTime fecha)
		{
			SQLControl sql = new SQLControl();
			DataTable dt = new DataTable();

			try
			{
				sql.OpenConectionWrite();

				using (SqlCommand cmd = new SqlCommand(@"
            SELECT
                RIGHT(
                    '000000' + LTRIM(RTRIM(
                        CAST(h.id_employee AS VARCHAR(20))
                    )), 6
                ) AS Codigo,

                LTRIM(RTRIM(CONCAT(
                    e.v_lastNamePat, ' ',
                    e.v_lastNameMat, ' ',
                    e.v_name
                ))) AS Empleado,

                CAST(h.d_date AS DATE) AS Fecha,

                MIN(CAST(h.d_time AS TIME))
                    AS [Primera Checada],

                MAX(CAST(h.d_time AS TIME))
                    AS [Última Checada]

            FROM dbo.Nom_HikvisionIVMS h

            LEFT JOIN dbo.Nom_Employees e
                ON RIGHT('000000' + LTRIM(RTRIM(
                    CAST(e.id_employee AS VARCHAR(20))
                )), 6)
                =
                RIGHT('000000' + LTRIM(RTRIM(
                    CAST(h.id_employee AS VARCHAR(20))
                )), 6)

            WHERE
                h.d_date >= @Fecha
                AND h.d_date < DATEADD(DAY, 1, @Fecha)

                AND (
                    @Codigo IS NULL
                    OR RIGHT('000000' + LTRIM(RTRIM(
                        CAST(h.id_employee AS VARCHAR(20))
                    )), 6) = @Codigo
                )

            GROUP BY
                h.id_employee,
                e.v_lastNamePat,
                e.v_lastNameMat,
                e.v_name,
                CAST(h.d_date AS DATE)

            ORDER BY
                e.v_lastNamePat,
                e.v_lastNameMat,
                e.v_name;",
					sql.cnn))
				{
					string codigo = codigoEmpleado?.Trim() ?? "";

					cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 6)
						.Value = string.IsNullOrWhiteSpace(codigo)
							? DBNull.Value
							: codigo.PadLeft(6, '0');

					cmd.Parameters.Add("@Fecha", SqlDbType.Date)
						.Value = fecha.Date;

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}

				return dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"Consultar checadas",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return dt;
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		public void ConfigurarGridReloj()
		{
			DataGridView dgv = frm.dgvLista;

			dgv.ReadOnly = true;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.MultiSelect = false;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.RowHeadersVisible = false;
			dgv.AutoGenerateColumns = true;

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			dgv.RowTemplate.Height = 35;

			// Encabezados: azul de nómina
			dgv.EnableHeadersVisualStyles = false;

			dgv.ColumnHeadersDefaultCellStyle.BackColor =
				Color.FromArgb(47, 117, 163);

			dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

			dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(47, 117, 163);

			dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

			dgv.ColumnHeadersDefaultCellStyle.Font =
				new Font("Segoe UI", 9F, FontStyle.Bold);

			dgv.ColumnHeadersDefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			dgv.ColumnHeadersHeight = 38;

			// Filas normales
			dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);

			dgv.DefaultCellStyle.ForeColor =
				Color.FromArgb(35, 55, 77);

			dgv.DefaultCellStyle.BackColor = Color.White;

			// Filas alternadas: azul muy claro de nómina
			dgv.AlternatingRowsDefaultCellStyle.BackColor =
				Color.FromArgb(241, 247, 252);

			// Selección: azul de nómina
			dgv.DefaultCellStyle.SelectionBackColor =
				Color.FromArgb(31, 111, 170);

			dgv.DefaultCellStyle.SelectionForeColor = Color.White;

			dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor =
				Color.FromArgb(31, 111, 170);

			dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor =
				Color.White;

			// Alineación
			dgv.DefaultCellStyle.Alignment =
				DataGridViewContentAlignment.MiddleCenter;

			// Bordes y fondo
			dgv.BorderStyle = BorderStyle.None;

			dgv.CellBorderStyle =
				DataGridViewCellBorderStyle.SingleHorizontal;

			dgv.GridColor = Color.FromArgb(220, 230, 238);

			dgv.BackgroundColor = Color.White;
		}
	}
}
