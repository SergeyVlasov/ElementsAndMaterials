using System;
using System.IO;


namespace Utils
{
    class Logger
    {
        public static void Log(string text)
        {
            using (StreamWriter w = File.AppendText(FilePathFinder.GetPathToFile("\\log.txt")))
            {
                w.WriteLine(new string('-', 20) + Environment.NewLine + text + Environment.NewLine + new string('-', 20) + Environment.NewLine);
            }
        }
        
        public static void ClearLog()
        {
            FileInfo fileInf = new FileInfo(FilePathFinder.GetPathToFile("\\log.txt"));
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
    }
}
