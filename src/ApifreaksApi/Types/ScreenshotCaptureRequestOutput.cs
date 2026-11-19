using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(ScreenshotCaptureRequestOutput.ScreenshotCaptureRequestOutputSerializer))]
[Serializable]
public readonly record struct ScreenshotCaptureRequestOutput : IStringEnum
{
    public static readonly ScreenshotCaptureRequestOutput Json = new(Values.Json);

    public ScreenshotCaptureRequestOutput(string value)
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
    public static ScreenshotCaptureRequestOutput FromCustom(string value)
    {
        return new ScreenshotCaptureRequestOutput(value);
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

    public static bool operator ==(ScreenshotCaptureRequestOutput value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScreenshotCaptureRequestOutput value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScreenshotCaptureRequestOutput value) => value.Value;

    public static explicit operator ScreenshotCaptureRequestOutput(string value) => new(value);

    internal class ScreenshotCaptureRequestOutputSerializer
        : JsonConverter<ScreenshotCaptureRequestOutput>
    {
        public override ScreenshotCaptureRequestOutput Read(
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
            return new ScreenshotCaptureRequestOutput(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScreenshotCaptureRequestOutput value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScreenshotCaptureRequestOutput ReadAsPropertyName(
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
            return new ScreenshotCaptureRequestOutput(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScreenshotCaptureRequestOutput value,
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
    }
}
