using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VatValidateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "country_code": "country_code",
              "vat_number": "vat_number",
              "requester_country_code": "requester_country_code",
              "requester_vat_number": "requester_vat_number",
              "requested_at": "2024-01-15T09:30:00.000Z",
              "validation": {
                "is_valid": true,
                "consultation_number": "consultation_number",
                "consultation_authority": "consultation_authority"
              },
              "company": {
                "company_name": "company_name",
                "company_address": "company_address"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/vat/validation")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("vatNumber", "vatNumber")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.VatValidateAsync(
            new VatValidateRequest { ApiKey = "apiKey", VatNumber = "vatNumber" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "country_code": "GB",
              "vat_number": "289111588",
              "requester_country_code": "GB",
              "requester_vat_number": "288305674",
              "requested_at": "2026-04-14T13:51:32.000Z",
              "validation": {
                "is_valid": true,
                "consultation_number": "KNN-ARL-LTK",
                "consultation_authority": "HMRC"
              },
              "company": {
                "company_name": "EVENTURED LTD",
                "company_address": "SUITE 10, BEAUFORT COURT, ADMIRALS WAY, LONDON, E14 9XL, GB"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/vat/validation")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("vatNumber", "vatNumber")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.VatValidateAsync(
            new VatValidateRequest { ApiKey = "apiKey", VatNumber = "vatNumber" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
