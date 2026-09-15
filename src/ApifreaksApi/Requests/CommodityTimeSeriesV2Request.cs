using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CommodityTimeSeriesV2Request
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Response format. Currently only `json` is supported.
    /// </summary>
    [JsonIgnore]
    public CommodityTimeSeriesV2RequestFormat? Format { get; set; }

    /// <summary>
    /// Comma-separated list of commodity symbols. Case-insensitive; duplicates are deduplicated server-side, with one response entry and one credit charge per unique symbol.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Symbols { get; set; } = new List<string>();

    /// <summary>
    /// Start date (YYYY-MM-DD)
    /// </summary>
    [JsonIgnore]
    public required DateOnly StartDate { get; set; }

    /// <summary>
    /// End date (YYYY-MM-DD). Maximum range is 365 days.
    /// </summary>
    [JsonIgnore]
    public required DateOnly EndDate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
