using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity.DomainReputationResponseTrustSignalsSignalsPositiveItemPolaritySerializer)
)]
[Serializable]
public readonly record struct DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity
    : IStringEnum
{
    public static readonly DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity Positive =
        new(Values.Positive);

    public static readonly DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity Negative =
        new(Values.Negative);

    public static readonly DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity Neutral =
        new(Values.Neutral);

    public DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity(string value)
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
    public static DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity FromCustom(
        string value
    )
    {
        return new DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity(value);
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
        DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity value
    ) => value.Value;

    public static explicit operator DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity(
        string value
    ) => new(value);

    internal class DomainReputationResponseTrustSignalsSignalsPositiveItemPolaritySerializer
        : JsonConverter<DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity>
    {
        public override DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity Read(
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
            return new DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity ReadAsPropertyName(
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
            return new DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity value,
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
