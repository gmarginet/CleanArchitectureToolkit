using System;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Scheduling.Abstractions;

/// <summary>
/// A declared job: a name, the service request to send and the settings.
/// </summary>
public class CatJobRegistration
{
    /// <summary>
    /// Creates a registration.
    /// </summary>
    /// <param name="name">The name of the job. It is the key in the configuration and in the claim store.</param>
    /// <param name="requestFactory">Creates the service request for a run.</param>
    /// <param name="options">The settings of the job.</param>
    public CatJobRegistration(string name, Func<ICatServiceRequest> requestFactory, CatJobOptions options)
    {
        Name = name;
        RequestFactory = requestFactory;
        Options = options;
    }

    /// <summary>
    /// The name of the job.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Creates the service request for a run. It is called once for every run.
    /// </summary>
    public Func<ICatServiceRequest> RequestFactory { get; }

    /// <summary>
    /// The settings of the job.
    /// </summary>
    public CatJobOptions Options { get; }
}
