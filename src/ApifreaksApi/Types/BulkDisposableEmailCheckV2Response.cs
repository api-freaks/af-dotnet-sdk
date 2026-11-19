using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Wrapper containing the per-email results array.
/// </summary>
[Serializable]
public record BulkDisposableEmailCheckV2Response : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of per-email results, one entry per requested email, in the same order as the request.
    /// </summary>
    [JsonPropertyName("disposableEmailResponse")]
    public IEnumerable<BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItem> DisposableEmailResponse { get; set; } =
        new List<BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItem>();

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
