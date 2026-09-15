using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Underlying lexical / statistical features used in DGA detection.
/// </summary>
[Serializable]
public record DomainReputationResponseDgaScoreFeatures : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Length of the domain name.
    /// </summary>
    [JsonPropertyName("domain_length")]
    public required int DomainLength { get; set; }

    /// <summary>
    /// Ratio of vowels to consonants in the domain.
    /// </summary>
    [JsonPropertyName("vowel_consonant_ratio")]
    public required float VowelConsonantRatio { get; set; }

    /// <summary>
    /// N-gram perplexity score of the domain string.
    /// </summary>
    [JsonPropertyName("ngram_perplexity")]
    public required float NgramPerplexity { get; set; }

    /// <summary>
    /// Shannon entropy of the domain string.
    /// </summary>
    [JsonPropertyName("shannon_entropy")]
    public required float ShannonEntropy { get; set; }

    /// <summary>
    /// Ratio of digits to letters in the domain.
    /// </summary>
    [JsonPropertyName("digit_letter_ratio")]
    public required float DigitLetterRatio { get; set; }

    /// <summary>
    /// Maximum consecutive consonant streak in the domain.
    /// </summary>
    [JsonPropertyName("consonant_streak_max")]
    public required int ConsonantStreakMax { get; set; }

    /// <summary>
    /// Indicates if the TLD belongs to a known DGA set.
    /// </summary>
    [JsonPropertyName("tld_in_known_dga_set")]
    public required bool TldInKnownDgaSet { get; set; }

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
