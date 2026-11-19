using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(GetCreditsUsageResponseUserStatus.GetCreditsUsageResponseUserStatusSerializer)
)]
[Serializable]
public readonly record struct GetCreditsUsageResponseUserStatus : IStringEnum
{
    public static readonly GetCreditsUsageResponseUserStatus Active = new(Values.Active);

    public static readonly GetCreditsUsageResponseUserStatus Inactive = new(Values.Inactive);

    public static readonly GetCreditsUsageResponseUserStatus Deleted = new(Values.Deleted);

    public GetCreditsUsageResponseUserStatus(string value)
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
    public static GetCreditsUsageResponseUserStatus FromCustom(string value)
    {
        return new GetCreditsUsageResponseUserStatus(value);
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

    public static bool operator ==(GetCreditsUsageResponseUserStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetCreditsUsageResponseUserStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetCreditsUsageResponseUserStatus value) => value.Value;

    public static explicit operator GetCreditsUsageResponseUserStatus(string value) => new(value);

    internal class GetCreditsUsageResponseUserStatusSerializer
        : JsonConverter<GetCreditsUsageResponseUserStatus>
    {
        public override GetCreditsUsageResponseUserStatus Read(
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
            return new GetCreditsUsageResponseUserStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetCreditsUsageResponseUserStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetCreditsUsageResponseUserStatus ReadAsPropertyName(
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
            return new GetCreditsUsageResponseUserStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetCreditsUsageResponseUserStatus value,
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

        public const string Inactive = "inactive";

        public const string Deleted = "deleted";
    }
}
