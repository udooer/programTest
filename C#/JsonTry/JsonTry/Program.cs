using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonTry
{

    public class Rootobject
    {
        public Book1 Book1 { get; set; }
        public Book2 Book2 { get; set; }
    }

    public class Book1
    {
        public string title { get; set; }
        public string genre { get; set; }
        public string price { get; set; }
    }

    public class Book2
    {
        public string title2 { get; set; }
        public string genre2 { get; set; }
        public string price2 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(@"test.json"));
            foreach (PropertyInfo prop in result.GetType().GetProperties()) 
            {
                var tmp = prop.GetValue(result, null);
                foreach (PropertyInfo prop1 in tmp.GetType().GetProperties())
                {
                    var tmp1 = prop1.GetValue(tmp, null);
                    Console.WriteLine($"{prop1.Name}: {tmp1}");
                }
            }
            int a = 0;
        }
    }
}
