using System.Text.Json.Serialization;

namespace LamodaB2BSDK.Responses;

public record struct AuthorizationResponse(
    [property: JsonPropertyName("access_token")] string AccessToken, 
    [property: JsonPropertyName("expires_in")] string ExpiresIn,
    [property: JsonPropertyName("token_type")] string TokenType,
    [property: JsonPropertyName("scope")] string Scope);