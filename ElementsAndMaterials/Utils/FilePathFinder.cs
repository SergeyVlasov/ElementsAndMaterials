using System;
using System.IO;
using System.Reflection;

namespace Utils
{
    class FilePathFinder
    {
        public static string GetPathToFile(string pathFileFolder)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string pathfile = Path.GetDirectoryName(path);
            pathfile = pathfile.Replace("\\bin\\Debug", pathFileFolder);
            return pathfile;
        }
    }
}
