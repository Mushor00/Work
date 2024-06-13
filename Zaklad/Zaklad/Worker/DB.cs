using System.Security.Cryptography.X509Certificates;
using static Zaklad.Worker.Work;

namespace Zaklad.Worker.DB;
public class Db
{
    public List<Workers> workers = new()
    {
        new Workers
        {
            ID = 1,
            FirstName = "Jan",
            LastName = "Nowak",
            Birthday = new DateTime(2002, 03, 04),
            Position = "pracownik fizyczny",
            HourlyRate = 18.5m,
            FixedSalary = 0m
        },
        new Workers
        {
            ID = 2,
            FirstName = "Agnieszka",
            LastName = "Kowalska",
            Birthday = new DateTime(1973, 12, 14),
            Position = "urzędnik",
            HourlyRate = 0m,
            FixedSalary = 2800m
        },
        new Workers
        {
            ID = 3,
            FirstName = "Robert",
            LastName = "Lewandowski",
            Birthday = new DateTime(1980, 05, 23),
            Position = "pracownik fizyczny",
            HourlyRate = 29.0m,
            FixedSalary = 0m
        },
        new Workers
        {
            ID = 4,
            FirstName = "Zofia",
            LastName = "Plucińska",
            Birthday = new DateTime(1998, 11, 02),
            Position = "urzędnik",
            HourlyRate = 0m,
            FixedSalary = 4750m
        },
        new Workers
        {
            ID = 5,
            FirstName = "Grzegorz",
            LastName = "Braun",
            Birthday = new DateTime(1960, 01, 29),
            Position = "pracownik fizyczny",
            HourlyRate = 48.0m,
            FixedSalary = 0m
        }
    };


    public List<Workers> GetWorkers() => workers;
    public void UpdateWorker(Work.Workers updatedWorker)
    {
        var existingWorker = workers.FirstOrDefault(worker => worker.ID == updatedWorker.ID);
        if (existingWorker != null)
        {
            existingWorker.FirstName = updatedWorker.FirstName;
            existingWorker.LastName = updatedWorker.LastName;
            existingWorker.Birthday = updatedWorker.Birthday;
            existingWorker.Position = updatedWorker.Position;
            existingWorker.HourlyRate = updatedWorker.HourlyRate;
            existingWorker.FixedSalary = updatedWorker.FixedSalary;
        }
    }

    public Workers GetWorkerById(int id) => workers.First(x => x.ID == id);
}
