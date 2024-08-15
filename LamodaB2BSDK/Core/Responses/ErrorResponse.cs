using System.Text.Json.Serialization;

namespace LamodaB2BSDK.Core.Responses;

public class ErrorResponse
{
    [JsonPropertyName("code")] public int ErrorCode { get; set; }
    
    /// <summary>
    /// Additional information about the error
    /// </summary>
    [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;

    /// <summary>
    /// List of errors
    /// </summary>
    [JsonPropertyName("errors")] public IEnumerable<Error> Errors { get; set; }

    /// <summary>
    /// Error description
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; } = string.Empty;
}

public class Error
{
    /// <summary>
    /// Error value
    /// </summary>
    [JsonPropertyName("field")] public string Field { get; set; } = string.Empty;
    /// <summary>
    /// Error message
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; } = string.Empty;
}