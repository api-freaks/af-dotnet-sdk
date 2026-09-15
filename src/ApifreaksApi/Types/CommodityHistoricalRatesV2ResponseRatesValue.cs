using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CommodityHistoricalRatesV2ResponseRatesValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Date for which prices were fetched (YYYY-MM-DD). May differ from the requested date when the API falls back to the last available rate before it, or snaps to the first day of the month for monthly-updated commodities.
    /// </summary>
    [JsonPropertyName("date")]
    public required string Date { get; set; }

    /// <summary>
    /// Opening price on the given date. 0 for monthly-updated commodities.
    /// </summary>
    [JsonPropertyName("open")]
    public required float Open { get; set; }

    /// <summary>
    /// Highest price recorded on the given date. 0 for monthly-updated commodities.
    /// </summary>
    [JsonPropertyName("high")]
    public required float High { get; set; }

    /// <summary>
    /// Lowest price recorded on the given date. 0 for monthly-updated commodities.
    /// </summary>
    [JsonPropertyName("low")]
    public required float Low { get; set; }

    /// <summary>
    /// Closing price on the given date.
    /// </summary>
    [JsonPropertyName("close")]
    public required float Close { get; set; }

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
