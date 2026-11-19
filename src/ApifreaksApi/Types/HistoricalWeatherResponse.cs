using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record HistoricalWeatherResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Location information
    /// </summary>
    [JsonPropertyName("location")]
    public OneOf<
        HistoricalWeatherResponseLocationContinentCode,
        HistoricalWeatherResponseLocationCity,
        HistoricalWeatherResponseLocationZero
    >? Location { get; set; }

    /// <summary>
    /// Historical data object of the provided date
    /// </summary>
    [JsonPropertyName("historical")]
    public HistoricalWeatherResponseHistorical? Historical { get; set; }

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
