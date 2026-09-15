using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkEmailValidateResponseEmailResponseItemDomain : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("disposable")]
    public required bool Disposable { get; set; }

    [JsonPropertyName("spam")]
    public required bool Spam { get; set; }

    [JsonPropertyName("free")]
    public required bool Free { get; set; }

    [JsonPropertyName("catchAll")]
    public required bool CatchAll { get; set; }

    [JsonPropertyName("validDomain")]
    public required bool ValidDomain { get; set; }

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
