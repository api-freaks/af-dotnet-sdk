using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkPdfGenerateFromTemplateRequest
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// The template to render, from the APIFreaks PDF Template Builder. Copy it from your dashboard when you save the template.
    /// </summary>
    [JsonIgnore]
    public required string TemplateId { get; set; }

    /// <summary>
    /// Template version to render, e.g. v2. Must start with v. Omit this parameter entirely to use the latest version; the literal value 'latest' is not accepted by the API.
    /// </summary>
    [JsonIgnore]
    public string? Version { get; set; }

    public required FileParameter File { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
