using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PdfGetTaskStatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "taskId": "taskId",
              "status": "status",
              "createdAt": "createdAt",
              "zipOutputUrl": "zipOutputUrl",
              "zipFileId": "zipFileId",
              "outputUrls": [
                "outputUrls",
                "outputUrls"
              ],
              "outputIds": [
                "outputIds",
                "outputIds"
              ],
              "inputIds": [
                "inputIds",
                "inputIds"
              ],
              "error": "error",
              "message": "message",
              "expiresAt": "expiresAt",
              "zipFileUrl": "zipFileUrl"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/pdf/task-status")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("task_id", "task_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PdfGetTaskStatusAsync(
            new PdfGetTaskStatusRequest { ApiKey = "apiKey", TaskId = "task_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "taskId": "taskId",
              "status": "status",
              "createdAt": "createdAt",
              "zipFileId": "zipFileId",
              "outputUrls": [
                "outputUrls"
              ],
              "outputIds": [
                "outputIds"
              ],
              "inputIds": [
                "inputIds"
              ],
              "error": "error",
              "message": "message",
              "expiresAt": "expiresAt",
              "zipFileUrl": "zipFileUrl"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/pdf/task-status")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("task_id", "task_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PdfGetTaskStatusAsync(
            new PdfGetTaskStatusRequest { ApiKey = "apiKey", TaskId = "task_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
