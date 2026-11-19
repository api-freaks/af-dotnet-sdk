using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record AirQualityResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Location information
    /// </summary>
    [JsonPropertyName("location")]
    public OneOf<
        AirQualityResponseLocationContinentCode,
        AirQualityResponseLocationCity,
        AirQualityResponseLocationZero
    >? Location { get; set; }

    /// <summary>
    /// Current air quality data
    /// </summary>
    [JsonPropertyName("current")]
    public AirQualityResponseCurrent? Current { get; set; }

    /// <summary>
    /// Air quality forecast data object
    /// </summary>
    [JsonPropertyName("forecast")]
    public Dictionary<string, AirQualityResponseForecastValue>? Forecast { get; set; }

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
