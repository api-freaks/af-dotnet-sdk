using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainAvailabilitySuggestionsResponseDomainAvailableResponseDomainAvailableResponseItem
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("domainAvailability")]
    public bool? DomainAvailability { get; set; }

    /// <summary>
    /// Extra details if the domain is not registered.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

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
