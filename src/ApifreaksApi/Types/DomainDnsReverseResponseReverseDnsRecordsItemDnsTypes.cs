using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainDnsReverseResponseReverseDnsRecordsItemDnsTypes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("A")]
    public double? A { get; set; }

    [JsonPropertyName("AAAA")]
    public double? Aaaa { get; set; }

    [JsonPropertyName("CNAME")]
    public double? Cname { get; set; }

    [JsonPropertyName("MX")]
    public double? Mx { get; set; }

    [JsonPropertyName("NS")]
    public double? Ns { get; set; }

    [JsonPropertyName("SOA")]
    public double? Soa { get; set; }

    [JsonPropertyName("TXT")]
    public double? Txt { get; set; }

    [JsonPropertyName("SPF")]
    public double? Spf { get; set; }

    [JsonPropertyName("PTR")]
    public double? Ptr { get; set; }

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
