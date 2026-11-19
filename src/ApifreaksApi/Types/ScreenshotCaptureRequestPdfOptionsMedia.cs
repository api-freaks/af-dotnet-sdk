using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(ScreenshotCaptureRequestPdfOptionsMedia.ScreenshotCaptureRequestPdfOptionsMediaSerializer)
)]
[Serializable]
public readonly record struct ScreenshotCaptureRequestPdfOptionsMedia : IStringEnum
{
    public static readonly ScreenshotCaptureRequestPdfOptionsMedia Print = new(Values.Print);

    public static readonly ScreenshotCaptureRequestPdfOptionsMedia Screen = new(Values.Screen);

    public ScreenshotCaptureRequestPdfOptionsMedia(string value)
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
    public static ScreenshotCaptureRequestPdfOptionsMedia FromCustom(string value)
    {
        return new ScreenshotCaptureRequestPdfOptionsMedia(value);
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

    public static bool operator ==(ScreenshotCaptureRequestPdfOptionsMedia value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScreenshotCaptureRequestPdfOptionsMedia value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScreenshotCaptureRequestPdfOptionsMedia value) =>
        value.Value;

    public static explicit operator ScreenshotCaptureRequestPdfOptionsMedia(string value) =>
        new(value);

    internal class ScreenshotCaptureRequestPdfOptionsMediaSerializer
        : JsonConverter<ScreenshotCaptureRequestPdfOptionsMedia>
    {
        public override ScreenshotCaptureRequestPdfOptionsMedia Read(
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
            return new ScreenshotCaptureRequestPdfOptionsMedia(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScreenshotCaptureRequestPdfOptionsMedia value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScreenshotCaptureRequestPdfOptionsMedia ReadAsPropertyName(
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
            return new ScreenshotCaptureRequestPdfOptionsMedia(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScreenshotCaptureRequestPdfOptionsMedia value,
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
        public const string Print = "print";

        public const string Screen = "screen";
    }
}
