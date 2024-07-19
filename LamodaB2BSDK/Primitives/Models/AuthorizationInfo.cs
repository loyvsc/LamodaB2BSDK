using LamodaB2BSDK.Primitives.Enums;

namespace LamodaB2BSDK.Primitives.Models;

public class AuthorizationInfo
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public GrantType GrantType { get; set; } = GrantType.None;
    public string? Username { get; set; }
    public string? Password { get; set; }
}