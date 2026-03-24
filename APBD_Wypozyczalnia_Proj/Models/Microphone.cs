namespace APBD_Wypozyczalnia_Proj.Models;

public class Microphone: Equipment
{
    public string Connectivity { get; set; }
    public int MembraneSize { get; set; }
    public string PickupPattern { get; set; }
    public Microphone(
        string brand, string model, double feePrice, string connectivity, int membraneSize,string pickupPattern
        ) : base(brand, model, feePrice)
    {
        Connectivity = connectivity;
        MembraneSize = membraneSize;
        PickupPattern = pickupPattern;
    }

    public override string ToString()
    {
        return $"Mikrofon: {Brand} {Model} {Connectivity} {MembraneSize}mm {PickupPattern}";
    }
}