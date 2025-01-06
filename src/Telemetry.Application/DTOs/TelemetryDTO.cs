using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry.Application.DTOs;

public class TelemetryDTO
{
    public required string Driver { get; set; }
    public float Speed { get; set; }
    public float Fuel { get; set; }
    public DateTime Timestamp { get; set; }
}
