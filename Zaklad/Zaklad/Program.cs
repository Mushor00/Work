using System.Collections.Generic;
using Zaklad;

var meesage = new Message();
var showWorker = new WorkersList();
//var workersList = new WorkersList();
meesage.DisplayMainScreen();

//showWorker.ListWorkers();

/*
string sWybor = Console.ReadLine();  
int wybor = int.Parse(sWybor);
*/
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
        showWorker.SelectWorker( );
        break;
    }
    if (wybor == 3)
    {
        Console.Clear();
        break;
    }
}
