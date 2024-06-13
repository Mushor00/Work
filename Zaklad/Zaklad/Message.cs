namespace Zaklad.Message
{
    public class Message
    {
        public readonly Message _message;
        public void DisplayMainScreen()
        {
            Console.WriteLine("WYBIERZ OPCJE");
            Console.WriteLine();
            Console.WriteLine("1 => LISTA WSZYSTKICH PRACOWNIKÓW");
            Console.WriteLine();
            Console.WriteLine("2 => WYLICZ PENSJĘ PRACOWNIKA");
            Console.WriteLine();
            Console.WriteLine("3 => DODAWANIE, MODYFIKOWANIE I USUWANIE PRACOWNIKA");
            Console.WriteLine();
            Console.WriteLine("4 => ZAKOŃCZ PROGRAM");
            Console.WriteLine();
            Console.WriteLine("WYBIERZ 1, 2, 3 LUB 4:");
            Console.WriteLine();
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
                if (number >= 1 && number < 5)
                    return true;
            }

            return false;

        }

        public int Show2()
        {
            string input = Console.ReadLine();
            var goodKeyPressed = CheckButton2(input);
            while (!goodKeyPressed)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Nacianąłeś nieprawidowy klawisz!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                AddWork();
                input = Console.ReadLine();
                goodKeyPressed = CheckButton2(input);
            }
            return int.Parse(input);
        }

        private bool CheckButton2(string userInput)
        {
            if (int.TryParse(userInput, out int number))
            {
                if (number >= 1 && number < 4)
                    return true;
            }

            return false;

        }
        public void AddWork()
        {
            Console.WriteLine("Wybierz opcje 1, 2 lub 3");
            Console.WriteLine();
            Console.WriteLine("1. Dodaj pracownika");
            Console.WriteLine();
            Console.WriteLine("2. Usuń pracownika");
            Console.WriteLine();
            Console.WriteLine("3. Zmień dane pracownika");
            Console.WriteLine();

        }
    }
}
