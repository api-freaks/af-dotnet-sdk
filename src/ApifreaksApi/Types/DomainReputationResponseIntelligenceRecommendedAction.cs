using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(DomainReputationResponseIntelligenceRecommendedAction.DomainReputationResponseIntelligenceRecommendedActionSerializer)
)]
[Serializable]
public readonly record struct DomainReputationResponseIntelligenceRecommendedAction : IStringEnum
{
    public static readonly DomainReputationResponseIntelligenceRecommendedAction Allow = new(
        Values.Allow
    );

    public static readonly DomainReputationResponseIntelligenceRecommendedAction Monitor = new(
        Values.Monitor
    );

    public static readonly DomainReputationResponseIntelligenceRecommendedAction Block = new(
        Values.Block
    );

    public DomainReputationResponseIntelligenceRecommendedAction(string value)
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
    public static DomainReputationResponseIntelligenceRecommendedAction FromCustom(string value)
    {
        return new DomainReputationResponseIntelligenceRecommendedAction(value);
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
        DomainReputationResponseIntelligenceRecommendedAction value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DomainReputationResponseIntelligenceRecommendedAction value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        DomainReputationResponseIntelligenceRecommendedAction value
    ) => value.Value;

    public static explicit operator DomainReputationResponseIntelligenceRecommendedAction(
        string value
    ) => new(value);

    internal class DomainReputationResponseIntelligenceRecommendedActionSerializer
        : JsonConverter<DomainReputationResponseIntelligenceRecommendedAction>
    {
        public override DomainReputationResponseIntelligenceRecommendedAction Read(
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
            return new DomainReputationResponseIntelligenceRecommendedAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainReputationResponseIntelligenceRecommendedAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainReputationResponseIntelligenceRecommendedAction ReadAsPropertyName(
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
            return new DomainReputationResponseIntelligenceRecommendedAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainReputationResponseIntelligenceRecommendedAction value,
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
        public const string Allow = "allow";

        public const string Monitor = "monitor";

        public const string Block = "block";
    }
}
