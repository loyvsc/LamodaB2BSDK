namespace LamodaB2BSDK.Primitives.Models;

public class PreviousDayInfo
{
    public PreviousDayInfo(int orderCount, float avgOrderPrice, float takedmoney)
    {
        OrderCount = orderCount;
        AvgOrderPrice = avgOrderPrice;
        Takedmoney = takedmoney;
    }

    public int OrderCount { get; set; }
    public float AvgOrderPrice { get; set; }
    public float Takedmoney { get; set; }
}