using LamodaB2BSDK.Primitives.Interfaces;

namespace LamodaB2BSDK.Primitives.Models;

public abstract class Service
{
    protected string ServiceBaseUrl { get; private set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="Service"/> class with a
    /// custom <see cref="IClient"/>.
    /// </summary>
    /// <param name="client">the client used by the service to send requests.</param>
    protected Service(IClient client)
    {
        Client = client;
    }

    /// <summary>
    /// Client base url
    /// </summary>
    public virtual string BaseUrl => Client.ApiBase;

    /// <summary>
    /// Gets or sets the client used by this service to send requests. If no client was set when the
    /// service instance was created, then the default client in
    /// <see cref="Client"/> is used instead.
    /// </summary>
    /// <remarks>
    /// Setting the client at runtime may not be thread-safe.
    /// If you wish to use a custom client, it is recommended that you pass it to the service's constructor and not change it during the service's lifetime.
    /// </remarks>
    public IClient Client { get; set; }
}