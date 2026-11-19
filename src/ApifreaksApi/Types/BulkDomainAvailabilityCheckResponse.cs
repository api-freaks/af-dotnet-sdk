using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkDomainAvailabilityCheckResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Deprecated: the API returns this field as `bulk_domain_availability_response`; read `bulk_domain_availability_response` instead.
    /// </summary>
    [JsonPropertyName("bulk_domain_available_response")]
    public IEnumerable<BulkDomainAvailabilityCheckResponseBulkDomainAvailableResponseItem>? BulkDomainAvailableResponse { get; set; }

    [JsonPropertyName("bulk_domain_availability_response")]
    public IEnumerable<BulkDomainAvailabilityCheckResponseBulkDomainAvailabilityResponseItem>? BulkDomainAvailabilityResponse { get; set; }

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
