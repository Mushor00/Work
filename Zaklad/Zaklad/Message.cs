using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaklad
{
    public class Message
    {
        public void DisplayMainScreen()
        {
            Console.WriteLine("WYBIERZ OPCJE");
            Console.WriteLine();
            Console.WriteLine("1 => LISTA WSZYSTKICH PRACOWNIKÓW");
            Console.WriteLine();
            Console.WriteLine("2 => WYLICZ PENSJĘ PRACOWNIKA");
            Console.WriteLine();
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine();
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");

        }
    }
}
