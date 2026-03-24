using APBD_Wypozyczalnia_Proj.Models;

namespace APBD_Wypozyczalnia_Proj.Services;

public class RentalService
{
    private List<Rental> _rentals = new();
    
    public Rental RentEquipment(User user, Equipment equipment, int days)
    {
        if (!equipment.Avalible)
            throw new Exception("Equipment not available");

        int activeRentals = _rentals.Count(r => r.User == user && !r.IsReturned);
        if (activeRentals >= user.MaxRentals)
            throw new Exception("User reached rental limit!!!");

        var rental = new Rental(user, equipment, days);
        _rentals.Add(rental);

        equipment.Avalible = false;
        return rental;
    }

    public void ReturnEquipment(long rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);
        if (rental == null || rental.IsReturned)
            throw new Exception("Invalid rental");

        rental.ReturnDate = DateTime.Now;
        rental.Equipment.Avalible = true;
    }

    public double CalculatePenalty(Rental rental)
    {
        int delayDays = rental.GetDelayDays();
        return delayDays * rental.Equipment.FeePrice;
    }

    public List<Rental> GetActiveRentals()
    {
        return _rentals.Where(r => !r.IsReturned).ToList();
    }

    public List<Rental> GetUserRentals(User user)
    {
        return _rentals.Where(r => r.User == user).ToList();
    }
}