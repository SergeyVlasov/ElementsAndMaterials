using System.IO;
using System.Text.Json;

namespace Utils
{
    class JSONReader
    {
        public static string GetPropertyFromJSONFile(string pathToFile, string property)
        {
            var data = File.ReadAllText(pathToFile);
            JsonDocument doc = JsonDocument.Parse(data);
            JsonElement root = doc.RootElement;
            return root.GetProperty(property).ToString();
        }
    }
}
