namespace APBD_Wypozyczalnia_Proj.Models;

public abstract class Equipment
{
    private static long Idcount { get; set; }
    public long Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double FeePrice { get; set; }
    public bool Avalible { get; set; }

    public Equipment(string brand, string model, double feePrice)
    {
        this.Brand = brand;
        this.Model = model;
        this.FeePrice = feePrice;
        Idcount++;
        this.Id = Idcount;
        this.Avalible = true;
    }

    public string GetStatus()
    {
        return Avalible ? "Avalible" : "Unavalible";
    }
    
}