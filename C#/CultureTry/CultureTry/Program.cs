using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CultureTry
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo cultureInfo1 = Thread.CurrentThread.CurrentCulture;
            CultureInfo cultureInfo2 = Thread.CurrentThread.CurrentUICulture;
            int a = 0;
        }
    }
}
