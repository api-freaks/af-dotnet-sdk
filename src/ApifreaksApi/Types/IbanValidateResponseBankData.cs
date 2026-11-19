using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Object contains Bank and BIC details.
/// </summary>
[Serializable]
public record IbanValidateResponseBankData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// SWIFT/BIC code extracted from IBAN for some countries.
    /// </summary>
    [JsonPropertyName("bic")]
    public string? Bic { get; set; }

    /// <summary>
    /// Bank name extracted from IBAN for some countries.
    /// </summary>
    [JsonPropertyName("bank")]
    public string? Bank { get; set; }

    /// <summary>
    /// Bank code extracted from IBAN for some countries.
    /// </summary>
    [JsonPropertyName("bank_code")]
    public string? BankCode { get; set; }

    /// <summary>
    /// Branch code extracted from IBAN for some countries.
    /// </summary>
    [JsonPropertyName("branch_code")]
    public string? BranchCode { get; set; }

    /// <summary>
    /// Country name extracted from IBAN.
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; set; }

    /// <summary>
    /// Alpha-2 standard country code extracted from IBAN.
    /// </summary>
    [JsonPropertyName("country_iso2")]
    public required string CountryIso2 { get; set; }

    /// <summary>
    /// City / branch name for respective bank extracted from IBAN for some countries.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Bank branch address extracted from IBAN
    /// </summary>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Account number extracted from IBAN
    /// </summary>
    [JsonPropertyName("account")]
    public string? Account { get; set; }

    /// <summary>
    /// Indicates whether given IBAN country supports Single Euro Payments Area (SEPA)
    /// </summary>
    [JsonPropertyName("sepa")]
    public required bool Sepa { get; set; }

    /// <summary>
    /// Name of the branch or office. Null when not resolvable.
    /// </summary>
    [JsonPropertyName("branch_name")]
    public string? BranchName { get; set; }

    /// <summary>
    /// Type of institution: "FIIN" (financial institution) or "NFIN" (non-financial institution). Null when not resolvable.
    /// </summary>
    [JsonPropertyName("instit_type")]
    public string? InstitType { get; set; }

    /// <summary>
    /// Postal/ZIP code of the bank branch. Null when not resolvable.
    /// </summary>
    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

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
