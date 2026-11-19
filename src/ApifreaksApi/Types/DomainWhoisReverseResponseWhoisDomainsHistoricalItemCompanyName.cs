using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainWhoisReverseResponseWhoisDomainsHistoricalItemCompanyName : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("num")]
    public required int Num { get; set; }

    [JsonPropertyName("domain_name")]
    public required string DomainName { get; set; }

    [JsonPropertyName("create_date")]
    public DateOnly? CreateDate { get; set; }

    [JsonPropertyName("update_date")]
    public DateOnly? UpdateDate { get; set; }

    [JsonPropertyName("expiry_date")]
    public DateOnly? ExpiryDate { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Deprecated: the API returns this field as `company_name`; read `company_name` instead.
    /// </summary>
    [JsonPropertyName("companyname")]
    public string? Companyname { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

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
