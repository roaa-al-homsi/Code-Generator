using GeneratorBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        private int _numbersOfRecords = 0;
        public struct ColumnInfo
        {
            public string DataType { get; set; }
            public bool IsNull { get; set; }
        }
        private Dictionary<string, ColumnInfo> _nameColumnWithDataType = new Dictionary<string, ColumnInfo>();
        public Form1()
        {
            InitializeComponent();
        }
        private void _FillCmbDatabase()
        {
            DataTable dataTable = Generator.AllNamesDatabase();
            foreach (DataRow row in dataTable.Rows)
            {
                cbDatabase.Items.Add(row["name"]);
            }
        }
        private void _FillCmbNamesTables(string nameDB)
        {
            DataTable dataTable = Generator.AllNamesTablesInSpecificDB(nameDB);
            foreach (DataRow row in dataTable.Rows)
            {
                cbTables.Items.Add(row["Table_Name"]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _FillCmbDatabase();
        }
        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTables.Enabled = true;
            cbTables.Items.Clear();
            _FillCmbNamesTables(cbDatabase.SelectedItem.ToString());
        }
        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvColumns.DataSource = Generator.AllNamesColumnsInSpecificTables(cbTables.Text, cbDatabase.Text);
            labCountColumns.Text = Generator.NumberOfColumnsInSpecificTable(cbTables.Text, cbDatabase.Text).ToString();
            _numbersOfRecords = Convert.ToInt32(labCountColumns.Text);
        }
        private void _FillDictionaryFromDgvColumns()
        {
            var dicSqlToCSharpDatatype = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
             { "int", "int" },
             { "datetime", "DateTime" },
             { "bit", "bool" },
             { "decimal", "decimal" },
             { "float", "double" },
             { "char", "char" },
             { "date", "DateTime" },
             {"SMALLINT","short" }

            };
            foreach (DataGridViewRow row in dgvColumns.Rows)
            {
                string name = row.Cells["COLUMN_NAME"]?.Value?.ToString();
                string dataType = row.Cells["DATA_TYPE"]?.Value?.ToString();
                bool isNull = string.Equals(row.Cells["IS_NULLABLE"]?.Value?.ToString(), "YES", StringComparison.OrdinalIgnoreCase);

                string cSharpDataType = "object";

                if (!string.IsNullOrEmpty(dataType))
                {
                    if (dataType.StartsWith("nvarchar", StringComparison.OrdinalIgnoreCase) ||
                        dataType.StartsWith("varchar", StringComparison.OrdinalIgnoreCase))
                    {
                        cSharpDataType = "string";
                    }
                    else if (dicSqlToCSharpDatatype.ContainsKey(dataType))
                    {
                        cSharpDataType = dicSqlToCSharpDatatype[dataType];
                    }
                }

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(cSharpDataType))
                {
                    if (!_nameColumnWithDataType.ContainsKey(name))
                    {
                        _nameColumnWithDataType.Add(name, new ColumnInfo { DataType = cSharpDataType, IsNull = isNull });
                    }
                }
            }
        }
        private static StringBuilder ProcessAddMethod(Dictionary<string, ColumnInfo> nameColumnWithDataType, string tableName)
        {
            string columns = string.Join(",", nameColumnWithDataType.Keys);
            string parameters = string.Join(",", nameColumnWithDataType.Keys.Select(K => "@" + K));
            string query = $@"insert into {tableName} ({columns}) values ({parameters})    SELECT SCOPE_IDENTITY(); ";
            string parametersMethod = string.Join(",", nameColumnWithDataType.Select(dty => $"{dty.Value.DataType} {dty.Key}"));

            StringBuilder stringBuilderCommandParameters = new StringBuilder();
            foreach (var dty in nameColumnWithDataType)
            {
                stringBuilderCommandParameters.Append((dty.Value.IsNull) ? $@"command.Parameters.AddWithValue(@{dty.Key}, !string.IsNullOrWhiteSpace({dty.Key})?{dty.Key}: (object)DBNull.Value)" : $@"command.Parameters.AddWithValue(@{dty.Key}, {dty.Key})");
                stringBuilderCommandParameters.AppendLine();
            }
            return Generator.Add(parametersMethod, query, parameters, stringBuilderCommandParameters);
        }
        private void btnViewDataAccessLayer_Click(object sender, EventArgs e)
        {

            _nameColumnWithDataType.Clear();
            _FillDictionaryFromDgvColumns();
            richTxtContantLayers.Text = ProcessAddMethod(_nameColumnWithDataType, cbTables.Text).ToString();

        }




    }
}

