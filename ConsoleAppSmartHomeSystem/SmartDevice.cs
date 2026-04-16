namespace ConsoleAppSmartHomeSystem;

public class SmartDevice
{
    public required string Name { get; init; }
    public int Watts { get; init; }
    public bool IsOn { get; set; }
}
         