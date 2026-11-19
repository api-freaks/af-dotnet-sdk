using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Countries and organizations that have flags available.
/// </summary>
[Serializable]
public record GetSupportedFlagsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Countries with a flag, each with its name and ISO 3166-1 alpha-2/alpha-3 codes.
    /// </summary>
    [JsonPropertyName("supported_countries")]
    public IEnumerable<GetSupportedFlagsResponseSupportedCountriesItem> SupportedCountries { get; set; } =
        new List<GetSupportedFlagsResponseSupportedCountriesItem>();

    /// <summary>
    /// Identifiers of supported organizations, usable as the flag lookup key.
    /// </summary>
    [JsonPropertyName("supported_organizations")]
    public IEnumerable<string> SupportedOrganizations { get; set; } = new List<string>();

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
