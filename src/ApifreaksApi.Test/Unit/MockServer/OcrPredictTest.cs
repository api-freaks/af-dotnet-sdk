using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class OcrPredictTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "model": "mini-ocr-v1"
            }
            """;

        const string mockResponse = """
            {
              "OCRText": [
                "Extracted text from the image or document"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/ocr/predict")
                    .WithParam("apiKey", "apiKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OcrPredictAsync(
            new OcrPredictRequest { ApiKey = "apiKey", Model = OcrPredictRequestModel.MiniOcrV1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "model": "mini-ocr-v1"
            }
            """;

        const string mockResponse = """
            {
              "OCRText": [
                "Line 1 of extracted text",
                "Line 2 of extracted text",
                "Line 3 of extracted text"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/ocr/predict")
                    .WithParam("apiKey", "apiKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OcrPredictAsync(
            new OcrPredictRequest { ApiKey = "apiKey", Model = OcrPredictRequestModel.MiniOcrV1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "model": "mini-ocr-v1"
            }
            """;

        const string mockResponse = """
            {
              "OCRText": [
                "Text extracted from file 1",
                "Text extracted from file 2",
                "Text extracted from file 3"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/ocr/predict")
                    .WithParam("apiKey", "apiKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OcrPredictAsync(
            new OcrPredictRequest { ApiKey = "apiKey", Model = OcrPredictRequestModel.MiniOcrV1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "model": "mini-ocr-v1"
            }
            """;

        const string mockResponse = """
            {
              "OCRText": [
                [
                  "Line 1 of file 1",
                  "Line 2 of file 1",
                  "Line 3 of file 1"
                ],
                [
                  "Line 1 of file 2",
                  "Line 2 of file 2"
                ],
                [
                  "Line 1 of file 3",
                  "Line 2 of file 3",
                  "Line 3 of file 3",
                  "Line 4 of file 3"
                ]
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/ocr/predict")
                    .WithParam("apiKey", "apiKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OcrPredictAsync(
            new OcrPredictRequest { ApiKey = "apiKey", Model = OcrPredictRequestModel.MiniOcrV1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
