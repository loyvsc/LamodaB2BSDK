using System.Text.Json;

namespace LamodaB2BSDK.Requests;

public abstract class RequestBase
{
    public virtual IDictionary<string, string> GetQueryParameters()
    {
        Dictionary<string, string> result = new ();
        
        var properties = GetType().GetProperties();
        foreach (var propertyInfo in properties)
        {
            if (propertyInfo.GetCustomAttributes(typeof(JsonProperty), true).FirstOrDefault() is JsonProperty
                propertyNameAttribute)
            {
                var attributeValue = propertyInfo.GetValue(this).ToString() ?? string.Empty;
                result.Add(propertyNameAttribute.Name,attributeValue);
            }
        }
        
        return result;
    }
}