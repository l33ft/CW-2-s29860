namespace APBD_CW2;

public class ContainerShip
{
    public string Name { get; private set; }
    public double MaxSpeed { get; private set; }
    public int MaxContainers { get; private set; }
    public double MaxWeight { get; private set; }  // in tons
    private List<Container> containers;

    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        containers = new List<Container>();
    }

    public bool LoadContainer(Container container)
    {
        if (containers.Count >= MaxContainers)
        {
            Console.WriteLine($"Cannot load container {container.SerialNumber}: Ship at maximum container capacity");
            return false;
        }

        double currentWeight = GetTotalWeight();
        double containerWeightInTons = (container.Weight + container.CurrentLoad) / 1000; // Convert kg to tons
        
        if (currentWeight + containerWeightInTons > MaxWeight)
        {
            Console.WriteLine($"Cannot load container {container.SerialNumber}: Would exceed ship's weight limit");
            return false;
        }

        containers.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} loaded onto {Name}");
        return true;
    }

    public bool LoadContainers(List<Container> containerList)
    {
        bool allLoaded = true;
        foreach (Container container in containerList)
        {
            if (!LoadContainer(container))
            {
                allLoaded = false;
            }
        }
        return allLoaded;
    }
    
    public bool RemoveContainer(string serialNumber)
    {
        Container container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            containers.Remove(container);
            Console.WriteLine($"Container {serialNumber} removed from {Name}");
            return true;
        }
        
        Console.WriteLine($"Container {serialNumber} not found on {Name}");
        return false;
    }

    public bool ReplaceContainer(string oldSerialNumber, Container newContainer)
    {
        int index = containers.FindIndex(c => c.SerialNumber == oldSerialNumber);
        if (index != -1)
        {
            containers[index] = newContainer;
            Console.WriteLine($"Container {oldSerialNumber} replaced with {newContainer.SerialNumber} on {Name}");
            return true;
        }
        
        Console.WriteLine($"Container {oldSerialNumber} not found on {Name}");
        return false;
    }

    public bool TransferContainer(string serialNumber, ContainerShip destinationShip)
    {
        Container container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            if (destinationShip.LoadContainer(container))
            {
                containers.Remove(container);
                Console.WriteLine($"Container {serialNumber} transferred from {Name} to {destinationShip.Name}");
                return true;
            }
            return false;
        }
        
        Console.WriteLine($"Container {serialNumber} not found on {Name}");
        return false;
    }

    public void PrintContainerInfo(string serialNumber)
    {
        Container container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Console.WriteLine(container.GetInfo());
        }
        else
        {
            Console.WriteLine($"Container {serialNumber} not found on {Name}");
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"--- Ship: {Name} ---");
        Console.WriteLine($"Max Speed: {MaxSpeed} knots");
        Console.WriteLine($"Container Capacity: {containers.Count}/{MaxContainers}");
        Console.WriteLine($"Weight: {GetTotalWeight():F2}/{MaxWeight} tons");
        Console.WriteLine("Containers:");
        
        if (containers.Count == 0)
        {
            Console.WriteLine("  No containers on board");
        }
        else
        {
            foreach (Container container in containers)
            {
                Console.WriteLine($"  - {container.GetInfo()}");
            }
        }
    }

    private double GetTotalWeight()
    {
        double totalWeight = 0;
        foreach (Container container in containers)
        {
            totalWeight += (container.Weight + container.CurrentLoad) / 1000;
        }
        return totalWeight;
    }
}