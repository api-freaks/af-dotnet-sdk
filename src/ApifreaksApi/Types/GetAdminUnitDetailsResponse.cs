using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Detailed information for a single administrative unit.
/// </summary>
[Serializable]
public record GetAdminUnitDetailsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the administrative unit.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Administrative code of the unit.
    /// </summary>
    [JsonPropertyName("admin_code")]
    public required string AdminCode { get; set; }

    /// <summary>
    /// The unit's full ISO 3166-2 code, formed as {country}-{admin_code} (e.g. US-CA, DE-BY).
    /// </summary>
    [JsonPropertyName("admin_iso3166_2")]
    public string? AdminIso31662 { get; set; }

    /// <summary>
    /// Level or type of the administrative unit (e.g. land, province, state).
    /// </summary>
    [JsonPropertyName("admin_level")]
    public required string AdminLevel { get; set; }

    /// <summary>
    /// Country code in ISO 3166-1 alpha-2 format.
    /// </summary>
    [JsonPropertyName("country_iso3166_2")]
    public required string CountryIso31662 { get; set; }

    /// <summary>
    /// Name of the country.
    /// </summary>
    [JsonPropertyName("country_name")]
    public required string CountryName { get; set; }

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
