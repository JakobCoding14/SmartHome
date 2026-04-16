namespace ConsoleAppSmartHomeSystem;

public class HomeManager
{
    public List<SmartDevice> DeviceList = new();
    public List<SmartEvent> Events = new();
    
    public void AddDevice (SmartDevice device)
    {
        DeviceList.Add(device);
        SmartEvent newEvent = new SmartEvent { Message = $"{device.Name} has been registered. It {(device.IsOn ? "is on" : "isn't on")}"};
        newEvent.Timestamp = DateTime.Now;
        Events.Add(newEvent);
    }
    
    public int CountWatts()
    {
        var totalWatts = DeviceList.Where(d => d.IsOn).Sum(d => d.Watts);
        int test = 0;
        return totalWatts;
        
    }
}