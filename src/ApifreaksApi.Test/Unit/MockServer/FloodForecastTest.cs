using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class FloodForecastTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "location": {
                "continent_code": "continent_code",
                "continent_name": "continent_name",
                "country_code2": "country_code2",
                "country_code3": "country_code3",
                "country_name": "country_name",
                "country_name_official": "country_name_official",
                "is_eu": true,
                "state_prov": "state_prov",
                "state_code": "state_code",
                "district": "district",
                "city": "city",
                "zipcode": "zipcode",
                "latitude": "latitude",
                "longitude": "longitude",
                "locality": "locality",
                "elevation": "elevation",
                "timezone": "timezone",
                "timezone_abbreviation": "timezone_abbreviation"
              },
              "forecast": {
                "forecast": {
                  "daily": {
                    "timestamp": "timestamp",
                    "river_discharge": 1.1,
                    "river_discharge_mean": 1.1,
                    "river_discharge_median": 1.1,
                    "river_discharge_max": 1.1,
                    "river_discharge_min": 1.1,
                    "river_discharge_p25": 1.1,
                    "river_discharge_p75": 1.1
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/weather/flood")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("startDate", "2023-01-15")
                    .WithParam("endDate", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.FloodForecastAsync(
            new FloodForecastRequest
            {
                ApiKey = "apiKey",
                StartDate = new DateOnly(2023, 1, 15),
                EndDate = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "location": {
                "continent_code": "NA",
                "continent_name": "North America",
                "country_code2": "US",
                "country_code3": "USA",
                "country_name": "United States",
                "country_name_official": "United States of America",
                "is_eu": false,
                "state_prov": "California",
                "state_code": "US-CA",
                "district": "Santa Clara",
                "city": "Mountain View",
                "zipcode": "94043-1351",
                "latitude": "37.42240",
                "longitude": "-122.08421",
                "locality": "Charleston Terrace",
                "elevation": "3",
                "timezone": "GMT",
                "timezone_abbreviation": "GMT"
              },
              "forecast": {
                "2025-10-01": {
                  "daily": {
                    "timestamp": "2025-10-01",
                    "river_discharge": 0.44,
                    "river_discharge_mean": 0.44,
                    "river_discharge_median": 0.44,
                    "river_discharge_max": 0.49,
                    "river_discharge_min": 0.44,
                    "river_discharge_p25": 0.44,
                    "river_discharge_p75": 0.44
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/weather/flood")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("startDate", "2023-01-15")
                    .WithParam("endDate", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.FloodForecastAsync(
            new FloodForecastRequest
            {
                ApiKey = "apiKey",
                StartDate = new DateOnly(2023, 1, 15),
                EndDate = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
