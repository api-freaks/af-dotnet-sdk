using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkScreenshotCaptureRequestUrlsItemWaitForEvent.BulkScreenshotCaptureRequestUrlsItemWaitForEventSerializer)
)]
[Serializable]
public readonly record struct BulkScreenshotCaptureRequestUrlsItemWaitForEvent : IStringEnum
{
    public static readonly BulkScreenshotCaptureRequestUrlsItemWaitForEvent Load = new(Values.Load);

    public static readonly BulkScreenshotCaptureRequestUrlsItemWaitForEvent Domcontentloaded = new(
        Values.Domcontentloaded
    );

    public static readonly BulkScreenshotCaptureRequestUrlsItemWaitForEvent Networkidle = new(
        Values.Networkidle
    );

    public BulkScreenshotCaptureRequestUrlsItemWaitForEvent(string value)
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
    public static BulkScreenshotCaptureRequestUrlsItemWaitForEvent FromCustom(string value)
    {
        return new BulkScreenshotCaptureRequestUrlsItemWaitForEvent(value);
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
        BulkScreenshotCaptureRequestUrlsItemWaitForEvent value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BulkScreenshotCaptureRequestUrlsItemWaitForEvent value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BulkScreenshotCaptureRequestUrlsItemWaitForEvent value
    ) => value.Value;

    public static explicit operator BulkScreenshotCaptureRequestUrlsItemWaitForEvent(
        string value
    ) => new(value);

    internal class BulkScreenshotCaptureRequestUrlsItemWaitForEventSerializer
        : JsonConverter<BulkScreenshotCaptureRequestUrlsItemWaitForEvent>
    {
        public override BulkScreenshotCaptureRequestUrlsItemWaitForEvent Read(
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
            return new BulkScreenshotCaptureRequestUrlsItemWaitForEvent(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemWaitForEvent value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkScreenshotCaptureRequestUrlsItemWaitForEvent ReadAsPropertyName(
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
            return new BulkScreenshotCaptureRequestUrlsItemWaitForEvent(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkScreenshotCaptureRequestUrlsItemWaitForEvent value,
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
        public const string Load = "load";

        public const string Domcontentloaded = "domcontentloaded";

        public const string Networkidle = "networkidle";
    }
}
