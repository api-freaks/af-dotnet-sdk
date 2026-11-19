using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Geolocation and security enrichment data for the IP address.
/// </summary>
[Serializable]
public record DisposableEmailCheckV2ResponseAddress : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// IP recognized/reachable by the geolocation provider.
    /// </summary>
    [JsonPropertyName("validIpAddress")]
    public bool? ValidIpAddress { get; set; }

    /// <summary>
    /// Geolocation data derived from the IP address.
    /// </summary>
    [JsonPropertyName("location")]
    public DisposableEmailCheckV2ResponseAddressLocation? Location { get; set; }

    /// <summary>
    /// Threat and anonymity profile for the IP address.
    /// </summary>
    [JsonPropertyName("security")]
    public DisposableEmailCheckV2ResponseAddressSecurity? Security { get; set; }

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
