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
        public int Show()
        {
            string odpGracza = Console.ReadLine();
            var czyWcisnalDobryKlawisz = SprawdzCzyDobryKlawisz(odpGracza);
            while (!czyWcisnalDobryKlawisz)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Nacianąłeś nieprawidowy klawisz!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                DisplayMainScreen();
                odpGracza = Console.ReadLine();
                czyWcisnalDobryKlawisz = SprawdzCzyDobryKlawisz(odpGracza);
            }
            return int.Parse(odpGracza);
        }
        private bool SprawdzCzyDobryKlawisz(string odpowiedzGracza)
        {
            if (int.TryParse(odpowiedzGracza, out int liczba))
            {
                if (liczba >= 1 && liczba <= 4)
                    return true;
            }

            return false;

        }
    }
}
