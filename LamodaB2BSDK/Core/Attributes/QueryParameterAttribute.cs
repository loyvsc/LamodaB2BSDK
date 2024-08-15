namespace LamodaB2BSDK.Core.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class QueryParameterAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}