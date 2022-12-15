using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaklad;


namespace Zaklad
{

    public class ShowWorkers
    {
        public void SelectWorker()
        {
            Console.WriteLine("PROSZE PODAC ID PRACOWNIKA DLA KTOREGO ZOSTANIE WYLICZONE WYNAGRODZENIE:");
            string sID = Console.ReadLine();
            int aID = int.Parse(sID);
            List<Workers> workers = new List<Workers>();

            var emploee = workers.FirstOrDefault(a => a.ID == aID);


            Console.WriteLine("WYLICZONE WYNAGRODZENIE PRACOWNIKA");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("DANE PRACOWNIKA");
            foreach (var worker in workers) 
            {
                Console.WriteLine($"IMIE I NAZWISKO: {worker.FisrtAndLastName}");
                Console.WriteLine($"WIEK: ");
                Console.WriteLine($"STANOWISKO: ");
            }
            //zalezy od id czy stala czy godzinowa
            Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYVH DNI PRZEZ PRACOWNIKA (MAX 20): ");
            Console.ReadLine();
        }
    }
}
