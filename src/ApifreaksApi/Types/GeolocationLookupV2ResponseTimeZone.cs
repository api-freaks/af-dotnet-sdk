using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Time zone information for the IP's location.
/// </summary>
[Serializable]
public record GeolocationLookupV2ResponseTimeZone : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Time zone in IANA TZDB format.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Standard time UTC offset in hours.
    /// </summary>
    [JsonPropertyName("offset")]
    public required float Offset { get; set; }

    /// <summary>
    /// Current effective UTC offset in hours, including DST.
    /// </summary>
    [JsonPropertyName("offset_with_dst")]
    public required float OffsetWithDst { get; set; }

    /// <summary>
    /// Local date/time in YYYY-MM-DD HH:mm:ss.SSS±ZZZZ format.
    /// </summary>
    [JsonPropertyName("current_time")]
    public required string CurrentTime { get; set; }

    /// <summary>
    /// Local time as Unix epoch seconds.
    /// </summary>
    [JsonPropertyName("current_time_unix")]
    public required float CurrentTimeUnix { get; set; }

    /// <summary>
    /// Current time zone abbreviation.
    /// </summary>
    [JsonPropertyName("current_tz_abbreviation")]
    public string? CurrentTzAbbreviation { get; set; }

    /// <summary>
    /// Current time zone full name.
    /// </summary>
    [JsonPropertyName("current_tz_full_name")]
    public string? CurrentTzFullName { get; set; }

    /// <summary>
    /// Standard (non-DST) abbreviation.
    /// </summary>
    [JsonPropertyName("standard_tz_abbreviation")]
    public string? StandardTzAbbreviation { get; set; }

    /// <summary>
    /// Standard (non-DST) full name.
    /// </summary>
    [JsonPropertyName("standard_tz_full_name")]
    public string? StandardTzFullName { get; set; }

    /// <summary>
    /// true if DST is active.
    /// </summary>
    [JsonPropertyName("is_dst")]
    public required bool IsDst { get; set; }

    /// <summary>
    /// DST shift amount in hours.
    /// </summary>
    [JsonPropertyName("dst_savings")]
    public required float DstSavings { get; set; }

    /// <summary>
    /// true if the time zone observes DST.
    /// </summary>
    [JsonPropertyName("dst_exists")]
    public required bool DstExists { get; set; }

    /// <summary>
    /// DST abbreviation when DST is active.
    /// </summary>
    [JsonPropertyName("dst_tz_abbreviation")]
    public string? DstTzAbbreviation { get; set; }

    /// <summary>
    /// DST full name when DST is active.
    /// </summary>
    [JsonPropertyName("dst_tz_full_name")]
    public string? DstTzFullName { get; set; }

    /// <summary>
    /// DST transition details (used for both the DST start and DST end transitions).
    /// </summary>
    [JsonPropertyName("dst_start")]
    public GeolocationLookupV2ResponseTimeZoneDstStart? DstStart { get; set; }

    /// <summary>
    /// DST transition details (used for both the DST start and DST end transitions).
    /// </summary>
    [JsonPropertyName("dst_end")]
    public GeolocationLookupV2ResponseTimeZoneDstEnd? DstEnd { get; set; }

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
