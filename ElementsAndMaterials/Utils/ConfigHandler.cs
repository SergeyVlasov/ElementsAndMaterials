
namespace Utils
{
    class ConfigHandler
    {
        public static string GetConnString()
        {
            return JSONReader.GetPropertyFromJSONFile(FilePathFinder.GetPathToFile("\\configuration.json"), "SQLconnection");
        }
        public static string GetConnStringEF()
        {
            return JSONReader.GetPropertyFromJSONFile(FilePathFinder.GetPathToFile("\\configuration.json"), "SQLconnection_EF");
        }
    }
}
