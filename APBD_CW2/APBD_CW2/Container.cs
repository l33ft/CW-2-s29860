namespace APBD_CW2;

public abstract class Container : IHazardNotifier
{
    private static Dictionary<string, int> serials = new Dictionary<string, int>
    {
        { "L", 1 },
        { "G", 1 },
        { "C", 1 }
    };

    public string SerialNumber { get; protected set; }
    public double Height { get; protected set; }
    public double Weight { get; protected set; }
    public double Depth { get; protected set; }
    public double MaxCapacity { get; protected set; }
    public double CurrentLoad { get; protected set; }

    protected Container(double height, double weight, double depth, double maxCapacity, string type)
    {
        Height = height;
        Weight = weight;
        Depth = depth;
        MaxCapacity = maxCapacity;
        CurrentLoad = 0;
        int serialIndex = serials[type];
        SerialNumber = $"KON-{type}-{serialIndex}";
        serials[type]++;
    }

    public virtual void EmptyContainer()
    {
        CurrentLoad = 0;
    }

    public virtual void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaxCapacity)
        {
            throw new OverfillException($"Attempted to load {cargoWeight}kg into container with max capacity of {MaxCapacity}kg");
        }
        
        CurrentLoad = cargoWeight;
    }

    public void NotifyHazard(string message, string serialNumber)
    {
        Console.WriteLine($"HAZARD ALERT for {serialNumber}: {message}");
    }
    
    public abstract string GetInfo();
}
