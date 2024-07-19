using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using LamodaB2BSDK.Primitives.Interfaces;
using LamodaB2BSDK.Primitives.Models;
using Newtonsoft.Json;

namespace LamodaB2BSDK.Helpers;

internal sealed class HttpHelper : IDisposable
{
    private readonly HttpClient _httpClient;

    public HttpHelper()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task PostAsync<T>(T contentValue, RequestOptions requestOptions) where T : ILamodaEntity
    {
        var content = new StringContent(JsonConvert.SerializeObject(contentValue,
            new JsonSerializerSettings()
            { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), Encoding.UTF8, "application/json");
        
        var result = await _httpClient.PostAsync(requestOptions.ParseQuery(), content);
        result.EnsureSuccessStatusCode();
    }
    
    public async Task<T?> GetAsync<T>(RequestOptions requestOptions) where T : ILamodaEntity
    {
        var response = await _httpClient.GetAsync(requestOptions.ParseQuery());
        response.EnsureSuccessStatusCode();
        
        var serializedData = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<T>(serializedData);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}