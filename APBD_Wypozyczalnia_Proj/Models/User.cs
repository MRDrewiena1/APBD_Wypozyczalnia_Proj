namespace APBD_Wypozyczalnia_Proj.Models;

public abstract class User
{
    private static long Idcount { get; set; }
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public int MaxRentals { get; protected set; }

    protected User( string name, string email)
    {
        Idcount ++;
        this.Id = Idcount;
        this.Name = name;
        this.Email = email;
    }
}