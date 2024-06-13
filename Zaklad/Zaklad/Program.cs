using Zaklad.Message;
using Zaklad.Worker;

var meesage = new Message();
var showWorker = new Work();


a:
meesage.DisplayMainScreen();
while (true)
{
    var wybor = meesage.Show();

    if (wybor == 1)
    {
        Console.Clear();
        showWorker.ListWorkers();
        Console.Clear();
        goto a;
    }
    if (wybor == 2)
    {
        Console.Clear();
        showWorker.SelectWorker();
        Console.Clear();
        goto a;
    }
    if (wybor == 3)
    {
        Console.Clear();
        meesage.AddWork();
        var zmiana = meesage.Show2();

        if (zmiana == 1)
        {
            showWorker.AddWorker();
            Console.Clear();
            goto a;
        }
        if (zmiana == 2)
        {
            showWorker.DeleteWorker();
            Console.Clear();
            goto a;
        }
        if (zmiana == 3)
        {
            showWorker.ModifyWorker();
            Console.Clear();
            goto a;
        }

    }
    else
    {
        Console.Clear();
        break;
    }
}
