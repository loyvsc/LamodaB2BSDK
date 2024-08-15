using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LamodaB2BSDK.Core.Serialization;

public class JsonEnumMemberConverter(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true)
    : JsonConverterFactory
{
    private readonly JsonStringEnumConverter _baseConverter = new(namingPolicy, allowIntegerValues);

    public JsonEnumMemberConverter() : this(null) { }

    public override bool CanConvert(Type typeToConvert) => _baseConverter.CanConvert(typeToConvert);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
                    let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                    where attr?.Value != null
                    select (field.Name, attr.Value);
        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        return dictionary.Count > 0 
            ? new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, namingPolicy), allowIntegerValues).CreateConverter(typeToConvert, options) 
            : _baseConverter.CreateConverter(typeToConvert, options);
    }
}

public class JsonNamingPolicyDecorator(JsonNamingPolicy? underlyingNamingPolicy) : JsonNamingPolicy
{
    public override string ConvertName (string name) => underlyingNamingPolicy?.ConvertName(name) ?? name;
}

internal class DictionaryLookupNamingPolicy(
    Dictionary<string, string> dictionary,
    JsonNamingPolicy? underlyingNamingPolicy)
    : JsonNamingPolicyDecorator(underlyingNamingPolicy)
{
    private readonly Dictionary<string, string> _dictionary = dictionary ?? throw new ArgumentNullException();

    public override string ConvertName (string name) => _dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
}