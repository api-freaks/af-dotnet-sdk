using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// BGP route object containing the route prefix, origin AS, and related metadata.
/// </summary>
[Serializable]
public record IpWhoisLookupResponseRoutesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// BGP route prefix (e.g., 8.8.8.0/24).
    /// </summary>
    [JsonPropertyName("route")]
    public string? Route { get; set; }

    /// <summary>
    /// Origin AS number for this route.
    /// </summary>
    [JsonPropertyName("origin")]
    public string? Origin { get; set; }

    /// <summary>
    /// Description values for this route object.
    /// </summary>
    [JsonPropertyName("description")]
    public IEnumerable<string>? Description { get; set; }

    /// <summary>
    /// Country of the organization managing this route.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Pingable IP addresses in this route.
    /// </summary>
    [JsonPropertyName("pingable")]
    public IEnumerable<string>? Pingable { get; set; }

    /// <summary>
    /// Handles of pingable contacts for this route.
    /// </summary>
    [JsonPropertyName("ping_hdl")]
    public IEnumerable<string>? PingHdl { get; set; }

    /// <summary>
    /// Sub-allocation holes (more specific routes) within this route.
    /// </summary>
    [JsonPropertyName("holes")]
    public IEnumerable<string>? Holes { get; set; }

    /// <summary>
    /// Route sets this route is a member of.
    /// </summary>
    [JsonPropertyName("member_of")]
    public IEnumerable<string>? MemberOf { get; set; }

    /// <summary>
    /// Injection details for this route.
    /// </summary>
    [JsonPropertyName("inject")]
    public IEnumerable<string>? Inject { get; set; }

    /// <summary>
    /// Aggregation method for this route.
    /// </summary>
    [JsonPropertyName("aggr_mtd")]
    public string? AggrMtd { get; set; }

    /// <summary>
    /// Aggregation boundary for this route.
    /// </summary>
    [JsonPropertyName("aggr_bndry")]
    public string? AggrBndry { get; set; }

    /// <summary>
    /// Export composition for this route.
    /// </summary>
    [JsonPropertyName("export_comps")]
    public string? ExportComps { get; set; }

    /// <summary>
    /// Route components.
    /// </summary>
    [JsonPropertyName("components")]
    public string? Components { get; set; }

    /// <summary>
    /// Handles of organization objects related to this route.
    /// </summary>
    [JsonPropertyName("organizations")]
    public IEnumerable<string>? Organizations { get; set; }

    /// <summary>
    /// Remarks for this route object.
    /// </summary>
    [JsonPropertyName("remarks")]
    public IEnumerable<string>? Remarks { get; set; }

    /// <summary>
    /// Notify email addresses for this route object.
    /// </summary>
    [JsonPropertyName("notify")]
    public IEnumerable<string>? Notify { get; set; }

    /// <summary>
    /// Lower-level maintainer handles for this route.
    /// </summary>
    [JsonPropertyName("mnt_lower")]
    public IEnumerable<string>? MntLower { get; set; }

    /// <summary>
    /// Maintainer handles for this route object.
    /// </summary>
    [JsonPropertyName("mnt_by")]
    public IEnumerable<string>? MntBy { get; set; }

    /// <summary>
    /// Registration date of this route object (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("date_created")]
    public DateOnly? DateCreated { get; set; }

    /// <summary>
    /// Last update date of this route object (YYYY-MM-DD).
    /// </summary>
    [JsonPropertyName("date_updated")]
    public DateOnly? DateUpdated { get; set; }

    /// <summary>
    /// WHOIS data source for this route object.
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

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
