using System.Diagnostics;
using System.Diagnostics.Metrics;
using ServiceName.CoreService.Telemetry;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameTelemetryTests
{
    [Test]
    public void StartActivity_WithAListener_ShouldStartASpan()
    {
        using var telemetry = new ItemNameTelemetry();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == ItemNameTelemetry.Name,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData
        };
        ActivitySource.AddActivityListener(listener);

        using var activity = telemetry.StartActivity("Work");

        Assert.That(activity, Is.Not.Null);
    }

    [Test]
    public void CountCall_ShouldAddToTheCounter()
    {
        using var telemetry = new ItemNameTelemetry();
        long total = 0;
        using var listener = new MeterListener
        {
            InstrumentPublished = (instrument, meterListener) =>
            {
                if (instrument.Meter.Name == ItemNameTelemetry.Name)
                {
                    meterListener.EnableMeasurementEvents(instrument);
                }
            }
        };
        listener.SetMeasurementEventCallback<long>((_, value, _, _) => total += value);
        listener.Start();

        telemetry.CountCall("success");

        Assert.That(total, Is.EqualTo(1));
    }
}
