using APBD_Wypozyczalnia_Proj.Services;
using APBD_Wypozyczalnia_Proj.Models;

namespace APBD_Wypozyczalnia_Proj.Test;

public class RunDemo
{
    public static void Run()
    {
        var equipmentService = new EquipmentService();
        var rentalService = new RentalService();

        var users = new List<User>();

        Console.WriteLine("=== DEMO START ===");

        // 11. Dodanie Sprzętu
        var cam = new Camera("Canon", "R5", 50, "4K", "FullFrame", 60);
        var lap = new Laptop("Dell", "XPS", 80, 15.6f, "i7", 16, 512);
        var mic = new Microphone("Blue", "Yeti", 30, "USB", 25, "Cardioid");

        equipmentService.AddEquipment(cam);
        equipmentService.AddEquipment(lap);
        equipmentService.AddEquipment(mic);

        Console.WriteLine("Added equipment.");

        // 12. Dodanie Użytkowników
        var student = new Student("Konrad", "s33534@mail.com", "s33534", "IT");
        var employee = new Employee("Tomasz", "tomasz@mail.com", "Head Of IT Admin", "Administration of IT");

        users.Add(student);
        users.Add(employee);

        Console.WriteLine("Added users.");

        // 13. Poprawne wypożyczenie
        var r1 = rentalService.RentEquipment(student, cam, 2);
        Console.WriteLine("Equipment rented correctly.");

        // 14. Niepoprawna operacja (ten sam sprzęt)
        try
        {
            rentalService.RentEquipment(employee, cam, 2);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Expected error: {e.Message}");
        }

        // 15. Zwrot w terminie
        rentalService.ReturnEquipment(r1.Id);

        Console.WriteLine("Returned on time.");

        // 16. Zwrot opóźniony
        var r2 = rentalService.RentEquipment(employee, lap, 1);
        
        rentalService.ReturnEquipment(r2.Id);

        r2.ReturnDate = r2.DueDate.AddDays(2);

        double penalty = rentalService.CalculatePenalty(r2);

        Console.WriteLine($"Late return fee: {penalty}");

        // 17. Raport
        Console.WriteLine("\n=== FINAL REPORT ===");
        var all = equipmentService.GetAll();
        var available = equipmentService.GetAvailable();
        var active = rentalService.GetActiveRentals();

        Console.WriteLine($"Total equipment: {all.Count}");
        Console.WriteLine($"Available: {available.Count}");
        Console.WriteLine($"Rented: {active.Count}");

        Console.WriteLine("=== DEMO END ===");
    }
}