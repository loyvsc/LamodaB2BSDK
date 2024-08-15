using System.Text.Json.Serialization;

namespace LamodaB2BSDK.Core.Responses;

public class AuthorizationResponse
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = string.Empty;
    [JsonPropertyName("expires_in")] public string ExpiresIn { get; set; } = string.Empty;
    [JsonPropertyName("token_type")] public string TokenType { get; set; } = string.Empty;
    [JsonPropertyName("scope")] public string Scope { get; set; } = string.Empty;
}