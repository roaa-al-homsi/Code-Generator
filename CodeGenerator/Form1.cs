using GeneratorBusiness;
using System;
using System.Data;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void _FillcmbDatabase()
        {
            DataTable dataTable = Generator.AllNamesDatabase();
            foreach (DataRow row in dataTable.Rows)
            {
                cbDatabase.Items.Add(row["name"]);
            }
        }
        private void _FillcmbNamesTables(string nameDB)
        {
            DataTable dataTable = Generator.AllNamesTablesInSpecificDB(nameDB);
            foreach (DataRow row in dataTable.Rows)
            {
                cbTables.Items.Add(row["Table_Name"]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _FillcmbDatabase();
        }
        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTables.Enabled = true;
            cbTables.Items.Clear();
            _FillcmbNamesTables(cbDatabase.SelectedItem.ToString());
        }
        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvColumns.DataSource = Generator.AllNamesColumnsInSpecificTables(cbTables.Text, cbDatabase.Text);
            labCountColumns.Text = Generator.NumberOfColumnsInSpecificTable(cbTables.Text, cbDatabase.Text).ToString();
        }
    }
}
