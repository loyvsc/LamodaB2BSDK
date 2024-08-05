using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace LamodaB2BSDK.Responses;

public class ErrorResponse
{
    [JsonProperty("code")] public int ErrorCode { get; }
    
    /// <summary>
    /// Additional information about the error
    /// </summary>
    [JsonProperty("description")] public string Description { get; }
    
    /// <summary>
    /// List of errors
    /// </summary>
    [JsonProperty("errors")] public ReadOnlyCollection<Error> Errors { get; }
    
    /// <summary>
    /// Error description
    /// </summary>
    [JsonProperty("message")] public string Message { get; }
}

public class Error
{
    /// <summary>
    /// Error value
    /// </summary>
    [JsonProperty("field")] public string Field { get; set; }
    /// <summary>
    /// Error message
    /// </summary>
    [JsonProperty("message")] public string Message { get; set; }
}