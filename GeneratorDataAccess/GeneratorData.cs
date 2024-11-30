using System;
using System.Data;
using System.Data.SqlClient;


namespace GeneratorDataAccess
{
    public static class GeneratorData
    {

        public static DataTable AllDatabaseInSqlServer()
        {
            return GenericData.All("SELECT name FROM sys.databases WHERE database_id>4  ORDER BY name;");
        }
        public static DataTable AllNamesTablesInSpecificDB(string nameDB)
        {
            string query = $@"
        USE [{nameDB}];
        SELECT Table_Name 
        FROM INFORMATION_SCHEMA.TABLES 
        WHERE TABLE_TYPE = 'BASE TABLE'  AND Table_Name NOT LIKE 'sys%'
        ORDER BY Table_Name;";
            return GenericData.All(query);
        }
        public static DataTable AllColumnsForSpecificTable(string tableName, string databaseName)
        {
            string query = $@"
            USE [{databaseName}];
            SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName ORDER BY ORDINAL_POSITION;";

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tableName", tableName);
                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = command.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            dt.Load(Reader);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return dt;

        }
        public static int GetNumberOfColumnsInSpecificTable(string tableName, string nameDB)
        {
            int numberOfColumns = 0;
            string query = $@" use [{nameDB}]
                          SELECT COUNT(*) AS ColumnCount
                             FROM INFORMATION_SCHEMA.COLUMNS
                              WHERE TABLE_NAME = @tableName AND TABLE_SCHEMA = 'dbo';";


            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tableName", tableName);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int columnsCount))
                        {
                            numberOfColumns = columnsCount;
                        }
                    }
                    catch (Exception ex) { }

                }
            }
            return numberOfColumns;
        }
    }
}

