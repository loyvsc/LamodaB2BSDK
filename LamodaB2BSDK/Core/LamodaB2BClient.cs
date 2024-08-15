using System.Net.Http.Headers;
using LamodaB2BSDK.Core.Models;
using LamodaB2BSDK.Core.Requests;
using LamodaB2BSDK.Core.Responses;

namespace LamodaB2BSDK.Core;

public sealed class LamodaB2BClient : IDisposable
{
    private const string URI_API_BASE = "https://api-b2b.lamoda.ru/";
    private const string URI_DEMO_API_BASE = "https://api-demo-b2b.lamoda.ru/";

    #region Fields

    private readonly LamodaHttpAdapter _lamodaHttpAdapter;
    private readonly LamodaB2BApplication _application;
    private bool _isDemo;

    #endregion

    public bool IsDemo
    {
        get => _isDemo;
        set
        {
            if (value != _isDemo)
            {
                _isDemo = value;
                _application.Token = string.Empty;
                _lamodaHttpAdapter.HttpClient.BaseAddress = new Uri(value ? URI_DEMO_API_BASE : URI_API_BASE);
                _lamodaHttpAdapter.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("");
            }
        }
    }

    public LamodaB2BClient(LamodaB2BApplication application)
    {
        _application = application;
        _lamodaHttpAdapter = new LamodaHttpAdapter(URI_API_BASE);
    }
    
    public async Task AuthorizeAsync(AuthorizationRequest authorizationRequest, CancellationToken cancellationToken = default)
    {
        var response = await _lamodaHttpAdapter.GetAsync<AuthorizationResponse,AuthorizationRequest>("/auth/token",authorizationRequest,cancellationToken);

        if (response.IsT1)
        {
            throw new LamodaB2BException(response.AsT1.Message);
        }

        _application.Token = response.AsT0.AccessToken;
        _application.ExpiresIn = DateTime.Parse(response.AsT0.ExpiresIn);
    }
    
    public void Dispose()
    {
        _lamodaHttpAdapter.Dispose();
    }
}