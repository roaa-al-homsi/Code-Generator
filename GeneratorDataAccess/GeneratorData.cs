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
            SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH,IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName ORDER BY ORDINAL_POSITION;";

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

        public static int Add(string Name, DateTime BirthDate, string Gender, string Phone, string Email, int CountryId, string Address, string ImagePath)
        {
            int IdNewPerson = 0;

            string query = @"INSERT INTO Persons (Name, BirthDate, Gender, Phone, Email, CountryId, Address, ImagePath)
                     VALUES (@Name, @BirthDate, @Gender, @Phone, @Email, @CountryId, @Address, @ImagePath);
                     SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@BirthDate", BirthDate);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@CountryId", CountryId);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@ImagePath", !string.IsNullOrWhiteSpace(ImagePath) ? ImagePath : (object)DBNull.Value);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            IdNewPerson = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception as needed
                    }
                }
            }

            return IdNewPerson;
        }


    }
}

