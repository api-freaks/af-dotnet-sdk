using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AstronomyLookupV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "ip": "ip",
              "location": {
                "location_string": "location_string",
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
                "elevation": "elevation"
              },
              "astronomy": {
                "time_zone": "time_zone",
                "date": "date",
                "current_time": "current_time",
                "mid_night": "mid_night",
                "night_end": "night_end",
                "morning": {
                  "astronomical_twilight_begin": "astronomical_twilight_begin",
                  "astronomical_twilight_end": "astronomical_twilight_end",
                  "nautical_twilight_begin": "nautical_twilight_begin",
                  "nautical_twilight_end": "nautical_twilight_end",
                  "civil_twilight_begin": "civil_twilight_begin",
                  "civil_twilight_end": "civil_twilight_end",
                  "blue_hour_begin": "blue_hour_begin",
                  "blue_hour_end": "blue_hour_end",
                  "golden_hour_begin": "golden_hour_begin",
                  "golden_hour_end": "golden_hour_end"
                },
                "sunrise": "sunrise",
                "sunset": "sunset",
                "evening": {
                  "golden_hour_begin": "golden_hour_begin",
                  "golden_hour_end": "golden_hour_end",
                  "blue_hour_begin": "blue_hour_begin",
                  "blue_hour_end": "blue_hour_end",
                  "civil_twilight_begin": "civil_twilight_begin",
                  "civil_twilight_end": "civil_twilight_end",
                  "nautical_twilight_begin": "nautical_twilight_begin",
                  "nautical_twilight_end": "nautical_twilight_end",
                  "astronomical_twilight_begin": "astronomical_twilight_begin",
                  "astronomical_twilight_end": "astronomical_twilight_end"
                },
                "night_begin": "night_begin",
                "sun_status": "sun_status",
                "solar_noon": "solar_noon",
                "day_length": "day_length",
                "sun_altitude": 1.1,
                "sun_distance": 1.1,
                "sun_azimuth": 1.1,
                "moon_phase": "moon_phase",
                "moonrise": "moonrise",
                "moonset": "moonset",
                "moon_status": "moon_status",
                "moon_altitude": 1.1,
                "moon_distance": 1.1,
                "moon_azimuth": 1.1,
                "moon_parallactic_angle": 1.1,
                "moon_illumination_percentage": "moon_illumination_percentage",
                "moon_angle": 1.1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/geolocation/astronomy")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AstronomyLookupV2Async(
            new AstronomyLookupV2Request { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
