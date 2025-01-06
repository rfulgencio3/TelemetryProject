namespace Telemetry.Core.Domain.Entities;

public class Base
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
}
