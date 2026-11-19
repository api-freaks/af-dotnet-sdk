using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record PdfGetTaskStatusResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the PDF processing task.
    /// </summary>
    [JsonPropertyName("taskId")]
    public required string TaskId { get; set; }

    /// <summary>
    /// The current status of the task (e.g., 'queued', 'processing', 'completed', 'failed').
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <summary>
    /// The timestamp when the task status was created, formatted as 'yyyy-MM-dd HH:mm:ss'.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// Deprecated: the API returns this field as `zipFileUrl`; read `zipFileUrl` instead.
    /// </summary>
    [JsonPropertyName("zipOutputUrl")]
    public string? ZipOutputUrl { get; set; }

    /// <summary>
    /// The unique identifier for the ZIP file. This is present only when the task status is 'COMPLETED'.
    /// </summary>
    [JsonPropertyName("zipFileId")]
    public string? ZipFileId { get; set; }

    /// <summary>
    /// A list of URLs for each individual output file. This is present only when the task is 'COMPLETED'.
    /// </summary>
    [JsonPropertyName("outputUrls")]
    public IEnumerable<string>? OutputUrls { get; set; }

    /// <summary>
    /// A list of unique IDs for the output files. This is present only when the task is 'COMPLETED'.
    /// </summary>
    [JsonPropertyName("outputIds")]
    public IEnumerable<string>? OutputIds { get; set; }

    /// <summary>
    /// A list of unique IDs for the input files submitted with the task. If the task was initiated with the `destroy` parameter set to `true`, `inputIds` will not be generated.
    /// </summary>
    [JsonPropertyName("inputIds")]
    public IEnumerable<string>? InputIds { get; set; }

    /// <summary>
    /// The error code for the PDF Task. This is included only if the task fails.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// A descriptive message indicating the reason for task failure. This is included only if the task fails.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The timestamp when the task status will expire and be removed from the system, formatted as 'yyyy-MM-dd HH:mm:ss'.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public string? ExpiresAt { get; set; }

    /// <summary>
    /// URL to download all output files as a ZIP archive; present only on completed tasks.
    /// </summary>
    [JsonPropertyName("zipFileUrl")]
    public string? ZipFileUrl { get; set; }

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
