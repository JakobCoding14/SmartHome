namespace ConsoleAppSmartHomeSystem;

class Program
{
    private static readonly HomeManager MyManager = new();

    static async Task Main()
    {
        NewInstances(); 
        _ = ClearListTimer();
        
        while (true)
        {
            PrintSystemStats();
            await Task.Delay(2000);
        }
    }    

    static void NewInstances()
    {
        var oledTv = new SmartDevice { Name = "Tv", Watts = 70, IsOn = true };
        var smartToaster = new SmartDevice { Name = "SmartToaster", Watts = 800, IsOn = true };
        var raspberryPi = new SmartDevice { Name = "RaspberryPi", Watts = 15, IsOn = false };

        MyManager.AddDevice(oledTv);
        MyManager.AddDevice(smartToaster);
        MyManager.AddDevice(raspberryPi);
    }

    static void PrintSystemStats()
    {
        // Clearing the Console (old values)
        Console.Clear();

        // Storing and initializing the store-variables
        int totalDevices = MyManager.DeviceList.Count;
        int activeDevices = MyManager.DeviceList.Count(d => d.IsOn);
        int totalWattUsage = MyManager.CountWatts();
        
        // Output
        Console.WriteLine("\n");
        Console.WriteLine("---------------System Stats---------------"); 
        Console.WriteLine($"Total devices: {totalDevices}");
        Console.WriteLine($"Active devices: {activeDevices}");
        Console.WriteLine($"Total watt usage: {totalWattUsage}");
        Console.WriteLine("\n");

        // Output Events
        PrintEvents();
    }

    static void PrintEvents()
    {
        Console.WriteLine("---------------System Events---------------");
        
        foreach (SmartEvent ev in MyManager.Events)
        {
            Console.WriteLine("Event: " + ev.Message);
        }
    }

    static async Task ClearListTimer()
    {
        while (true) 
        {
            MyManager.Events.RemoveAll(e => (DateTime.Now - e.Timestamp).TotalSeconds > 60);

            if (MyManager.Events.Count == 0)
            {
                SmartEvent noEventsEvent = new SmartEvent{ Message = "No relevant events lately"};
                noEventsEvent.Timestamp = DateTime.Now; 
                MyManager.Events.Add(noEventsEvent);
            }
            
            await Task.Delay(60000); 
        }
    }
    
    public async Task SetDeviceOnOff()
    {
        // Output new random variable true false
        bool changeIsOn = Random.Shared.Next(2) == 0;
        

    }
}