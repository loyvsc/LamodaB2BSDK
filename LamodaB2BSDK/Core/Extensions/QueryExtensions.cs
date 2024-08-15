using System.Reflection;
using LamodaB2BSDK.Core.Attributes;

namespace LamodaB2BSDK.Core.Extensions;

public static class QueryExtensions
{
    public static string ToQueryParameters<T>(this T obj, string uri)
    {
        var properties = typeof(T)
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => x.GetCustomAttribute<QueryParameterAttribute>()!=null)
            .ToArray();

        return uri+"?" + string.Join('&',
            properties.Select(x => $"{x.GetCustomAttribute<QueryParameterAttribute>()?.Name}={x.GetValue(obj)}"));
    }
}