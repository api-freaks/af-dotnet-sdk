using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity.DomainReputationResponseTrustSignalsSignalsNegativeItemPolaritySerializer)
)]
[Serializable]
public readonly record struct DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity
    : IStringEnum
{
    public static readonly DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity Positive =
        new(Values.Positive);

    public static readonly DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity Negative =
        new(Values.Negative);

    public static readonly DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity Neutral =
        new(Values.Neutral);

    public DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity FromCustom(
        string value
    )
    {
        return new DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity value
    ) => value.Value;

    public static explicit operator DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity(
        string value
    ) => new(value);

    internal class DomainReputationResponseTrustSignalsSignalsNegativeItemPolaritySerializer
        : JsonConverter<DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity>
    {
        public override DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainReputationResponseTrustSignalsSignalsNegativeItemPolarity value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Positive = "positive";

        public const string Negative = "negative";

        public const string Neutral = "neutral";
    }
}
