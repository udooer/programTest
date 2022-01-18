using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullpath = @"C:\Users\shane_hsu\Desktop\test.txt";
            using (StreamWriter writer = new StreamWriter(fullpath))
            {
                writer.WriteLine("Monica Rathbun");
                writer.WriteLine("Vidya Agarwal");
                writer.WriteLine("Mahesh Chand");
                writer.WriteLine("Vijay Anand");
                writer.WriteLine("Jignesh Trivedi");
            }
        }
    }
}
