using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkDisposableEmailCheckV2Request
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Format of the response.
    /// </summary>
    [JsonIgnore]
    public BulkDisposableEmailCheckV2RequestFormat? Format { get; set; }

    /// <summary>
    /// Entries to check. Maximum 100 per request. Must not be empty, and must not contain null entries or entries without a valid email.
    /// </summary>
    [JsonPropertyName("emailData")]
    public IEnumerable<BulkDisposableEmailCheckV2RequestEmailDataItem> EmailData { get; set; } =
        new List<BulkDisposableEmailCheckV2RequestEmailDataItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
