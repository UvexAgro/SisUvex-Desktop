using System.Data;
using System.Data.SqlClient;
using System.Media;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using SisUvex.Catalogos.GTIN_UPC;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.CheckBoxes;
using SisUvex.Catalogos.Metods.ComboBoxes;
using SisUvex.Catalogos.Metods.Controls;
using SisUvex.Catalogos.Metods.DataGridViews;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Catalogos.Metods.TextBoxes;
using SisUvex.Catalogos.Metods.Values;
using static SisUvex.Catalogos.Metods.ClsObject;
using DrawingColor = System.Drawing.Color;


namespace SisUvex.Nomina.Work_time
{
    internal class ClsWorkTime
    {
        SQLControl sql = new SQLControl();
        ClsControls controlList;
        private FrmWorkTimeAdd _frmAdd;
        public FrmWorkTimeCat _frmCat;
        public FrmBoxesPackedPerEmployee frmReport;
        public EWorkTime eWorkTime;
        public ClsDataGridViewCatalogs dgv = new ClsDataGridViewCatalogs();
        public const string ColumnDateWtm = "idFecha";
		private string queryCatalog = $" SELECT [id_workTime] AS '{ClsObject.Column.id}',  d_workTime, FORMAT(d_workTime, 'yyyy-MMM-dd, dddd', 'es-MX') AS 'Fecha', FORMAT([d_workTime], 'yyyy-MM-dd') AS '{ColumnDateWtm}', id_ProductionLine AS '{ClsObject.ProductionLine.ColumnName}', [id_workGroup] AS '{ClsObject.WorkGroup.ColumnName}' ,FORMAT([d_dateHourBeginNormal],'yy/MM/dd hh:mm tt', 'es-MX') AS 'Inicio hora normal' ,FORMAT([d_dateHourEndNormal],'yy/MM/dd hh:mm tt', 'es-MX') AS 'Fin hora normal' ,FORMAT([d_dateHourBeginExtra],'yy/MM/dd hh:mm tt', 'es-MX') AS 'Inicio hora extra' ,FORMAT([d_dateHourEndExtra],'yy/MM/dd hh:mm tt', 'es-MX') AS 'Fin hora extra',d_overtime AS 'Horas Extras', i_workers AS 'Trabajadores', FORMAT(CAST(t_BreakStart AS DATETIME), 'hh:mm tt', 'es-MX') AS 'Break Inicio', FORMAT(CAST(t_BreakEnd AS DATETIME), 'hh:mm tt', 'es-MX') AS 'Break Fin', d_BreakHours AS 'Horas Break', FORMAT(CAST(t_LunchStart AS DATETIME), 'hh:mm tt', 'es-MX') AS 'Comida Inicio',FORMAT(CAST(t_LunchEnd AS DATETIME), ' hh:mm tt', 'es-MX') AS 'Comida Fin', d_LunchHours AS 'Horas Comida', FORMAT(CAST(t_DinnerStart AS DATETIME), 'hh:mm tt', 'es-MX') AS 'Cena Inicio', FORMAT(CAST(t_DinnerEnd AS DATETIME), 'hh:mm tt', 'es-MX') AS 'Cena Fin', d_DinnerHours AS 'Horas Cena', FORMAT(CAST(t_BreakStart2 AS DATETIME), ' hh:mm tt', 'es-MX') AS 'Break2 Inicio', FORMAT(CAST(t_BreakEnd2 AS DATETIME), ' hh:mm tt', 'es-MX') AS 'Break2 Fin', d_BreakHours2 AS 'Horas2 Break' FROM [Nom_WorkTime] ";
		private string queryOrderBy = " ORDER BY [d_workTime] DESC";
        public DataTable dtCatalog; 
        public DataTable dtCatalogActives;
        public ClsWorkTime()
        {
            _frmCat = new FrmWorkTimeCat(this);

            // _frmAdd = new FrmGtinAdd(_frmCat, this);
        }
        public void BeginFormCat()
        {
            ClsComboBoxes.CboLoadActives(_frmCat.cboProductionLine, ClsObject.ProductionLine.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmCat.cboProductionLine, _frmCat.chbActiveProductionLine);
			CargarPeriodos();

			dgv.queryCatalog = queryCatalog;
            dgv.dgvCatalog = _frmCat.dgvCatalog;

			_frmCat.dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			_frmCat.dgvCatalog.ColumnHeadersHeight = 50;
			_frmCat.dgvCatalog.EnableHeadersVisualStyles = false;

			//  CENTRAR TEXTO
			_frmCat.dgvCatalog.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			_frmCat.dgvCatalog.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//  AJUSTAR ENCABEZADOS
			AjustarEncabezados();

			if (_frmCat.dgvCatalog.Columns.Contains("d_workTime"))
			{
				_frmCat.dgvCatalog.Columns["d_workTime"].Visible = false;
			}
		}
		public void OrdenarColumnas()
		{
			var dgv = _frmCat.dgvCatalog;

			
			for (int x = 0; x < dgv.Columns.Count; x++)
			{
				dgv.Columns[x].DisplayIndex = x;
			}

			int i = 0;

			void SetIndex(string col)
			{
				if (dgv.Columns.Contains(col))
				{
					dgv.Columns[col].DisplayIndex = i;
					i++;
				}
			}

			//  BASE
			SetIndex("Fecha");
			SetIndex("Banda");
			SetIndex("Cuadrilla");

			//  INICIO NORMAL
			SetIndex("Inicio hora normal");

			//  COMIDA
			SetIndex("Comida Inicio");
			SetIndex("Comida Fin");
			SetIndex("Horas Comida");

			//  CENA
			SetIndex("Cena Inicio");
			SetIndex("Cena Fin");
			SetIndex("Horas Cena");

			//  DESCANSO 1
			SetIndex("Break Inicio");
			SetIndex("Break Fin");
			SetIndex("Horas Break");

			//  DESCANSO 2
			SetIndex("Break2 Inicio");
			SetIndex("Break2 Fin");
			SetIndex("Horas2 Break");

			//  FIN NORMAL
			SetIndex("Fin hora normal");

			//  EXTRAS
			SetIndex("Inicio hora extra");
			SetIndex("Fin hora extra");
			SetIndex("Horas Extras");

			//  FINAL
			SetIndex("Trabajadores");
		}
		public void ColorearColumnas()
		{
			var dgv = _frmCat.dgvCatalog;

			//  DESCANSO
			if (dgv.Columns.Contains("Break Inicio"))
			{
				dgv.Columns["Break Inicio"].DefaultCellStyle.BackColor = _frmCat.colorDescanso;
				dgv.Columns["Break Fin"].DefaultCellStyle.BackColor = _frmCat.colorDescanso;
				dgv.Columns["Horas Break"].DefaultCellStyle.BackColor = _frmCat.colorDescanso;
			}

			//  COMIDA
			if (dgv.Columns.Contains("Comida Inicio"))
			{
				dgv.Columns["Comida Inicio"].DefaultCellStyle.BackColor = _frmCat.colorComida;
				dgv.Columns["Comida Fin"].DefaultCellStyle.BackColor = _frmCat.colorComida;
				dgv.Columns["Horas Comida"].DefaultCellStyle.BackColor = _frmCat.colorComida;
			}

			// CENA
			if (dgv.Columns.Contains("Cena Inicio"))
			{
				dgv.Columns["Cena Inicio"].DefaultCellStyle.BackColor = _frmCat.colorCena;
				dgv.Columns["Cena Fin"].DefaultCellStyle.BackColor = _frmCat.colorCena;
				dgv.Columns["Horas Cena"].DefaultCellStyle.BackColor = _frmCat.colorCena;
			}
			//  DESCANSO
			if (dgv.Columns.Contains("Break2 Inicio"))
			{
				dgv.Columns["Break2 Inicio"].DefaultCellStyle.BackColor = _frmCat.colorDescanso2;
				dgv.Columns["Break2 Fin"].DefaultCellStyle.BackColor = _frmCat.colorDescanso2;
				dgv.Columns["Horas2 Break"].DefaultCellStyle.BackColor = _frmCat.colorDescanso2;
			}
		}

		public void LoadDgvCatalog()
		{
			string queryCat = queryCatalog + " WHERE 1=1 ";

			var parametros = new Dictionary<string, object>();

			//  Línea de producción
			if (_frmCat.cboProductionLine.SelectedIndex > 0)
			{
				queryCat += " AND [id_ProductionLine] = @ProductionLine";
				parametros.Add("@ProductionLine", _frmCat.cboProductionLine.SelectedValue);
			}

			//  Fechas (periodo)
			if (_frmCat.cboFechaInicio.SelectedIndex >= 0 &&
				_frmCat.cboFinal.SelectedIndex >= 0)
			{
				var rowInicio = (DataRowView)_frmCat.cboFechaInicio.SelectedItem;
				var rowFin = (DataRowView)_frmCat.cboFinal.SelectedItem;

				queryCat += " AND  d_workTime BETWEEN @FechaInicio AND @FechaFin";

				parametros.Add("@FechaInicio", rowInicio[Payroll_AttendancePeriod.ColumnStartDate]);
				parametros.Add("@FechaFin", rowFin[Payroll_AttendancePeriod.ColumnEndDate]);
			}

			queryCat += queryOrderBy;


			_frmCat.dgvCatalog.DataSource = ClsQuerysDB.ExecuteParameterizedQuery(queryCat, parametros);
		}

		public void CargarPeriodos()
		{
			// Cargar combos
			ClsComboBoxes.CboLoadActives(_frmCat.cboFechaInicio, Payroll_AttendancePeriod.Cbo);
			ClsComboBoxes.CboLoadActives(_frmCat.cboFinal, Payroll_AttendancePeriod.Cbo);

			DateTime hoy = DateTime.Today;

			for (int i = 0; i < _frmCat.cboFechaInicio.Items.Count; i++)
			{
				DataRowView row = (DataRowView)_frmCat.cboFechaInicio.Items[i];

				if (row[Payroll_AttendancePeriod.ColumnStartDate] == DBNull.Value ||
					row[Payroll_AttendancePeriod.ColumnEndDate] == DBNull.Value)
				{
					continue;
				}

				DateTime fechaInicio = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Payroll_AttendancePeriod.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					_frmCat.cboFechaInicio.SelectedIndex = i;
					_frmCat.cboFinal.SelectedIndex = i;
					break;
				}
			}
		}
		public void OpenFrmAdd()
        {
            _frmAdd = new FrmWorkTimeAdd(_frmCat, this);
            _frmAdd.Text = "Añadir horario de empaque";
            _frmAdd.lblTitle.Text = "Añadir horario de empaque";
            _frmAdd.IsAddModify = true;

            _frmAdd.ShowDialog();
		}
		public void OpenFrmModify()
		{
			if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
			{
				_frmAdd = new FrmWorkTimeAdd(_frmCat, this);
				_frmAdd.Text = "Modificar horario de empaque";
				_frmAdd.lblTitle.Text = "Modificar horario de empaque";
				_frmAdd.IsAddModify = false;

				_frmAdd.idModify = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.Column.id].Value.ToString();
				CargarDatosModificar();

				_frmAdd.ShowDialog();
			}
			else
				SystemSounds.Exclamation.Play();
		}
		public void CargarDatosModificar()
		{
			DataRowView drv = (DataRowView)_frmCat.dgvCatalog.SelectedRows[0].DataBoundItem;
			DataRow row = drv.Row;

			//  DESCANSO
			SetDtpFromDb(_frmAdd.dtpDescansoInicial, row["Break Inicio"]);
			SetDtpFromDb(_frmAdd.dtpDescansoFinal, row["Break Fin"]);
			SetNudFromDb(_frmAdd.nudHorasDescanso, row["Horas Break"], _frmAdd.dtpDescansoInicial);

			//  COMIDA
			SetDtpFromDb(_frmAdd.dtpComidaInicial, row["Comida Inicio"]);
			SetDtpFromDb(_frmAdd.dtpComidaFinal, row["Comida Fin"]);
			SetNudFromDb(_frmAdd.nudComidaHora, row["Horas Comida"], _frmAdd.dtpComidaInicial);

			//  CENA
			SetDtpFromDb(_frmAdd.dtpCenaInicial, row["Cena Inicio"]);
			SetDtpFromDb(_frmAdd.dtpCenaFinal, row["Cena Fin"]);
			SetNudFromDb(_frmAdd.nudCenaHora, row["Horas Cena"], _frmAdd.dtpCenaInicial);

			//  DESCANSO 2
			SetDtpFromDb(_frmAdd.dtpDinicial2, row["Break2 Inicio"]);
			SetDtpFromDb(_frmAdd.dtpFinalD2, row["Break2 Fin"]);
			SetNudFromDb(_frmAdd.nudHorasD2, row["Horas2 Break"], _frmAdd.dtpDinicial2);
		}
		public void BeginFormAdd()
        {
            AddControlsToList();

            SetControls();

            if (_frmAdd.IsAddModify)
            {
                //LoadControlsAdd(); //NO SE OCUPA EN AQUÍ
                _frmAdd.dtpDay.Value = DateTime.Today;
            }
            else
                LoadControlsModify();
        }
        public void btnAcceptAddModify()
        {
            if (!controlList.ValidateControls())
                return;

            if (_frmAdd.IsAddModify)
                if (IsWorkTimeEnable())
                    AddProcedure();
                else if (AskForModification())
                    ModifyProcedure();
                else
                    return;
            else
                ModifyProcedure();

            if (_frmAdd.AddIsUpdate)
            {
                LoadDgvCatalog();
                _frmAdd.Close();
            }
        }
        private void LoadControlsModify()
        {
            eWorkTime = new EWorkTime();
            eWorkTime.SetWorkTime(_frmAdd.idModify);

            _frmAdd.dtpDay.Value = eWorkTime.dateWorkTime;
            _frmAdd.dtpBeginNormal.Value = eWorkTime.dateHourBeginNormal;
            _frmAdd.dtpEndNormal.Value = eWorkTime.dateHourEndNormal;
            _frmAdd.dtpEndExtra.Value = eWorkTime.dateHourEndExtra;
            _frmAdd.txbWorkers.Text = eWorkTime.workers;
            _frmAdd.nudOvertime.Value = eWorkTime.overTime;

            ClsComboBoxes.CboSelectIndexWithTextInValueMember(_frmAdd.cboProductionLine, eWorkTime.idProductionLine);
        }
        private void SetControls()
        {
            ClsComboBoxes.CboLoadActives(_frmAdd.cboProductionLine, ClsObject.ProductionLine.Cbo);
            ClsComboBoxes.CboApplyClickEvent(_frmAdd.cboProductionLine, _frmAdd.chbActiveProductionLine);

            ClsTextBoxes.TxbApplyKeyPressEventInt(_frmAdd.txbWorkers);
        }
        private void AddControlsToList()
        {
            controlList = new ClsControls();

            controlList.ChangeHeadMessage("Para capturar el horario se debe:\n");

            controlList.Add(_frmAdd.cboProductionLine, "Seleccionar banda.");
            controlList.Add(_frmAdd.txbWorkers, "Introducir cantidad de trabajadores.");
			controlList.Add(_frmAdd.clbCuadrilla, "Selecciona una cuadrilla.");
		}
		private void SetDtpFromDb(DateTimePicker dtp, object value)
		{
			if (value == DBNull.Value || value == null || string.IsNullOrWhiteSpace(value.ToString()))
			{
				dtp.Checked = false;
				return;
			}

			if (DateTime.TryParse(value.ToString(), out DateTime dt))
			{
				dtp.Checked = true;
				dtp.Value = dt;
			}
			else
			{
				dtp.Checked = false;
			}
		}
		private void SetNudFromDb(NumericUpDown nud, object value, DateTimePicker dtp)
		{
			if (value == DBNull.Value || value == null || !dtp.Checked)
			{
				nud.Value = 0;
				nud.Enabled = false;
			}
			else
			{
				nud.Value = Convert.ToDecimal(value);
				nud.Enabled = true;
			}
		}
		public void AddProcedure()
		{
			try
			{
				sql.OpenConectionWrite();

				if (_frmAdd.clbCuadrilla.CheckedItems.Count == 0)
				{
					MessageBox.Show("Selecciona al menos una cuadrilla");
					return;
				}

				foreach (var item in _frmAdd.clbCuadrilla.CheckedItems)
				{
					 ItemCuadrilla cuad = (ItemCuadrilla)item;

					SqlCommand cmd = new SqlCommand("sp_Nom_WorkTimeAdd", sql.cnn);
					cmd.CommandType = CommandType.StoredProcedure;

					// 🔹 DATOS PRINCIPALES
					cmd.Parameters.AddWithValue("@idProductionLine", _frmAdd.cboProductionLine.SelectedValue);
					cmd.Parameters.AddWithValue("@idWorkGroup", cuad.Id);

					cmd.Parameters.AddWithValue("@Day", _frmAdd.dtpDay.Value.ToString("yyyy-MM-dd"));

					cmd.Parameters.AddWithValue("@dateHourBeginNormal", _frmAdd.dtpBeginNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
					cmd.Parameters.AddWithValue("@dateHourEndNormal", _frmAdd.dtpEndNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));

					cmd.Parameters.AddWithValue("@dateHourBeginExtra", _frmAdd.dtpEndNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
					cmd.Parameters.AddWithValue("@dateHourEndExtra", _frmAdd.dtpEndExtra.Value.ToString("yyyy-MM-dd HH:mm:ss"));

					cmd.Parameters.AddWithValue("@workers", Convert.ToInt32(_frmAdd.txbWorkers.Text));
					cmd.Parameters.AddWithValue("@userCreate", User.GetUserName());
					cmd.Parameters.AddWithValue("@overTime", _frmAdd.nudOvertime.Value);

					//  BREAK
					cmd.Parameters.Add("@t_BreakStart", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpDescansoInicial);
					cmd.Parameters.Add("@t_BreakEnd", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpDescansoFinal);
					cmd.Parameters.Add("@d_BreakHours", SqlDbType.Decimal).Value =
					_frmAdd.dtpDescansoInicial.Checked ? _frmAdd.nudHorasDescanso.Value : (object)DBNull.Value;


					//  LUNCH
					cmd.Parameters.Add("@t_LunchStart", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpComidaInicial);
					cmd.Parameters.Add("@t_LunchEnd", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpComidaFinal);
					cmd.Parameters.Add("@d_LunchHours", SqlDbType.Decimal).Value =
					_frmAdd.dtpComidaInicial.Checked ? _frmAdd.nudComidaHora.Value : (object)DBNull.Value;

					// DINNER
					cmd.Parameters.Add("@t_DinnerStart", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpCenaInicial);
					cmd.Parameters.Add("@t_DinnerEnd", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpCenaFinal);
					cmd.Parameters.Add("@d_DinnerHours", SqlDbType.Decimal).Value =
					_frmAdd.dtpCenaInicial.Checked ? _frmAdd.nudCenaHora.Value : (object)DBNull.Value;

					//  BREAK 2 
					cmd.Parameters.Add("@t_BreakStart2", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpDinicial2);
					cmd.Parameters.Add("@t_BreakEnd2", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpFinalD2);
					cmd.Parameters.Add("@d_BreakHours2", SqlDbType.Decimal).Value =
					_frmAdd.dtpDinicial2.Checked ? _frmAdd.nudHorasD2.Value : (object)DBNull.Value;

					cmd.ExecuteNonQuery();
				}

				_frmAdd.AddIsUpdate = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Catálogo añadir");
			}
			finally
			{
				sql.CloseConectionWrite();
			}
		}
		private object GetTimeOrNull(DateTimePicker dtp)
		{
			if (!dtp.Checked)
				return DBNull.Value;

			return dtp.Value.TimeOfDay;
		}
		public void ModifyProcedure()
		{
			try
			{
				sql.OpenConectionWrite();

				SqlCommand cmd = new SqlCommand("sp_Nom_WorkTimeModify", sql.cnn);
				cmd.CommandType = CommandType.StoredProcedure;

			
				cmd.Parameters.AddWithValue("@idWorkTime", _frmAdd.idModify);

			
				cmd.Parameters.AddWithValue("@idProductionLine", _frmAdd.cboProductionLine.SelectedValue);

			
				if (_frmAdd.clbCuadrilla.CheckedItems.Count == 0)
				{
					MessageBox.Show("Selecciona una cuadrilla");
					return;
				}

				ItemCuadrilla cuad = (ItemCuadrilla)_frmAdd.clbCuadrilla.CheckedItems[0];
				cmd.Parameters.AddWithValue("@idWorkGroup", cuad.Id);
				cmd.Parameters.AddWithValue("@Day", _frmAdd.dtpDay.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@dateHourBeginNormal", _frmAdd.dtpBeginNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourEndNormal", _frmAdd.dtpEndNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourBeginExtra", _frmAdd.dtpEndNormal.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@dateHourEndExtra", _frmAdd.dtpEndExtra.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@workers", _frmAdd.txbWorkers.Text);
                cmd.Parameters.AddWithValue("@userUpdate", User.GetUserName());
				cmd.Parameters.AddWithValue("@overTime", _frmAdd.nudOvertime.Value);
				//  BREAK
				cmd.Parameters.Add("@t_BreakStart", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpDescansoInicial);
				cmd.Parameters.Add("@t_BreakEnd", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpDescansoFinal);
				cmd.Parameters.Add("@d_BreakHours", SqlDbType.Decimal).Value =
				_frmAdd.dtpDescansoInicial.Checked ? _frmAdd.nudHorasDescanso.Value : (object)DBNull.Value;


				//  LUNCH
				cmd.Parameters.Add("@t_LunchStart", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpComidaInicial);
				cmd.Parameters.Add("@t_LunchEnd", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpComidaFinal);
				cmd.Parameters.Add("@d_LunchHours", SqlDbType.Decimal).Value =
				_frmAdd.dtpComidaInicial.Checked ? _frmAdd.nudComidaHora.Value : (object)DBNull.Value;

				// DINNER
				cmd.Parameters.Add("@t_DinnerStart", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpCenaInicial);
				cmd.Parameters.Add("@t_DinnerEnd", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpCenaFinal);
				cmd.Parameters.Add("@d_DinnerHours", SqlDbType.Decimal).Value =
				_frmAdd.dtpCenaInicial.Checked ? _frmAdd.nudCenaHora.Value : (object)DBNull.Value;

				//  BREAK 2 
				cmd.Parameters.Add("@t_BreakStart2", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpDinicial2);
				cmd.Parameters.Add("@t_BreakEnd2", SqlDbType.Time).Value = GetTimeOrNull(_frmAdd.dtpFinalD2);
				cmd.Parameters.Add("@d_BreakHours2", SqlDbType.Decimal).Value =
				_frmAdd.dtpDinicial2.Checked ? _frmAdd.nudHorasD2.Value : (object)DBNull.Value;

				cmd.ExecuteNonQuery();
                _frmAdd.AddIsUpdate = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Catálogo añadir");
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }
		public void FormatearColumnasHora(DataGridView dgv)
		{
			var cultura = new System.Globalization.CultureInfo("es-MX");

			string[] columnasHora =
			{
				"Comida Inicio", "Comida Fin",
				"Cena Inicio", "Cena Fin",
				"Break Inicio", "Break Fin",
				"Break2 Inicio", "Break2 Fin"
			};

			foreach (string col in columnasHora)
			{
				if (dgv.Columns.Contains(col))
				{
					dgv.Columns[col].DefaultCellStyle.Format = "hh:mm tt";
					dgv.Columns[col].DefaultCellStyle.FormatProvider = cultura;
				}
			}
		}
		public void CalcularHoras(DateTimePicker inicio, DateTimePicker fin, NumericUpDown nud)
		{
			if (inicio.Checked && fin.Checked)
			{
				TimeSpan diff = fin.Value - inicio.Value;

				if (diff.TotalMinutes >= 0)
				{
					decimal horas = Math.Round((decimal)diff.TotalHours, 2);

					if (horas > nud.Maximum)
						nud.Value = nud.Maximum;
					else if (horas < nud.Minimum)
						nud.Value = nud.Minimum;
					else
						nud.Value = horas;
				}
				else
				{
					nud.Value = 0;
				}
			}
			else
			{
				nud.Value = 0;
			}
		}

		public class ItemCuadrilla
		{
			public string Id { get; set; }
			public string Nombre { get; set; }

			public override string ToString()
			{
				return Nombre;
			}
		}
		public void CargarCuadrillasCheckList()
		{
			int temporada = Convert.ToInt32(_frmCat.cboTemporada.SelectedValue);

			DataTable dt = ClbCuadrilla(temporada);

			_frmAdd.clbCuadrilla.Items.Clear();

			foreach (DataRow row in dt.Rows)
			{
				_frmAdd.clbCuadrilla.Items.Add(new ItemCuadrilla
				{
					Id = row["Código"].ToString(),
					Nombre = row["Nombre"].ToString()
				});
			}

			_frmAdd.clbCuadrilla.CheckOnClick = true;
		}
		public DataTable ClbCuadrilla(int temporada)
		{
			DataTable dt = new DataTable();

			sql.OpenConectionWrite();

			string query = @"
				SELECT 
					g.id_workGroup AS Código,
					g.v_nameWorkGroup + ' - ' + c.v_nameContractor AS Nombre
				FROM Pack_WorkGroup g
				INNER JOIN Pack_Contractor c 
					ON g.id_contractor = c.id_contractor
				WHERE g.id_season = @Temporada
				AND g.c_active = 1
				ORDER BY g.v_nameWorkGroup";

			SqlCommand cmd = new SqlCommand(query, sql.cnn);
			cmd.Parameters.AddWithValue("@Temporada", temporada);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);

			sql.CloseConectionWrite();

			return dt;
		}
		public void CargarTemporada()
		{
			ClsComboBoxes.CboLoadActives(_frmCat.cboTemporada, Season.CboWithDates);

			DateTime hoy = DateTime.Today;

			for (int i = 0; i < _frmCat.cboTemporada.Items.Count; i++)
			{
				DataRowView row = _frmCat.cboTemporada.Items[i] as DataRowView;

				if (row == null)
					continue;

				if (!row.Row.Table.Columns.Contains(Season.ColumnStartDate) ||
					!row.Row.Table.Columns.Contains(Season.ColumnEndDate))
					continue;

				if (row[Season.ColumnStartDate] == DBNull.Value ||
					row[Season.ColumnEndDate] == DBNull.Value)
					continue;

				DateTime fechaInicio = Convert.ToDateTime(row[Season.ColumnStartDate]);
				DateTime fechaFin = Convert.ToDateTime(row[Season.ColumnEndDate]);

				if (hoy >= fechaInicio && hoy <= fechaFin)
				{
					_frmCat.cboTemporada.SelectedIndex = i;
					return;
				}
			}
		}
		public void PintarEncabezadosAgrupados(object sender, DataGridViewCellPaintingEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;

			// SOLO encabezados
			if (e.RowIndex != -1 || e.ColumnIndex < 0)
				return;

			var grupos = new[]
			{
		new { Nombre = "Comida", Inicio = "Comida Inicio", Fin = "Comida Fin", Horas = "Horas Comida", Color = _frmCat.colorComida},
		new { Nombre = "Cena", Inicio = "Cena Inicio", Fin = "Cena Fin", Horas = "Horas Cena", Color = _frmCat.colorCena},
		new { Nombre = "Descanso", Inicio = "Break Inicio", Fin = "Break Fin", Horas = "Horas Break", Color = _frmCat.colorDescanso},
		new { Nombre = "Descanso 2", Inicio = "Break2 Inicio", Fin = "Break2 Fin", Horas = "Horas2 Break", Color = _frmCat.colorDescanso2}
	};

			
			var gruposOrdenados = grupos
				.Where(g => dgv.Columns.Contains(g.Inicio))
				.OrderBy(g => dgv.Columns[g.Inicio].DisplayIndex)
				.ToList();

			foreach (var g in gruposOrdenados)
			{
				if (!dgv.Columns.Contains(g.Inicio) ||
					!dgv.Columns.Contains(g.Fin) ||
					!dgv.Columns.Contains(g.Horas))
					continue;

				int colInicio = dgv.Columns[g.Inicio].Index;
				int colFin = dgv.Columns[g.Fin].Index;
				int colHoras = dgv.Columns[g.Horas].Index;

				// 🔥 OBTENER POSICIÓN REAL EN PANTALLA
				Rectangle r1 = dgv.GetCellDisplayRectangle(colInicio, -1, true);
				Rectangle r2 = dgv.GetCellDisplayRectangle(colFin, -1, true);
				Rectangle r3 = dgv.GetCellDisplayRectangle(colHoras, -1, true);

				Rectangle rectTotal = new Rectangle(
					r1.Left,
					r1.Top,
					r3.Right - r1.Left,
					r1.Height
				);

				// 🔹 PARTE SUPERIOR (TÍTULO DEL GRUPO)
				if (e.ColumnIndex == colInicio)
				{
					using (SolidBrush brush = new SolidBrush(System.Drawing.Color.WhiteSmoke))
						e.Graphics.FillRectangle(brush, rectTotal);

					Rectangle rectTop = new Rectangle(
						rectTotal.Left,
						rectTotal.Top,
						rectTotal.Width,
						rectTotal.Height / 2
					);

					using (SolidBrush brush = new SolidBrush(g.Color))
						e.Graphics.FillRectangle(brush, rectTop);

					using (StringFormat sf = new StringFormat()
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					})
					{
						e.Graphics.DrawString(g.Nombre,
							dgv.ColumnHeadersDefaultCellStyle.Font,
							Brushes.Black,
							rectTop,
							sf);
					}

					e.Graphics.DrawRectangle(Pens.Gray, rectTotal);

					e.Handled = true;
				}

				// 🔹 PARTE INFERIOR (SUBCOLUMNAS)
				if (e.ColumnIndex == colInicio ||
					e.ColumnIndex == colFin ||
					e.ColumnIndex == colHoras)
				{
					Rectangle rectBottom = new Rectangle(
						e.CellBounds.Left,
						e.CellBounds.Top + e.CellBounds.Height / 2,
						e.CellBounds.Width,
						e.CellBounds.Height / 2
					);

					using (SolidBrush brush = new SolidBrush(g.Color))
						e.Graphics.FillRectangle(brush, rectBottom);

					string texto = dgv.Columns[e.ColumnIndex].HeaderText;

					using (StringFormat sf = new StringFormat()
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					})
					{
						e.Graphics.DrawString(texto,
							dgv.ColumnHeadersDefaultCellStyle.Font,
							Brushes.Black,
							rectBottom,
							sf);
					}

					e.Graphics.DrawRectangle(Pens.LightGray, rectBottom);

					e.Handled = true;
				}
			}
		}
		public void AjustarEncabezados()
		{
			var dgv = _frmCat.dgvCatalog;

			//  COMIDA
			if (dgv.Columns.Contains("Comida Inicio"))
			{
				dgv.Columns["Comida Inicio"].HeaderText = "Inicio";
				dgv.Columns["Comida Fin"].HeaderText = "Fin";
				dgv.Columns["Horas Comida"].HeaderText = "Horas";
			}

			//  CENA
			if (dgv.Columns.Contains("Cena Inicio"))
			{
				dgv.Columns["Cena Inicio"].HeaderText = "Inicio";
				dgv.Columns["Cena Fin"].HeaderText = "Fin";
				dgv.Columns["Horas Cena"].HeaderText = "Horas";
			}

			//  DESCANSO
			if (dgv.Columns.Contains("Break Inicio"))
			{
				dgv.Columns["Break Inicio"].HeaderText = "Inicio";
				dgv.Columns["Break Fin"].HeaderText = "Fin";
				dgv.Columns["Horas Break"].HeaderText = "Horas";
			}
			//  DESCANSO2
			if (dgv.Columns.Contains("Break2 Inicio"))
			{
				dgv.Columns["Break2 Inicio"].HeaderText = "Inicio";
				dgv.Columns["Break2 Fin"].HeaderText = "Fin";
				dgv.Columns["Horas2 Break"].HeaderText = "Horas";
			}
		}
		public void OpenFrmReport(int reportType)
        {//reportType 1 para reporte de campo, 2 para reporte de empaque
            if (_frmCat.dgvCatalog.SelectedRows.Count != 0)
            {
                frmReport = new FrmBoxesPackedPerEmployee();
                frmReport.cls = this;
                frmReport.reportType = reportType;
                frmReport.idProductionLine = _frmCat.dgvCatalog.SelectedRows[0].Cells[ClsObject.ProductionLine.ColumnName].Value.ToString();
                frmReport.dWorkTime = _frmCat.dgvCatalog.SelectedRows[0].Cells[ColumnDateWtm].Value.ToString();
                frmReport.MdiParent = FrmMenu.FrmMenuInstance;
                frmReport.Show();
            }
            else
                SystemSounds.Exclamation.Play();
        }

        public void BeginFrmReport(int reportType)
        {//reportType 1 para reporte de campo, 2 para reporte de empaque
            string rType = reportType.ToString();
            string date = DateTime.Parse(frmReport.dWorkTime).ToString("dddd, dd-MMMM-yyyy");
            string priceType = "Campo";
            if (reportType == 2)
                priceType = "Empaque";

            frmReport.lblSubTitle.Text = $"Banda: {frmReport.idProductionLine}       Fecha: {date}       Precios para: {priceType}";

            //string qryNameProc = "sp_NomPackedBoxEmployeePerDay"; //PARA LA TEMPORADA DE UVA
            string qryNameProc = "sp_NomPackedUniqueBoxEmployeePerDay"; //PARA LA TEMPORADA DE ESPARRAGO

            frmReport.dgvCatalog.DataSource = ClsQuerysDB.GetDataTable($"EXEC {qryNameProc} '{frmReport.idProductionLine}', '{frmReport.dWorkTime}', '{rType}'");
        }

        private bool IsWorkTimeEnable()
        {
            string date = _frmAdd.dtpDay.Value.ToString("yyyy-MM-dd");
            string idProductionLine = _frmAdd.cboProductionLine.SelectedValue.ToString();
            string qry = $"SELECT id_workTime FROM Nom_WorkTime WHERE d_workTime = '{date}' AND id_ProductionLine = '{idProductionLine}'";
            string workTimeId = ClsQuerysDB.GetData(qry);
            if (!string.IsNullOrEmpty(workTimeId))
            {
                _frmAdd.idModify = workTimeId; //PARA EL DE MODIFICAR
                return false;
            }
            else
                return true;
        }

        private bool AskForModification()
        {
            string dateName = _frmAdd.dtpDay.Value.ToString("dddd, dd-MMMM-yyyy");
            string nameProductionLine = _frmAdd.cboProductionLine.Text.ToString();

            DialogResult result = MessageBox.Show($"El horario con para la banda {nameProductionLine} con fecha {dateName} ya existe. ¿Desea sobrescribirlo?", "Horarios de empaque", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
}
