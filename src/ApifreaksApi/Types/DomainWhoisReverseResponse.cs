using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record DomainWhoisReverseResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Total results found across the query.
    /// </summary>
    [JsonPropertyName("total_Result")]
    public int? TotalResult { get; set; }

    /// <summary>
    /// Total number of pages (50 records per page in default mode, 100 in mini mode).
    /// </summary>
    [JsonPropertyName("total_Pages")]
    public int? TotalPages { get; set; }

    /// <summary>
    /// Current page number.
    /// </summary>
    [JsonPropertyName("current_Page")]
    public int? CurrentPage { get; set; }

    [JsonPropertyName("whois_domains_historical")]
    public IEnumerable<
        OneOf<
            DomainWhoisReverseResponseWhoisDomainsHistoricalItemAdministrativeContact,
            DomainWhoisReverseResponseWhoisDomainsHistoricalItemCompanyName
        >
    >? WhoisDomainsHistorical { get; set; }

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
