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
            string input = Console.ReadLine();
            var goodKeyPressed = CheckButton(input);
            while (!goodKeyPressed)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Nacianąłeś nieprawidowy klawisz!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                DisplayMainScreen();
                input = Console.ReadLine();
                goodKeyPressed = CheckButton(input);
            }
            return int.Parse(input);
        }
        private bool CheckButton(string userInput)
        {
            if (int.TryParse(userInput, out int number))
            {
                if (number >= 1 && number < 4)
                    return true;
            }

            return false;

        }
    }
}
