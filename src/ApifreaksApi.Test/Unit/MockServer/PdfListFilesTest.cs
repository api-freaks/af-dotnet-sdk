using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PdfListFilesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "files": [
                {
                  "fileId": "fileId",
                  "fileName": "fileName",
                  "fileType": "fileType",
                  "fileCreationTime": "2024-01-15T09:30:00.000Z",
                  "fileDeletionTime": "2023-01-15"
                },
                {
                  "fileId": "fileId",
                  "fileName": "fileName",
                  "fileType": "fileType",
                  "fileCreationTime": "2024-01-15T09:30:00.000Z",
                  "fileDeletionTime": "2023-01-15"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/pdf/files")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PdfListFilesAsync(
            new PdfListFilesRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "files": [
                {
                  "fileId": "fileId",
                  "fileName": "fileName",
                  "fileType": "fileType",
                  "fileCreationTime": "2024-01-15T09:30:00.000Z",
                  "fileDeletionTime": "2023-01-15"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/pdf/files")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PdfListFilesAsync(
            new PdfListFilesRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
