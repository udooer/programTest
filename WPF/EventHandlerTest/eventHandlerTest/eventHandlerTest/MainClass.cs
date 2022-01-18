using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventHandlerTest
{
    class Cow { 
        public string Name { get; set; }
        public event EventHandler Moo;
        public void BeTippedOver() {
            Moo?.Invoke(this, EventArgs.Empty);
        }
    }
    class MainClass
    {
        static void Main() {
            Cow c1 = new Cow { Name = "Shane" };
            Cow c2 = new Cow { Name = "Jerry" };
            c1.Moo += Sound;
            c1.Moo += Sound2;
            c2.Moo += Sound;
            c2.Moo += Sound2;

            Cow c3 = new Random().Next() % 2 == 0 ? c1 : c2;
            c3.BeTippedOver();
        }

        static private void Sound(object sender, EventArgs e) {
            Cow c = sender as Cow;
            Console.WriteLine($"{c.Name} is Moo Moo!");
        }

        static private void Sound2(object sender, EventArgs e)
        {
            Cow c = sender as Cow;
            Console.WriteLine($"{c.Name} is mooo mooo!");
        }


    }
}
