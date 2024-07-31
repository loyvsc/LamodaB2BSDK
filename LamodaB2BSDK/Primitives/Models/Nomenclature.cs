using System.Text.Json.Serialization;

namespace LamodaB2BSDK.Primitives.Models;

public class Nomenclature
{
    [JsonPropertyName("sku")] public string Sku { get; set; } = string.Empty;
    [JsonPropertyName("supplier_sku")] public string SupplierSku { get; set; } = string.Empty;
    [JsonPropertyName("supplier_size")] public string SupplierSize { get; set; } = string.Empty;
    [JsonPropertyName("quantity")] public int Quantity { get; set; }
    [JsonPropertyName("barcode")] public string BarCode { get; set; } = string.Empty;
    /// <summary>
    /// Описание номенклатуры
    /// </summary>
    [JsonPropertyName("name")] public string Description { get; set; } = string.Empty;
    [JsonPropertyName("category")] public string Category { get; set; } = string.Empty;
    /// <summary>
    /// Подкатегория номенклатуры
    /// </summary>
    [JsonPropertyName("lamodaSubCategory")] public string LamodaSubCategory { get; set; } = string.Empty;
    /// <summary>
    /// Ставка НДС в процентах
    /// </summary>
    [JsonPropertyName("vat")] public float Vat { get; set; }
    /// <summary>
    /// Код ТН ВЭД
    /// </summary>
    [JsonPropertyName("tnVed")] public string TnVed { get; set; }
    
    [JsonPropertyName("_embedded")] public NomenclatureEmbedded? NomenclatureEmbedded { get; set; }

    [JsonIgnore] public NomenclaturePartner? Partner => NomenclatureEmbedded.Partner;

}

public class NomenclatureEmbedded
{
    [JsonPropertyName("partner")] public NomenclaturePartner Partner { get; set; }
}

public class NomenclaturePartner
{
    [JsonPropertyName("code")] public string Code { get; set; } = string.Empty;
    [JsonPropertyName("shopName")] public string ShopName { get; set; } = string.Empty;
}