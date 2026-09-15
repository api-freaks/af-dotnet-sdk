using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(DomainTyposquattingRequestFormat.DomainTyposquattingRequestFormatSerializer))]
[Serializable]
public readonly record struct DomainTyposquattingRequestFormat : IStringEnum
{
    public static readonly DomainTyposquattingRequestFormat Json = new(Values.Json);

    public static readonly DomainTyposquattingRequestFormat Xml = new(Values.Xml);

    public DomainTyposquattingRequestFormat(string value)
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
    public static DomainTyposquattingRequestFormat FromCustom(string value)
    {
        return new DomainTyposquattingRequestFormat(value);
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

    public static bool operator ==(DomainTyposquattingRequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainTyposquattingRequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainTyposquattingRequestFormat value) => value.Value;

    public static explicit operator DomainTyposquattingRequestFormat(string value) => new(value);

    internal class DomainTyposquattingRequestFormatSerializer
        : JsonConverter<DomainTyposquattingRequestFormat>
    {
        public override DomainTyposquattingRequestFormat Read(
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
            return new DomainTyposquattingRequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainTyposquattingRequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainTyposquattingRequestFormat ReadAsPropertyName(
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
            return new DomainTyposquattingRequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainTyposquattingRequestFormat value,
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
