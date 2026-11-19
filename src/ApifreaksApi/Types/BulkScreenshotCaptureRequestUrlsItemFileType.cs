using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkScreenshotCaptureRequestUrlsItemFileType.BulkScreenshotCaptureRequestUrlsItemFileTypeSerializer)
)]
[Serializable]
public readonly record struct BulkScreenshotCaptureRequestUrlsItemFileType : IStringEnum
{
    public static readonly BulkScreenshotCaptureRequestUrlsItemFileType Png = new(Values.Png);

    public static readonly BulkScreenshotCaptureRequestUrlsItemFileType Jpeg = new(Values.Jpeg);

    public static readonly BulkScreenshotCaptureRequestUrlsItemFileType Webp = new(Values.Webp);

    public static readonly BulkScreenshotCaptureRequestUrlsItemFileType Pdf = new(Values.Pdf);

    public static readonly BulkScreenshotCaptureRequestUrlsItemFileType Mp4 = new(Values.Mp4);

    public static readonly BulkScreenshotCaptureRequestUrlsItemFileType Gif = new(Values.Gif);

    public static readonly BulkScreenshotCaptureRequestUrlsItemFileType Webm = new(Values.Webm);

    public BulkScreenshotCaptureRequestUrlsItemFileType(string value)
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
    public static BulkScreenshotCaptureRequestUrlsItemFileType FromCustom(string value)
    {
        return new BulkScreenshotCaptureRequestUrlsItemFileType(value);
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
        BulkScreenshotCaptureRequestUrlsItemFileType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BulkScreenshotCaptureRequestUrlsItemFileType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BulkScreenshotCaptureRequestUrlsItemFileType value) =>
        value.Value;

    public static explicit operator BulkScreenshotCaptureRequestUrlsItemFileType(string value) =>
        new(value);

    internal class BulkScreenshotCaptureRequestUrlsItemFileTypeSerializer
        : JsonConverter<BulkScreenshotCaptureRequestUrlsItemFileType>
    {
        public override BulkScreenshotCaptureRequestUrlsItemFileType Read(
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
            return new BulkScreenshotCaptureRequestUrlsItemFileType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemFileType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkScreenshotCaptureRequestUrlsItemFileType ReadAsPropertyName(
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
            return new BulkScreenshotCaptureRequestUrlsItemFileType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemFileType value,
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
        public const string Png = "PNG";

        public const string Jpeg = "JPEG";

        public const string Webp = "WEBP";

        public const string Pdf = "PDF";

        public const string Mp4 = "MP4";

        public const string Gif = "GIF";

        public const string Webm = "WEBM";
    }
}
