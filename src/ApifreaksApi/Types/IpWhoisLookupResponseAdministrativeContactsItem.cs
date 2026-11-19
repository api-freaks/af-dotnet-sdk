using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record IpWhoisLookupResponseAdministrativeContactsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("handle")]
    public string? Handle { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public IEnumerable<string>? Email { get; set; }

    [JsonPropertyName("phone")]
    public IEnumerable<string>? Phone { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// Abuse mailbox email addresses for this contact.
    /// </summary>
    [JsonPropertyName("abuse_mailbox")]
    public IEnumerable<string>? AbuseMailbox { get; set; }

    /// <summary>
    /// Address lines for this contact.
    /// </summary>
    [JsonPropertyName("address")]
    public IEnumerable<string>? Address { get; set; }

    /// <summary>
    /// Handles of admin persons or roles linked to this contact.
    /// </summary>
    [JsonPropertyName("admin_contacts")]
    public IEnumerable<string>? AdminContacts { get; set; }

    /// <summary>
    /// Parsed city from the address field.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Parsed country from the address field.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Registration date of this contact object (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("date_created")]
    public DateOnly? DateCreated { get; set; }

    /// <summary>
    /// Last update date of this contact object (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("date_updated")]
    public DateOnly? DateUpdated { get; set; }

    /// <summary>
    /// Parsed district from the address field.
    /// </summary>
    [JsonPropertyName("district")]
    public string? District { get; set; }

    /// <summary>
    /// Fax numbers for this contact.
    /// </summary>
    [JsonPropertyName("fax_no")]
    public IEnumerable<string>? FaxNo { get; set; }

    /// <summary>
    /// Maintainer handles for this contact object.
    /// </summary>
    [JsonPropertyName("mnt_by")]
    public IEnumerable<string>? MntBy { get; set; }

    /// <summary>
    /// Referenced maintainer handles for this contact object.
    /// </summary>
    [JsonPropertyName("mnt_ref")]
    public IEnumerable<string>? MntRef { get; set; }

    /// <summary>
    /// Notify email addresses for this contact object.
    /// </summary>
    [JsonPropertyName("notify")]
    public IEnumerable<string>? Notify { get; set; }

    /// <summary>
    /// Handles of organization objects managing this contact.
    /// </summary>
    [JsonPropertyName("organizations")]
    public IEnumerable<string>? Organizations { get; set; }

    /// <summary>
    /// Remarks for this contact object.
    /// </summary>
    [JsonPropertyName("remarks")]
    public IEnumerable<string>? Remarks { get; set; }

    /// <summary>
    /// Parsed state from the address field.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Parsed street address from the address field.
    /// </summary>
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    /// <summary>
    /// Handles of technical persons or roles linked to this contact.
    /// </summary>
    [JsonPropertyName("tech_contacts")]
    public IEnumerable<string>? TechContacts { get; set; }

    /// <summary>
    /// Parsed ZIP code from the address field.
    /// </summary>
    [JsonPropertyName("zip_code")]
    public string? ZipCode { get; set; }

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
