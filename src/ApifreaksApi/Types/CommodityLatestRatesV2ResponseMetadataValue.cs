using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CommodityLatestRatesV2ResponseMetadataValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unit of measurement for the commodity (e.g., Bbl, T.oz).
    /// </summary>
    [JsonPropertyName("unit")]
    public required string Unit { get; set; }

    /// <summary>
    /// Quote currency used for this commodity's price.
    /// </summary>
    [JsonPropertyName("quote")]
    public required string Quote { get; set; }

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
