using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record FloodForecastResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Location information
    /// </summary>
    [JsonPropertyName("location")]
    public OneOf<
        FloodForecastResponseLocationContinentCode,
        FloodForecastResponseLocationCity,
        FloodForecastResponseLocationZero
    >? Location { get; set; }

    /// <summary>
    /// Flood forecast data object
    /// </summary>
    [JsonPropertyName("forecast")]
    public Dictionary<string, FloodForecastResponseForecastValue>? Forecast { get; set; }

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
