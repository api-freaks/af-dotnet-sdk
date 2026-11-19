using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia.BulkScreenshotCaptureRequestUrlsItemPdfOptionsMediaSerializer)
)]
[Serializable]
public readonly record struct BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia : IStringEnum
{
    public static readonly BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia Print = new(
        Values.Print
    );

    public static readonly BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia Screen = new(
        Values.Screen
    );

    public BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia(string value)
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
    public static BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia FromCustom(string value)
    {
        return new BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia(value);
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
        BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia value
    ) => value.Value;

    public static explicit operator BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia(
        string value
    ) => new(value);

    internal class BulkScreenshotCaptureRequestUrlsItemPdfOptionsMediaSerializer
        : JsonConverter<BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia>
    {
        public override BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia Read(
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
            return new BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia ReadAsPropertyName(
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
            return new BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia value,
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
