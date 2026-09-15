using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkDomainWhoisLookupV2Request
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
    public BulkDomainWhoisLookupV2RequestFormat? Format { get; set; }

    /// <summary>
    /// List of domain names to retrieve WHOIS data for.
    /// </summary>
    [JsonPropertyName("domainNames")]
    public IEnumerable<string> DomainNames { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
