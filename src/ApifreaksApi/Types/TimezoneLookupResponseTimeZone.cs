using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record TimezoneLookupResponseTimeZone : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("offset")]
    public required double Offset { get; set; }

    [JsonPropertyName("offset_with_dst")]
    public required double OffsetWithDst { get; set; }

    [JsonPropertyName("date")]
    public required string Date { get; set; }

    [JsonPropertyName("date_time")]
    public required string DateTime { get; set; }

    [JsonPropertyName("date_time_txt")]
    public required string DateTimeTxt { get; set; }

    [JsonPropertyName("date_time_wti")]
    public required string DateTimeWti { get; set; }

    [JsonPropertyName("date_time_ymd")]
    public required string DateTimeYmd { get; set; }

    [JsonPropertyName("date_time_unix")]
    public required double DateTimeUnix { get; set; }

    [JsonPropertyName("time_24")]
    public required string Time24 { get; set; }

    [JsonPropertyName("time_12")]
    public required string Time12 { get; set; }

    [JsonPropertyName("week")]
    public required double Week { get; set; }

    [JsonPropertyName("month")]
    public required double Month { get; set; }

    [JsonPropertyName("year")]
    public required double Year { get; set; }

    [JsonPropertyName("year_abbr")]
    public required string YearAbbr { get; set; }

    [JsonPropertyName("current_tz_abbreviation")]
    public required string CurrentTzAbbreviation { get; set; }

    [JsonPropertyName("current_tz_full_name")]
    public required string CurrentTzFullName { get; set; }

    [JsonPropertyName("standard_tz_abbreviation")]
    public required string StandardTzAbbreviation { get; set; }

    [JsonPropertyName("standard_tz_full_name")]
    public required string StandardTzFullName { get; set; }

    [JsonPropertyName("is_dst")]
    public required bool IsDst { get; set; }

    [JsonPropertyName("dst_savings")]
    public required double DstSavings { get; set; }

    [JsonPropertyName("dst_exists")]
    public required bool DstExists { get; set; }

    [JsonPropertyName("dst_start")]
    public TimezoneLookupResponseTimeZoneDstStart? DstStart { get; set; }

    [JsonPropertyName("dst_end")]
    public TimezoneLookupResponseTimeZoneDstEnd? DstEnd { get; set; }

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

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
