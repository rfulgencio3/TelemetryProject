using System.Reactive.Subjects;
using Telemetry.Core.Domain.Entities;
using Telemetry.Core.Domain.Interfaces;

namespace Telemetry.Infrastructure.Providers;

public class TelemetryProvider : ITelemetryProvider
{
    private readonly Subject<TelemetryData> _subject = new Subject<TelemetryData>();
    public void Complete()
    {
        _subject.OnCompleted();
    }

    public void Error(Exception exception)
    {
        _subject.OnError(exception);
    }

    public void PublishTelemetry(TelemetryData eventData)
    {
        _subject.OnNext(eventData);
    }

    public IDisposable Subscribe(IObserver<TelemetryData> observer)
    {
        return _subject.Subscribe(observer);
    }
}
