using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CommoditySymbolsV2ResponseSymbolsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier/ticker symbol for the commodity (e.g., XAU, NG-FUT). Use this value in the symbols parameter of the rate endpoints.
    /// </summary>
    [JsonPropertyName("symbol")]
    public required string Symbol { get; set; }

    /// <summary>
    /// Full name of the commodity (e.g., Gold, Natural Gas Futures).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Short description of the commodity. May be an empty string for some symbols.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Category the commodity belongs to (e.g., Metals, Energy, Agriculture, Industrial, Raw Materials, Oils and Meals, Textiles, Meats, Poultry, Livestock).
    /// </summary>
    [JsonPropertyName("category")]
    public required string Category { get; set; }

    /// <summary>
    /// Current status of the commodity. "inactive" means the symbol is deprecated - latest rates are unavailable, but historical rates remain available up to its deprecationDate.
    /// </summary>
    [JsonPropertyName("status")]
    public required CommoditySymbolsV2ResponseSymbolsItemStatus Status { get; set; }

    /// <summary>
    /// The rate at which this commodity's price is updated.
    /// </summary>
    [JsonPropertyName("updateInterval")]
    public required CommoditySymbolsV2ResponseSymbolsItemUpdateInterval UpdateInterval { get; set; }

    /// <summary>
    /// Data source for the symbol (e.g., World Bank). Present only for some symbols.
    /// </summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; set; }

    /// <summary>
    /// Present only when status is "inactive". Date the symbol was deprecated (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("deprecationDate")]
    public DateOnly? DeprecationDate { get; set; }

    [JsonPropertyName("currency")]
    public required CommoditySymbolsV2ResponseSymbolsItemCurrency Currency { get; set; }

    [JsonPropertyName("unit")]
    public required CommoditySymbolsV2ResponseSymbolsItemUnit Unit { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
