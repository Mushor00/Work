﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaklad
{
    public class Workers
    {
        public int ID { get; set; }
        public string FisrtAndLastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
        public decimal HourlyRate { get; set; }
        public int FixedSalary { get; set; }

    }

    public class WorkersList
    {
        public void ListWorkers()
        {
            List<Workers> workers = new List<Workers>();

            workers.Add(new Workers() { ID = 1, FisrtAndLastName = "Jan Kowalski", Birthday = new DateTime(2002, 03, 04), Position = "pracownik fizyczny", HourlyRate = 18.5m, FixedSalary = 0});
            workers.Add(new Workers() { ID = 2, FisrtAndLastName = "Agnieszka Kowalska", Birthday = new DateTime(1973, 12, 14), Position = "urzędnik", HourlyRate = 0, FixedSalary = 2800 });
            workers.Add(new Workers() { ID = 3, FisrtAndLastName = "Robert Lewandowski", Birthday = new DateTime(1980, 05, 23), Position = "pracownik fizyczny", HourlyRate = 29.0m, FixedSalary = 0 });
            workers.Add(new Workers() { ID = 4, FisrtAndLastName = "Zofia Plucińska", Birthday = new DateTime(1998, 11, 02), Position = "urzędnik", HourlyRate =0, FixedSalary = 4750 });
            workers.Add(new Workers() { ID = 5, FisrtAndLastName = "Grzegorz Braun", Birthday = new DateTime(1960, 01, 29), Position = "pracownik fizyczny", HourlyRate = 49.0m, FixedSalary = 0 });

            Console.WriteLine();
            foreach(Workers aWorkers in workers)
            {
                Console.WriteLine(aWorkers);
            }
        }
    }

}