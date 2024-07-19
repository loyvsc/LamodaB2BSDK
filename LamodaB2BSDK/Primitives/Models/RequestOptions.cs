using System.Web;

namespace LamodaB2BSDK.Primitives.Models;

public class RequestOptions : BaseOptions
{
    public string BaseUrl { get; set; }
    private IDictionary<string, string> UriHeaders { get; }

    public RequestOptions(string baseUrl, IDictionary<string, string>? headers = null)
    {
        BaseUrl = baseUrl;
        UriHeaders = headers ?? new Dictionary<string, string>();
    }

    public RequestOptions()
    {
        BaseUrl = string.Empty;
        UriHeaders = new Dictionary<string, string>();
    }
    
    public void AddHeaders(IDictionary<string,string> headers)
    {
        foreach (var header in headers)
        {
            UriHeaders.TryAdd(header.Key, header.Value);
        }
    }
    
    public virtual string ParseQuery()
    {
        var builder = new UriBuilder(BaseUrl);
        var query = HttpUtility.ParseQueryString(BaseUrl);
        
        foreach (var keyValuePair in UriHeaders)
        {
            query.Add(keyValuePair.Key,keyValuePair.Value);
        }
        
        builder.Query = query.ToString();
        return builder.ToString();
    }
}