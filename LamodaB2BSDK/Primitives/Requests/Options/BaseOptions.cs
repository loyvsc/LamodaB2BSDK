namespace LamodaB2BSDK.Primitives.Requests.Options;

public abstract class BaseOptions
{
    protected List<string> Expand { get; } = [];

    protected void AddExpand(string expand) => Expand.Add(expand);

    protected void AddExpandRange(string[] expands) => Expand.AddRange(expands);
    
    protected bool RemoveExpand(string expand) => Expand.Remove(expand);

    public abstract string ParseQuery();
}