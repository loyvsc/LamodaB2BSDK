using LamodaB2BSDK.Primitives.Enums;
using Newtonsoft.Json;

namespace LamodaB2BSDK.Requests;

public class AuthorizationRequest : RequestBase
{
    [JsonProperty("client_id")] public string ClientId { get; set; } = string.Empty;
    [JsonProperty("client_secret")] public string ClientSecret { get; set; } = string.Empty;
    [JsonProperty("grant_type")] public GrantType GrantType { get; set; }
    [JsonProperty("username")] public string? Username { get; set; }
    [JsonProperty("password")] public string? Password { get; set; }
    [JsonProperty("redirect_uri")] public string? RedirectUrl { get; set; }

    public override IDictionary<string, string> GetQueryParameters()
    {
        var parameters = base.GetQueryParameters();
        parameters["grant_type"] = GrantType switch
        {
            GrantType.Password => "password",
            GrantType.Token => "token",
            GrantType.ClientCredentials => "client_credentials",
            GrantType.AuthorizationCode => "authorization_code",
            GrantType.RefreshToken => "refresh_token",
            GrantType.Extensions => "extensions",
            _ => throw new ArgumentOutOfRangeException()
        };
        return parameters;
    }
}