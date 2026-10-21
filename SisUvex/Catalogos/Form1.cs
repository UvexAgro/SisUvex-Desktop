using System;
using System.Windows.Forms;
using SisUvex.Cuadro_de_herramientas;

namespace SisUvex.Catalogos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            LoadMarkGrid();
        }

        private void LoadMarkGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "colEmpleado",
                HeaderText = "Empleado",
                ReadOnly = true,
                Width = 150
            };
            dataGridView1.Columns.Add(nameColumn);

            string[] days = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
            foreach (string day in days)
            {
                dataGridView1.Columns.Add(new TriMarkColumn
                {
                    Name = "col" + day,
                    HeaderText = day,
                    Width = 78
                });
            }

            TriMarkValue check = TriMarkValue.Check;
            TriMarkValue cross = TriMarkValue.Cross;
            TriMarkValue empty = TriMarkValue.Empty;

            AddEmployee("Ana López", check, check, check, check, check, empty, cross);
            AddEmployee("Luis Hernández", check, check, cross, check, check, empty, empty);
            AddEmployee("María Soto", empty, check, check, check, cross, empty, empty);
            AddEmployee("José Ramírez", check, check, check, empty, check, check, empty);
            AddEmployee("Carmen Díaz", cross, check, check, check, check, empty, empty);
            AddEmployee("Pedro Morales", check, cross, check, check, empty, empty, empty);
            AddEmployee("Lucía Fernández", check, check, check, check, check, check, empty);
            AddEmployee("Jorge Castillo", empty, empty, check, check, check, cross, empty);
            AddEmployee("Elena Vargas", check, check, empty, cross, check, empty, empty);
            AddEmployee("Miguel Torres", check, check, check, check, cross, empty, empty);
        }

        private void AddEmployee(string name, params TriMarkValue[] days)
        {
            object[] values = new object[days.Length + 1];
            values[0] = name;
            for (int i = 0; i < days.Length; i++)
                values[i + 1] = days[i];

            dataGridView1.Rows.Add(values);
        }

        private void triMarkPrueba_ValueChanged(object? sender, EventArgs e)
        {
            lblPrueba.Text = triMarkPrueba.Value switch
            {
                TriMarkValue.Check => "Clic: paloma",
                TriMarkValue.Cross => "Clic: equis",
                _ => "Clic: vacío"
            };
        }
    }
}
