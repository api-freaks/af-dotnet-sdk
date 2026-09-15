using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record GeolocationLookupV2Request
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Format of the response.
    /// </summary>
    [JsonIgnore]
    public GeolocationLookupV2RequestFormat? Format { get; set; }

    /// <summary>
    /// IPv4, IPv6, or hostname for geolocation lookup.
    /// </summary>
    [JsonIgnore]
    public string? Ip { get; set; }

    /// <summary>
    /// Response language for location fields. Default: en.
    /// </summary>
    [JsonIgnore]
    public GeolocationLookupV2RequestLang? Lang { get; set; }

    /// <summary>
    /// Comma-separated list of fields to include in response. For example, `location` includes all location fields, `location.city` is a specific field.
    /// </summary>
    [JsonIgnore]
    public string? Fields { get; set; }

    /// <summary>
    /// Comma-separated list of fields to exclude from response.
    /// </summary>
    [JsonIgnore]
    public string? Excludes { get; set; }

    /// <summary>
    /// Comma-separated list of additional data modules to include. Possible values: security (threat intelligence), hostname (IP-Hostname lookup), liveHostname (live hostname lookup), hostnameFallbackLive (hostname with live fallback), user_agent (parse User-Agent header), abuse (abuse contact info), dma_code (DMA code), geo_accuracy (accuracy_radius, confidence, locality), * (all modules).
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
