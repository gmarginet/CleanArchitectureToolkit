using System;
using Cat.Scheduling.Abstractions;
using Cronos;

namespace Cat.Scheduling;

/// <summary>
/// The due times of a job, worked out from its cron expression and time zone.
/// </summary>
internal sealed class CronSchedule
{
    private readonly CronExpression _expression;
    private readonly TimeZoneInfo _zone;

    private CronSchedule(CronExpression expression, TimeZoneInfo zone)
    {
        _expression = expression;
        _zone = zone;
    }

    /// <summary>
    /// Reads the cron expression and the time zone of a job.
    /// </summary>
    /// <param name="jobName">The name of the job, for the message of the exception.</param>
    /// <param name="options">The settings of the job.</param>
    /// <returns>The schedule.</returns>
    /// <exception cref="ArgumentException">The cron expression or the time zone is not valid.</exception>
    public static CronSchedule Create(string jobName, CatJobOptions options)
    {
        var format = options.Cron.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length == 6
            ? CronFormat.IncludeSeconds
            : CronFormat.Standard;

        CronExpression expression;
        try
        {
            expression = CronExpression.Parse(options.Cron, format);
        }
        catch (CronFormatException exception)
        {
            throw new ArgumentException($"The cron expression '{options.Cron}' of job {jobName} is not valid. {exception.Message}", exception);
        }

        TimeZoneInfo zone;
        try
        {
            zone = TimeZoneInfo.FindSystemTimeZoneById(options.TimeZoneId);
        }
        catch (Exception exception) when (exception is TimeZoneNotFoundException || exception is InvalidTimeZoneException)
        {
            throw new ArgumentException($"The time zone '{options.TimeZoneId}' of job {jobName} is not known.", exception);
        }

        return new CronSchedule(expression, zone);
    }

    /// <summary>
    /// Gets the first due time after a moment.
    /// </summary>
    /// <param name="after">The moment to look from. It is not included.</param>
    /// <returns>The next due time, or <c>null</c> when there is none.</returns>
    public DateTimeOffset? GetNext(DateTimeOffset after)
    {
        return _expression.GetNextOccurrence(after, _zone);
    }
}
