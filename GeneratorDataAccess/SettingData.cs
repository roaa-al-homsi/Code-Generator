using System.Configuration;

namespace GeneratorDataAccess
{
    public static class SettingData
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    }
}
