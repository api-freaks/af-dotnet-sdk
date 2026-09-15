using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CommodityTimeSeriesV2Response : IJsonOnDeserialized
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
    /// The start date of the time series data in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("startDate")]
    public required string StartDate { get; set; }

    /// <summary>
    /// The end date of the time series data in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("endDate")]
    public required string EndDate { get; set; }

    /// <summary>
    /// Map of trading dates (YYYY-MM-DD) to per-symbol OHLC data. Non-trading days are excluded.
    /// </summary>
    [JsonPropertyName("rates")]
    public Dictionary<
        string,
        Dictionary<string, CommodityTimeSeriesV2ResponseRatesValueValue>
    > Rates { get; set; } =
        new Dictionary<string, Dictionary<string, CommodityTimeSeriesV2ResponseRatesValueValue>>();

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
