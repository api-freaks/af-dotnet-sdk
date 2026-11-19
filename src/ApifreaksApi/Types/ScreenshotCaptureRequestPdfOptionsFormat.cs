using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(ScreenshotCaptureRequestPdfOptionsFormat.ScreenshotCaptureRequestPdfOptionsFormatSerializer)
)]
[Serializable]
public readonly record struct ScreenshotCaptureRequestPdfOptionsFormat : IStringEnum
{
    public static readonly ScreenshotCaptureRequestPdfOptionsFormat A0 = new(Values.A0);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat A1 = new(Values.A1);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat A2 = new(Values.A2);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat A3 = new(Values.A3);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat A4 = new(Values.A4);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat A5 = new(Values.A5);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat A6 = new(Values.A6);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat Letter = new(Values.Letter);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat Legal = new(Values.Legal);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat Tabloid = new(Values.Tabloid);

    public static readonly ScreenshotCaptureRequestPdfOptionsFormat Ledger = new(Values.Ledger);

    public ScreenshotCaptureRequestPdfOptionsFormat(string value)
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
    public static ScreenshotCaptureRequestPdfOptionsFormat FromCustom(string value)
    {
        return new ScreenshotCaptureRequestPdfOptionsFormat(value);
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
        ScreenshotCaptureRequestPdfOptionsFormat value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ScreenshotCaptureRequestPdfOptionsFormat value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ScreenshotCaptureRequestPdfOptionsFormat value) =>
        value.Value;

    public static explicit operator ScreenshotCaptureRequestPdfOptionsFormat(string value) =>
        new(value);

    internal class ScreenshotCaptureRequestPdfOptionsFormatSerializer
        : JsonConverter<ScreenshotCaptureRequestPdfOptionsFormat>
    {
        public override ScreenshotCaptureRequestPdfOptionsFormat Read(
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
            return new ScreenshotCaptureRequestPdfOptionsFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScreenshotCaptureRequestPdfOptionsFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScreenshotCaptureRequestPdfOptionsFormat ReadAsPropertyName(
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
            return new ScreenshotCaptureRequestPdfOptionsFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScreenshotCaptureRequestPdfOptionsFormat value,
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
        public const string A0 = "A0";

        public const string A1 = "A1";

        public const string A2 = "A2";

        public const string A3 = "A3";

        public const string A4 = "A4";

        public const string A5 = "A5";

        public const string A6 = "A6";

        public const string Letter = "Letter";

        public const string Legal = "Legal";

        public const string Tabloid = "Tabloid";

        public const string Ledger = "Ledger";
    }
}
