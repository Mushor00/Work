using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zaklad.Worker;
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
        public string FisrtAndLastName
        {
            get { return FirstName + " " + LastName; }
        }
        public int Age 
        {
            get {return DateTime.Now.Year - Birthday.Year; }
        }
    }

    
    public void ListWorkers()
    {
        Console.WriteLine("ID" + " | " + "Imię i Nazwisko" + " | " + "Data Urodzenia" + " | " + "Stanowisko");
        Console.WriteLine();
        foreach (var aWorkers in _db.GetWorkers())
        {
            Console.WriteLine($"{aWorkers.ID.ToString()} | {aWorkers.FisrtAndLastName} | {aWorkers.Birthday.ToShortDateString()} | {aWorkers.Position}");
            Console.WriteLine();
        }
    }
    public void SelectWorker()
    {
        Console.WriteLine("PROSZE PODAC ID PRACOWNIKA DLA KTOREGO ZOSTANIE WYLICZONE WYNAGRODZENIE:");
        var aId = int.Parse(Console.ReadLine() ?? "0");
        if (aId == 0) return;

        try
        {
            var worker = _db.GetWorkerById(aId);
            ShowWorkerData(worker);
        }
        catch (Exception e)
        {
            SelectWorker();
        }
    }

    private static void ShowWorkerData(Workers worker)
    {
        while (true)
        {
           

            Console.WriteLine("WYLICZONE WYNAGRODZENIE PRACOWNIKA");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("DANE PRACOWNIKA");
            Console.WriteLine($"IMIE I NAZWISKO: {worker.FisrtAndLastName}");
            Console.WriteLine($"WIEK: {worker.Age} lat");
            Console.WriteLine($"STANOWISKO: {worker.Position}");
            if (worker.Position == "urzędnik")
            {
                Console.WriteLine($"PENSJA {Math.Round(worker.FixedSalary, 2)} zł");
            }
            else 
            {
                Console.WriteLine($"PENSJA {Math.Round(worker.HourlyRate, 2)} zł/h");
            }
            Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYCH DNI PRZEZ PRACOWNIKA (MAX 20): ");
            if (!int.TryParse(Console.ReadLine(), out var s))
            {
                break;
            }
            Console.WriteLine("PROSZĘ PODAĆ KWOTĘ PREMII DLA PRACOWNIKA: ");
            decimal bonus = decimal.Parse(Console.ReadLine());
            if(bonus == .5m)
            {
                bonus = bonus + .1m;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            if (worker.Age <= 26)
            {
                if (worker.Position == "urzędnik")
                {
                    if (s == 20)
                    {
                        Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {Math.Round(worker.FixedSalary + bonus)} zł");
                    }
                    else
                    {
                        decimal m = 0.8m;
                        Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {Math.Round(m * worker.FixedSalary + bonus)} zł");
                    }
                }
                else
                {
                    Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {Math.Round(s * worker.HourlyRate * 8) + bonus} zł");
                }
            }
            else
            {
                if (worker.Position == "urzędnik")
                {
                    if (s == 20)
                    {
                        Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {Math.Round(worker.FixedSalary+bonus)} zł");
                        Console.WriteLine($"POTRĄCONY PODATEK (18%): {Math.Round(worker.FixedSalary * 0.18m +bonus)}   zł");
                        Console.WriteLine($"DO WYPŁATY: {Math.Round(worker.FixedSalary - (worker.FixedSalary * 0.18m) + bonus)}  zł");
                    }
                    else
                    {
                        decimal m = 0.8m;
                        Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {Math.Round((m * worker.FixedSalary) + bonus)} zł");
                        Console.WriteLine($"POTRĄCONY PODATEK (18%): {Math.Round(worker.FixedSalary * 0.18m + bonus)}  zł");
                        Console.WriteLine($"DO WYPŁATY: {Math.Round(worker.FixedSalary - (worker.FixedSalary * 0.18m) + bonus)}  zł");
                    }
                }
                else
                {
                    Console.WriteLine($"WYNAGRODZENIE PRACOWNIKA BRUTTO WYNOSI: {Math.Round(s * worker.HourlyRate * 8 + bonus)} zł");
                    Console.WriteLine($"POTRĄCONY PODATEK (18%): {Math.Round((s * worker.HourlyRate * 8) * 0.18m + bonus)} zł");
                    Console.WriteLine($"DO WYPŁATY: {Math.Round((s * worker.HourlyRate * 8) - ((s * worker.HourlyRate * 8) * 0.18m) + bonus)} zł");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;



            return;
        }
    }



}