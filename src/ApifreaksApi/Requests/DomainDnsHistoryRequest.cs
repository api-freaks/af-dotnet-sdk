using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainDnsHistoryRequest
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
    public DomainDnsHistoryRequestFormat? Format { get; set; }

    /// <summary>
    /// Hostname or URL whose historical DNS records are required
    /// </summary>
    [JsonIgnore]
    public required string HostName { get; set; }

    /// <summary>
    /// DNS record types to look up, sent as a comma-separated list (e.g. `A,MX`). Possible values: A, AAAA, MX, NS, SOA, SPF, TXT, CNAME, or all.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Type { get; set; } = new List<string>();

    /// <summary>
    /// Page number for paginated results
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
