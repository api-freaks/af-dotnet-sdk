using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record TimezoneLookupV2Request
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Format of the response. Possible values: json, xml.
    /// </summary>
    [JsonIgnore]
    public TimezoneLookupV2RequestFormat? Format { get; set; }

    /// <summary>
    /// IPv4 or IPv6 address to extract timezone information.
    /// </summary>
    [JsonIgnore]
    public string? Ip { get; set; }

    /// <summary>
    /// Timezone name in IANA format (e.g., Asia/Kolkata) to retrieve information directly.
    /// </summary>
    [JsonIgnore]
    public string? Tz { get; set; }

    /// <summary>
    /// Location string (preferably city and country) to extract timezone.
    /// </summary>
    [JsonIgnore]
    public string? Location { get; set; }

    /// <summary>
    /// Latitude for geolocation-based timezone lookup. Only time_zone is returned for this mode; no location object is included.
    /// </summary>
    [JsonIgnore]
    public float? Lat { get; set; }

    /// <summary>
    /// Longitude for geolocation-based timezone lookup. Only time_zone is returned for this mode; no location object is included.
    /// </summary>
    [JsonIgnore]
    public float? Long { get; set; }

    /// <summary>
    /// Response language for location fields. Default: en.
    /// </summary>
    [JsonIgnore]
    public TimezoneLookupV2RequestLang? Lang { get; set; }

    /// <summary>
    /// 3-letter IATA airport code (e.g., LHR) to extract timezone.
    /// </summary>
    [JsonIgnore]
    public string? IataCode { get; set; }

    /// <summary>
    /// 4-letter ICAO airport code (e.g., KJFK) to extract timezone.
    /// </summary>
    [JsonIgnore]
    public string? IcaoCode { get; set; }

    /// <summary>
    /// 5-letter UN/LOCODE city code to extract timezone.
    /// </summary>
    [JsonIgnore]
    public string? LoCode { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
