using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkDisposableEmailCheckV2RequestFormat.BulkDisposableEmailCheckV2RequestFormatSerializer)
)]
[Serializable]
public readonly record struct BulkDisposableEmailCheckV2RequestFormat : IStringEnum
{
    public static readonly BulkDisposableEmailCheckV2RequestFormat Json = new(Values.Json);

    public static readonly BulkDisposableEmailCheckV2RequestFormat Xml = new(Values.Xml);

    public BulkDisposableEmailCheckV2RequestFormat(string value)
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
    public static BulkDisposableEmailCheckV2RequestFormat FromCustom(string value)
    {
        return new BulkDisposableEmailCheckV2RequestFormat(value);
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

    public static bool operator ==(BulkDisposableEmailCheckV2RequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BulkDisposableEmailCheckV2RequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BulkDisposableEmailCheckV2RequestFormat value) =>
        value.Value;

    public static explicit operator BulkDisposableEmailCheckV2RequestFormat(string value) =>
        new(value);

    internal class BulkDisposableEmailCheckV2RequestFormatSerializer
        : JsonConverter<BulkDisposableEmailCheckV2RequestFormat>
    {
        public override BulkDisposableEmailCheckV2RequestFormat Read(
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
            return new BulkDisposableEmailCheckV2RequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkDisposableEmailCheckV2RequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkDisposableEmailCheckV2RequestFormat ReadAsPropertyName(
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
            return new BulkDisposableEmailCheckV2RequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkDisposableEmailCheckV2RequestFormat value,
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
        public const string Json = "json";

        public const string Xml = "xml";
    }
}
