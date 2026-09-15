using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkGeolocationLookupV2Request
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
    public BulkGeolocationLookupV2RequestFormat? Format { get; set; }

    /// <summary>
    /// Response language for location fields. Default: en.
    /// </summary>
    [JsonIgnore]
    public BulkGeolocationLookupV2RequestLang? Lang { get; set; }

    /// <summary>
    /// Comma-separated list of fields to include in the response. For example, `location` includes all location fields, `location.city` is a specific field.
    /// </summary>
    [JsonIgnore]
    public string? Fields { get; set; }

    /// <summary>
    /// Comma-separated list of fields to exclude from response.
    /// </summary>
    [JsonIgnore]
    public string? Excludes { get; set; }

    /// <summary>
    /// Comma-separated list of additional data modules to include. Possible values: security (threat intelligence), hostname (IP-Hostname lookup), liveHostname (live hostname lookup), user_agent (parse User-Agent header), abuse (abuse contact info), * (all modules).
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <summary>
    /// List of IP addresses or hostnames to lookup.
    /// </summary>
    [JsonPropertyName("ips")]
    public IEnumerable<string> Ips { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
