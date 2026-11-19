using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record MarineWeatherResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Location information
    /// </summary>
    [JsonPropertyName("location")]
    public OneOf<
        MarineWeatherResponseLocationContinentCode,
        MarineWeatherResponseLocationCity,
        MarineWeatherResponseLocationZero
    >? Location { get; set; }

    /// <summary>
    /// Current marine data
    /// </summary>
    [JsonPropertyName("current")]
    public MarineWeatherResponseCurrent? Current { get; set; }

    /// <summary>
    /// Marine forecast data object keyed by date in YYYY-MM-DD format
    /// </summary>
    [JsonPropertyName("forecast")]
    public Dictionary<string, MarineWeatherResponseForecastValue>? Forecast { get; set; }

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
