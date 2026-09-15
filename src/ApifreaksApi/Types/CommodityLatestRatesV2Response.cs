using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CommodityLatestRatesV2Response : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// API request success indicator. "true" for successful requests.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <summary>
    /// Unix timestamp (seconds) indicating when the response was generated.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required int Timestamp { get; set; }

    /// <summary>
    /// Map of requested commodity symbols to their current live price.
    /// </summary>
    [JsonPropertyName("rates")]
    public Dictionary<string, double> Rates { get; set; } = new Dictionary<string, double>();

    /// <summary>
    /// Map containing unit and quote currency metadata for all requested commodities, keyed by commodity symbol.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, CommodityLatestRatesV2ResponseMetadataValue> Metadata { get; set; } =
        new Dictionary<string, CommodityLatestRatesV2ResponseMetadataValue>();

    /// <summary>
    /// Present only when currency conversion for the requested `quote` is temporarily unavailable; rates are returned in each commodity's default currency instead.
    /// </summary>
    [JsonPropertyName("warning")]
    public string? Warning { get; set; }

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
