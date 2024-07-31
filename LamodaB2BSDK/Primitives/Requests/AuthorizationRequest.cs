namespace LamodaB2BSDK.Primitives.Requests;

public class AuthorizationRequest
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string GrantType { get; set; } = Enums.GrantType.ClientCredentials;
    public string? Username { get; set; }
    public string? Password { get; set; }
}