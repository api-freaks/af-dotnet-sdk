using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainTyposquattingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "status": true,
              "totalRecords": 1,
              "currentPage": 1,
              "hasNextPage": true,
              "totalPages": 1,
              "nextPageToken": "nextPageToken",
              "domains": [
                {
                  "domainName": "domainName",
                  "createDate": "createDate",
                  "expiryDate": "expiryDate",
                  "lastSeen": "lastSeen",
                  "isDropped": true
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/typosquatting")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainTyposquattingAsync(
            new DomainTyposquattingRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
