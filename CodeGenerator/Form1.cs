using GeneratorBusiness;
using Humanizer;
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

        public static string Columns2//here problem
        {
            get
            {
                if (NameColumnWithDataType == null || NameColumnWithDataType.Keys.Count == 0)
                {
                    return string.Empty;
                }

                return string.IsNullOrWhiteSpace(Columns2) ? string.Join(",", NameColumnWithDataType.Keys) : Columns2;
            }
            private set
            {
                Columns2 = value;
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

        private string _parametersMethodWithThisKeyword;
        public string ParametersMethodWithThisKeyword
        {
            get
            {
                if (NameColumnWithDataType == null || NameColumnWithDataType.Keys.Count == 0)
                {
                    return string.Empty;
                }
                return string.IsNullOrWhiteSpace(_parametersMethodWithThisKeyword) ? string.Join(",", NameColumnWithDataType.Select(dty => $@"this.{dty.Key}")) : _parametersMethodWithThisKeyword;

            }
            private set { _parametersMethodWithThisKeyword = value; }
        }

        public struct ColumnInfo
        {
            public string DataType { get; set; }
            public bool IsNull { get; set; }
        }
        public static Dictionary<string, ColumnInfo> NameColumnWithDataType { get; private set; }
        public static StringBuilder StringBuilderCommandParameters { get; private set; }
        public static StringBuilder StringBuilderAssignPropertiesForPublicConstructor { get; private set; } // long but great
        public enum Mode { Add, Update };
        private Mode mode;
        public Form1()
        {
            InitializeComponent();

            NameColumnWithDataType = new Dictionary<string, ColumnInfo>();
            StringBuilderCommandParameters = new StringBuilder();
            StringBuilderAssignPropertiesForPublicConstructor = new StringBuilder();
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
            StringBuilderAssignPropertiesForPublicConstructor.Clear();
            StringBuilderAssignPropertiesForPublicConstructor = _FillStringBuilderAssignPropertiesForPublicConstructor();
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
                // this is not enough yes i forgot edit it , you will now forget it now
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
                    switch (dty.Value.DataType)
                    {
                        case "int":
                        case "short":
                        case "byte":
                        case "decimal":
                            StringBuilderCommandParameters.AppendLine((dty.Key).EndsWith("Id") ? $@"command.Parameters.AddWithValue( ""@{dty.Key}"", ({dty.Key} == -1)?DBNull.Value : (object){dty.Key});" : $@"command.Parameters.AddWithValue(""@{dty.Key}"",({dty.Key} == 0)?DBNull.Value : (object){dty.Key});");
                            break;
                        case "string":

                            StringBuilderCommandParameters.AppendLine($@"command.Parameters.AddWithValue( ""@{dty.Key}"", !string.IsNullOrWhiteSpace({dty.Key}) ? {dty.Key} : (object)DBNull.Value);");
                            break;
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
                //what if bool? I forgot too 
            }
            return stringBuilder;
        }
        private StringBuilder _FillStringBuilderAssignPropertiesForPublicConstructor()
        {
            foreach (var dty in NameColumnWithDataType)
            {
                switch (dty.Value.DataType)
                {
                    case "int":
                    case "short":
                    case "byte":
                    case "decimal":
                        StringBuilderAssignPropertiesForPublicConstructor.AppendLine(dty.Key.EndsWith("Id") ? $"this.{dty.Key} = -1;" : $"this.{dty.Key} = 0;");
                        break;
                    case "string":
                        StringBuilderAssignPropertiesForPublicConstructor.AppendLine($"this.{dty.Key} = string.Empty;");
                        break;
                    case "bool":
                        StringBuilderAssignPropertiesForPublicConstructor.AppendLine($"this.{dty.Key} = false;");
                        break;
                    case "DateTime":
                        StringBuilderAssignPropertiesForPublicConstructor.AppendLine($"this.{dty.Key} = DateTime.MinValue;");
                        break;

                }
            }
            return StringBuilderAssignPropertiesForPublicConstructor;
        }


        #region Generate Data Access Layer
        private static string ProcessAddMethod(string tableName)
        {// This row is for applying edits on StringBuilderCommandParameters without effect on the original copy. 

            string pk = _GetPrimaryKey();
            StringBuilder tempStringBuilder = new StringBuilder(StringBuilderCommandParameters.ToString());
            tempStringBuilder.Replace($"command.Parameters.AddWithValue(\"@{pk}\", {pk});", string.Empty);
            string query = $@"insert into {tableName} ({Columns.Replace($"{pk},", "")}) values ({Values.Replace($"@{pk},", "")}) SELECT SCOPE_IDENTITY(); ";
            return Generator.Add(ParametersMethod.Replace($"{_GetDataTypePrimaryKey()} {pk},", ""), query, tempStringBuilder);
        }
        private static string ProcessUpdateMethod(string tableName)
        {
            string columnsWithValues = string.Join(",", NameColumnWithDataType.Select(dty => $"{dty.Key} = @{dty.Key}")); //(Name=@Name,Age=@Age)
            string pk = _GetPrimaryKey();
            string query = $@"update {tableName} set {columnsWithValues}  WHERE {pk}=@{pk};";

            return Generator.Update(ParametersMethod, query, StringBuilderCommandParameters);
        }
        private string ProcessGetByIdMethod(string tableName)
        {
            string pk = _GetPrimaryKey();

            string query = $@"select * from {tableName}  WHERE {pk}=@{pk};";
            string parametersMethodWithRefKeyword = string.Join(",", NameColumnWithDataType.Select(dty => dty.Key == $"{pk}" ? $"{dty.Value.DataType} {dty.Key}" : $" ref {dty.Value.DataType} {dty.Key}"));
            return Generator.GetById(parametersMethodWithRefKeyword, query, $"command.Parameters.AddWithValue(\"@{pk}\",{pk});", _FillStringBuilderGetValuesFromDB());
            // Great!
        }
        private string ProcessAllMethod(string tableName)
        {
            return Generator.All(tableName);
        }
        private string ProcessDeleteMethod(string tableName)
        {

            return Generator.DeleteByPk(tableName, _GetPrimaryKey(), _GetDataTypePrimaryKey());
        }
        private string ProcessExistMethod(string tableName)
        {

            return Generator.ExistByPK(tableName, _GetPrimaryKey(), _GetDataTypePrimaryKey());
        }
        private static string _GetPrimaryKey()
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
        private static string _GetDataTypePrimaryKey()
        {
            if (NameColumnWithDataType.Count == 0)
            {
                return "dic is empty";
            }

            string datatypePk = NameColumnWithDataType[NameColumnWithDataType.Keys.First()].DataType;

            if (string.IsNullOrWhiteSpace(datatypePk))
            {
                return "int";
            }

            return datatypePk;
        }
        private StringBuilder _DataAccessLayer()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(ProcessAddMethod(cbTables.Text));
            stringBuilder.AppendLine(ProcessUpdateMethod(cbTables.Text));
            stringBuilder.AppendLine(ProcessGetByIdMethod(cbTables.Text));
            stringBuilder.AppendLine(ProcessAllMethod(cbTables.Text));
            stringBuilder.AppendLine(ProcessDeleteMethod(cbTables.Text));
            stringBuilder.AppendLine(ProcessExistMethod(cbTables.Text));

            return stringBuilder;
        }
        private void btnViewDataAccessLayer_Click(object sender, EventArgs e)
        {
            richTxtContantLayers.Clear();
            richTxtContantLayers.Text = _DataAccessLayer().ToString();
        }
        #endregion

        #region Generator Generic Methods...
        private string ProcessGenericAllMethod()
        {
            return Generator.GenericAll();
        }
        private string ProcessGenericDeleteMethod()
        {
            return Generator.GenericDelete();
        }
        private string ProcessGenericExistMethod()
        {
            return Generator.GenericExist();
        }
        private StringBuilder _GenerateGenericDataAccessMethods()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ProcessGenericAllMethod());
            sb.AppendLine(ProcessGenericDeleteMethod());
            sb.AppendLine(ProcessGenericExistMethod());
            return sb;
        }
        private void btnViewGenericMethods_Click(object sender, EventArgs e)
        {
            richTxtContantLayers.Text = _GenerateGenericDataAccessMethods().ToString();
        }
        #endregion

        #region Generator Business Layer Methods...
        private StringBuilder _GetPropertiesClass()
        {
            StringBuilder sbProperties = new StringBuilder();
            foreach (var dty in NameColumnWithDataType)
            {
                sbProperties.AppendLine($@"public {dty.Value.DataType} {dty.Key}  {{get; set;}}");
            }
            return sbProperties;
        }
        private string _HeaderClassInBusinessLayer(string nameClass)
        {
            return Generator.PrintHeaderClass(nameClass, _GetPropertiesClass());
        }
        private string _GeneratePublicConstructor(string nameClass)
        {
            StringBuilder sbPublicConstructor = new StringBuilder();
            //string intStatus = string.Join(";", NameColumnWithDataType.Select(dty => dty.Value.DataType=="int" ? dty.Key.EndsWith("Id")? $"this.{dty.Key} = -1;\n" : $"this.{dty.Key} = 0;\n" 
            //: dty.Value.DataType == "string" ? $"this.{dty.Key} = string.Empty;\n":dty.Value.DataType=="DateTime"? $"this.{dty.Key} = DateTime.MinValue;":string.Empty ));
            return Generator.PublicConstructor(nameClass, StringBuilderAssignPropertiesForPublicConstructor);
        }
        private string _GeneratePrivateConstructor(string nameClass)
        {
            StringBuilder sbAssignProperties = new StringBuilder();
            //string intStatus = string.Join(";", NameColumnWithDataType.Select(dty => dty.Value.DataType=="int" ? dty.Key.EndsWith("Id")? $"this.{dty.Key} = -1;\n" : $"this.{dty.Key} = 0;\n" 
            //: dty.Value.DataType == "string" ? $"this.{dty.Key} = string.Empty;\n":dty.Value.DataType=="DateTime"? $"this.{dty.Key} = DateTime.MinValue;":string.Empty ));

            foreach (var dty in NameColumnWithDataType)
            {
                sbAssignProperties.AppendLine($"this.{dty.Key} = {dty.Key};");
            }
            return Generator.PrivateConstructor(nameClass, ParametersMethod, sbAssignProperties, StringBuilderAssignPropertiesForPublicConstructor);
        }
        private StringBuilder _GenerateAddMethod(string nameClass)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($@"private bool _Add()
            {{ ");
            stringBuilder.AppendLine($@"this.{NameColumnWithDataType.Keys.First()}=
            {nameClass}Data.Add({ParametersMethodWithThisKeyword.Replace($"this.{NameColumnWithDataType.Keys.First()},", " ")} ); "); //{ParametersMethodWithThisKeyword.Remove(0, 7)}

            stringBuilder.AppendLine($@" return (this.{NameColumnWithDataType.Keys.First()} != -1 ); }}");
            return stringBuilder;
        }
        private string _GenerateUpdateMethod(string nameClass)
        {
            return Generator.UpdateBusiness(nameClass, ParametersMethodWithThisKeyword);
        }
        private string _GenerateSaveMethod()
        {
            return Generator.SaveBusiness();
        }
        private string _GenerateAllMethod(string tableName)
        {
            return Generator.AllBusiness(tableName);
        }
        private string _GenerateExistMethod(string nameClass)
        {
            return Generator.ExistBusiness(nameClass, _GetPrimaryKey(), _GetDataTypePrimaryKey());
        }
        private string _GenerateDeleteMethod(string nameClass)
        {
            return Generator.DeleteBusiness(nameClass, _GetPrimaryKey(), _GetDataTypePrimaryKey());
        }
        private StringBuilder _DecelerateNewPropertiesWithinFindMethod()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var dty in NameColumnWithDataType)
            {
                switch (dty.Value.DataType)
                {
                    case "int":
                    case "short":
                    case "byte":
                    case "decimal":
                        stringBuilder.AppendLine(dty.Key.EndsWith("Id", StringComparison.OrdinalIgnoreCase) ? $"{dty.Value.DataType} {dty.Key} = -1;" : $"{dty.Value.DataType} {dty.Key} = 0;");
                        break;
                    case "string":
                        stringBuilder.AppendLine($"{dty.Value.DataType} {dty.Key} = string.Empty;");
                        break;
                    case "bool":
                        stringBuilder.AppendLine($"{dty.Value.DataType} {dty.Key}= false;");
                        break;
                    case "DateTime":
                        stringBuilder.AppendLine($"{dty.Value.DataType} {dty.Key} = DateTime.MinValue;");
                        break;

                }
            }
            return stringBuilder;
        }
        private StringBuilder _GenerateFindMethod(string nameClass)
        {
            StringBuilder stringBuilderFindMethod = new StringBuilder();
            string par = string.Join(", ", NameColumnWithDataType.Select(dty => dty.Key == "Id" ? $"{dty.Key}" : $" ref {dty.Key}"));
            string pk = _GetPrimaryKey();

            StringBuilder tempStringBuilder = new StringBuilder(_DecelerateNewPropertiesWithinFindMethod().ToString());
            tempStringBuilder.Replace($"{_GetDataTypePrimaryKey()} {pk} = -1;", "");
            stringBuilderFindMethod.AppendLine($@" public {nameClass} Find({_GetDataTypePrimaryKey()} {pk})
            {{    {tempStringBuilder} 
                            if ({nameClass}Data.Get({par}))
            {{
                return new {nameClass}({Columns});
            }}  
                return null;}} }} ");

            return stringBuilderFindMethod;

        }
        private StringBuilder _BusinessLayer()
        {
            StringBuilder stringBuilder = new StringBuilder();
            txtNameClass.Text = cbTables.Text.Singularize();
            stringBuilder.AppendLine(_HeaderClassInBusinessLayer(txtNameClass.Text));
            stringBuilder.AppendLine(_GeneratePublicConstructor(txtNameClass.Text));
            stringBuilder.AppendLine(_GeneratePrivateConstructor(txtNameClass.Text));
            stringBuilder.AppendLine(_GenerateAddMethod(txtNameClass.Text).ToString());
            stringBuilder.AppendLine(_GenerateUpdateMethod(txtNameClass.Text).ToString());
            stringBuilder.AppendLine(_GenerateSaveMethod());
            stringBuilder.AppendLine(_GenerateExistMethod(txtNameClass.Text));
            stringBuilder.AppendLine(_GenerateDeleteMethod(txtNameClass.Text));
            stringBuilder.AppendLine(_GenerateFindMethod(txtNameClass.Text).ToString());

            return stringBuilder;
        }
        private void btnViewBuisnessLayer_Click(object sender, EventArgs e)
        {
            richTxtContantLayers.Text = _BusinessLayer().ToString();
        }
        #endregion

        private void btnCopy_Click(object sender, EventArgs e)
        {
            richTxtContantLayers.SelectAll(); // Select all text in the RichTextBox
            richTxtContantLayers.Copy();

        }
    }
}

