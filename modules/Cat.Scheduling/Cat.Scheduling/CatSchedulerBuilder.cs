using System;
using System.Collections.Generic;
using Cat.Scheduling.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Scheduling;

/// <summary>
/// Declares the jobs of a service. You get one from <c>AddCatScheduling</c>.
/// </summary>
public sealed class CatSchedulerBuilder
{
    private readonly List<CatJobRegistration> _registrations = new List<CatJobRegistration>();

    /// <summary>
    /// The default name of the system user a job runs as.
    /// </summary>
    public const string DefaultSystemUserName = "scheduler";

    internal IReadOnlyList<CatJobRegistration> Registrations => _registrations;

    internal string SystemUserName { get; private set; } = DefaultSystemUserName;

    /// <summary>
    /// Sets the name of the system user every job runs as, so <c>ICatUser</c> always has a value.
    /// Use the name of the service, such as <c>orders</c>. The default is <see cref="DefaultSystemUserName"/>.
    /// </summary>
    /// <param name="systemUserName">The name of the system user.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public CatSchedulerBuilder RunAs(string systemUserName)
    {
        if (string.IsNullOrWhiteSpace(systemUserName))
        {
            throw new ArgumentException("The name of the system user cannot be empty.", nameof(systemUserName));
        }

        SystemUserName = systemUserName;
        return this;
    }

    /// <summary>
    /// Declares a job that sends a service request with a parameterless constructor, such as one without data.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Every run creates a new one.</typeparam>
    /// <param name="name">The name of the job. It must be unique. It is the key in the configuration and in the claim store.</param>
    /// <param name="cron">The cron expression, see <see cref="CatJobOptions.Cron"/>.</param>
    /// <param name="configure">Changes the other settings of the job.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public CatSchedulerBuilder Job<TRequest>(string name, string cron, Action<CatJobOptions>? configure = null)
        where TRequest : ICatServiceRequest, new()
    {
        return Job(name, cron, () => new TRequest(), configure);
    }

    /// <summary>
    /// Declares a job that sends a service request built by a factory, for a request with data.
    /// </summary>
    /// <param name="name">The name of the job. It must be unique. It is the key in the configuration and in the claim store.</param>
    /// <param name="cron">The cron expression, see <see cref="CatJobOptions.Cron"/>.</param>
    /// <param name="requestFactory">Creates the service request. It is called once for every run.</param>
    /// <param name="configure">Changes the other settings of the job.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public CatSchedulerBuilder Job(string name, string cron, Func<ICatServiceRequest> requestFactory,
        Action<CatJobOptions>? configure = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("The name of a job cannot be empty.", nameof(name));
        }

        if (requestFactory == null)
        {
            throw new ArgumentNullException(nameof(requestFactory));
        }

        if (_registrations.Exists(job => string.Equals(job.Name, name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException($"A job named {name} is already declared.", nameof(name));
        }

        var options = new CatJobOptions { Cron = cron };
        configure?.Invoke(options);
        _registrations.Add(new CatJobRegistration(name, requestFactory, options));
        return this;
    }
}
