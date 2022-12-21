using System.Collections.Generic;
using Zaklad;
using Zaklad.Worker;

var meesage = new Message();
var showWorker = new Work();
meesage.DisplayMainScreen();


while (true)
{
   
    var wybor = meesage.Show();
    if (wybor == 1)
    {
        Console.Clear();
        showWorker.ListWorkers();
        //workersList.ListWorkers();
        meesage.DisplayMainScreen();
        
    }
    if (wybor == 2)
    {
        Console.Clear();
        showWorker.SelectWorker();
        break;
    }
    if (wybor == 3)
    {
        Console.Clear();
        break;
    }
}
