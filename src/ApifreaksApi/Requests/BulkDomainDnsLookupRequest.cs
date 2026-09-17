using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkDomainDnsLookupRequest
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
    public BulkDomainDnsLookupRequestFormat? Format { get; set; }

    /// <summary>
    /// A comma-separated list of DNS record types for lookup.
    /// Possible values: A, AAAA, MX, NS, SOA, SPF, TXT, CNAME, or all
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Type { get; set; } = new List<string>();

    /// <summary>
    /// List of hostnames to lookup DNS records for
    /// </summary>
    [JsonPropertyName("domainNames")]
    public IEnumerable<string> DomainNames { get; set; } = new List<string>();

    /// <summary>
    /// Array of IP addresses to include in the lookup for PTR record enrichment.
    /// </summary>
    [JsonPropertyName("ipAddresses")]
    public IEnumerable<string>? IpAddresses { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
