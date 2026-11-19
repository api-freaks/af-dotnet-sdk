using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record SwiftCodeLookupResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("swiftCode")]
    public required string SwiftCode { get; set; }

    [JsonPropertyName("countryCode")]
    public required string CountryCode { get; set; }

    [JsonPropertyName("bankAddress")]
    public required string BankAddress { get; set; }

    [JsonPropertyName("bankCode")]
    public required string BankCode { get; set; }

    [JsonPropertyName("bankName")]
    public required string BankName { get; set; }

    [JsonPropertyName("city")]
    public required string City { get; set; }

    [JsonPropertyName("country")]
    public required string Country { get; set; }

    /// <summary>
    /// Name of the branch or office. Null when not resolvable.
    /// </summary>
    [JsonPropertyName("branchName")]
    public string? BranchName { get; set; }

    /// <summary>
    /// Type of institution: "FIIN" (financial institution) or "NFIN" (non-financial institution).
    /// </summary>
    [JsonPropertyName("institType")]
    public string? InstitType { get; set; }

    /// <summary>
    /// Postal/ZIP code of the bank branch. Null when not resolvable.
    /// </summary>
    [JsonPropertyName("postalCode")]
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
