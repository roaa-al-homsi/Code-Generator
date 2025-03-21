﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace GeneratorDataAccess
{
    public static class GenericData
    {

        static public DataTable All(string query, string databaseName = "master")
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(SettingData.ConnectionString(databaseName)))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
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




    }
}
