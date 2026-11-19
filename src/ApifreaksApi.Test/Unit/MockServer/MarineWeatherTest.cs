using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class MarineWeatherTest : BaseMockServerTest
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
              "current": {
                "timestamp": "timestamp",
                "wave_height": 1.1,
                "wave_direction": 1.1,
                "wave_period": 1.1,
                "wind_wave_height": 1.1,
                "wind_wave_direction": 1.1,
                "wind_wave_period": 1.1,
                "swell_wave_height": 1.1,
                "swell_wave_direction": 1.1,
                "swell_wave_period": 1.1,
                "sea_level_height_msl": 1.1,
                "sea_surface_temperature": 1.1,
                "ocean_current_velocity": 1.1,
                "ocean_current_direction": 1.1,
                "swell_wave_peak_period": 1.1,
                "wind_wave_peak_period": 1.1
              },
              "forecast": {
                "forecast": {
                  "daily": {
                    "timestamp": "timestamp",
                    "wave_height_max": 1.1,
                    "wave_direction_dominant": 1,
                    "wave_period_max": 1.1,
                    "wind_wave_height_max": 1.1,
                    "wind_wave_direction_dominant": 1,
                    "wind_wave_period_max": 1.1,
                    "wind_wave_peak_period_max": 1.1,
                    "swell_wave_height_max": 1.1,
                    "swell_wave_direction_dominant": 1,
                    "swell_wave_period_max": 1.1,
                    "swell_wave_peak_period_max": 1.1
                  },
                  "hourly": [
                    {
                      "timestamp": "timestamp",
                      "wave_height": 1.1,
                      "wave_direction": 1,
                      "wave_period": 1.1,
                      "wind_wave_height": 1.1,
                      "wind_wave_peak_period": 1.1,
                      "wind_wave_direction": 1,
                      "wind_wave_period": 1.1,
                      "swell_wave_height": 1.1,
                      "swell_wave_direction": 1,
                      "swell_wave_period": 1.1,
                      "swell_wave_peak_period": 1.1,
                      "sea_surface_temperature": 1.1,
                      "sea_level_height_msl": 1.1,
                      "ocean_current_velocity": 1.1,
                      "ocean_current_direction": 1
                    },
                    {
                      "timestamp": "timestamp",
                      "wave_height": 1.1,
                      "wave_direction": 1,
                      "wave_period": 1.1,
                      "wind_wave_height": 1.1,
                      "wind_wave_peak_period": 1.1,
                      "wind_wave_direction": 1,
                      "wind_wave_period": 1.1,
                      "swell_wave_height": 1.1,
                      "swell_wave_direction": 1,
                      "swell_wave_period": 1.1,
                      "swell_wave_peak_period": 1.1,
                      "sea_surface_temperature": 1.1,
                      "sea_level_height_msl": 1.1,
                      "ocean_current_velocity": 1.1,
                      "ocean_current_direction": 1
                    }
                  ],
                  "minutely": [
                    {
                      "timestamp": "timestamp",
                      "ocean_current_velocity": 1.1,
                      "ocean_current_direction": 1,
                      "sea_level_height_msl": 1.1
                    },
                    {
                      "timestamp": "timestamp",
                      "ocean_current_velocity": 1.1,
                      "ocean_current_direction": 1,
                      "sea_level_height_msl": 1.1
                    }
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/weather/marine")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MarineWeatherAsync(
            new MarineWeatherRequest { ApiKey = "apiKey" }
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
                "timezone": "America/Los_Angeles",
                "timezone_abbreviation": "GMT-7"
              },
              "current": {
                "timestamp": "timestamp",
                "wave_height": 1.1,
                "wave_direction": 1.1,
                "wave_period": 1.1,
                "wind_wave_height": 1.1,
                "wind_wave_direction": 1.1,
                "wind_wave_period": 1.1,
                "swell_wave_height": 1.1,
                "swell_wave_direction": 1.1,
                "swell_wave_period": 1.1,
                "sea_level_height_msl": 1.1,
                "sea_surface_temperature": 1.1,
                "ocean_current_velocity": 1.1,
                "ocean_current_direction": 1.1,
                "swell_wave_peak_period": 1.1,
                "wind_wave_peak_period": 1.1
              },
              "forecast": {
                "2025-10-01": {
                  "daily": {
                    "timestamp": "2025-10-01"
                  },
                  "hourly": [
                    {}
                  ],
                  "minutely": [
                    {}
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/weather/marine")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MarineWeatherAsync(
            new MarineWeatherRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
