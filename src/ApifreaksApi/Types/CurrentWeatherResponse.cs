using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record CurrentWeatherResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Location information
    /// </summary>
    [JsonPropertyName("location")]
    public required OneOf<
        CurrentWeatherResponseLocationContinentCode,
        CurrentWeatherResponseLocationCity,
        CurrentWeatherResponseLocationZero
    > Location { get; set; }

    /// <summary>
    /// Current weather data
    /// </summary>
    [JsonPropertyName("current")]
    public required CurrentWeatherResponseCurrent Current { get; set; }

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
