using LamodaB2BSDK.Core.Attributes;

namespace LamodaB2BSDK.Core.Requests;

public class PaginationRequest
{
    /// <summary>
    /// Count of items on the page. Default = 25
    /// </summary>
    [QueryParameter("limit")] public int Limit { get; set; } = 25;

    /// <summary>
    /// Current page number
    /// </summary>
    [QueryParameter("page")] public int Page { get; set; } = 1;
    
    
}