using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record AirQualityResponseForecastValueHourlyItem : IJsonOnDeserialized
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
    /// Concentration of particulate matter ≤10 micrometers (μg/m³)
    /// </summary>
    [JsonPropertyName("pm10")]
    public double? Pm10 { get; set; }

    /// <summary>
    /// Concentration of carbon monoxide (μg/m³)
    /// </summary>
    [JsonPropertyName("carbon_monoxide")]
    public double? CarbonMonoxide { get; set; }

    /// <summary>
    /// Concentration of particulate matter ≤2.5 micrometers (μg/m³)
    /// </summary>
    [JsonPropertyName("pm2_5")]
    public double? Pm25 { get; set; }

    /// <summary>
    /// Concentration of carbon dioxide (ppm)
    /// </summary>
    [JsonPropertyName("carbon_dioxide")]
    public double? CarbonDioxide { get; set; }

    /// <summary>
    /// Concentration of nitrogen dioxide (μg/m³)
    /// </summary>
    [JsonPropertyName("nitrogen_dioxide")]
    public double? NitrogenDioxide { get; set; }

    /// <summary>
    /// Concentration of sulphur dioxide (μg/m³)
    /// </summary>
    [JsonPropertyName("sulphur_dioxide")]
    public double? SulphurDioxide { get; set; }

    /// <summary>
    /// Concentration of ozone (μg/m³)
    /// </summary>
    [JsonPropertyName("ozone")]
    public double? Ozone { get; set; }

    /// <summary>
    /// Concentration of dust particles (μg/m³)
    /// </summary>
    [JsonPropertyName("dust")]
    public double? Dust { get; set; }

    /// <summary>
    /// Ultraviolet radiation index
    /// </summary>
    [JsonPropertyName("uv_index")]
    public double? UvIndex { get; set; }

    /// <summary>
    /// Aerosol optical depth
    /// </summary>
    [JsonPropertyName("aerosol_optical_depth")]
    public double? AerosolOpticalDepth { get; set; }

    /// <summary>
    /// Ultraviolet radiation index under clear sky conditions
    /// </summary>
    [JsonPropertyName("uv_index_clear_sky")]
    public double? UvIndexClearSky { get; set; }

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
