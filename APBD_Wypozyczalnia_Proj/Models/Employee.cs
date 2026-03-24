namespace APBD_Wypozyczalnia_Proj.Models;

public class Employee : User
{
    public string Position { get; set; }
    public string Department { get; set; }

    public Employee(string name, string email, string position, string department)
        : base( name, email)
    {
        Position = position;
        Department = department;
        MaxRentals = 5;
    }
}