namespace APBD_CW2;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; private set; }
    public double Temperature { get; private set; }
    private static Dictionary<string, double> productTemperatures = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public RefrigeratedContainer(double height, double weight, double depth, double maxCapacity, 
        string productType, double temperature) 
        : base(height, weight, depth, maxCapacity, "C")
    {
        if (productTemperatures.ContainsKey(productType) && temperature > productTemperatures[productType])
        {
            throw new ArgumentException($"Temperature {temperature}°C is too high for {productType} (requires {productTemperatures[productType]}°C)");
        }
        
        ProductType = productType;
        Temperature = temperature;
    }
    
    public override string GetInfo()
    {
        return $"Refrigerated Container {SerialNumber} - Load: {CurrentLoad}kg/{MaxCapacity}kg, Product: {ProductType}, Temp: {Temperature}°C";
    }
}