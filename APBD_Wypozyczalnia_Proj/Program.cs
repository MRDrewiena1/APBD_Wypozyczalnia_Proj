using APBD_Wypozyczalnia_Proj.CLI;
using APBD_Wypozyczalnia_Proj.Test;

namespace APBD_Wypozyczalnia_Proj;

class Program
{
    static void Main(string[] args)
    {
        RunDemo.Run();

        var ui = new ConsoleUi();
        ui.Run();
    }
    
}