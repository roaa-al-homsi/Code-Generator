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
        private static int _numbersOfRecords = 0;

        private static string _columns;
        public static string Columns
        {
            get
            {
                if (NameColumnWithDataType == null || NameColumnWithDataType.Keys.Count == 0)
                {
                    return string.Empty;
                }

                return string.IsNullOrWhiteSpace(_columns) ? string.Join(",", NameColumnWithDataType.Keys) : _columns;
            }
            private set
            {

                _columns = value;
            }
        }

        private static string _values;
        public static string Values
        {
            get
            {
                if (NameColumnWithDataType == null || NameColumnWithDataType.Keys.Count == 0)
                {
                    return string.Empty;
                }
                return string.IsNullOrWhiteSpace(_values) ? string.Join(",", NameColumnWithDataType.Keys.Select(K => "@" + K)) : _values;
            }
            private set { _values = value; }
        }

        private static string _parametersMethod;
        public static string ParametersMethod
        {
            get
            {
                if (NameColumnWithDataType == null || NameColumnWithDataType.Keys.Count == 0)
                {
                    return string.Empty;
                }
                return string.IsNullOrWhiteSpace(_parametersMethod) ? string.Join(",", NameColumnWithDataType.Select(dty => $"{dty.Value.DataType} {dty.Key}")) : _parametersMethod;
            }
            private set { _parametersMethod = value; }
        }
        public struct ColumnInfo
        {
            public string DataType { get; set; }
            public bool IsNull { get; set; }
        }
        public static Dictionary<string, ColumnInfo> NameColumnWithDataType { get; private set; }
        public static StringBuilder StringBuilderCommandParameters { get; private set; }
        public enum Mode { Add, Update };
        private Mode mode;
        public Form1()
        {
            InitializeComponent();

            NameColumnWithDataType = new Dictionary<string, ColumnInfo>();
            StringBuilderCommandParameters = new StringBuilder();
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
            NameColumnWithDataType.Clear();
            NameColumnWithDataType = _FillDictionaryFromDgvColumns();
            StringBuilderCommandParameters.Clear();
            StringBuilderCommandParameters = _FillStringBuilderCommandParameters();
            labCountColumns.Text = NameColumnWithDataType.Keys.Count.ToString();
            _numbersOfRecords = Convert.ToInt32(labCountColumns.Text);
        }
        private Dictionary<string, ColumnInfo> _FillDictionaryFromDgvColumns()
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
            //SqlDbType
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
                    if (!NameColumnWithDataType.ContainsKey(name))
                    {
                        NameColumnWithDataType.Add(name, new ColumnInfo { DataType = cSharpDataType, IsNull = isNull });
                    }
                }
            }

            return NameColumnWithDataType;
        }
        private StringBuilder _FillStringBuilderCommandParameters()
        {
            foreach (var dty in NameColumnWithDataType)
            {
                if (dty.Value.IsNull)
                {
                    if ((dty.Value.DataType == "int"))
                    {
                        StringBuilderCommandParameters.AppendLine((dty.Key).EndsWith("Id") ? $@"command.Parameters.AddWithValue( ""@{dty.Key}"", ({dty.Key} == -1)?DBNull.Value : (object){dty.Key});" : $@"command.Parameters.AddWithValue(""@{dty.Key}"",({dty.Key} == 0)?DBNull.Value : (object){dty.Key});");
                    }

                    else if (dty.Value.DataType == "string")
                    {
                        StringBuilderCommandParameters.AppendLine($@"command.Parameters.AddWithValue(""@{dty.Key}"", !string.IsNullOrWhiteSpace({dty.Key}) ? {dty.Key} : (object)DBNull.Value);");
                    }
                }
                else
                {
                    StringBuilderCommandParameters.AppendLine($@"command.Parameters.AddWithValue(""@{dty.Key}"", {dty.Key});");

                }
            }
            return StringBuilderCommandParameters;
        }
        private StringBuilder _FillStringBuilderGetValuesFromDB()
        {//     Address = (string)reader[""Address""];
         //ImagePath = (reader[""ImagePath""] != DBNull.Value) ? (string)reader[""ImagePath""] : string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var dty in NameColumnWithDataType)
            {
                if (dty.Value.IsNull)
                {
                    if (string.Equals(dty.Value.DataType, "string", StringComparison.OrdinalIgnoreCase))
                    {
                        stringBuilder.AppendLine($@"{dty.Key} = reader [""{dty.Key}""] != DBNull.Value ? ({dty.Value.DataType})reader [""{dty.Key}""]: string.Empty;");
                    }
                    if (string.Equals(dty.Value.DataType, "int", StringComparison.OrdinalIgnoreCase))
                    {
                        stringBuilder.AppendLine((dty.Key).EndsWith("Id", StringComparison.OrdinalIgnoreCase) ? $@"{dty.Key} = reader [""{dty.Key}""] != DBNull.Value ? ({dty.Value.DataType})reader [""{dty.Key}""]: -1;" :
                        $@"{dty.Key} = reader [""{dty.Key}""] != DBNull.Value ? ({dty.Value.DataType})reader [""{dty.Key}""]: 0;");
                    }
                }
                else
                {
                    stringBuilder.AppendLine($@"{dty.Key} = ({dty.Value.DataType})reader [""{dty.Key}""];");
                }

            }
            return stringBuilder;
        }

        private StringBuilder _DataAccessLayer()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(ProcessAddMethod(cbTables.Text));
            stringBuilder.AppendLine(ProcessUpdateMethod(cbTables.Text));
            stringBuilder.AppendLine(ProcessGetByIdMethod(cbTables.Text));
            stringBuilder.AppendLine(ProcessAllMethod(cbTables.Text));

            return stringBuilder;
        }
        private static string ProcessAddMethod(string tableName)
        {// This row is for applying edits on StringBuilderCommandParameters without effect on the original copy. 
            StringBuilder tempStringBuilder = new StringBuilder(StringBuilderCommandParameters.ToString());
            tempStringBuilder.Replace("command.Parameters.AddWithValue(\"@Id\", Id);", string.Empty);
            string query = $@"insert into {tableName} ({Columns}) values ({Values}) SELECT SCOPE_IDENTITY(); ";
            return Generator.Add(ParametersMethod.Remove(0, 7), query, tempStringBuilder);
        }
        private static string ProcessUpdateMethod(string tableName)
        {
            string columnsWithValues = string.Join(",", NameColumnWithDataType.Select(dty => $"{dty.Key} = @{dty.Key}")); //(Name=@Name,Age=@Age)
            string pk = GetPrimaryKey();
            string query = $@"update {tableName} set {columnsWithValues}  WHERE {pk}=@{pk};";

            return Generator.Update(ParametersMethod, query, StringBuilderCommandParameters);
        }
        private string ProcessGetByIdMethod(string tableName)
        {
            string pk = GetPrimaryKey();
            string query = $@"select * from {tableName}  WHERE {pk}=@{pk};";
            ParametersMethod = string.Join(",", NameColumnWithDataType.Select(dty => dty.Key == "Id" ? $"{dty.Value.DataType} {dty.Key}" : $" ref {dty.Value.DataType} {dty.Key}"));
            return Generator.GetById(ParametersMethod, query, $"command.Parameters.AddWithValue(\"@{pk}\",{pk});", _FillStringBuilderGetValuesFromDB());
        }
        private string ProcessAllMethod(string tableName)
        {
            return Generator.All(tableName);
        }
        private void btnViewDataAccessLayer_Click(object sender, EventArgs e)
        {
            richTxtContantLayers.Clear();
            richTxtContantLayers.Text = _DataAccessLayer().ToString();
        }
        private static string GetPrimaryKey()
        {
            if (NameColumnWithDataType.Count == 0)
            {
                return "RoaaId";
            }

            string pk = NameColumnWithDataType.Keys.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(pk))
            {
                return "Id";
            }

            return pk.EndsWith("Id", StringComparison.OrdinalIgnoreCase) ? pk : "Id";
        }
    }
}

