using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkScreenshotCaptureRequestUrlsItemOutput.BulkScreenshotCaptureRequestUrlsItemOutputSerializer)
)]
[Serializable]
public readonly record struct BulkScreenshotCaptureRequestUrlsItemOutput : IStringEnum
{
    public static readonly BulkScreenshotCaptureRequestUrlsItemOutput Json = new(Values.Json);

    public static readonly BulkScreenshotCaptureRequestUrlsItemOutput Image = new(Values.Image);

    public BulkScreenshotCaptureRequestUrlsItemOutput(string value)
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
    public static BulkScreenshotCaptureRequestUrlsItemOutput FromCustom(string value)
    {
        return new BulkScreenshotCaptureRequestUrlsItemOutput(value);
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
        BulkScreenshotCaptureRequestUrlsItemOutput value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BulkScreenshotCaptureRequestUrlsItemOutput value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BulkScreenshotCaptureRequestUrlsItemOutput value) =>
        value.Value;

    public static explicit operator BulkScreenshotCaptureRequestUrlsItemOutput(string value) =>
        new(value);

    internal class BulkScreenshotCaptureRequestUrlsItemOutputSerializer
        : JsonConverter<BulkScreenshotCaptureRequestUrlsItemOutput>
    {
        public override BulkScreenshotCaptureRequestUrlsItemOutput Read(
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
            return new BulkScreenshotCaptureRequestUrlsItemOutput(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemOutput value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkScreenshotCaptureRequestUrlsItemOutput ReadAsPropertyName(
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
            return new BulkScreenshotCaptureRequestUrlsItemOutput(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemOutput value,
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

        public const string Image = "image";
    }
}
