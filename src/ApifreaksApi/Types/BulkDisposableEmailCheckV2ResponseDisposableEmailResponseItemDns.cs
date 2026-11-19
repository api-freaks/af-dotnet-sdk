using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// DNS records for the email domain. Omitted entirely when validSyntax is false or the domain does not exist (NXDOMAIN).
/// </summary>
[Serializable]
public record BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItemDns : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Every MX hostname at the domain's lowest preference (not just one). ["."]  means the domain publishes a null MX and accepts no mail at all. Absent entirely when the domain has no MX record of any kind — check aRecord in that case.
    /// </summary>
    [JsonPropertyName("mxRecord")]
    public IEnumerable<string>? MxRecord { get; set; }

    /// <summary>
    /// Collection of A (Address) records for the domain. Present when the domain has no MX record but does resolve to a web server or other host.
    /// </summary>
    [JsonPropertyName("aRecord")]
    public IEnumerable<string>? ARecord { get; set; }

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
