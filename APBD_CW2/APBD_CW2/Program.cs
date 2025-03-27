using APBD_CW2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ContainerShip olympus = new ContainerShip("Olympus", 25, 10, 100);
            ContainerShip atlas = new ContainerShip("Atlas", 22, 15, 150);
            
            LiquidContainer milk = new LiquidContainer(250, 500, 200, 5000, false);
            LiquidContainer fuel = new LiquidContainer(250, 500, 200, 8000, true);
            GasContainer helium = new GasContainer(200, 300, 200, 2000, 10.5);
            RefrigeratedContainer bananas = new RefrigeratedContainer(220, 800, 200, 10000, "Bananas", 12);
            RefrigeratedContainer meat = new RefrigeratedContainer(220, 800, 200, 8000, "Meat", -18);
            
            Console.WriteLine("=== Container Management System Demo ===\n");
            
            Console.WriteLine("--- Loading Cargo ---");
            milk.LoadCargo(4000);
            try {
                fuel.LoadCargo(4500);
            } catch (OverfillException ex) {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            fuel.LoadCargo(3000); 
            helium.LoadCargo(1800);
            bananas.LoadCargo(9000);
            meat.LoadCargo(7000);
            
            Console.WriteLine("\n--- Loading Containers onto Ships ---");
            olympus.LoadContainer(milk);
            olympus.LoadContainer(fuel);
            olympus.LoadContainer(helium);
            
            atlas.LoadContainer(bananas);
            atlas.LoadContainer(meat);
            
            Console.WriteLine("\n--- Ship Information ---");
            olympus.PrintShipInfo();
            Console.WriteLine();
            atlas.PrintShipInfo();
            
            Console.WriteLine("\n--- Container Operations ---");
            
            olympus.RemoveContainer("KON-L-1");
            
            RefrigeratedContainer cheese = new RefrigeratedContainer(220, 800, 200, 7000, "Cheese", 6);
            cheese.LoadCargo(6000);
            atlas.ReplaceContainer("KON-C-1", cheese);
            
            olympus.TransferContainer("KON-G-1", atlas);
            
            meat.EmptyContainer();
            
            Console.WriteLine("\n--- Updated Ship Information ---");
            olympus.PrintShipInfo();
            Console.WriteLine();
            atlas.PrintShipInfo();
            
            Console.WriteLine("\n--- Testing Temperature Validation ---");
            try {
                RefrigeratedContainer iceCream = new RefrigeratedContainer(220, 800, 200, 5000, "Ice cream", -15);
                Console.WriteLine("This shouldn't be printed - temperature is too high");
            } catch (ArgumentException ex) {
                Console.WriteLine($"Validation works: {ex.Message}");
            }
            
            Console.WriteLine("\n--- Testing Overfill Protection ---");
            try {
                cheese.LoadCargo(8000);
                Console.WriteLine("This shouldn't be printed - container overfilled");
            } catch (OverfillException ex) {
                Console.WriteLine($"Overfill protection works: {ex.Message}");
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}