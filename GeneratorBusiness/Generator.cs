using GeneratorDataAccess;
using System.Data;
using System.Text;


namespace GeneratorBusiness
{
    public class Generator
    {
        private static string CreateConnection
        {
            get { return "SqlConnection connection = new SqlConnection(SettingData.ConnectionString)"; }
        }
        private static string CreateCommand
        {
            get { return "SqlCommand command = new SqlCommand(query, connection)"; }
        }
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

        #region Data Access Methods...
        public static string Add(string parametersMethod, string query, StringBuilder stringBuilderCommandParameters)
        {
            string addMethodSyntax = $@" public static int Add ({parametersMethod}) 
            {{
                     int newId = 0;
                     string query = ""{query}"";
                        using ({CreateConnection})
                        {{
                              using ({CreateCommand})
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
                        using ({CreateConnection})
                        {{
                              using ({CreateCommand})
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
            string updateMethodSyntax = $@" public static bool Get({parametersMethod}) 
            {{
                   bool IsFound = false;
                     string query = ""{query}"";

                 try {{
                        using ({CreateConnection})
                        {{   connection.Open();
                              using ({CreateCommand})
                                 {{
                                           {CommandParameters}
                                                    
                                                          
                                    using( SqlDataReader reader = command.ExecuteReader())
                         {{
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
                           }}
                           }}
                           }}
                                                      catch(Exception ex) {{}}
                            return IsFound ;
                                  }}
                         

           
            }}  ";

            return updateMethodSyntax;
        }
        public static string DeleteByPk(string tableName, string pk, string datatypePK)
        {
            string deleteMethodSyntax = $@"  static public bool Delete({datatypePK} {pk})
        {{
            return GenericData.Delete(""delete {tableName} where {pk} = @{pk}"", ""@{pk}"", {pk});
        }}          ";

            return deleteMethodSyntax;
        }
        public static string ExistByPK(string tableName, string pk, string datatypePK)
        {
            string existMethodSyntax = $@"static public bool Exist({datatypePK} {pk})
        {{
            return GenericData.Exist(""select Found=1 from {tableName} where {pk}= @{pk}"", ""@{pk}"", {pk});
        }}";

            return existMethodSyntax;
        }
        public static string All(string tableName)
        {
            string allMethodSyntax = $@"static public DataTable All()
            {{
           return GenericData.All(""select * from {tableName}"");
            }}";
            return allMethodSyntax;
        }
        #endregion

        #region Generic Methods...
        public static string GenericAll()
        {
            string genericAllMethodSyntax = $@"   static public DataTable All(string query)
        {{
            DataTable dt = new DataTable();
            try
            {{
            using ({CreateConnection})
            {{  connection.Open();
                using ({CreateCommand})
                {{
                    
                       
                        using(SqlDataReader Reader = command.ExecuteReader())
                        {{
                        if (Reader.HasRows)
                        {{
                            dt.Load(Reader);
                        }}
                        }}
                 }}
            }}
            }}
                    catch (Exception ex) {{ }}
                return dt;
            }}
           
        }}";

            return genericAllMethodSyntax;
        }
        public static string GenericDelete()
        {
            string genericDeleteMethodSyntax = $@" static public bool Delete<T>(string query, string ParameterName, T DeleteBy)
        {{
            int RowsAffected = 0;
            using ({CreateConnection})
            {{
                using ({CreateCommand})
                {{
                    command.Parameters.AddWithValue(ParameterName, DeleteBy);

                    try
                    {{
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }}
                    catch (Exception ex) {{ return false; }}
                }}
            }}

            return RowsAffected > 0;
        }}";


            return genericDeleteMethodSyntax;
        }
        public static string GenericExist()
        {
            string genericExistMethodSyntax = $@"static public bool Exist<T>(string query, string ParameterName, T ParameterValue)
        {{
            bool IsFound = false;
try
{{
            using ({CreateConnection})
            {{
                using ({CreateCommand})
                {{
                    command.Parameters.AddWithValue(ParameterName, ParameterValue);
                    
                        connection.Open();
                        using(SqlDataReader Reader = command.ExecuteReader())
                       {{
                        IsFound = Reader.HasRows;
                       }}
                 }}
            }}

}}
                    catch (Exception ex) {{ }}
                    return IsFound;
                
            }}
           
        }}";

            return genericExistMethodSyntax;
        }
        #endregion

        #region Generate Business Layer
        public static string PublicConstructor(string nameClass, StringBuilder SBAssignPropertiesForPublicConstructorAndFindMethod)
        {
            string pCons = $@"  public {nameClass}(){{  {SBAssignPropertiesForPublicConstructorAndFindMethod}
             _mode = Mode.Add;}}";
            return pCons;
        }
        public static string PrivateConstructor(string nameClass, string ParametersMethod,
            StringBuilder sbAssignProperties, StringBuilder StringBuilderAssignPropertiesForPublicConstructorAndFindMethod)
        {
            string pCons = $@" private {nameClass}({ParametersMethod})
             {{ 
             {sbAssignProperties}

            _mode = Mode.Update;}}";
            return pCons;
        }
        public static string UpdateBusiness(string nameClass, string ParametersMethodWithThisKeyword)
        {
            string updateBus = $@" private bool _Update() {{ 
             return {nameClass}Data.Update({ParametersMethodWithThisKeyword}); }}";
            return updateBus;
        }
        public static string SaveBusiness()
        {
            string save = $@" public bool Save() {{ 
            
              switch (_mode)
            {{
                case Mode.Add: {{
                        _mode = Mode.Update;
                        return _Add();
                    }}
                case Mode.Update: return _Update();
            }}
                 return false; 
                }}";
            return save;
        }
        public static string AllBusiness(string tableName)
        {
            string allMethod = $@"  public static DataTable All()
        {{
            return {tableName}Data.All();
        }}";
            return allMethod;
        }
        public static string ExistBusiness(string nameClass, string namePk, string dtPK)
        {
            string existMethod = $@"  public static bool Exist({dtPK} {namePk})
        {{
            return {nameClass}Data.Exist({namePk});
        }}  ";
            return existMethod;

        }
        public static string DeleteBusiness(string tableName, string namePk, string dtPK)
        {
            string deleteMethod = $@" public static bool Delete({dtPK} {namePk}) 
 {{
            if (!Exist({namePk}))
            {{
                return false;
            }}
            else {{  return {tableName}Data.Delete({namePk}); }} }}";

            return deleteMethod;
        }
        public static string PrintHeaderClass(string nameClass, StringBuilder stringPropertiesClass)
        {
            string headerAndPropertiesClass = $@"public class {nameClass}
    {{
        private enum Mode {{ Add, Update }}
        private Mode _mode;  
            {stringPropertiesClass}";

            return headerAndPropertiesClass;
        }
        #endregion
    }
}
