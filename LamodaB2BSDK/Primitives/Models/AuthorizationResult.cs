using System.Text.Json.Serialization;

namespace LamodaB2BSDK.Primitives.Models;

public class AuthorizationResult
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }

    [JsonPropertyName("token_type")] public string TokenType { get; set; } = string.Empty;

    [JsonPropertyName("scope")] public string Scope { get; set; } = string.Empty;
}