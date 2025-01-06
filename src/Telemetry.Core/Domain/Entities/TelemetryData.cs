namespace Telemetry.Core.Domain.Entities;

public class TelemetryData : Base
{
    public required string Driver { get; set; }
    public float Speed { get; set; }
    public float Fuel { get; set; }
    public DateTime Timestamp { get; set; }
}
