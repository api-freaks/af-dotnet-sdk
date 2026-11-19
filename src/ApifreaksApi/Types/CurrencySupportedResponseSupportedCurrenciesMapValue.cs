using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CurrencySupportedResponseSupportedCurrenciesMapValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("currencyCode")]
    public required string CurrencyCode { get; set; }

    /// <summary>
    /// Currency name; null for some entries (e.g. crypto tokens).
    /// </summary>
    [JsonPropertyName("currencyName")]
    public string? CurrencyName { get; set; }

    /// <summary>
    /// Country code; null for currencies not tied to a country.
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Country name; null for currencies not tied to a country.
    /// </summary>
    [JsonPropertyName("countryName")]
    public string? CountryName { get; set; }

    [JsonPropertyName("status")]
    public required CurrencySupportedResponseSupportedCurrenciesMapValueStatus Status { get; set; }

    [JsonPropertyName("availableFrom")]
    public required string AvailableFrom { get; set; }

    [JsonPropertyName("availableUntil")]
    public required string AvailableUntil { get; set; }

    [JsonPropertyName("icon")]
    public required string Icon { get; set; }

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
