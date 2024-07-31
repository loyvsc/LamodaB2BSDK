using System.Text.Json.Serialization;
using LamodaB2BSDK.Primitives.Interfaces;

namespace LamodaB2BSDK.Primitives.Models;

public class Order : IHasId
{ 
    /// <summary>
    /// Номер заказа
    /// </summary>
    [JsonPropertyName("orderNr")] public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Номер заказа Lamoda
    /// </summary>
    [JsonPropertyName("id")] public string LamodaId { get; set; } = string.Empty;
    
    [JsonPropertyName("status")] public string Status { get; set; } = string.Empty;
    
    [JsonPropertyName("paymentMethod")] public string PaymentMethod { get; set; } = string.Empty;
    
    /// <summary>
    /// Полная стоимость заказа в рублях
    /// </summary>
    [JsonPropertyName("fullSum")] public float FullSum { get; set; }
    
    /// <summary>
    /// Стоимость доставки
    /// </summary>
    [JsonPropertyName("deliveryPrice")] public float DeliveryPrice { get; set; }
    
    /// <summary>
    /// Дата создания заказа
    /// </summary>
    [JsonPropertyName("createdAt")] public DateTime CreateDate { get; set; }
    
    /// <summary>
    /// Дата последнего обновления заказа
    /// </summary>
    [JsonPropertyName("updatedAt")] public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("dates")] public OrderDates OrderDates { get; set; }
    
    [JsonPropertyName("isConfirmed")] public bool IsConfirmed { get; set; }
    
    [JsonPropertyName("rejectPrice")] public float RejectPrice { get; set; }
    
    
}

public class OrderDates
{
    [JsonPropertyName("delivered")] public DateTime DeliveredDateTime { get; set; }
    [JsonPropertyName("shipped")] public DateTime ShippedDateTime { get; set; }
}