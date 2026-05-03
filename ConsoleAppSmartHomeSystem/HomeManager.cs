using System.ComponentModel;

namespace ConsoleAppSmartHomeSystem;

public class HomeManager
{
    public List<SmartDevice> DeviceList = new();
    public List<SmartEvent> Events = new();
    
    public void AddDevice (SmartDevice device)
    {
        DeviceList.Add(device);
        AddNewSmartEvent($"{device.Name} has been registered. It {(device.IsOn ? "is on" : "isn't on")}");
    }
    
    
    public int CountWatts()
    {
        // Using LINQ to shorten the code
        var totalWatts = DeviceList.Where(d => d.IsOn).Sum(d => d.Watts);
        return totalWatts; 
    }
    
    public void AddNewSmartEvent(string message)
    {
        SmartEvent newEvent = new SmartEvent { Message = message };
        newEvent.Timestamp = DateTime.Now;
        Events.Add(newEvent); 
    }
}