using System;
using System.IO;


namespace FileExistTest
{
    class Test
    {
        public static string programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public static string dataSubFolder = "\\ASUS\\GlideX";
        private static string path = programDataPath + dataSubFolder;
        private static string filename = Path.Combine(path, "GlideX.log");
        private static bool isWriteLog = System.IO.File.Exists(filename);
        public static void Main() {
            Console.WriteLine(filename);
            if (isWriteLog)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
    }
}
