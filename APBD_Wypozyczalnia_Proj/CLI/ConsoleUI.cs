
using APBD_Wypozyczalnia_Proj.Models;
using APBD_Wypozyczalnia_Proj.Services;

namespace APBD_Wypozyczalnia_Proj.CLI;

class ConsoleUi
{
    static EquipmentService _equipmentService = new();
    static RentalService _rentalService = new();

    static List<User> _users = new();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Add equipment");
            Console.WriteLine("3. Show all equipment");
            Console.WriteLine("4. Show available equipment");
            Console.WriteLine("5. Rent equipment");
            Console.WriteLine("6. Return equipment");
            Console.WriteLine("7. Mark equipment unavailable");
            Console.WriteLine("8. Show user rentals");
            Console.WriteLine("9. Show overdue rentals");
            Console.WriteLine("10. Report");
            Console.WriteLine("0. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddUser(); break;
                case "2": AddEquipment(); break;
                case "3": ShowAllEquipment(); break;
                case "4": ShowAvailable(); break;
                case "5": Rent(); break;
                case "6": Return(); break;
                case "7": MarkUnavailable(); break;
                case "8": ShowUserRentals(); break;
                case "9": ShowOverdue(); break;
                case "10": Report(); break;
                case "0": return;
            }
        }
    }

    static void AddUser()
    {
        Console.WriteLine("1. Student  2. Employee");
        var type = Console.ReadLine();

        var name = ReadString("Name: ");

        var email = ReadString("Email: ");

        if (type == "1")
        {
            var sid = ReadString("StudentId: ");
            
            var fac = ReadString("Faculty: ");

            _users.Add(new Student( name, email, sid, fac));
        }
        else
        {
            var pos = ReadString("Position: ");
            
            var dep = ReadString("Department: ");

            _users.Add(new Employee(name, email, pos, dep));
        }
    }

    static void AddEquipment()
    {
        Console.WriteLine("1. Camera  2. Laptop  3. Microphone");
        var type = ReadInt("Type: ");

        var brand = ReadString("Brand: ");

        var model = ReadString("Model: ");

        var price = ReadDouble("Fee price: ");

        Equipment? eq = type switch
        {
            1 => CreateCamera(brand, model, price),
            2 => CreateLaptop(brand, model, price),
            3 => CreateMicrophone(brand, model, price),
            _ => null
        };

        if (eq != null)
            _equipmentService.AddEquipment(eq);
    }

    static void ShowAllEquipment()
    {
        foreach (var e in _equipmentService.GetAll())
            Console.WriteLine($"{e.Id} | {e.Brand} {e.Model} | {e.GetStatus()}");
    }

    static void ShowAvailable()
    {
        foreach (var e in _equipmentService.GetAvailable())
            Console.WriteLine($"{e.Id} | {e.Brand} {e.Model}");
    }

    static void Rent()
    {
        int uid = ReadInt("User ID: ");
        
        long eid = ReadLong("Equipment ID: ");
        
        int days = ReadInt("Days: ");

        var user = _users.FirstOrDefault(u => u.Id == uid);
        var eq = _equipmentService.GetById(eid);

        if (user != null && eq != null)
        {
            try
            {
                _rentalService.RentEquipment(user, eq, days);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    static void Return()
    {
        int rid = ReadInt("Rental ID: ");

        try
        {
            var rental = _rentalService.GetActiveRentals()
                .FirstOrDefault(r => r.Id == rid);

            if (rental != null)
            {
                _rentalService.ReturnEquipment(rid);
                double penalty = _rentalService.CalculatePenalty(rental);

                Console.WriteLine($"Penalty: {penalty}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void MarkUnavailable()
    {
        long id = ReadLong("Equipment ID: ");

        var eq = _equipmentService.GetById(id);
        if (eq != null)
            eq.Avalible = false;
    }

    static void ShowUserRentals()
    {
        int uid = ReadInt("User ID: ");

        var user = _users.FirstOrDefault(u => u.Id == uid);

        if (user != null)
        {
            var rentals = _rentalService.GetUserRentals(user);
            foreach (var r in rentals.Where(r => !r.IsReturned))
            {
                Console.WriteLine($"{r.Id} | {r.Equipment.Brand} {r.Equipment.Model}");
            }
        }
    }

    static void ShowOverdue()
    {
        var overdue = _rentalService.GetActiveRentals()
            .Where(r => DateTime.Now > r.DueDate);

        foreach (var r in overdue)
        {
            Console.WriteLine($"{r.Id} | {r.User.Name} | {r.Equipment.Model}");
        }
    }

    static void Report()
    {
        var all = _equipmentService.GetAll();
        var available = _equipmentService.GetAvailable();
        var active = _rentalService.GetActiveRentals();

        Console.WriteLine($"Total equipment: {all.Count}");
        Console.WriteLine($"Available: {available.Count}");
        Console.WriteLine($"Rented: {active.Count}");
    }
    
    private static Camera CreateCamera(string brand, string model, double price)
    {
        string resolution = ReadString("Resolution: ");

        string sensor = ReadString("Sensor size: ");

        int fps = ReadInt("Framerate: ");

        return new Camera(brand, model, price, resolution, sensor, fps);
    }
    
    private static Laptop CreateLaptop(string brand, string model, double price)
    {
        float screen = ReadFloat("Screen size: ");

        string cpu = ReadString("Processor: ");

        int ram = ReadInt("RAM (GB): ");

        int ssd = ReadInt("SSD (GB): ");

        return new Laptop(brand, model, price, screen, cpu, ram, ssd);
    }
    
    private static Microphone CreateMicrophone(string brand, string model, double price)
    {
        string conn = ReadString("Connectivity: ");

        int size = ReadInt("Membrane size (mm): ");

        string pattern = ReadString("Pickup pattern: ");

        return new Microphone(brand, model, price, conn, size, pattern);
    }
    
    private static string ReadString(string label)
    {
        while (true)
        {
            Console.Write(label);
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Invalid input.");
        }
    }
    
    private static int ReadInt(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;

            Console.WriteLine("Invalid number.");
        }
    }
    
    private static float ReadFloat(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (float.TryParse(Console.ReadLine(), out float value))
                return value;

            Console.WriteLine("Invalid number.");
        }
    }
    
    private static double ReadDouble(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (double.TryParse(Console.ReadLine(), out double value))
                return value;

            Console.WriteLine("Invalid number.");
        }
    }
    
    private static long ReadLong(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (long.TryParse(Console.ReadLine(), out long value))
                return value;

            Console.WriteLine("Invalid number.");
        }
    }
}

