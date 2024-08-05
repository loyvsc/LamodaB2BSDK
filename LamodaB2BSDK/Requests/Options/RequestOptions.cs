using System.Web;

namespace LamodaB2BSDK.Requests.Options;

public class RequestOptions : BaseOptions
{
    public object? Body { get; set; }
    public string EndPoint { get; set; }
    private IDictionary<string, string> Headers { get; }

    public RequestOptions(string endPoint, IDictionary<string, string>? headers = null)
    {
        EndPoint = endPoint;
        Headers = headers ?? new Dictionary<string, string>();
    }

    public RequestOptions()
    {
        EndPoint = string.Empty;
        Headers = new Dictionary<string, string>();
    }
    
    public void AddHeaders(IDictionary<string,string> headers)
    {
        foreach (var header in headers)
        {
            Headers.TryAdd(header.Key, header.Value);
        }
    }
    
    public override string ParseQuery()
    {
        var builder = new UriBuilder(EndPoint);
        var query = HttpUtility.ParseQueryString(EndPoint);
        
        foreach (var keyValuePair in Headers)
        {
            query.Add(keyValuePair.Key,keyValuePair.Value);
        }
        
        builder.Query = query.ToString();
        return builder.ToString();
    }
}