using GeneratorDataAccess;
using System.Data;

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
    }
}
