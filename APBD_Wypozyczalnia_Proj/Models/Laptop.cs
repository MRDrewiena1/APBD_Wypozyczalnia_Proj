namespace APBD_Wypozyczalnia_Proj.Models;

public class Laptop : Equipment
{
    public float ScreenSize { get; set; }
    public string Processor { get; set; }
    public int RamSize { get; set; }
    public int SsdSize { get; set; }
    
    public Laptop(
        string brand, string model, double feePrice,float screenSize, string processor, int ramSize, int ssdSize
    ) : base(brand, model, feePrice)
    {
        this.ScreenSize = screenSize;
        this.Processor = processor;
        this.RamSize = ramSize;
        this.SsdSize = ssdSize;
    }

    public override string ToString()
    {
        return $"Laptop: {Brand} {Model} {ScreenSize}inch RAM:{RamSize}GB SSD:{SsdSize}GB";
    }
}