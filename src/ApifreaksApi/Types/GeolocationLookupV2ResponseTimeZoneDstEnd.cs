using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// DST transition details (used for both the DST start and DST end transitions).
/// </summary>
[Serializable]
public record GeolocationLookupV2ResponseTimeZoneDstEnd : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// DST transition moment in UTC.
    /// </summary>
    [JsonPropertyName("utc_time")]
    public string? UtcTime { get; set; }

    /// <summary>
    /// Clock change at the DST transition, in hours.
    /// </summary>
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    /// <summary>
    /// true if local time jumps forward (some times do not exist).
    /// </summary>
    [JsonPropertyName("gap")]
    public bool? Gap { get; set; }

    /// <summary>
    /// Local date/time immediately after the DST transition.
    /// </summary>
    [JsonPropertyName("date_time_after")]
    public string? DateTimeAfter { get; set; }

    /// <summary>
    /// Local date/time immediately before the DST transition.
    /// </summary>
    [JsonPropertyName("date_time_before")]
    public string? DateTimeBefore { get; set; }

    /// <summary>
    /// true if local times repeat around the DST transition.
    /// </summary>
    [JsonPropertyName("overlap")]
    public bool? Overlap { get; set; }

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
