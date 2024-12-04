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
        public static string Add(string parametersMethod, string query, StringBuilder stringBuilderCommandParameters)
        {
            string addMethodSyntax = $@" public static int Add ({parametersMethod}) 
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

            return addMethodSyntax;
        }

        public static string Update(string parametersMethod, string query, StringBuilder stringBuilderCommandParameters)
        {
            string updateMethodSyntax = $@" public static bool Update ({parametersMethod}) 
            {{
                     int RowsAffected = 0;
                     string query = ""{query}"";
                        using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
                        {{
                              using (SqlCommand command = new SqlCommand(query, connection))
                                 {{
                                           {stringBuilderCommandParameters}
                                                    try
                                                     {{
                                                            connection.Open();
                                                            RowsAffected = command.ExecuteNonQuery();
                                                      }}
                                                      catch(Exception ex) {{}}
                                  }}
                          }}

            return RowsAffected > 0;
            }}  ";

            return updateMethodSyntax;
        }

        public static string GetById(string parametersMethod, string query, string CommandParameters, StringBuilder stringBuilderGetValuesFromDB)
        {
            string updateMethodSyntax = $@" public static bool GetById ({parametersMethod}) 
            {{
                   bool IsFound = false;
                     string query = ""{query}"";
                        using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
                        {{
                              using (SqlCommand command = new SqlCommand(query, connection))
                                 {{
                                           {CommandParameters}
                                                    try
                                                     {{
                                                            connection.Open();
                                                               SqlDataReader reader = command.ExecuteReader();
                           if (reader.Read())
                        {{
                            IsFound = true;
                            {stringBuilderGetValuesFromDB}
                        
                        }}
                        else
                        {{
                            IsFound = false;
                        }}
                                                      }}
                                                      catch(Exception ex) {{}}
                                  }}
                          }}

            return IsFound ;
            }}  ";

            return updateMethodSyntax;
        }

        //SqlDbType


    }
}
