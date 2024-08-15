using System.Runtime.Serialization;

namespace LamodaB2BSDK.Core.Enums;

public enum GrantType
{
    None,
    [EnumMember(Value = "password")] Password,
    [EnumMember(Value = "token")] Token,
    [EnumMember(Value = "client_credentials")] ClientCredentials,
    [EnumMember(Value = "authorization_code")] AuthorizationCode,
    [EnumMember(Value = "refresh_token")] RefreshToken,
    [EnumMember(Value = "extensions")] Extensions
}