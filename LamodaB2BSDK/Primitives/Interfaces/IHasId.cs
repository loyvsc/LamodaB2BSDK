using System.Text.Json.Serialization;

namespace LamodaB2BSDK.Primitives.Interfaces;

public interface IHasId
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}