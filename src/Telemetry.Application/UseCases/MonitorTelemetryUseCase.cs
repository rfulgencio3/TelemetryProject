using System.Reactive.Linq;
using Telemetry.Core.Domain.Entities;
using Telemetry.Core.Domain.Interfaces;

namespace Telemetry.Application.UseCases;

public class MonitorTelemetryUseCase(ITelemetryProvider telemetryProvider) : IDisposable
{
    private readonly ITelemetryProvider _telemetryProvider = telemetryProvider;
    private IDisposable? _subscription;

    /// <summary>
    /// Inicia o monitoramento dos dados da telemetria, filtrando por piloto e gera alertas (em desenvolvimento)
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void StartMonitoring()
    {
        _subscription = _telemetryProvider
            .Where(data => data.Driver == "Hamilton" || data.Driver == "Verstappen" || data.Driver == "Bortoleto" || data.Driver == "Leclerc")
            .Subscribe(OnNextTelemetry, OnError, OnCompleted);
    }

    private void OnNextTelemetry(TelemetryData telemetry)
    {
        Console.WriteLine($"[telemetry-read] " +
                        $"Id: {telemetry.Id} | {telemetry.Driver} > Speed: {telemetry.Speed} > Fuel: {telemetry.Fuel}");
        
        if ( telemetry.Fuel < 5f)
        {
            Console.WriteLine($"[ALERT]: Id: {telemetry.Id} | Fuel is minumum for {telemetry.Driver} | Fuel: {telemetry.Fuel}.");
        }
    }

    private void OnError(Exception exception)
    {
        Console.WriteLine($"[ERROR]: {exception.Message}");
    }
    private void OnCompleted()
    {
        Console.WriteLine($"[COMPLETED]: Telemetry end at {DateTime.UtcNow}");
    }

    public void Dispose()
    {
        _subscription?.Dispose();
    }
}
