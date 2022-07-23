
namespace Utils
{
    class ConfigHandler
    {
        public static string GetConnString()
        {
            return JSONReader.GetPropertyFromJSONFile(FilePathFinder.GetPathToFile("\\configuration.json"), "SQLconnection");
        }
    }
}
