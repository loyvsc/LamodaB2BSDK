using LamodaB2BSDK.Primitives.Interfaces;

namespace LamodaB2BSDK.Primitives.Clients;

public class Client : IClient
{
    public string ApiBase { get; }
    public string Token { get; }
}