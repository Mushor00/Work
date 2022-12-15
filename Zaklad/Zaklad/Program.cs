using Zaklad;

var meesage = new Message();
var showWorker = new WorkersList();
var selectWorker = new ShowWorkers();
//var workersList = new WorkersList();

meesage.DisplayMainScreen();
/*
string sWybor = Console.ReadLine();  
int wybor = int.Parse(sWybor);
*/
while (true)
{
    string sWybor = Console.ReadLine();
    int wybor = int.Parse(sWybor);
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
        selectWorker.SelectWorker();
        break;
    }
    if (wybor == 3)
    {
        Console.Clear();
        break;
    }
}
