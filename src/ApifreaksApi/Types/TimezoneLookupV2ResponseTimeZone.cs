using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Timezone and date/time information for the location.
/// </summary>
[Serializable]
public record TimezoneLookupV2ResponseTimeZone : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The IANA timezone name/identifier for the location.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The Standard time zone offset from UTC in hours.
    /// </summary>
    [JsonPropertyName("offset")]
    public required float Offset { get; set; }

    /// <summary>
    /// The time zone offset from UTC in hours, accounting for DST.
    /// </summary>
    [JsonPropertyName("offset_with_dst")]
    public required float OffsetWithDst { get; set; }

    /// <summary>
    /// The current date and time with timezone offset in YYYY-MM-DD HH:mm:ss.SSS±ZZZZ format.
    /// </summary>
    [JsonPropertyName("current_time")]
    public required string CurrentTime { get; set; }

    /// <summary>
    /// The Unix timestamp representing the date and time in seconds.
    /// </summary>
    [JsonPropertyName("current_time_unix")]
    public required float CurrentTimeUnix { get; set; }

    /// <summary>
    /// The current date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("date")]
    public required string Date { get; set; }

    /// <summary>
    /// The current date and time in YYYY-MM-DD HH:mm:ss format.
    /// </summary>
    [JsonPropertyName("date_time")]
    public required string DateTime { get; set; }

    /// <summary>
    /// The current date and time in descriptive format EEEE, MMMM dd, yyyy HH:mm:ss.
    /// </summary>
    [JsonPropertyName("date_time_txt")]
    public required string DateTimeTxt { get; set; }

    /// <summary>
    /// The date and time with time zone information in EEE, dd MMM yyyy HH:mm:ss Z format.
    /// </summary>
    [JsonPropertyName("date_time_wti")]
    public required string DateTimeWti { get; set; }

    /// <summary>
    /// The date and time with timezone offset in ISO 8601 format YYYY-MM-DDTHH:mm:ss±HHMM.
    /// </summary>
    [JsonPropertyName("date_time_ymd")]
    public required string DateTimeYmd { get; set; }

    /// <summary>
    /// The current time in 24-hour format HH:mm:ss.
    /// </summary>
    [JsonPropertyName("time_24")]
    public required string Time24 { get; set; }

    /// <summary>
    /// The current time in 12-hour format with AM/PM notation.
    /// </summary>
    [JsonPropertyName("time_12")]
    public required string Time12 { get; set; }

    /// <summary>
    /// The week number of the year (1-52).
    /// </summary>
    [JsonPropertyName("week")]
    public required int Week { get; set; }

    /// <summary>
    /// The current month as a number (1-12).
    /// </summary>
    [JsonPropertyName("month")]
    public required int Month { get; set; }

    /// <summary>
    /// The four-digit current year.
    /// </summary>
    [JsonPropertyName("year")]
    public required int Year { get; set; }

    /// <summary>
    /// The two-digit abbreviation for the year.
    /// </summary>
    [JsonPropertyName("year_abbr")]
    public required string YearAbbr { get; set; }

    /// <summary>
    /// Abbreviation of the time zone currently in effect (standard or DST).
    /// </summary>
    [JsonPropertyName("current_tz_abbreviation")]
    public required string CurrentTzAbbreviation { get; set; }

    /// <summary>
    /// Full name of the time zone currently in effect.
    /// </summary>
    [JsonPropertyName("current_tz_full_name")]
    public required string CurrentTzFullName { get; set; }

    /// <summary>
    /// Abbreviation of the standard (non-DST) time zone.
    /// </summary>
    [JsonPropertyName("standard_tz_abbreviation")]
    public required string StandardTzAbbreviation { get; set; }

    /// <summary>
    /// Full name of the standard (non-DST) time zone.
    /// </summary>
    [JsonPropertyName("standard_tz_full_name")]
    public required string StandardTzFullName { get; set; }

    /// <summary>
    /// Is the time zone in daylight savings?
    /// </summary>
    [JsonPropertyName("is_dst")]
    public required bool IsDst { get; set; }

    /// <summary>
    /// Abbreviation of the DST time zone. Always present as a key; holds an empty string when dst_exists is false.
    /// </summary>
    [JsonPropertyName("dst_tz_abbreviation")]
    public string? DstTzAbbreviation { get; set; }

    /// <summary>
    /// Full name of the DST time zone. Always present as a key; holds an empty string when dst_exists is false.
    /// </summary>
    [JsonPropertyName("dst_tz_full_name")]
    public string? DstTzFullName { get; set; }

    /// <summary>
    /// The amount of time added for daylight saving in hours.
    /// </summary>
    [JsonPropertyName("dst_savings")]
    public required float DstSavings { get; set; }

    /// <summary>
    /// Indicates whether DST is observed in the region.
    /// </summary>
    [JsonPropertyName("dst_exists")]
    public required bool DstExists { get; set; }

    /// <summary>
    /// DST transition details (used for both the DST start and DST end transitions). Always present as a key on the parent TimeZone object; returned as an empty object {} when dst_exists is false, so none of its properties are required.
    /// </summary>
    [JsonPropertyName("dst_start")]
    public TimezoneLookupV2ResponseTimeZoneDstStart? DstStart { get; set; }

    /// <summary>
    /// DST transition details (used for both the DST start and DST end transitions). Always present as a key on the parent TimeZone object; returned as an empty object {} when dst_exists is false, so none of its properties are required.
    /// </summary>
    [JsonPropertyName("dst_end")]
    public TimezoneLookupV2ResponseTimeZoneDstEnd? DstEnd { get; set; }

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
