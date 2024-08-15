namespace LamodaB2BSDK.Core.Models;

public abstract class Service : IDisposable
{
    protected readonly LamodaHttpAdapter HttpAdapter;
    protected readonly string ServiceEndPoint;

    /// <summary>
    /// Initializes a new instance of the <see cref="Service"/> class
    /// </summary>
    /// <param name="httpAdapter">Instance of LamodaHttpAdapter for send requests and receive responses</param>
    /// <param name="serviceEndPoint">Service url endpoint. Example: api/v1/orders</param>
    protected Service(LamodaHttpAdapter httpAdapter, string serviceEndPoint)
    {
        HttpAdapter = httpAdapter;
        ServiceEndPoint = serviceEndPoint;
    }

    public virtual void Dispose()
    {
        HttpAdapter.Dispose();
    }
}