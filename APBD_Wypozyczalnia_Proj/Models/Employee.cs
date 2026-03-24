namespace APBD_Wypozyczalnia_Proj;

public class Employee : User
{
    public string Position { get; set; }
    public string Department { get; set; }

    public Employee(int id, string name, string email, string position, string department)
        : base( name, email)
    {
        Position = position;
        Department = department;
        MaxRentals = 5;
    }
}