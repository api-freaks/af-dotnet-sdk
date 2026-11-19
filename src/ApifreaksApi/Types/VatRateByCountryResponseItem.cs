using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record VatRateByCountryResponseItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("country")]
    public required string Country { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("currency")]
    public required string Currency { get; set; }

    [JsonPropertyName("standard_rate")]
    public required float StandardRate { get; set; }

    [JsonPropertyName("reduced_rate")]
    public IEnumerable<float>? ReducedRate { get; set; }

    /// <summary>
    /// Optional super-reduced VAT rates applicable in specific categories.
    /// </summary>
    [JsonPropertyName("super_reduced_rate")]
    public IEnumerable<float>? SuperReducedRate { get; set; }

    [JsonPropertyName("parking_rate")]
    public float? ParkingRate { get; set; }

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
