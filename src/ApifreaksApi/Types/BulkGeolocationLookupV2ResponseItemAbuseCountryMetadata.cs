using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Country-specific metadata.
/// </summary>
[Serializable]
public record BulkGeolocationLookupV2ResponseItemAbuseCountryMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Calling code/Dialing code of the country.
    /// </summary>
    [JsonPropertyName("calling_code")]
    public required string CallingCode { get; set; }

    /// <summary>
    /// Top Level Domain Name (TLD) of the country, which is also called ccTLD.
    /// </summary>
    [JsonPropertyName("tld")]
    public required string Tld { get; set; }

    /// <summary>
    /// List of the languages' codes, spoken in the country.
    /// </summary>
    [JsonPropertyName("languages")]
    public IEnumerable<string> Languages { get; set; } = new List<string>();

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
