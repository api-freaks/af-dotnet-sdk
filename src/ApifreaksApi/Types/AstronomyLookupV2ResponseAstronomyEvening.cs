using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Evening astronomical data including golden hour, blue hour, and twilight times.
/// </summary>
[Serializable]
public record AstronomyLookupV2ResponseAstronomyEvening : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The beginning of the golden hour in the evening
    /// </summary>
    [JsonPropertyName("golden_hour_begin")]
    public required string GoldenHourBegin { get; set; }

    /// <summary>
    /// The end of the golden hour in the evening
    /// </summary>
    [JsonPropertyName("golden_hour_end")]
    public required string GoldenHourEnd { get; set; }

    /// <summary>
    /// The beginning of the blue hour in the evening
    /// </summary>
    [JsonPropertyName("blue_hour_begin")]
    public required string BlueHourBegin { get; set; }

    /// <summary>
    /// The end of the blue hour in the evening
    /// </summary>
    [JsonPropertyName("blue_hour_end")]
    public required string BlueHourEnd { get; set; }

    /// <summary>
    /// The start of civil twilight in the evening
    /// </summary>
    [JsonPropertyName("civil_twilight_begin")]
    public required string CivilTwilightBegin { get; set; }

    /// <summary>
    /// The end of civil twilight in the evening
    /// </summary>
    [JsonPropertyName("civil_twilight_end")]
    public required string CivilTwilightEnd { get; set; }

    /// <summary>
    /// The start of nautical twilight in the evening
    /// </summary>
    [JsonPropertyName("nautical_twilight_begin")]
    public required string NauticalTwilightBegin { get; set; }

    /// <summary>
    /// The end of nautical twilight in the evening
    /// </summary>
    [JsonPropertyName("nautical_twilight_end")]
    public required string NauticalTwilightEnd { get; set; }

    /// <summary>
    /// The start of astronomical twilight in the evening
    /// </summary>
    [JsonPropertyName("astronomical_twilight_begin")]
    public required string AstronomicalTwilightBegin { get; set; }

    /// <summary>
    /// The end of astronomical twilight in the evening
    /// </summary>
    [JsonPropertyName("astronomical_twilight_end")]
    public required string AstronomicalTwilightEnd { get; set; }

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
