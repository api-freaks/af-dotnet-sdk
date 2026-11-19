using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record AsnWhoisLookupResponseRouteObjectsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("route")]
    public required string Route { get; set; }

    [JsonPropertyName("origin")]
    public required string Origin { get; set; }

    [JsonPropertyName("originName")]
    public required string OriginName { get; set; }

    [JsonPropertyName("isp")]
    public required string Isp { get; set; }

    /// <summary>
    /// Number of IP addresses in the route. IPv6 routes exceed the 64-bit integer range, so this is a floating-point number.
    /// </summary>
    [JsonPropertyName("numberOfIps")]
    public required double NumberOfIps { get; set; }

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
