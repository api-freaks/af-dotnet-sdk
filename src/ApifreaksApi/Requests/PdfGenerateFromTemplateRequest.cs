using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record PdfGenerateFromTemplateRequest
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

    /// <summary>
    /// A URL the API fetches your JSON data from, instead of the request body. Provide this when you are not sending a request body.
    /// </summary>
    [JsonIgnore]
    public string? DataUrl { get; set; }

    /// <summary>
    /// Free-form JSON object whose keys map to the fields bound in the template.
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, object?> Body { get; set; } = new Dictionary<string, object?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
