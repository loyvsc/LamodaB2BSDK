using LamodaB2BSDK.Requests;
using LamodaB2BSDK.Responses;
using OneOf;

namespace LamodaB2BSDK.Primitives.Interfaces;

public interface IClient
{
    /// <summary>Gets the base URL for B2B Lamoda API.</summary>
    /// <value>The base URL for B2B Lamoda API.</value>
    string ApiBase { get; set; }
    
    /// <summary>Gets the token used by the client to send requests.</summary>
    /// <value>The token used by the client to send requests.</value>
    string Token { get; }
    
    OneOf<AuthorizationResponse,ErrorResponse> Authorize(AuthorizationRequest authorizationRequest);
    Task<OneOf<AuthorizationResponse,ErrorResponse>> AuthorizeAsync(AuthorizationRequest authorizationRequest, CancellationToken cancellationToken = default);

}