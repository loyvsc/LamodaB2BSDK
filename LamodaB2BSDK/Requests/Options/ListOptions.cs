namespace LamodaB2BSDK.Requests.Options;

public class ListOptions
{
    /// <summary>
    /// Set limit entities per page
    /// </summary>
    public int EntitiesPerPage { get; set; }
    
    /// <summary>
    /// Set page
    /// </summary>
    public int Page { get; set; }

    public ListOptions(int page, int entitiesPerPage)
    {
        Page = page;
        EntitiesPerPage = entitiesPerPage;
    }
}