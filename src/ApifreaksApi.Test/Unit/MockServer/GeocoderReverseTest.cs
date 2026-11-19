using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GeocoderReverseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "lat": 1.1,
              "lon": 1.1,
              "name": "name",
              "category": "category",
              "type": "type",
              "poi": [
                {
                  "name": "name",
                  "category": "category",
                  "type": "type"
                },
                {
                  "name": "name",
                  "category": "category",
                  "type": "type"
                }
              ],
              "street": "street",
              "area": "area",
              "postcode": "postcode",
              "city": "city",
              "county": "county",
              "state_code": "state_code",
              "state": "state",
              "country_code": "country_code",
              "country": "country",
              "full_address": "full_address",
              "bounding_box": [
                "bounding_box",
                "bounding_box"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geocoder/reverse")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("lat", "90")
                    .WithParam("lon", "180")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GeocoderReverseAsync(
            new GeocoderReverseRequest
            {
                ApiKey = "apiKey",
                Lat = 90,
                Lon = 180,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "lat": 1.1,
              "lon": 1.1,
              "name": "name",
              "category": "category",
              "type": "type",
              "poi": [
                {
                  "name": "name",
                  "category": "category",
                  "type": "type"
                }
              ],
              "street": "street",
              "area": "area",
              "postcode": "postcode",
              "city": "city",
              "county": "county",
              "state_code": "state_code",
              "state": "state",
              "country_code": "country_code",
              "country": "country",
              "full_address": "full_address",
              "bounding_box": [
                "bounding_box"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geocoder/reverse")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("lat", "1.1")
                    .WithParam("lon", "1.1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GeocoderReverseAsync(
            new GeocoderReverseRequest
            {
                ApiKey = "apiKey",
                Lat = 1.1,
                Lon = 1.1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
