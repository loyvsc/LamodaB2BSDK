using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LamodaB2BSDK.Core.Extensions;
using LamodaB2BSDK.Core.Responses;
using LamodaB2BSDK.Core.Serialization;
using OneOf;

namespace LamodaB2BSDK.Core;

public sealed class LamodaHttpAdapter : IDisposable
{
    public readonly HttpClient HttpClient;

    #region Constants

    private const string HttpExceptionMessage = "An error occurred while sending the request. Try again later...";
    private const string TaskCanceledMessage = "Operation canceled";
    
    #endregion

    private readonly JsonSerializerOptions _serializerOptions;

    public LamodaHttpAdapter(string baseAddress)
    {
        HttpClient = new HttpClient
        {
            BaseAddress = new Uri(baseAddress)
        };
        _serializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };
        _serializerOptions.Converters.Add(new JsonEnumMemberConverter());

        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task<OneOf<TResponse,ErrorResponse>> PostAsync<TResponse, TBody>(string endpoint, TBody body, CancellationToken cancellationToken = default)
    {
        try
        {
            var requestContent = new StringContent(JsonSerializer.Serialize(body,_serializerOptions), Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            var uri = body is null ? endpoint : body.ToQueryParameters(endpoint);
            var response = await HttpClient.PostAsync(uri,requestContent,cancellationToken);
            var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            
            return response.IsSuccessStatusCode
                ? await JsonSerializer.DeserializeAsync<TResponse>(stream,_serializerOptions, cancellationToken: cancellationToken)
                : await JsonSerializer.DeserializeAsync<ErrorResponse>(stream,_serializerOptions,cancellationToken: cancellationToken);
        }
        catch (TaskCanceledException ex)
        {
            throw new LamodaB2BException(TaskCanceledMessage,ex);
        }
        catch (Exception ex)
        {
            throw new LamodaB2BException(HttpExceptionMessage,ex);
        }
    }
    
    public async Task<OneOf<TResponse,ErrorResponse>> GetAsync<TResponse,TBody>(string endPoint, TBody body, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await HttpClient.GetAsync(body.ToQueryParameters(endPoint), cancellationToken);
            var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

            return response.IsSuccessStatusCode
                ? await JsonSerializer.DeserializeAsync<TResponse>(stream,_serializerOptions)
                : await JsonSerializer.DeserializeAsync<ErrorResponse>(stream,_serializerOptions);
        }
        catch (TaskCanceledException ex)
        {
            throw new LamodaB2BException(TaskCanceledMessage,ex);
        }
        catch (Exception ex)
        {
            throw new LamodaB2BException(HttpExceptionMessage,ex);
        }
    }
    
    public void Dispose()
    {
        HttpClient.Dispose();
    }
}