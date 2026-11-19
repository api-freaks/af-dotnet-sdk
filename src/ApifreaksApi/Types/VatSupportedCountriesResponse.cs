using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record VatSupportedCountriesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("VAT_Supported_Countries_And_States")]
    public IEnumerable<
        Dictionary<string, VatSupportedCountriesResponseVatSupportedCountriesAndStatesItemValue>
    >? VatSupportedCountriesAndStates { get; set; }

    /// <summary>
    /// Array of countries supported by the IBAN Validation API.
    /// </summary>
    [JsonPropertyName("IBAN_Supported_Countries")]
    public IEnumerable<VatSupportedCountriesResponseIbanSupportedCountriesItem>? IbanSupportedCountries { get; set; }

    /// <summary>
    /// Array of countries supported by the SWIFT/BIC Code Lookup and Finder APIs.
    /// </summary>
    [JsonPropertyName("SWIFT_Supported_Countries")]
    public IEnumerable<VatSupportedCountriesResponseSwiftSupportedCountriesItem>? SwiftSupportedCountries { get; set; }

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
