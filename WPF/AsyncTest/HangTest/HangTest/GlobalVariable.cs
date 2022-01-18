using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangTest
{
    static class GlobalVariable
    {
        public static int testNumber;
        static GlobalVariable() {
            testNumber = 0;
        }
    }
}
