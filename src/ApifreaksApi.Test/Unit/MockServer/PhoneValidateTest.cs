using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PhoneValidateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "number": "number"
            }
            """;

        const string mockResponse = """
            {
              "raw_input": {
                "number": "number",
                "region": "region",
                "dialer_region": "dialer_region"
              },
              "possible": true,
              "valid": true,
              "country_prefix": 1,
              "national_number": 1000000,
              "country_code": "country_code",
              "carrier": "carrier",
              "location": "location",
              "time_zones": [
                "time_zones",
                "time_zones"
              ],
              "line_type": "MOBILE",
              "formats": {
                "E164": "E164",
                "International": "International",
                "National": "National",
                "RFC3966": "RFC3966"
              },
              "area_code_length": 1,
              "ndc_length": 1,
              "can_be_internationally_dialled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/phone/validation")
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

        var response = await Client.PhoneValidateAsync(
            new PhoneValidateRequest
            {
                ApiKey = "apiKey",
                Number = "number",
                Region = null,
                DialerRegion = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "number": "+14155552671"
            }
            """;

        const string mockResponse = """
            {
              "raw_input": {
                "number": "+14155552671",
                "region": "US",
                "dialer_region": "dialer_region"
              },
              "possible": true,
              "valid": true,
              "country_prefix": 1,
              "national_number": 4155552671,
              "country_code": "US",
              "carrier": "Verizon Communications",
              "location": "San Francisco, CA",
              "time_zones": [
                "America/Los_Angeles"
              ],
              "line_type": "MOBILE",
              "formats": {
                "E164": "+14155552671",
                "International": "+1 415-555-2671",
                "National": "(415) 555-2671",
                "RFC3966": "tel:+1-415-555-2671"
              },
              "area_code_length": 3,
              "ndc_length": 3,
              "can_be_internationally_dialled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/phone/validation")
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

        var response = await Client.PhoneValidateAsync(
            new PhoneValidateRequest { ApiKey = "apiKey", Number = "+14155552671" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "number": "03301112233",
              "region": "PK"
            }
            """;

        const string mockResponse = """
            {
              "raw_input": {
                "number": "+14155552671",
                "region": "US",
                "dialer_region": "dialer_region"
              },
              "possible": true,
              "valid": true,
              "country_prefix": 1,
              "national_number": 4155552671,
              "country_code": "US",
              "carrier": "Verizon Communications",
              "location": "San Francisco, CA",
              "time_zones": [
                "America/Los_Angeles"
              ],
              "line_type": "MOBILE",
              "formats": {
                "E164": "+14155552671",
                "International": "+1 415-555-2671",
                "National": "(415) 555-2671",
                "RFC3966": "tel:+1-415-555-2671"
              },
              "area_code_length": 3,
              "ndc_length": 3,
              "can_be_internationally_dialled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/phone/validation")
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

        var response = await Client.PhoneValidateAsync(
            new PhoneValidateRequest
            {
                ApiKey = "apiKey",
                Number = "03301112233",
                Region = "PK",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "number": "0014155552671",
              "dialer_region": "AU"
            }
            """;

        const string mockResponse = """
            {
              "raw_input": {
                "number": "+14155552671",
                "region": "US",
                "dialer_region": "dialer_region"
              },
              "possible": true,
              "valid": true,
              "country_prefix": 1,
              "national_number": 4155552671,
              "country_code": "US",
              "carrier": "Verizon Communications",
              "location": "San Francisco, CA",
              "time_zones": [
                "America/Los_Angeles"
              ],
              "line_type": "MOBILE",
              "formats": {
                "E164": "+14155552671",
                "International": "+1 415-555-2671",
                "National": "(415) 555-2671",
                "RFC3966": "tel:+1-415-555-2671"
              },
              "area_code_length": 3,
              "ndc_length": 3,
              "can_be_internationally_dialled": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/phone/validation")
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

        var response = await Client.PhoneValidateAsync(
            new PhoneValidateRequest
            {
                ApiKey = "apiKey",
                Number = "0014155552671",
                DialerRegion = "AU",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
