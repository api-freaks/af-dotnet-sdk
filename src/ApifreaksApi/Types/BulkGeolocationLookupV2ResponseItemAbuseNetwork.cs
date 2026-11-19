using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Network information for the IP.
/// </summary>
[Serializable]
public record BulkGeolocationLookupV2ResponseItemAbuseNetwork : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Network access type classification (e.g., DSL, Cable, Mobile, 5G) when available.
    /// </summary>
    [JsonPropertyName("connection_type")]
    public string? ConnectionType { get; set; }

    /// <summary>
    /// Network prefix in CIDR notation that contains the IP.
    /// </summary>
    [JsonPropertyName("route")]
    public string? Route { get; set; }

    /// <summary>
    /// true if the IP is anycast (same IP announced from multiple locations).
    /// </summary>
    [JsonPropertyName("is_anycast")]
    public bool? IsAnycast { get; set; }

    /// <summary>
    /// CDN provider name (e.g. Cloudflare) when is_cdn is true; empty otherwise.
    /// </summary>
    [JsonPropertyName("cdn_provider_name")]
    public string? CdnProviderName { get; set; }

    /// <summary>
    /// true if the IP belongs to a content delivery network (CDN) or a cloud provider's network.
    /// </summary>
    [JsonPropertyName("is_cdn")]
    public bool? IsCdn { get; set; }

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
