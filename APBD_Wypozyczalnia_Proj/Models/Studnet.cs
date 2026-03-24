namespace APBD_Wypozyczalnia_Proj.Models;

public class Student : User
{
    public string StudentIndexNo { get; set; }
    public string Faculty { get; set; }

    public Student(int id, string name, string email, string studentId, string faculty)
        : base( name, email)
    {
        StudentIndexNo = studentId;
        Faculty = faculty;
        MaxRentals = 3;
    }
}