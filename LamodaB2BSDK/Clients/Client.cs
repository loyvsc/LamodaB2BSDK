using System.Net.Http.Headers;
using LamodaB2BSDK.Exceptions;
using LamodaB2BSDK.Helpers;
using LamodaB2BSDK.Primitives.Interfaces;
using LamodaB2BSDK.Requests;
using LamodaB2BSDK.Requests.Options;
using LamodaB2BSDK.Responses;
using OneOf;

namespace LamodaB2BSDK.Clients;

public class Client : IClient
{
    #region Propertys

    public string ApiBase
    {
        get => _httpHelper.HttpClient.BaseAddress.AbsolutePath;
        set => _httpHelper.HttpClient.BaseAddress = new Uri(value);
    }

    public string Token
    {
        get => _httpHelper.HttpClient.DefaultRequestHeaders.Authorization?.Parameter ?? string.Empty;
        set
        {
            if (!_httpHelper.HttpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpHelper.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Authorization", value);
            }
        }
    }
    #endregion
    
    private readonly HttpHelper _httpHelper;

    public Client(string apiBase)
    {
        Token = string.Empty;
        _httpHelper = new HttpHelper(apiBase);
    }

    public async Task<OneOf<T, ErrorResponse>> GetAsync<T>(BaseOptions options, CancellationToken cancellationToken = default)
    {
        if (Token == string.Empty)
        {
            throw new AuthorizationException("Client not authorized!");
        }

        return await _httpHelper.GetAsync<T>(options, cancellationToken);
    }
    
    public async Task<OneOf<T, ErrorResponse>> PostAsync<T>(RequestOptions options, CancellationToken cancellationToken = default)
    {
        if (Token == string.Empty)
        {
            throw new AuthorizationException("Client not authorized!");
        }

        return await _httpHelper.PostAsync<T>(options, cancellationToken);
    }
    
    public OneOf<AuthorizationResponse, ErrorResponse> Authorize(AuthorizationRequest authorizationRequest)
    {
        var requestOptions = new RequestOptions("/auth/token",authorizationRequest.GetQueryParameters());
        
        try
        {
            var response = _httpHelper.GetAsync<AuthorizationResponse>(requestOptions).GetAwaiter().GetResult();
            if (response.IsT0)
            {
                Token = response.AsT0.AccessToken;
            }
            
            return response;
        }
        catch (Exception)
        {
            return new ErrorResponse();
        }
    }
    
    public async Task<OneOf<AuthorizationResponse, ErrorResponse>> AuthorizeAsync(AuthorizationRequest authorizationRequest, CancellationToken cancellationToken = default)
    {
        var requestOptions = new RequestOptions("/auth/token",authorizationRequest.GetQueryParameters());
        
        try
        {
            var response = await _httpHelper.GetAsync<AuthorizationResponse>(requestOptions,cancellationToken);
            if (response.IsT0)
            {
                Token = response.AsT0.AccessToken;
            }

            return response;
        }
        catch (OperationCanceledException)
        {
            return new ErrorResponse();
        }
        catch (Exception)
        {
            return new ErrorResponse();
        }
    }
}