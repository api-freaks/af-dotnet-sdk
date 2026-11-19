using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkScreenshotCaptureRequestUrlsItemScrollSpeed.BulkScreenshotCaptureRequestUrlsItemScrollSpeedSerializer)
)]
[Serializable]
public readonly record struct BulkScreenshotCaptureRequestUrlsItemScrollSpeed : IStringEnum
{
    public static readonly BulkScreenshotCaptureRequestUrlsItemScrollSpeed Normal = new(
        Values.Normal
    );

    public static readonly BulkScreenshotCaptureRequestUrlsItemScrollSpeed Fast = new(Values.Fast);

    public static readonly BulkScreenshotCaptureRequestUrlsItemScrollSpeed Slow = new(Values.Slow);

    public BulkScreenshotCaptureRequestUrlsItemScrollSpeed(string value)
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
    public static BulkScreenshotCaptureRequestUrlsItemScrollSpeed FromCustom(string value)
    {
        return new BulkScreenshotCaptureRequestUrlsItemScrollSpeed(value);
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
        BulkScreenshotCaptureRequestUrlsItemScrollSpeed value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BulkScreenshotCaptureRequestUrlsItemScrollSpeed value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(BulkScreenshotCaptureRequestUrlsItemScrollSpeed value) =>
        value.Value;

    public static explicit operator BulkScreenshotCaptureRequestUrlsItemScrollSpeed(string value) =>
        new(value);

    internal class BulkScreenshotCaptureRequestUrlsItemScrollSpeedSerializer
        : JsonConverter<BulkScreenshotCaptureRequestUrlsItemScrollSpeed>
    {
        public override BulkScreenshotCaptureRequestUrlsItemScrollSpeed Read(
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
            return new BulkScreenshotCaptureRequestUrlsItemScrollSpeed(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemScrollSpeed value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkScreenshotCaptureRequestUrlsItemScrollSpeed ReadAsPropertyName(
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
            return new BulkScreenshotCaptureRequestUrlsItemScrollSpeed(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemScrollSpeed value,
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
        public const string Normal = "normal";

        public const string Fast = "fast";

        public const string Slow = "slow";
    }
}
