using Telemetry.Application.UseCases;
using Telemetry.Core.Domain.Entities;
using Telemetry.Infrastructure.Providers;

namespace Telemetry.Presentation.ConsoleApp;

public class Program
{
    public static void Main()
    {
        //Infrastructure -> Implementação concrta do Provider
        var provider = new TelemetryProvider();

        //Application -> DI do provider no UseCase
        using var monitorUseCase = new MonitorTelemetryUseCase(provider);

        //Inicialização do monitoriramento das telemetrias
        monitorUseCase.StartMonitoring();

        //Inserção de dados hardcoded para simular telemetrias
        provider.PublishTelemetry(new TelemetryData { Driver = "Verstappen", Speed = 290.4F, Fuel = 6.9F, Timestamp = new DateTime(2023, 07, 01, 13, 0, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Verstappen", Speed = 299.2F, Fuel = 4.2F, Timestamp = new DateTime(2023, 07, 01, 13, 1, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Hamilton", Speed = 301.1F, Fuel = 5.3F, Timestamp = new DateTime(2023, 07, 01, 13, 2, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Alonso", Speed = 290.1F, Fuel = 6.3F, Timestamp = new DateTime(2023, 07, 01, 13, 3, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Bortoleto", Speed = 293.4F, Fuel = 5.1F, Timestamp = new DateTime(2023, 07, 01, 13, 4, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Sainz", Speed = 292.7F, Fuel = 5.8F, Timestamp = new DateTime(2023, 07, 01, 13, 5, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Leclerc", Speed = 295.3F, Fuel = 6.0F, Timestamp = new DateTime(2023, 07, 01, 13, 6, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Russell", Speed = 289.9F, Fuel = 6.2F, Timestamp = new DateTime(2023, 07, 01, 13, 7, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Bortoleto", Speed = 297.0F, Fuel = 5.1F, Timestamp = new DateTime(2023, 07, 01, 13, 8, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Norris", Speed = 294.5F, Fuel = 5.6F, Timestamp = new DateTime(2023, 07, 01, 13, 9, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Piastri", Speed = 291.2F, Fuel = 5.5F, Timestamp = new DateTime(2023, 07, 01, 13, 10, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Verstappen", Speed = 302.1F, Fuel = 4.6F, Timestamp = new DateTime(2023, 07, 01, 13, 11, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Hamilton", Speed = 298.7F, Fuel = 6.2F, Timestamp = new DateTime(2023, 07, 01, 13, 12, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Alonso", Speed = 289.9F, Fuel = 5.9F, Timestamp = new DateTime(2023, 07, 01, 13, 13, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Bortoleto", Speed = 291.1F, Fuel = 6.1F, Timestamp = new DateTime(2023, 07, 01, 13, 14, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Sainz", Speed = 296.8F, Fuel = 4.7F, Timestamp = new DateTime(2023, 07, 01, 13, 15, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Leclerc", Speed = 300.2F, Fuel = 5.0F, Timestamp = new DateTime(2023, 07, 01, 13, 16, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Hamilton", Speed = 288.9F, Fuel = 6.4F, Timestamp = new DateTime(2023, 07, 01, 13, 17, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Hulkenberg", Speed = 294.1F, Fuel = 4.3F, Timestamp = new DateTime(2023, 07, 01, 13, 18, 0, DateTimeKind.Utc) });
        provider.PublishTelemetry(new TelemetryData { Driver = "Norris", Speed = 297.6F, Fuel = 5.4F, Timestamp = new DateTime(2023, 07, 01, 13, 19, 0, DateTimeKind.Utc) });

        provider.Complete();

        Console.WriteLine("Press any key to finalize...");
        Console.ReadKey();
    }
}