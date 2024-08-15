using System.Text.Json.Serialization;
using LamodaB2BSDK.Core.Attributes;
using LamodaB2BSDK.Core.Enums;

namespace LamodaB2BSDK.Core.Requests;

public class AuthorizationRequest
{
    [JsonPropertyName("client_id")]
    [QueryParameter("client_id")]
    public string ClientId { get; set; } = string.Empty;
    
    [JsonPropertyName("client_secret")]
    [QueryParameter("client_secret")]
    public string ClientSecret { get; set; } = string.Empty;
    
    [JsonPropertyName("grant_type")]
    [QueryParameter("grant_type")]
    public GrantType GrantType { get; set; }
    [JsonPropertyName("username")]
    [QueryParameter("username")]
    public string? Username { get; set; }
    
    [JsonPropertyName("password")]
    [QueryParameter("password")]
    public string? Password { get; set; }
    
    [JsonPropertyName("redirect_uri")]
    [QueryParameter("redirect_uri")]
    public string? RedirectUrl { get; set; }
}