using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(DomainReputationResponseRiskCategorySeverity.DomainReputationResponseRiskCategorySeveritySerializer)
)]
[Serializable]
public readonly record struct DomainReputationResponseRiskCategorySeverity : IStringEnum
{
    public static readonly DomainReputationResponseRiskCategorySeverity None = new(Values.None);

    public static readonly DomainReputationResponseRiskCategorySeverity Low = new(Values.Low);

    public static readonly DomainReputationResponseRiskCategorySeverity Medium = new(Values.Medium);

    public static readonly DomainReputationResponseRiskCategorySeverity High = new(Values.High);

    public DomainReputationResponseRiskCategorySeverity(string value)
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
    public static DomainReputationResponseRiskCategorySeverity FromCustom(string value)
    {
        return new DomainReputationResponseRiskCategorySeverity(value);
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
        DomainReputationResponseRiskCategorySeverity value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DomainReputationResponseRiskCategorySeverity value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DomainReputationResponseRiskCategorySeverity value) =>
        value.Value;

    public static explicit operator DomainReputationResponseRiskCategorySeverity(string value) =>
        new(value);

    internal class DomainReputationResponseRiskCategorySeveritySerializer
        : JsonConverter<DomainReputationResponseRiskCategorySeverity>
    {
        public override DomainReputationResponseRiskCategorySeverity Read(
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
            return new DomainReputationResponseRiskCategorySeverity(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainReputationResponseRiskCategorySeverity value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainReputationResponseRiskCategorySeverity ReadAsPropertyName(
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
            return new DomainReputationResponseRiskCategorySeverity(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainReputationResponseRiskCategorySeverity value,
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
        public const string None = "none";

        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";
    }
}
