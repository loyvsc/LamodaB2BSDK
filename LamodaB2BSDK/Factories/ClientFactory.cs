using LamodaB2BSDK.Clients;
using LamodaB2BSDK.Primitives.Interfaces;

namespace LamodaB2BSDK.Factories;

public static class ClientFactory
{
    public static IClient CreateClient()
    {
        return new Client("https://api-b2b.lamoda.ru/auth/token");
    }
    
    public static IClient CreateDemoClient()
    {
        return new Client("https://api-demo-b2b.lamoda.ru/auth/token");
    }
}