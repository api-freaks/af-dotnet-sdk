using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Disposable email check result for a single item in the bulk request.
/// </summary>
[Serializable]
public record BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The email address submitted for the check.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// Validates email address format compliance with RFC 5322 standards. When false, domain only contains name/validDomain and account/dns are omitted entirely.
    /// </summary>
    [JsonPropertyName("validSyntax")]
    public required bool ValidSyntax { get; set; }

    /// <summary>
    /// Domain-level disposable/spam/free classification for the email address.
    /// </summary>
    [JsonPropertyName("domain")]
    public required BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItemDomain Domain { get; set; }

    /// <summary>
    /// Account-level detection details. Omitted entirely when validSyntax is false.
    /// </summary>
    [JsonPropertyName("account")]
    public BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItemAccount? Account { get; set; }

    /// <summary>
    /// DNS records for the email domain. Omitted entirely when validSyntax is false or the domain does not exist (NXDOMAIN).
    /// </summary>
    [JsonPropertyName("dns")]
    public BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItemDns? Dns { get; set; }

    /// <summary>
    /// The IP address that was looked up.
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// Geolocation and security enrichment data for the IP address.
    /// </summary>
    [JsonPropertyName("address")]
    public BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItemAddress? Address { get; set; }

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
