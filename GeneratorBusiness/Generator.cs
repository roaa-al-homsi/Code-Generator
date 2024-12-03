using GeneratorDataAccess;
using System.Data;
using System.Text;


namespace GeneratorBusiness
{
    public class Generator
    {


        public static DataTable AllNamesDatabase()
        {
            return GeneratorData.AllDatabaseInSqlServer();
        }
        public static DataTable AllNamesTablesInSpecificDB(string nameDB)
        {
            return GeneratorData.AllNamesTablesInSpecificDB(nameDB);
        }
        public static DataTable AllNamesColumnsInSpecificTables(string tableName, string databaseName)
        {
            return GeneratorData.AllColumnsForSpecificTable(tableName, databaseName);
        }
        public static int NumberOfColumnsInSpecificTable(string tableName, string nameDB)
        {
            return GeneratorData.GetNumberOfColumnsInSpecificTable(tableName, nameDB);
        }

        public static StringBuilder Add(string parametersMethod, string query, string parameters, StringBuilder stringBuilderCommandParameters)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string addMethod = $@" public static int Add ({parametersMethod}) 
            {{
             int newId = 0;
             string query = ""{query}"";
             using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {{
               using (SqlCommand command = new SqlCommand(query, connection))
            {{
                          {stringBuilderCommandParameters}
             try
            {{
                         connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {{
                            newId = insertedID;
                        }}

            }}
             catch(Exception ex) {{}}
 
            }}
            }}

             return newId;
            }}  ";
            stringBuilder.Append(addMethod);
            return stringBuilder;

        }







    }
}
