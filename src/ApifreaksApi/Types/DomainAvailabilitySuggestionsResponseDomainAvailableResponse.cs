using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Returned when `sug` is omitted or `true` — the queried domain plus suggested alternatives.
/// </summary>
[Serializable]
public record DomainAvailabilitySuggestionsResponseDomainAvailableResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("domain_available_response")]
    public IEnumerable<DomainAvailabilitySuggestionsResponseDomainAvailableResponseDomainAvailableResponseItem>? DomainAvailableResponse { get; set; }

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
