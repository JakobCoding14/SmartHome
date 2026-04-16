namespace ConsoleAppSmartHomeSystem;

public class SmartEvent
{
    public required string Message { get; set; } = null!;
    public DateTime Timestamp { get; set; } = DateTime.Now;   
}