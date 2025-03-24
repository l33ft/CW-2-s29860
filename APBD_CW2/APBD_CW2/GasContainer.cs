namespace APBD_CW2;

public class GasContainer : Container
{
    public double Pressure { get; private set; }

    public GasContainer(double height, double weight, double depth, double maxCapacity, double pressure) 
        : base(height, weight, depth, maxCapacity, "G")
    {
        Pressure = pressure;
    }

    public override void EmptyContainer()
    {
        CurrentLoad = MaxCapacity * 0.05;
    }

    public override void LoadCargo(double cargoWeight)
    {
        base.LoadCargo(cargoWeight);
        NotifyHazard($"Gas container loaded with {cargoWeight}kg at pressure {Pressure} atm", SerialNumber);
    }
    
    public override string GetInfo()
    {
        return $"Gas Container {SerialNumber} - Load: {CurrentLoad}kg/{MaxCapacity}kg, Pressure: {Pressure} atm";
    }
}