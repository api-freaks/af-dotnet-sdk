using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CommodityFluctuationV2ResponseRatesValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Price of the commodity on the start date.
    /// </summary>
    [JsonPropertyName("startRate")]
    public required float StartRate { get; set; }

    /// <summary>
    /// Price of the commodity on the end date.
    /// </summary>
    [JsonPropertyName("endRate")]
    public required float EndRate { get; set; }

    /// <summary>
    /// Absolute price difference between end and start dates. May be negative.
    /// </summary>
    [JsonPropertyName("change")]
    public required float Change { get; set; }

    /// <summary>
    /// Percentage price change from start to end date. May be negative.
    /// </summary>
    [JsonPropertyName("changePercent")]
    public required float ChangePercent { get; set; }

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
