# Lamoda B2B SDK

C# SDK for Lamoda B2B Platform

[![GitHub Repo stars](https://img.shields.io/github/stars/loyvsc/LamodaB2BSDK)](https://github.com/loyvsc/LamodaB2BSDK)

## Usage

Initially you need to add LamodaB2BSDK to host builder:

```
var hostBuilder = new HostBuilder().AddLamodaB2B().Build();
```

### Authorization

```
LamodaB2BClient client = services.GetRequiredService<LamodaB2BClient>();
try
{
    var request = new AuthorizationRequest()
    {
        ClientId = "<insert the client id here>",
        ClientSecret = "<insert the client secret here>",
        GrantType = GrantType.Token,
        Username = "<insert the user name here>",
        Password = "<insert the password here>",
    };

    await client.AuthorizeAsync(request);
}
catch (LamodaB2BException excaption)
{
    Console.WriteLine(exception.Message);
}
```
