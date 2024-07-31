using LamodaB2BSDK.Primitives.Interfaces;
using LamodaB2BSDK.Primitives.Models;

namespace LamodaB2BSDK.Services;

public class OrdersService : Service<Order>
{
    public OrdersService(IClient client) : base(client)
    {
    }
}