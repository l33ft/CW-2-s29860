namespace APBD_CW2;

public class LiquidContainer : Container
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double height, double weight, double depth, double maxCapacity, bool isHazardous) 
        : base(height, weight, depth, maxCapacity, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double cargoWeight)
    {
        double maxAllowedLoad = IsHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;
        
        if (cargoWeight > maxAllowedLoad)
        {
            NotifyHazard($"Attempted to load {cargoWeight}kg exceeding allowed limit of {maxAllowedLoad}kg", SerialNumber);
            throw new OverfillException($"Cannot load {cargoWeight}kg. Maximum allowed: {maxAllowedLoad}kg");
        }
        
        base.LoadCargo(cargoWeight);
    }
    
    public override string GetInfo()
    {
        return $"Liquid Container {SerialNumber} - Load: {CurrentLoad}kg/{MaxCapacity}kg, Hazardous: {IsHazardous}";
    }
}