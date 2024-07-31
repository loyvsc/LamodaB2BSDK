using LamodaB2BSDK.Helpers;
using LamodaB2BSDK.Primitives.Requests.Options;

namespace LamodaB2BSDK.Primitives.Interfaces;

public interface IClient
{
    /// <summary>Gets the base URL for B2B Lamoda API.</summary>
    /// <value>The base URL for B2B Lamoda API.</value>
    string ApiBase { get; }
    
    /// <summary>Gets the token used by the client to send requests.</summary>
    /// <value>The token used by the client to send requests.</value>
    string Token { get; set; }
    
    protected HttpHelper HttpHelper { get; set; }
    
}