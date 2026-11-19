using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Intraday response containing the prices of the requested symbol keyed by UTC timestamp.
/// </summary>
[Serializable]
public record CommodityIntradayRatesV2Response : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// `true` for successful requests.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <summary>
    /// The symbol the prices belong to.
    /// </summary>
    [JsonPropertyName("symbol")]
    public required string Symbol { get; set; }

    /// <summary>
    /// The UTC day requested. Format: `YYYY-MM-DD`.
    /// </summary>
    [JsonPropertyName("date")]
    public required string Date { get; set; }

    /// <summary>
    /// The interval used, in lowercase form (`5M` comes back as `5m`).
    /// </summary>
    [JsonPropertyName("interval")]
    public required CommodityIntradayRatesV2ResponseInterval Interval { get; set; }

    /// <summary>
    /// First mark of the window, `HH:mm` UTC.
    /// </summary>
    [JsonPropertyName("startTime")]
    public required string StartTime { get; set; }

    /// <summary>
    /// Number of points in `rates` (at most 100).
    /// </summary>
    [JsonPropertyName("count")]
    public required int Count { get; set; }

    /// <summary>
    /// `HH:mm` value to pass as `startTime` for the next page, or `null` when the window reached the end of the day (or the current minute, for today).
    /// </summary>
    [JsonPropertyName("nextStartTime")]
    public string? NextStartTime { get; set; }

    /// <summary>
    /// Prices keyed by ISO 8601 UTC timestamp (for example `2026-10-14T18:00:00Z`), in ascending order. Values are rounded to two decimals. A mark with no recorded price is left out rather than filled in.
    /// </summary>
    [JsonPropertyName("rates")]
    public Dictionary<string, float> Rates { get; set; } = new Dictionary<string, float>();

    /// <summary>
    /// Unit and currency of the prices, keyed by the requested symbol. Omitted when the request sets `metadata=false`.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, CommodityIntradayRatesV2ResponseMetadataValue>? Metadata { get; set; }

    /// <summary>
    /// Present when the symbol you sent was matched to a single alternative (200, with `resolvedTo`, for example `GOLD` answered as `XAU`), or not recognized at all (404, with a `suggestions` array when close matches exist).
    /// </summary>
    [JsonPropertyName("unresolved")]
    public Dictionary<
        string,
        CommodityIntradayRatesV2ResponseUnresolvedValue
    >? Unresolved { get; set; }

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
