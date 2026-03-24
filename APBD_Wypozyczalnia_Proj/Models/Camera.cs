namespace APBD_Wypozyczalnia_Proj.Models;

public class Camera : Equipment
{
    public string Resolution { get; set; }
    public string SensorSize { get; set; }
    public int Framerate { get; set; }
    
    public Camera(
        string brand, string model, double feePrice, string resolution,string sensorSize, int framerate
    ) : base(brand, model, feePrice)
    {
        this.Resolution = resolution;
        this.SensorSize = sensorSize;
        this.Framerate = framerate;
    }

    public override string ToString()
    {
        return $"Kamera: {Brand} {Model} {Resolution} {SensorSize}\" {Framerate}fps";
    }
}