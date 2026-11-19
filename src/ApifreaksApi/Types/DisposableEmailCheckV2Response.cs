using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Disposable email check response.
/// </summary>
[Serializable]
public record DisposableEmailCheckV2Response : IJsonOnDeserialized
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
    public required DisposableEmailCheckV2ResponseDomain Domain { get; set; }

    /// <summary>
    /// Account-level detection details. Omitted entirely when validSyntax is false.
    /// </summary>
    [JsonPropertyName("account")]
    public DisposableEmailCheckV2ResponseAccount? Account { get; set; }

    /// <summary>
    /// DNS records for the email domain. Omitted entirely when validSyntax is false or the domain does not exist (NXDOMAIN).
    /// </summary>
    [JsonPropertyName("dns")]
    public DisposableEmailCheckV2ResponseDns? Dns { get; set; }

    /// <summary>
    /// The IP address that was looked up.
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// Geolocation and security enrichment data for the IP address.
    /// </summary>
    [JsonPropertyName("address")]
    public DisposableEmailCheckV2ResponseAddress? Address { get; set; }

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
