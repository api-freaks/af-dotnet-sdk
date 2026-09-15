using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(TimezoneLookupV2RequestFormat.TimezoneLookupV2RequestFormatSerializer))]
[Serializable]
public readonly record struct TimezoneLookupV2RequestFormat : IStringEnum
{
    public static readonly TimezoneLookupV2RequestFormat Json = new(Values.Json);

    public static readonly TimezoneLookupV2RequestFormat Xml = new(Values.Xml);

    public TimezoneLookupV2RequestFormat(string value)
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
    public static TimezoneLookupV2RequestFormat FromCustom(string value)
    {
        return new TimezoneLookupV2RequestFormat(value);
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

    public static bool operator ==(TimezoneLookupV2RequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TimezoneLookupV2RequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TimezoneLookupV2RequestFormat value) => value.Value;

    public static explicit operator TimezoneLookupV2RequestFormat(string value) => new(value);

    internal class TimezoneLookupV2RequestFormatSerializer
        : JsonConverter<TimezoneLookupV2RequestFormat>
    {
        public override TimezoneLookupV2RequestFormat Read(
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
            return new TimezoneLookupV2RequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TimezoneLookupV2RequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TimezoneLookupV2RequestFormat ReadAsPropertyName(
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
            return new TimezoneLookupV2RequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TimezoneLookupV2RequestFormat value,
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
