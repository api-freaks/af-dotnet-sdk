using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class WebScrapeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "instructions": [
                {},
                {}
              ]
            }
            """;

        const string mockResponse = """
            {
              "extractedData": {
                "extractedData": {
                  "key": "value"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/scraping")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("url", "url")
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

        var response = await Client.WebScrapeAsync(
            new WebScrapeRequest
            {
                ApiKey = "apiKey",
                Url = "url",
                Body = new WebScrapeRequestBodyBlockUrl
                {
                    BlockUrl = null,
                    Cookies = null,
                    Instructions = new List<WebScrapeRequestBodyBlockUrlInstructionsItem>()
                    {
                        new WebScrapeRequestBodyBlockUrlInstructionsItem
                        {
                            Fill = null,
                            Click = null,
                            ClickIfExist = null,
                            Enter = null,
                            NewTab = null,
                            MoveToRelativeTab = null,
                            Wait = null,
                            WaitFor = null,
                            Select = null,
                            JsExe = null,
                            ConditionalCheck = null,
                            ClickButtonByValue = null,
                            GeneralImageCaptcha = null,
                            BlockElement = null,
                            Extract = null,
                            FillImageCaptcha = null,
                            SwitchToIframe = null,
                            SwitchToParentFrame = null,
                            ResolveAudioCaptcha = null,
                            Screenshot = null,
                            Saveimage = null,
                        },
                        new WebScrapeRequestBodyBlockUrlInstructionsItem
                        {
                            Fill = null,
                            Click = null,
                            ClickIfExist = null,
                            Enter = null,
                            NewTab = null,
                            MoveToRelativeTab = null,
                            Wait = null,
                            WaitFor = null,
                            Select = null,
                            JsExe = null,
                            ConditionalCheck = null,
                            ClickButtonByValue = null,
                            GeneralImageCaptcha = null,
                            BlockElement = null,
                            Extract = null,
                            FillImageCaptcha = null,
                            SwitchToIframe = null,
                            SwitchToParentFrame = null,
                            ResolveAudioCaptcha = null,
                            Screenshot = null,
                            Saveimage = null,
                        },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "instructions": [
                {},
                {},
                {},
                {},
                {
                  "extract": {
                    "profile": "#profile",
                    "welcomeMessage": "#welcome-message",
                    "userInfo": "#user-info"
                  }
                },
                {},
                {}
              ]
            }
            """;

        const string mockResponse = """
            {
              "extractedData": {
                "html": "El nombre de dominio: google.sv se encuentra RegistradoNombre de dominio: google.svEstado: RegistradoContacto Administrativo: Cesar Ulises Trujillo MartínezCorreo Electrónico: admin@admindotsv.comTeléfono: 503 2284-8531Fecha Registro: 01-01-2013Fecha de vencimiento: 01-01-2026Fecha de Baja: 01-02-2026"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/scraping")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("url", "https://example.com")
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

        var response = await Client.WebScrapeAsync(
            new WebScrapeRequest
            {
                ApiKey = "apiKey",
                Url = "https://example.com",
                Body = new WebScrapeRequestBodyBlockUrl
                {
                    Instructions = new List<WebScrapeRequestBodyBlockUrlInstructionsItem>()
                    {
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem
                        {
                            Extract = new Dictionary<string, string>()
                            {
                                { "profile", "#profile" },
                                { "welcomeMessage", "#welcome-message" },
                                { "userInfo", "#user-info" },
                            },
                        },
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "instructions": [
                {
                  "postForm": {
                    "selector": "#loginForm",
                    "data": {
                      "username": "myuser",
                      "password": "mypassword"
                    }
                  }
                },
                {
                  "extract": {
                    "mainContent": "#main-content",
                    "welcomeMessage": "#welcome-message"
                  }
                },
                {
                  "getForm": {
                    "selector": "#searchForm",
                    "data": {
                      "query": "API scraping"
                    }
                  }
                },
                {
                  "extract": {
                    "searchResults": "#search-results"
                  }
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "extractedData": {
                "html": "El nombre de dominio: google.sv se encuentra RegistradoNombre de dominio: google.svEstado: RegistradoContacto Administrativo: Cesar Ulises Trujillo MartínezCorreo Electrónico: admin@admindotsv.comTeléfono: 503 2284-8531Fecha Registro: 01-01-2013Fecha de vencimiento: 01-01-2026Fecha de Baja: 01-02-2026"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/scraping")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("url", "https://example.com")
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

        var response = await Client.WebScrapeAsync(
            new WebScrapeRequest
            {
                ApiKey = "apiKey",
                Url = "https://example.com",
                Body = new WebScrapeRequestBodyOne
                {
                    Instructions = new List<WebScrapeRequestBodyOneInstructionsItem>()
                    {
                        new WebScrapeRequestBodyOneInstructionsItem
                        {
                            PostForm = new WebScrapeRequestBodyOneInstructionsItemPostForm
                            {
                                Selector = "#loginForm",
                                Data = new Dictionary<string, string>()
                                {
                                    { "username", "myuser" },
                                    { "password", "mypassword" },
                                },
                            },
                        },
                        new WebScrapeRequestBodyOneInstructionsItem
                        {
                            Extract = new Dictionary<string, string>()
                            {
                                { "mainContent", "#main-content" },
                                { "welcomeMessage", "#welcome-message" },
                            },
                        },
                        new WebScrapeRequestBodyOneInstructionsItem
                        {
                            GetForm = new WebScrapeRequestBodyOneInstructionsItemGetForm
                            {
                                Selector = "#searchForm",
                                Data = new Dictionary<string, string>()
                                {
                                    { "query", "API scraping" },
                                },
                            },
                        },
                        new WebScrapeRequestBodyOneInstructionsItem
                        {
                            Extract = new Dictionary<string, string>()
                            {
                                { "searchResults", "#search-results" },
                            },
                        },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "instructions": [
                {},
                {},
                {},
                {},
                {
                  "extract": {
                    "profile": "#profile",
                    "welcomeMessage": "#welcome-message",
                    "userInfo": "#user-info"
                  }
                },
                {},
                {}
              ]
            }
            """;

        const string mockResponse = """
            {
              "extractedData": {
                "html": "El nombre de dominio: google.sv se encuentra RegistradoNombre de dominio: google.svEstado: RegistradoContacto Administrativo: Cesar Ulises Trujillo MartínezCorreo Electrónico: admin@admindotsv.comTeléfono: 503 2284-8531Fecha Registro: 01-01-2013Fecha de vencimiento: 01-01-2026Fecha de Baja: 01-02-2026"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/scraping")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("url", "https://example.com")
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

        var response = await Client.WebScrapeAsync(
            new WebScrapeRequest
            {
                ApiKey = "apiKey",
                Url = "https://example.com",
                Body = new WebScrapeRequestBodyBlockUrl
                {
                    Instructions = new List<WebScrapeRequestBodyBlockUrlInstructionsItem>()
                    {
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem
                        {
                            Extract = new Dictionary<string, string>()
                            {
                                { "profile", "#profile" },
                                { "welcomeMessage", "#welcome-message" },
                                { "userInfo", "#user-info" },
                            },
                        },
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "instructions": [
                {},
                {},
                {},
                {},
                {
                  "extract": {
                    "profile": "#profile",
                    "welcomeMessage": "#welcome-message",
                    "userInfo": "#user-info"
                  }
                },
                {},
                {}
              ]
            }
            """;

        const string mockResponse = """
            {
              "extractedData": {
                "server": [
                  "coleman.ns.cloudflare.com",
                  "nadia.ns.cloudflare.com",
                  "",
                  ""
                ],
                "domain name": "nust.edu.pk",
                "expiry date": "Feb 1, 2026",
                "status": "Domain is Registered"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/scraping")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("url", "https://example.com")
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

        var response = await Client.WebScrapeAsync(
            new WebScrapeRequest
            {
                ApiKey = "apiKey",
                Url = "https://example.com",
                Body = new WebScrapeRequestBodyBlockUrl
                {
                    Instructions = new List<WebScrapeRequestBodyBlockUrlInstructionsItem>()
                    {
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem
                        {
                            Extract = new Dictionary<string, string>()
                            {
                                { "profile", "#profile" },
                                { "welcomeMessage", "#welcome-message" },
                                { "userInfo", "#user-info" },
                            },
                        },
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                        new WebScrapeRequestBodyBlockUrlInstructionsItem(),
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
