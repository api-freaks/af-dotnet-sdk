using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Organization object containing the registrant's handle, name, address, contact details, and linked admin/tech/abuse contacts.
/// </summary>
[Serializable]
public record IpWhoisLookupResponseIrtOrganization : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Handle or unique identifier of this organization in WHOIS data.
    /// </summary>
    [JsonPropertyName("handle")]
    public required string Handle { get; set; }

    /// <summary>
    /// Name of the organization.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Type of the organization (e.g., BUSINESS, REGISTRY).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Description values from the organization object.
    /// </summary>
    [JsonPropertyName("description")]
    public IEnumerable<string>? Description { get; set; }

    /// <summary>
    /// Full address lines of the organization.
    /// </summary>
    [JsonPropertyName("address")]
    public IEnumerable<string>? Address { get; set; }

    /// <summary>
    /// Parsed street address from the address field.
    /// </summary>
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    /// <summary>
    /// Parsed city from the address field.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Parsed district from the address field.
    /// </summary>
    [JsonPropertyName("district")]
    public string? District { get; set; }

    /// <summary>
    /// Parsed state from the address field.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Parsed ZIP code from the address field.
    /// </summary>
    [JsonPropertyName("zip_code")]
    public string? ZipCode { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 country codes for the organization.
    /// </summary>
    [JsonPropertyName("country")]
    public IEnumerable<string>? Country { get; set; }

    /// <summary>
    /// Latitude parsed from the geoloc field.
    /// </summary>
    [JsonPropertyName("latitude")]
    public float? Latitude { get; set; }

    /// <summary>
    /// Longitude parsed from the geoloc field.
    /// </summary>
    [JsonPropertyName("longitude")]
    public float? Longitude { get; set; }

    /// <summary>
    /// Email addresses for the organization.
    /// </summary>
    [JsonPropertyName("email")]
    public IEnumerable<string>? Email { get; set; }

    /// <summary>
    /// Abuse mailbox email addresses for the organization.
    /// </summary>
    [JsonPropertyName("abuse_mailbox")]
    public IEnumerable<string>? AbuseMailbox { get; set; }

    /// <summary>
    /// Phone numbers for the organization.
    /// </summary>
    [JsonPropertyName("phone")]
    public IEnumerable<string>? Phone { get; set; }

    /// <summary>
    /// Fax numbers for the organization.
    /// </summary>
    [JsonPropertyName("fax_no")]
    public IEnumerable<string>? FaxNo { get; set; }

    /// <summary>
    /// Handles of admin persons or roles linked to this organization.
    /// </summary>
    [JsonPropertyName("admin_contacts")]
    public IEnumerable<string>? AdminContacts { get; set; }

    /// <summary>
    /// Handles of technical persons or roles linked to this organization.
    /// </summary>
    [JsonPropertyName("tech_contacts")]
    public IEnumerable<string>? TechContacts { get; set; }

    /// <summary>
    /// Handles of abuse persons or roles linked to this organization.
    /// </summary>
    [JsonPropertyName("abuse_contacts")]
    public IEnumerable<string>? AbuseContacts { get; set; }

    /// <summary>
    /// Remarks for this organization object.
    /// </summary>
    [JsonPropertyName("remarks")]
    public IEnumerable<string>? Remarks { get; set; }

    /// <summary>
    /// Notify email addresses for this organization object.
    /// </summary>
    [JsonPropertyName("notify")]
    public IEnumerable<string>? Notify { get; set; }

    /// <summary>
    /// Reference notification email addresses for this organization object.
    /// </summary>
    [JsonPropertyName("ref_nfy")]
    public IEnumerable<string>? RefNfy { get; set; }

    /// <summary>
    /// Maintainer handles for this organization object.
    /// </summary>
    [JsonPropertyName("mnt_by")]
    public IEnumerable<string>? MntBy { get; set; }

    /// <summary>
    /// Referenced maintainer handles for this organization object.
    /// </summary>
    [JsonPropertyName("mnt_ref")]
    public IEnumerable<string>? MntRef { get; set; }

    /// <summary>
    /// Registration date of this organization object (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("date_created")]
    public DateOnly? DateCreated { get; set; }

    /// <summary>
    /// Last update date of this organization object (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("date_updated")]
    public DateOnly? DateUpdated { get; set; }

    /// <summary>
    /// WHOIS data source (RIR registry URL) for this object.
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

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
