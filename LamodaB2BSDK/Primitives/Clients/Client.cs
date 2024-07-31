using LamodaB2BSDK.Helpers;
using LamodaB2BSDK.Primitives.Interfaces;

namespace LamodaB2BSDK.Primitives.Clients;

//TODO
public class Client : IClient
{
    public string ApiBase { get; set; }
    public string Token { get; set; }
    
    public HttpHelper HttpHelper { get; set; }

    public Client(string apiBase)
    {
        Token = string.Empty;
        HttpHelper = new HttpHelper(apiBase);
    }
}