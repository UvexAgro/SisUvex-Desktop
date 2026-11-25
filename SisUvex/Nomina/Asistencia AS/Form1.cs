using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarDatosPruebaListado();
            dgvPruebasListado.CellPainting += DgvPruebasListado_CellPainting;
            dgvPruebasListado.CellContentClick += (_, e) =>
            {
                // Confirma el cambio del checkbox al instante para que se repinte.
                if (e.ColumnIndex == colListSel.Index && e.RowIndex >= 0)
                    dgvPruebasListado.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        /// <summary>Datos fijos de prueba para el listado (dgvPruebasListado).</summary>
        private void CargarDatosPruebaListado()
        {
            const string patron = "FOMENTO DE AGRICULTURA INTERNACIONAL";
            const string lugarPago = "0002 - FOMENTO";
            const string rPatronal = "E5920867135";
            const string contratista = "CAMPO";

            // Sel, Código, Nombre, Edad, Nacimiento, Estado, CURP, NSS, RFC, RPatronal, Patron, LugarDePago, Contratista, Ingreso, Reingreso
            object[][] filas =
            {
                new object[] { "1", "179549", "JAVIER MONDRAGON GUTIERREZ",      59, "28/05/1967", "BAJA CALIFORNIA", "MOGJ670528HBCNTV00", "21886754932", "MOGJ670528FGA", rPatronal, patron, lugarPago, contratista, "22/10/2020", "22/10/2020" },
                new object[] { "1", "085498", "JONATHAN LORETO CARRILLO",        28, "16/10/1998", "SONORA",          "LOCJ981016HSRRRN06", "38169887882", "LOCJ981016355", rPatronal, patron, lugarPago, contratista, "24/05/2016", "08/09/2022" },
                new object[] { "1", "233999", "JOSE FRANCISCO PAREDES VEGA",     34, "22/05/1992", "SONORA",          "PAVF920522HSRRGR05", "24109222414", "PAVF920522TJA", rPatronal, patron, lugarPago, contratista, "10/04/2023", "10/04/2023" },
                new object[] { "1", "244350", "LUIS FERNANDO LORETO RODRIGUEZ",  28, "03/11/1998", "SONORA",          "LORL981103HSRRDS08", "08179860567", "LORL981103616", rPatronal, patron, lugarPago, contratista, "12/06/2023", "23/09/2024" },
                new object[] { "1", "238048", "MANUEL CASTRO JUNES",             27, "05/01/1999", "SONORA",          "CAJM990105HSRSNN08", "74169925588", "CAJM990105KG3", rPatronal, patron, lugarPago, contratista, "05/06/2023", "07/08/2023" },
                new object[] { "1", "155184", "MARCOS ANSELMO AGUSTIN",          54, "24/10/1972", "GUERRERO",        "AEAM721024HGRNGR01", "72927322973", "AEAM721024EL1", rPatronal, patron, lugarPago, contratista, "11/12/2019", "" },
                new object[] { "1", "098046", "SEVERINO CAYETANO AVENDAÑO",      65, "11/02/1961", "OAXACA",          "CAAS610211HOCYVV09", "12836117502", "CAAS610211345", rPatronal, patron, lugarPago, contratista, "05/04/2017", "30/10/2020" },
                new object[] { "1", "020602", "VALDEMAR LOPEZ LOPEZ",            31, "25/11/1994", "CHIAPAS",         "LOLV941125HCSPPL04", "03159431828", "LOLV941125IR7", rPatronal, patron, lugarPago, contratista, "28/06/2015", "17/11/2020" },
            };

            foreach (object[] fila in filas)
                dgvPruebasListado.Rows.Add(fila);
        }

        /// <summary>Dibuja los checkboxes de "Sel." con el mismo estilo morado de los filtros.</summary>
        private void DgvPruebasListado_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != colListSel.Index || e.RowIndex < -1) return;

            bool isChecked;
            if (e.RowIndex == -1)
            {
                isChecked = dgvPruebasListado.Rows.Count > 0 &&
                            dgvPruebasListado.Rows.Cast<DataGridViewRow>().All(r => (r.Cells[colListSel.Index].Value?.ToString() == "1"));
            }
            else
            {
                isChecked = e.FormattedValue is bool b ? b : e.Value?.ToString() == "1";
            }

            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.SelectionBackground);
            int size = AntdCheckGlyph.DefaultSize;
            Rectangle glyph = new(
                e.CellBounds.Left + (e.CellBounds.Width - size) / 2,
                e.CellBounds.Top + (e.CellBounds.Height - size) / 2,
                size, size);
            AntdCheckGlyph.Draw(e.Graphics!, glyph, isChecked);
            e.Handled = true;
        }
    }
}
