using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record IpWhoisLookupResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("status")]
    public bool? Status { get; set; }

    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("query_time")]
    public string? QueryTime { get; set; }

    [JsonPropertyName("whois_server")]
    public string? WhoisServer { get; set; }

    [JsonPropertyName("inet_nums")]
    public IEnumerable<IpWhoisLookupResponseInetNumsItem>? InetNums { get; set; }

    [JsonPropertyName("irt")]
    public IpWhoisLookupResponseIrt? Irt { get; set; }

    [JsonPropertyName("organization")]
    public IpWhoisLookupResponseOrganization? Organization { get; set; }

    [JsonPropertyName("technical_contacts")]
    public IEnumerable<IpWhoisLookupResponseTechnicalContactsItem>? TechnicalContacts { get; set; }

    [JsonPropertyName("abuse_contacts")]
    public IEnumerable<IpWhoisLookupResponseAbuseContactsItem>? AbuseContacts { get; set; }

    [JsonPropertyName("administrative_contacts")]
    public IEnumerable<IpWhoisLookupResponseAdministrativeContactsItem>? AdministrativeContacts { get; set; }

    [JsonPropertyName("whois_raw_response")]
    public string? WhoisRawResponse { get; set; }

    /// <summary>
    /// BGP route objects announced by this IP's network.
    /// </summary>
    [JsonPropertyName("routes")]
    public IEnumerable<IpWhoisLookupResponseRoutesItem>? Routes { get; set; }

    /// <summary>
    /// WHOIS response from the rwhois server, if available.
    /// </summary>
    [JsonPropertyName("r_whois_raw_response")]
    public string? RWhoisRawResponse { get; set; }

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
