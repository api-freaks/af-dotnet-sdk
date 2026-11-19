using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(GetCreditsUsageResponseSubStatus.GetCreditsUsageResponseSubStatusSerializer))]
[Serializable]
public readonly record struct GetCreditsUsageResponseSubStatus : IStringEnum
{
    public static readonly GetCreditsUsageResponseSubStatus Active = new(Values.Active);

    public static readonly GetCreditsUsageResponseSubStatus Overdue = new(Values.Overdue);

    public static readonly GetCreditsUsageResponseSubStatus Cancelled = new(Values.Cancelled);

    public static readonly GetCreditsUsageResponseSubStatus Deactivated = new(Values.Deactivated);

    public GetCreditsUsageResponseSubStatus(string value)
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
    public static GetCreditsUsageResponseSubStatus FromCustom(string value)
    {
        return new GetCreditsUsageResponseSubStatus(value);
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

    public static bool operator ==(GetCreditsUsageResponseSubStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetCreditsUsageResponseSubStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetCreditsUsageResponseSubStatus value) => value.Value;

    public static explicit operator GetCreditsUsageResponseSubStatus(string value) => new(value);

    internal class GetCreditsUsageResponseSubStatusSerializer
        : JsonConverter<GetCreditsUsageResponseSubStatus>
    {
        public override GetCreditsUsageResponseSubStatus Read(
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
            return new GetCreditsUsageResponseSubStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetCreditsUsageResponseSubStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetCreditsUsageResponseSubStatus ReadAsPropertyName(
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
            return new GetCreditsUsageResponseSubStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetCreditsUsageResponseSubStatus value,
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
        public const string Active = "active";

        public const string Overdue = "overdue";

        public const string Cancelled = "cancelled";

        public const string Deactivated = "deactivated";
    }
}
