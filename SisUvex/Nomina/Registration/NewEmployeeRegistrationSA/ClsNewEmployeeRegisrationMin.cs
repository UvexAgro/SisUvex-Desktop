using Microsoft.IdentityModel.Tokens;
using SisUvex.Catalogos.Metods.Querys;
using SisUvex.Configuracion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static SisUvex.Catalogos.Metods.ClsObject;

namespace SisUvex.Nomina.Registration.NewEmployeeRegistrationSA
{
    internal class ClsNewEmployeeRegisrationMin
    {
        SQLControl sql;
        public FrmNewEmployeeRegistrationMin frm;
        string qryInsertEmployee = $" INSERT INTO nomempleados (c_codigo_emp, v_apellidopat_emp, v_apellidomat_emp, v_nombre_emp, c_codigo_usu, d_creacion_emp, c_sexo_emp, c_activo_emp, c_codigollave_emp, n_sdoimss_emp, n_sueldofiscal_emp, n_factorimss_emp, d_fechainiciocfdi_emp, d_freingresosist_emp) VALUES (@codigo, @apellidop, @apellidom, @nombre, 'OSWALDO', CAST(GETDATE() AS DATE), @sexo, '1', @codigo, 0.00, 0.00, 0.0000, CAST(GETDATE() AS DATE), @dateRegister)";
        DataTable? dtEmployees;

        List<(string ColumnName, Type ColumnType)> columnDataTable = new List<(string, Type)>
        {
            ("CODIGO", typeof(string)),
            ("APELLIDO PATERNO", typeof(string)),
            ("APELLIDO MATERNO", typeof(string)),
            ("NOMBRE", typeof(string)),
            ("SEXO", typeof(string)),
            ("FECHA REGISTRO", typeof(string))
        };

        public DataTable SetDataTableColumns()
        {
            DataTable dt = new DataTable();
            foreach (var column in columnDataTable)
            {
                dt.Columns.Add(column.ColumnName, column.ColumnType);
            }
            return dt;
        }

        public void btnRegisterIndividualEmployee()
        {
            dtEmployees = SetDataTableColumns();

            frm.txbIdEmployee.Text = ConvertIdEmployee(frm.txbIdEmployee.Text);

            dtEmployees.Rows.Add(frm.txbIdEmployee.Text, frm.txbLastNamePat.Text, frm.txbLastNameMat.Text, frm.txbName.Text, frm.cboSex.Text, frm.dtpDateRegister.Value.ToString("yyyy-MM-dd"));

            RegisterEmployees(dtEmployees);
        }

        public void btnRegisterMultipleEmployee()
        {
            if (ValidateDataGridViewColumns())
            {
                RegisterEmployees(frm.dgvDatos.DataSource as DataTable);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("El archivo debe contener las siguientes columnas:");
                foreach (var column in columnDataTable)
                {
                    sb.AppendLine(column.ColumnName);
                }
                MessageBox.Show(sb.ToString(), "Columnas archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidateDataGridViewColumns()
        {
            foreach (var column in columnDataTable)
            {
                if (!frm.dgvDatos.Columns.Contains(column.ColumnName))
                {
                    return false;
                }
            }
            return true;
        }

        public void RegisterEmployees(DataTable employees)
        {
            sql = new SQLControl();

            sql.OpenConectionWrite();

            sql.BeginTransaction();

            string qry = " USE " + sql.dbEmployees + qryInsertEmployee;

            try
            {
                foreach (DataRow employee in employees.Rows)
                {
                    if (ValidateEmployeeData(employee))
                    {
                        Clipboard.SetText(qry);

                        SqlCommand cmd = new SqlCommand(qry, sql.cnn, sql.transaction);

                        MessageBox.Show(employee["CODIGO"].ToString() +"\n"+employee["FECHA REGISTRO"].ToString(), "INSERT");

                        cmd.Parameters.AddWithValue("@codigo", employee["CODIGO"]);
                        cmd.Parameters.AddWithValue("@apellidop", employee["APELLIDO PATERNO"].ToString().ToUpper());
                        cmd.Parameters.AddWithValue("@apellidom", employee["APELLIDO MATERNO"].ToString().ToUpper());
                        cmd.Parameters.AddWithValue("@nombre", employee["NOMBRE"].ToString().ToUpper());
                        cmd.Parameters.AddWithValue("@sexo", employee["SEXO"].ToString().ToUpper());
                        cmd.Parameters.AddWithValue("@dateRegister", DateTime.Parse(employee["FECHA REGISTRO"].ToString()).ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("Datos inválidos para el empleado de código: " + employee["CODIGO"]);
                    }
                }

                MessageBox.Show("Empleados registrados correctamente", "Registro de empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                sql.CommitTransaction();
            }
            catch (Exception ex)
            {
                sql.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error procesar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sql.CloseConectionWrite();
            }
        }

        public bool ValidateEmployeeData(DataRow employee)
        {
            string idEmployee = ConvertIdEmployee(employee["CODIGO"].ToString());

            employee["CODIGO"] = idEmployee;

            if (idEmployee.IsNullOrEmpty())
                throw new Exception("El código del empleado no puede estar vacío.");

            if (idEmployee.Length > 6)
                throw new Exception($"El código para el empleado {idEmployee} no es válido.");

            string idValidate = ClsQuerysDB.GetStringExecuteParameterizedQuery($"USE {sql.dbEmployees} SELECT COUNT(c_codigo_emp) FROM nomempleados WHERE c_codigo_emp = @codigo", new Dictionary<string, object> { { "@codigo", idEmployee } });

            if (idValidate != "0")
                throw new Exception($"El código para el empleado {idEmployee} ya está ocupado");

            if (!IsAlphabetic(employee["APELLIDO PATERNO"].ToString()) || !IsAlphabetic(employee["APELLIDO MATERNO"].ToString()) || !IsAlphabetic(employee["NOMBRE"].ToString()))
                throw new Exception($"El nombre del empleado {idEmployee} no es válido");

            if (employee["APELLIDO PATERNO"].ToString().Length > 30 || employee["APELLIDO MATERNO"].ToString().Length > 30 || employee["NOMBRE"].ToString().Length > 50 || employee["APELLIDO PATERNO"].ToString().Length == 0 || employee["NOMBRE"].ToString().Length == 0)
                throw new Exception($"El nombre del empleado {idEmployee} no es válido");

            string sexo = employee["SEXO"].ToString().ToUpper();
            if (sexo != "F" && sexo != "M")
                throw new Exception($"El sexo para el empleado {idEmployee} debe ser F o M.");

            if (!ValidateAndFormatEmployeeDate(employee))
                throw new Exception($"La fecha de registro para el empleado {idEmployee} no es válida.");

            return true;
        }

        private bool IsAlphabetic(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }
        public string ConvertIdEmployee(string idEmployee)
        {
            if (int.TryParse(idEmployee, out int number))
                return number.ToString("D6").ToUpper();

            return idEmployee;
        }

        public bool ValidateAndFormatEmployeeDate(DataRow employee)
        {
            if (DateTime.TryParse(employee["FECHA REGISTRO"].ToString(), out DateTime dateRegister))
            {
                employee["FECHA REGISTRO"] = dateRegister.ToString("yyyy-MM-dd");
                return true;
            }
            return false;
        }
    }
}