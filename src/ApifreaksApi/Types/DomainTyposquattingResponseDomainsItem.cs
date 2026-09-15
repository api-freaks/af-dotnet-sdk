using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainTyposquattingResponseDomainsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("domainName")]
    public required string DomainName { get; set; }

    /// <summary>
    /// Domain creation date (YYYY-MM-DD). May be absent for older or less-actively-tracked entries.
    /// </summary>
    [JsonPropertyName("createDate")]
    public string? CreateDate { get; set; }

    /// <summary>
    /// Domain expiration date (YYYY-MM-DD). May be absent for older or less-actively-tracked entries.
    /// </summary>
    [JsonPropertyName("expiryDate")]
    public string? ExpiryDate { get; set; }

    /// <summary>
    /// Last time the domain was observed (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("lastSeen")]
    public string? LastSeen { get; set; }

    /// <summary>
    /// Indicates whether the domain has dropped out of the registry and become available to register again.
    /// </summary>
    [JsonPropertyName("isDropped")]
    public required bool IsDropped { get; set; }

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
