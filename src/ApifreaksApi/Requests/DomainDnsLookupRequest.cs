using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainDnsLookupRequest
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
    public DomainDnsLookupRequestFormat? Format { get; set; }

    /// <summary>
    /// Hostname or URL whose DNS records are required. Give either `host-name` or `ipAddress`.
    /// </summary>
    [JsonIgnore]
    public string? HostName { get; set; }

    /// <summary>
    /// The IP address whose PTR (reverse DNS) record is required. Give either `host-name` or `ipAddress`; with `ipAddress`, set `type` to `all` or `PTR`.
    /// </summary>
    [JsonIgnore]
    public string? IpAddress { get; set; }

    /// <summary>
    /// DNS record types to look up, sent as a comma-separated list (e.g. `A,MX`). Possible values: A, AAAA, MX, NS, SOA, SPF, TXT, CNAME, PTR, or all. When ipAddress is provided, use "all" or "PTR".
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Type { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
