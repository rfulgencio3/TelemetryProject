using Telemetry.Core.Domain.Entities;

namespace Telemetry.Core.Domain.Interfaces;

public interface ITelemetryProvider : IObservable<TelemetryData>
{
    void PublishTelemetry(TelemetryData eventData);
    void Complete();
    void Error(Exception exception);
}
