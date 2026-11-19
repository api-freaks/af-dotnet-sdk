using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SwiftCodeLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "swiftCode": "swiftCode",
              "countryCode": "countryCode",
              "bankAddress": "bankAddress",
              "bankCode": "bankCode",
              "bankName": "bankName",
              "city": "city",
              "country": "country",
              "branchName": "branchName",
              "institType": "institType",
              "postalCode": "postalCode"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/swift-code/lookup")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("swiftCode", "swiftCode")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SwiftCodeLookupAsync(
            new SwiftCodeLookupRequest { ApiKey = "apiKey", SwiftCode = "swiftCode" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "swiftCode": "swiftCode",
              "countryCode": "countryCode",
              "bankAddress": "bankAddress",
              "bankCode": "bankCode",
              "bankName": "bankName",
              "city": "city",
              "country": "country",
              "branchName": "branchName",
              "institType": "institType",
              "postalCode": "postalCode"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/swift-code/lookup")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("swiftCode", "swiftCode")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SwiftCodeLookupAsync(
            new SwiftCodeLookupRequest { ApiKey = "apiKey", SwiftCode = "swiftCode" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
