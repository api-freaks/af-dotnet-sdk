using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Daily flood forecast data for the date.
/// </summary>
[Serializable]
public record FloodForecastResponseForecastValueDaily : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Local timestamp of this reading (format YYYY-MM-DDTHH:mm, not ISO 8601).
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }

    /// <summary>
    /// The observed river discharge value (m³/s)
    /// </summary>
    [JsonPropertyName("river_discharge")]
    public double? RiverDischarge { get; set; }

    /// <summary>
    /// The mean river discharge (m³/s)
    /// </summary>
    [JsonPropertyName("river_discharge_mean")]
    public double? RiverDischargeMean { get; set; }

    /// <summary>
    /// The median river discharge (m³/s)
    /// </summary>
    [JsonPropertyName("river_discharge_median")]
    public double? RiverDischargeMedian { get; set; }

    /// <summary>
    /// The maximum river discharge (m³/s)
    /// </summary>
    [JsonPropertyName("river_discharge_max")]
    public double? RiverDischargeMax { get; set; }

    /// <summary>
    /// The minimum river discharge (m³/s)
    /// </summary>
    [JsonPropertyName("river_discharge_min")]
    public double? RiverDischargeMin { get; set; }

    /// <summary>
    /// The 25th percentile of river discharge (m³/s)
    /// </summary>
    [JsonPropertyName("river_discharge_p25")]
    public double? RiverDischargeP25 { get; set; }

    /// <summary>
    /// The 75th percentile of river discharge (m³/s)
    /// </summary>
    [JsonPropertyName("river_discharge_p75")]
    public double? RiverDischargeP75 { get; set; }

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
