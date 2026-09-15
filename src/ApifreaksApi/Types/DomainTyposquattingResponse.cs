using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainTyposquattingResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("status")]
    public required bool Status { get; set; }

    [JsonPropertyName("totalRecords")]
    public required int TotalRecords { get; set; }

    [JsonPropertyName("currentPage")]
    public required int CurrentPage { get; set; }

    [JsonPropertyName("hasNextPage")]
    public required bool HasNextPage { get; set; }

    [JsonPropertyName("totalPages")]
    public required int TotalPages { get; set; }

    /// <summary>
    /// Opaque token to pass as pageToken on the next request. Present only when hasNextPage is true.
    /// </summary>
    [JsonPropertyName("nextPageToken")]
    public string? NextPageToken { get; set; }

    [JsonPropertyName("domains")]
    public IEnumerable<DomainTyposquattingResponseDomainsItem> Domains { get; set; } =
        new List<DomainTyposquattingResponseDomainsItem>();

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
