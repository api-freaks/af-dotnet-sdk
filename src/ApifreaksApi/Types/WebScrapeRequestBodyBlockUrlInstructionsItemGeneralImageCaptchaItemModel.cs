using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel.WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModelSerializer)
)]
[Serializable]
public readonly record struct WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel
    : IStringEnum
{
    public static readonly WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel Model1 =
        new(Values.Model1);

    public static readonly WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel Model2 =
        new(Values.Model2);

    public static readonly WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel Model3 =
        new(Values.Model3);

    public static readonly WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel Model4 =
        new(Values.Model4);

    public static readonly WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel Model5 =
        new(Values.Model5);

    public static readonly WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel Model6 =
        new(Values.Model6);

    public static readonly WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel BasicTnImageProcessing =
        new(Values.BasicTnImageProcessing);

    public static readonly WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel BasicPhImageProcessing =
        new(Values.BasicPhImageProcessing);

    public WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel(string value)
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
    public static WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel FromCustom(
        string value
    )
    {
        return new WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel(value);
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
        WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel value
    ) => value.Value;

    public static explicit operator WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel(
        string value
    ) => new(value);

    internal class WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModelSerializer
        : JsonConverter<WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel>
    {
        public override WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel Read(
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
            return new WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel ReadAsPropertyName(
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
            return new WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItemModel value,
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
        public const string Model1 = "Model_1";

        public const string Model2 = "Model_2";

        public const string Model3 = "Model_3";

        public const string Model4 = "Model_4";

        public const string Model5 = "Model_5";

        public const string Model6 = "Model_6";

        public const string BasicTnImageProcessing = "basicTnImageProcessing";

        public const string BasicPhImageProcessing = "basicPhImageProcessing";
    }
}
