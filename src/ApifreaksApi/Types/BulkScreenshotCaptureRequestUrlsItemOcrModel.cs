using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkScreenshotCaptureRequestUrlsItemOcrModel.BulkScreenshotCaptureRequestUrlsItemOcrModelSerializer)
)]
[Serializable]
public readonly record struct BulkScreenshotCaptureRequestUrlsItemOcrModel : IStringEnum
{
    public static readonly BulkScreenshotCaptureRequestUrlsItemOcrModel MiniOcrV1 = new(
        Values.MiniOcrV1
    );

    public static readonly BulkScreenshotCaptureRequestUrlsItemOcrModel OcrV1 = new(Values.OcrV1);

    public BulkScreenshotCaptureRequestUrlsItemOcrModel(string value)
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
    public static BulkScreenshotCaptureRequestUrlsItemOcrModel FromCustom(string value)
    {
        return new BulkScreenshotCaptureRequestUrlsItemOcrModel(value);
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
        BulkScreenshotCaptureRequestUrlsItemOcrModel value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BulkScreenshotCaptureRequestUrlsItemOcrModel value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BulkScreenshotCaptureRequestUrlsItemOcrModel value) =>
        value.Value;

    public static explicit operator BulkScreenshotCaptureRequestUrlsItemOcrModel(string value) =>
        new(value);

    internal class BulkScreenshotCaptureRequestUrlsItemOcrModelSerializer
        : JsonConverter<BulkScreenshotCaptureRequestUrlsItemOcrModel>
    {
        public override BulkScreenshotCaptureRequestUrlsItemOcrModel Read(
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
            return new BulkScreenshotCaptureRequestUrlsItemOcrModel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemOcrModel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkScreenshotCaptureRequestUrlsItemOcrModel ReadAsPropertyName(
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
            return new BulkScreenshotCaptureRequestUrlsItemOcrModel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemOcrModel value,
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
        public const string MiniOcrV1 = "mini-ocr-v1";

        public const string OcrV1 = "ocr-v1";
    }
}
