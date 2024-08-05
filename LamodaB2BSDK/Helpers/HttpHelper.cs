using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using LamodaB2BSDK.Requests.Options;
using LamodaB2BSDK.Responses;
using Newtonsoft.Json;
using OneOf;

namespace LamodaB2BSDK.Helpers;

public sealed class HttpHelper : IDisposable
{
    public HttpClient HttpClient { get; }

    public HttpHelper(string baseAddress)
    {
        HttpClient = new HttpClient()
        {
            BaseAddress = new Uri(baseAddress)
        };
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    /// <summary>
    /// Async send post request
    /// </summary>
    /// <param name="requestOptions">Request options</param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T">Response type</typeparam>
    /// <returns>
    /// <see cref="T"/> on success complete
    /// <see cref="ErrorResponse"/> on error
    /// </returns>
    public async Task<OneOf<T,ErrorResponse>> PostAsync<T>(RequestOptions requestOptions, CancellationToken cancellationToken = default)
    {
        StringContent? requestContent = null;
        if (requestOptions.Body != null)
        {
            requestContent = new StringContent(JsonConvert.SerializeObject(requestOptions.Body,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }), Encoding.UTF8, "application/json");
        }
        
        var response = await HttpClient.PostAsync(requestOptions.ParseQuery(), requestContent,cancellationToken);
        var deserializedContent = await response.Content.ReadAsStringAsync(cancellationToken);
        
        return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(deserializedContent)! 
            : JsonConvert.DeserializeObject<ErrorResponse>(deserializedContent)!;
    }
    
    /// <summary>
    /// Async send get request
    /// </summary>
    /// <param name="requestOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public async Task<OneOf<T,ErrorResponse>> GetAsync<T>(BaseOptions requestOptions,CancellationToken cancellationToken = default)
    {
        var response = await HttpClient.GetAsync(requestOptions.ParseQuery(),cancellationToken);
        var deserializedContent = await response.Content.ReadAsStringAsync(cancellationToken);
        
        return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(deserializedContent)! 
            : JsonConvert.DeserializeObject<ErrorResponse>(deserializedContent)!;
    }
    
    public void Dispose()
    {
        HttpClient.Dispose();
    }
}