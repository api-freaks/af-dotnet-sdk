using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class IbanValidateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "valid": true,
              "iban": "iban",
              "validation": {
                "is_alpha_numeric": true,
                "is_iban_supported_country": true,
                "is_valid_length": true,
                "is_valid_structure": true,
                "is_iban_check_digit_valid": true,
                "bban": "bban"
              },
              "bank_data": {
                "bic": "bic",
                "bank": "bank",
                "bank_code": "bank_code",
                "branch_code": "branch_code",
                "country": "country",
                "country_iso2": "country_iso2",
                "city": "city",
                "address": "address",
                "account": "account",
                "sepa": true,
                "branch_name": "branch_name",
                "instit_type": "instit_type",
                "postal_code": "postal_code"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/iban/validation")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("iban", "iban")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.IbanValidateAsync(
            new IbanValidateRequest { ApiKey = "apiKey", Iban = "iban" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "valid": true,
              "iban": "GB49NWBK08609000000003",
              "validation": {
                "is_alpha_numeric": true,
                "is_iban_supported_country": true,
                "is_valid_length": true,
                "is_valid_structure": true,
                "is_iban_check_digit_valid": true,
                "bban": "valid"
              },
              "bank_data": {
                "bic": "NWBKGB2LBHM",
                "bank": "NATIONAL WESTMINSTER BANK PLC",
                "bank_code": "NWBK",
                "branch_code": "branch_code",
                "country": "United Kingdom",
                "country_iso2": "GB",
                "city": "BIRMINGHAM",
                "address": "6 BRINDLEY PLACE",
                "account": "00000003",
                "sepa": true,
                "branch_name": "branch_name",
                "instit_type": "instit_type",
                "postal_code": "postal_code"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/iban/validation")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("iban", "iban")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.IbanValidateAsync(
            new IbanValidateRequest { ApiKey = "apiKey", Iban = "iban" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
