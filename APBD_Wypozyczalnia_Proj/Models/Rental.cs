namespace APBD_Wypozyczalnia_Proj.Models;

public class Rental
{
    private static long Idcount { get; set; }
    public long Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }

    public DateTime RentalDate { get; set; }
    public int Days { get; set; }
    public DateTime DueDate => RentalDate.AddDays(Days);

    public DateTime? ReturnDate { get; set; }

    public Rental( User user, Equipment equipment, int days)
    {
        Idcount++;
        this.Id = Idcount;
        this.User = user;
        this.Equipment = equipment;
        this.Days = days;
        this.RentalDate = DateTime.Now;
    }

    public bool IsReturned => ReturnDate != null;

    public int GetDelayDays()
    {
        if (ReturnDate == null) return 0;

        int delay = (ReturnDate.Value - DueDate).Days;
        return delay > 0 ? delay : 0;
    }

}