using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkVatRateByCountryResponseItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Country identifier in Alpha-2 (US), Alpha-3 (USA), or full name (United_States). Case-insensitive and may use underscores.
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; set; }

    /// <summary>
    /// Optional state identifier in Alpha-2 (NY) or full name (New_York). Required only for state-level taxation. Case-insensitive and may use underscores.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// Tax type applied for the country or state. Possible values include vat or none.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// ISO 4217 currency code.
    /// </summary>
    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    /// <summary>
    /// Standard VAT or sales tax rate. Zero indicates no tax.
    /// </summary>
    [JsonPropertyName("standard_rate")]
    public required float StandardRate { get; set; }

    /// <summary>
    /// Optional reduced VAT rates applicable in the country.
    /// </summary>
    [JsonPropertyName("reduced_rate")]
    public IEnumerable<float>? ReducedRate { get; set; }

    /// <summary>
    /// Optional super-reduced VAT rates applicable in specific categories.
    /// </summary>
    [JsonPropertyName("super_reduced_rate")]
    public IEnumerable<float>? SuperReducedRate { get; set; }

    [JsonPropertyName("parking_rate")]
    public float? ParkingRate { get; set; }

    /// <summary>
    /// Optional category-wise VAT rates.
    /// </summary>
    [JsonPropertyName("categories")]
    public Dictionary<string, float>? Categories { get; set; }

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
