using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

/// <summary>
/// Wrapper object containing one WHOIS result or error per requested domain, in request order.
/// </summary>
[Serializable]
public record BulkDomainWhoisLookupV2Response : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of per-domain results, one entry per requested domain. Each entry is either a full WHOIS result or, if that domain could not be resolved, an error object.
    /// </summary>
    [JsonPropertyName("bulk_whois_response")]
    public IEnumerable<
        OneOf<
            BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContact,
            BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemError
        >
    > BulkWhoisResponse { get; set; } =
        new List<
            OneOf<
                BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContact,
                BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemError
            >
        >();

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
