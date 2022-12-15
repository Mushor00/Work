using Zaklad;

var meesage = new Message();
var showWorker = new ShowWorkers();
var selectWorker = new ShowWorkers();
//var workersList = new WorkersList();

meesage.DisplayMainScreen();
string sWybor = Console.ReadLine();  
int wybor = int.Parse(sWybor);


if(wybor == 1)
{
    Console.Clear();
    showWorker.showWorkers();
    //workersList.ListWorkers();
    meesage.DisplayMainScreen();
}
if(wybor == 2)
{
    Console.Clear();
    selectWorker.showWorkers();

}
if(wybor == 3)
{
    Console.Clear();
    return;
}
