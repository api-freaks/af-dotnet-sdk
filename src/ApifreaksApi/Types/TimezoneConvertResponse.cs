using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record TimezoneConvertResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Original time before conversion (format YYYY-MM-DD HH:mm:ss, not ISO 8601).
    /// </summary>
    [JsonPropertyName("original_time")]
    public required string OriginalTime { get; set; }

    /// <summary>
    /// Time after conversion (format YYYY-MM-DD HH:mm:ss, not ISO 8601).
    /// </summary>
    [JsonPropertyName("converted_time")]
    public required string ConvertedTime { get; set; }

    /// <summary>
    /// Difference in hours
    /// </summary>
    [JsonPropertyName("diff_hour")]
    public required float DiffHour { get; set; }

    /// <summary>
    /// Difference in minutes
    /// </summary>
    [JsonPropertyName("diff_min")]
    public required float DiffMin { get; set; }

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
