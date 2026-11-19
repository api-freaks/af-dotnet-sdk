using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record IpWhoisLookupResponseIrt : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("handle")]
    public string? Handle { get; set; }

    [JsonPropertyName("address")]
    public IEnumerable<string>? Address { get; set; }

    [JsonPropertyName("street")]
    public string? Street { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("district")]
    public string? District { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("zip_code")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("email")]
    public IEnumerable<string>? Email { get; set; }

    [JsonPropertyName("abuse_mailbox")]
    public IEnumerable<string>? AbuseMailbox { get; set; }

    [JsonPropertyName("phone")]
    public IEnumerable<string>? Phone { get; set; }

    [JsonPropertyName("fax_no")]
    public IEnumerable<string>? FaxNo { get; set; }

    [JsonPropertyName("organizations")]
    public IEnumerable<string>? Organizations { get; set; }

    [JsonPropertyName("admin_contacts")]
    public IEnumerable<string>? AdminContacts { get; set; }

    [JsonPropertyName("tech_contacts")]
    public IEnumerable<string>? TechContacts { get; set; }

    [JsonPropertyName("remarks")]
    public IEnumerable<string>? Remarks { get; set; }

    [JsonPropertyName("signature")]
    public IEnumerable<string>? Signature { get; set; }

    [JsonPropertyName("encryption")]
    public IEnumerable<string>? Encryption { get; set; }

    [JsonPropertyName("auth")]
    public IEnumerable<string>? Auth { get; set; }

    [JsonPropertyName("notify")]
    public IEnumerable<string>? Notify { get; set; }

    [JsonPropertyName("irt_nfy")]
    public IEnumerable<string>? IrtNfy { get; set; }

    [JsonPropertyName("mnt_by")]
    public IEnumerable<string>? MntBy { get; set; }

    [JsonPropertyName("mnt_ref")]
    public IEnumerable<string>? MntRef { get; set; }

    [JsonPropertyName("date_created")]
    public string? DateCreated { get; set; }

    [JsonPropertyName("date_updated")]
    public string? DateUpdated { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// Abuse contacts linked to this IRT.
    /// </summary>
    [JsonPropertyName("abuse_contacts")]
    public IEnumerable<IpWhoisLookupResponseIrtAbuseContactsItem>? AbuseContacts { get; set; }

    /// <summary>
    /// Administrative contacts linked to this IRT.
    /// </summary>
    [JsonPropertyName("administrative_contacts")]
    public IEnumerable<IpWhoisLookupResponseIrtAdministrativeContactsItem>? AdministrativeContacts { get; set; }

    /// <summary>
    /// Organization object containing the registrant's handle, name, address, contact details, and linked admin/tech/abuse contacts.
    /// </summary>
    [JsonPropertyName("organization")]
    public IpWhoisLookupResponseIrtOrganization? Organization { get; set; }

    /// <summary>
    /// Technical contacts linked to this IRT.
    /// </summary>
    [JsonPropertyName("technical_contacts")]
    public IEnumerable<IpWhoisLookupResponseIrtTechnicalContactsItem>? TechnicalContacts { get; set; }

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
