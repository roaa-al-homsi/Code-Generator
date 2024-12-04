namespace GeneratorDataAccess
{
    public static class SettingData
    {
        //public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static string ConnectionString(string dataBaseName = "master")
        {
            return $"Data Source=.;Database={dataBaseName};Integrated Security=True;";
        }

    }
}
