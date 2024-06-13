using Zaklad.Worker.DB;

namespace Zaklad.Worker
{
    public class Work
    {
        private readonly Db _db;

        public Work()
        {
            _db = new Db();
        }

        public class Workers
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Birthday { get; set; }
            public string Position { get; set; }
            public decimal HourlyRate { get; set; }
            public decimal FixedSalary { get; set; }
            public string FirstAndLastName => $"{FirstName} {LastName}";
            public int Age => DateTime.Now.Year - Birthday.Year;
        }

        public void ListWorkers()
        {
            Console.WriteLine("ID | Imię i Nazwisko | Data Urodzenia | Stanowisko");
            Console.WriteLine();
            foreach (var worker in _db.GetWorkers())
            {
                Console.WriteLine($"{worker.ID} | {worker.FirstAndLastName} | {worker.Birthday.ToShortDateString()} | {worker.Position}");
                Console.WriteLine();
            }

            Console.WriteLine("Naciśnij enter aby powrócić do menu wyobru");
            Console.ReadLine();
        }

        public void SelectWorker()
        {
            Console.WriteLine("PROSZĘ PODAĆ ID PRACOWNIKA DLA KTOREGO ZOSTANIE WYLICZONE WYNAGRODZENIE:");
            if (!int.TryParse(Console.ReadLine(), out int aId) || aId == 0)
            {
                Console.WriteLine("Nieprawidłowy numer ID. Naciśnij enter aby spróbować ponownie.");
                Console.ReadLine();
                SelectWorker();
                return;
            }

            try
            {
                var worker = _db.GetWorkerById(aId);
                ShowWorkerData(worker);
            }
            catch (Exception)
            {
                Console.WriteLine("Pracownik o podanym ID nie istnieje. Naciśnij enter aby spróbować ponownie.");
                Console.ReadLine();
                SelectWorker();
            }
        }

        private static void ShowWorkerData(Workers worker)
        {
            Console.Clear();
            Console.WriteLine("WYLICZONE WYNAGRODZENIE PRACOWNIKA");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine("DANE PRACOWNIKA");
            Console.WriteLine();
            Console.WriteLine($"IMIE I NAZWISKO: {worker.FirstAndLastName}");
            Console.WriteLine();
            Console.WriteLine($"WIEK: {worker.Age} lat");
            Console.WriteLine();
            Console.WriteLine($"STANOWISKO: {worker.Position}");
            Console.WriteLine();

            if (worker.Position == "urzędnik")
            {
                Console.WriteLine($"PENSJA: {Math.Round(worker.FixedSalary, 2)} zł");
            }
            else
            {
                Console.WriteLine($"PENSJA: {Math.Round(worker.HourlyRate, 2)} zł/h");
            }

            Console.WriteLine();
            Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYCH DNI PRZEZ PRACOWNIKA (MAX 20): ");

            if (!int.TryParse(Console.ReadLine(), out var daysWorked) || daysWorked > 20)
            {
                Console.WriteLine("Nieprawidłowa ilość dni. Naciśnij enter aby spróbować ponownie.");
                Console.ReadLine();

            }

            Console.Clear();
            Console.WriteLine("PROSZĘ PODAĆ KWOTĘ PREMII DLA PRACOWNIKA: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal bonus))
            {
                Console.WriteLine("Nieprawidłowa kwota premii. Naciśnij enter aby spróbować ponownie.");
                Console.ReadLine();

            }

            if (bonus == 0.5m)
            {
                bonus += 0.1m;
                bonus = Math.Round(bonus, 0);
            }

            decimal grossSalary;
            decimal taxRate = 0.18m;

            if (worker.Age <= 26)
            {
                taxRate = 0;
            }

            if (worker.Position == "urzędnik")
            {
                grossSalary = worker.FixedSalary + bonus;
            }
            else
            {
                grossSalary = daysWorked * worker.HourlyRate * 8 + bonus;
            }

            decimal tax = grossSalary * taxRate;
            decimal netSalary = grossSalary - tax;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO: {Math.Round(grossSalary, 2)} zł");
            Console.WriteLine();
            Console.WriteLine($"POTRĄCONY PODATEK: {Math.Round(tax, 2)} zł");
            Console.WriteLine();
            Console.WriteLine($"DO WYPŁATY: {Math.Round(netSalary, 2)} zł");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Naciśnij enter aby powrócić do menu wyobru");
            Console.ReadKey();

        }

        public void AddWorker()
        {
            Console.Clear();
            int id = _db.GetWorkers().Max(workers => workers.ID) + 1;

            Console.WriteLine("PROSZE PODAĆ IMIE PRACOWNIKA:");
            string firstName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ NAZWISKO PRACOWNIKA:");
            string lastName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ DATE URODZENIA PRACOWNIKA (DD/MM/RRRR):");
            string birthdayStr = Console.ReadLine();
            DateTime birthday = DateTime.Parse(birthdayStr);
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ ZAJMOWANE STANOWISKO PRACOWNIKA: (URZĘDNIK/PRACOWNIK FIZYCZNY)");
            string position = Console.ReadLine().ToLower();
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ STAWKĘ GODZINOWĄ PRACOWNIKA: (MOŻE WYNOSIC 0 TYLKO JEŻELI PRACOWNIK MA POWYŻEJ 26 LAT)");
            decimal hourlyRate = decimal.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ STAŁĄ ZAPŁATĘ PRACOWNIKA: (MOŻE WYNOSIC 0 TYLKO JEŻELI PRACOWNIK MA PONIŻEJ 26 LAT)");
            decimal fixedSalary = decimal.Parse(Console.ReadLine());
            Console.WriteLine();

            _db.workers.Add(new Workers
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birthday,
                Position = position,
                HourlyRate = hourlyRate,
                FixedSalary = fixedSalary
            });

            Console.WriteLine("GRATULUJĘ WŁAŚNIE ZOSTAŁ DODANY NOWY PRACOWNIK");
            Console.WriteLine();
            Console.WriteLine("Naciśnij enter aby powrócić do menu wyobru");
            Console.ReadKey();
        }

        public void DeleteWorker()
        {
            Console.WriteLine("PROSZE PODAĆ ID PRACOWNIKA DO USUNIĘCIA:");
            Console.WriteLine();
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var worker = _db.GetWorkerById(id);
                if (worker != null)
                {
                    _db.workers.Remove(worker);
                    Console.WriteLine("Pracownik został usunięty.");
                }
                else
                {
                    Console.WriteLine("Pracownik o podanym ID nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy numer ID.");
            }
            Console.WriteLine();
            Console.WriteLine("Naciśnij enter aby powrócić do menu wyobru");
            Console.ReadKey();
        }

        public void ModifyWorker()
        {
            Console.WriteLine("PROSZE PODAĆ ID PRACOWNIKA DO MODYFIKACJI:");
            Console.WriteLine();
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Nieprawidłowy numer ID.");
                return;
            }

            var worker = _db.GetWorkerById(id);
            if (worker == null)
            {
                Console.WriteLine("Pracownik o podanym ID nie istnieje.");
                return;
            }

            Console.WriteLine("PROSZE PODAĆ NOWE IMIE PRACOWNIKA (POZOSTAW PUSTE ABY ZACHOWAĆ OBECNE):");
            string firstName = Console.ReadLine();
            if (!string.IsNullOrEmpty(firstName)) worker.FirstName = firstName;
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ NOWE NAZWISKO PRACOWNIKA (POZOSTAW PUSTE ABY ZACHOWAĆ OBECNE):");
            string lastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(lastName)) worker.LastName = lastName;
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ NOWĄ DATĘ URODZENIA PRACOWNIKA (DD/MM/RRRR) (POZOSTAW PUSTE ABY ZACHOWAĆ OBECNE):");
            string birthdayStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(birthdayStr) && DateTime.TryParse(birthdayStr, out DateTime birthday)) worker.Birthday = birthday;
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ NOWE STANOWISKO PRACOWNIKA (URZĘDNIK/PRACOWNIK FIZYCZNY) (POZOSTAW PUSTE ABY ZACHOWAĆ OBECNE):");
            string position = Console.ReadLine();
            if (!string.IsNullOrEmpty(position)) worker.Position = position.ToLower();
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ NOWĄ STAWKĘ GODZINOWĄ PRACOWNIKA (POZOSTAW PUSTE ABY ZACHOWAĆ OBECNE):");
            string hourlyRateStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(hourlyRateStr) && decimal.TryParse(hourlyRateStr, out decimal hourlyRate)) worker.HourlyRate = hourlyRate;
            Console.WriteLine();

            Console.WriteLine("PROSZE PODAĆ NOWĄ STAŁĄ ZAPŁATĘ PRACOWNIKA (POZOSTAW PUSTE ABY ZACHOWAĆ OBECNE):");
            string fixedSalaryStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(fixedSalaryStr) && decimal.TryParse(fixedSalaryStr, out decimal fixedSalary)) worker.FixedSalary = fixedSalary;
            Console.WriteLine();

            _db.UpdateWorker(worker);
            Console.WriteLine();
            Console.WriteLine("Dane pracownika zostały zaktualizowane.");
            Console.WriteLine();
            Console.WriteLine("Naciśnij enter aby powrócić do menu wyboru");
            Console.ReadKey();
        }
    }
}
