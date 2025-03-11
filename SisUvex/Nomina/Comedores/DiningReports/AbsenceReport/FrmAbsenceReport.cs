using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Comedores.DiningReports.AbsenceReport
{
    public partial class FrmAbsenceReport : Form
    {
        public FrmAbsenceReport()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string qry = @"	SELECT 
                                c_codigo_emp AS [Código],
	                            emp.v_lastNamePat AS [A. Paterno],
	                            emp.v_lastNameMat AS [A. Materno],
	                            emp.v_name AS [Nombre],
                                MAX(d_datetime) AS [Último registro]
                            FROM 
                                Hist_Nom_FoodRegister frg
	                            LEFT JOIN Nom_Employees emp ON emp.id_employee = frg.c_codigo_emp
                            WHERE 
                                d_datetime BETWEEN @d1 AND @d2
                                AND c_codigo_emp NOT IN (
                                    SELECT DISTINCT c_codigo_emp
                                    FROM Hist_Nom_FoodRegister
                                    WHERE d_datetime BETWEEN @d2 AND @d3
                                )
                            GROUP BY 
                                c_codigo_emp, emp.v_lastNamePat, emp.v_lastNameMat, emp.v_name;";

            string d1 = dtpDate1.Value.ToString("yyyy-MM-dd");
            string d2 = dtpDate2.Value.ToString("yyyy-MM-dd");
            string d3 = dtpDate3.Value.ToString("yyyy-MM-dd");

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@d1", d1 },
                { "@d2", d2 },
                { "@d3", d3 }
            };

            dgvQuery.DataSource =  ClsQuerysDB.ExecuteParameterizedQuery(qry, parameters);
        }
    }
}
