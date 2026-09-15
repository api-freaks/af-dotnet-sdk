using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record AstronomyLookupV2Request
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Format of the response. Can be "json" or "xml".
    /// </summary>
    [JsonIgnore]
    public AstronomyLookupV2RequestFormat? Format { get; set; }

    /// <summary>
    /// Extract astronomy information using location (preferably city)
    /// </summary>
    [JsonIgnore]
    public string? Location { get; set; }

    /// <summary>
    /// Latitude to extract astronomy information using location coordinates
    /// </summary>
    [JsonIgnore]
    public float? Lat { get; set; }

    /// <summary>
    /// Longitude to extract astronomy information using location coordinates
    /// </summary>
    [JsonIgnore]
    public float? Long { get; set; }

    /// <summary>
    /// IPv4 or IPv6 address to extract astronomy information using IP address
    /// </summary>
    [JsonIgnore]
    public string? Ip { get; set; }

    /// <summary>
    /// Response language of "location" field in case of lookup through IP address only.
    /// </summary>
    [JsonIgnore]
    public AstronomyLookupV2RequestLang? Lang { get; set; }

    /// <summary>
    /// Specific date (format YYYY-MM-DD) for which astronomy data is required
    /// </summary>
    [JsonIgnore]
    public DateOnly? Date { get; set; }

    /// <summary>
    /// Elevation above sea level at the location, in meters. The value should be between 0 meter and a maximum value of 10,000 meters. Negative value is set to 0.
    /// </summary>
    [JsonIgnore]
    public float? Elevation { get; set; }

    /// <summary>
    /// Time zone to receive all time-based data in your preferred local time.
    /// </summary>
    [JsonIgnore]
    public string? TimeZone { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
