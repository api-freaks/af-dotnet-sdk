using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record WeatherForecastResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Location information
    /// </summary>
    [JsonPropertyName("location")]
    public OneOf<
        WeatherForecastResponseLocationContinentCode,
        WeatherForecastResponseLocationCity,
        WeatherForecastResponseLocationZero
    >? Location { get; set; }

    /// <summary>
    /// Forecast data object of the provided date range
    /// </summary>
    [JsonPropertyName("forecast")]
    public Dictionary<string, WeatherForecastResponseForecastValue>? Forecast { get; set; }

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
