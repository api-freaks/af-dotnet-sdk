using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record ZipcodeSearchByRegionRequest
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
    public ZipcodeSearchByRegionRequestFormat? Format { get; set; }

    /// <summary>
    /// Country code in ISO 3166-1 alpha-2 format.
    /// </summary>
    [JsonIgnore]
    public required string Country { get; set; }

    /// <summary>
    /// Name of the region, state or province associated with the country. Either region or region_code is required; region_code takes priority if both are given.
    /// </summary>
    [JsonIgnore]
    public string? Region { get; set; }

    /// <summary>
    /// Page no. to retrieve paginated results.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// ISO code of the region, state, or province associated with the country. Either region or region_code is required. region_code takes priority if both are given.
    /// </summary>
    [JsonIgnore]
    public string? RegionCode { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
