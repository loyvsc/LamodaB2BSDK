using LamodaB2BSDK.Primitives.Enums;

namespace LamodaB2BSDK.Primitives.Extensions;

public static class GrantTypeExtensions
{
    public static string ToStringValue(this GrantType grantType)
    {
        return grantType switch
        {
            GrantType.Extensions => "extensions",
            GrantType.Password => "password",
            GrantType.Token => "token",
            GrantType.ClientCredentials => "client_credentials",
            GrantType.AutorizationCode => "authorization_code",
            GrantType.RefreshToken => "refresh_token",
            GrantType.None => throw new ArgumentOutOfRangeException(nameof(grantType), grantType, "Value type GrantType cannot be None"),
            _ => throw new ArgumentOutOfRangeException(nameof(grantType), grantType, "")
        };
    }
}