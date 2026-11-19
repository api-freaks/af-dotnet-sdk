using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record BulkCurrentWeatherResponseBulkItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Location information
    /// </summary>
    [JsonPropertyName("location")]
    public required OneOf<
        BulkCurrentWeatherResponseBulkItemLocationContinentCode,
        BulkCurrentWeatherResponseBulkItemLocationCity,
        BulkCurrentWeatherResponseBulkItemLocationZero
    > Location { get; set; }

    /// <summary>
    /// Current weather data
    /// </summary>
    [JsonPropertyName("current")]
    public required BulkCurrentWeatherResponseBulkItemCurrent Current { get; set; }

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
