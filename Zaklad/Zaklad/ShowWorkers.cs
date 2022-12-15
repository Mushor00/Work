using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaklad;


namespace Zaklad
{

    public class ShowWorkers
    {

        public void showWorkers()
        {
            var workers = new Workers();

            Workers w1 = new Workers();
            w1.ID = 1;
            w1.FisrtAndLastName = "Jan Kowalski";
            w1.Birthday = new DateTime(2002, 03, 04);
            w1.Position = "pracownik fizyczny";
            w1.HourlyRate = 18.5m;
            w1.FixedSalary = 0;

            Workers w2 = new Workers();
            w2.ID = 2;
            w2.FisrtAndLastName = "Agnieszka Kowalska";
            w2.Birthday = new DateTime(1973, 12, 14);
            w2.Position = "urzędnik";
            w2.HourlyRate = 0;
            w2.FixedSalary = 2800;

            Workers w3 = new Workers();
            w3.ID = 3;
            w3.FisrtAndLastName = "Robert Lewandowski";
            w3.Birthday = new DateTime(1980, 05, 23);
            w3.Position = "pracownik fizyczny";
            w3.HourlyRate = 29.0m;
            w3.FixedSalary = 0;

            Workers w4 = new Workers();
            w4.ID = 4;
            w4.FisrtAndLastName = "Zofia Plucińska";
            w4.Birthday = new DateTime(1998, 11, 02);
            w4.Position = "urzędnik";
            w4.HourlyRate = 0;
            w4.FixedSalary = 4750;

            Workers w5 = new Workers();
            w5.ID = 5;
            w5.FisrtAndLastName = "Grzegorz Braun";
            w5.Birthday = new DateTime(1960, 01, 29);
            w5.Position = "pracownik fizyczny";
            w5.HourlyRate = 48.0m;
            w5.FixedSalary = 0;
          
            Console.WriteLine("ID" + " | " + "FisrtName" + " | " + "LastName" + " | " + "Birthday" + " | " + "Position");
            Console.WriteLine(w1.ID + " | " + w1.FisrtAndLastName + " | " + w1.Birthday.ToShortDateString() + " | " + w1.Position);
            Console.WriteLine();
            Console.WriteLine(w2.ID + " | " + w2.FisrtAndLastName + " | " + w2.Birthday.ToShortDateString() + " | " + w2.Position);
            Console.WriteLine();
            Console.WriteLine(w3.ID + " | " + w3.FisrtAndLastName + " | " + w3.Birthday.ToShortDateString() + " | " + w3.Position);
            Console.WriteLine();
            Console.WriteLine(w4.ID + " | " + w4.FisrtAndLastName + " | " + w4.Birthday.ToShortDateString() + " | " + w4.Position);
            Console.WriteLine();
            Console.WriteLine(w5.ID + " | " + w5.FisrtAndLastName + " | " + w5.Birthday.ToShortDateString() + " | " + w5.Position);
            Console.WriteLine();
        }

        public void SelectWorker()
        {
            Console.WriteLine("PROSZE PODAC ID PRACOWNIKA DLA KTOREGO ZOSTANIE WYLICZONE WYNAGRODZENIE:");
            string sID = Console.ReadLine();
            int ID = int.Parse(sID);

            

            Console.WriteLine("WYLICZONE WYNAGRODZENIE PRACOWNIKA");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("DANE PRACOWNIKA");
            Console.WriteLine("IMIE I NAZWISKO: ");
            Console.WriteLine("WIEK: ");
            Console.WriteLine("STANOWISKO: ");
            //zalezy od id czy stala czy godzinowa
            Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYVH DNI PRZEZ PRACOWNIKA (MAX 20): ");
        }
    }
}
