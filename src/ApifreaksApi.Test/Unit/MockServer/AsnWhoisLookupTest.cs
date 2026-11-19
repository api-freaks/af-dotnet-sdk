using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AsnWhoisLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "asNumber": "asNumber",
              "asName": "asName",
              "orgName": "orgName",
              "description": "description",
              "orgHandle": "orgHandle",
              "country": "country",
              "domain": "domain",
              "website": "website",
              "allocationStatus": "allocationStatus",
              "numOfIPv4Routes": "numOfIPv4Routes",
              "numOfIPv6Routes": "numOfIPv6Routes",
              "whoisHost": "whoisHost",
              "dateAllocated": "2023-01-15",
              "type": "type",
              "routeObjects": [
                {
                  "route": "route",
                  "origin": "origin",
                  "originName": "originName",
                  "isp": "isp",
                  "numberOfIps": 1.1
                },
                {
                  "route": "route",
                  "origin": "origin",
                  "originName": "originName",
                  "isp": "isp",
                  "numberOfIps": 1.1
                }
              ],
              "whoisResponse": "whoisResponse",
              "downstreams": [
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                },
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                }
              ],
              "parsedWhoisResponse": {
                "status": true,
                "whois_server": "whois_server",
                "aut_nums": [
                  {
                    "aut_num": "aut_num",
                    "as_handle": "as_handle",
                    "as_name": "as_name",
                    "tech_contacts": [
                      "tech_contacts",
                      "tech_contacts"
                    ],
                    "abuse_contacts": [
                      "abuse_contacts",
                      "abuse_contacts"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source",
                    "description": "description",
                    "country": "country",
                    "status": [
                      "status",
                      "status"
                    ],
                    "member_of": [
                      "member_of",
                      "member_of"
                    ],
                    "import_via": [
                      "import_via",
                      "import_via"
                    ],
                    "import": [
                      "import",
                      "import"
                    ],
                    "mp_import": [
                      "mp_import",
                      "mp_import"
                    ],
                    "export_via": [
                      "export_via",
                      "export_via"
                    ],
                    "export": [
                      "export",
                      "export"
                    ],
                    "mp_export": [
                      "mp_export",
                      "mp_export"
                    ],
                    "default": [
                      "default",
                      "default"
                    ],
                    "mp_default": [
                      "mp_default",
                      "mp_default"
                    ],
                    "organization": "organization",
                    "sponsoring_organization": "sponsoring_organization",
                    "admin_contacts": [
                      "admin_contacts",
                      "admin_contacts"
                    ]
                  },
                  {
                    "aut_num": "aut_num",
                    "as_handle": "as_handle",
                    "as_name": "as_name",
                    "tech_contacts": [
                      "tech_contacts",
                      "tech_contacts"
                    ],
                    "abuse_contacts": [
                      "abuse_contacts",
                      "abuse_contacts"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source",
                    "description": "description",
                    "country": "country",
                    "status": [
                      "status",
                      "status"
                    ],
                    "member_of": [
                      "member_of",
                      "member_of"
                    ],
                    "import_via": [
                      "import_via",
                      "import_via"
                    ],
                    "import": [
                      "import",
                      "import"
                    ],
                    "mp_import": [
                      "mp_import",
                      "mp_import"
                    ],
                    "export_via": [
                      "export_via",
                      "export_via"
                    ],
                    "export": [
                      "export",
                      "export"
                    ],
                    "mp_export": [
                      "mp_export",
                      "mp_export"
                    ],
                    "default": [
                      "default",
                      "default"
                    ],
                    "mp_default": [
                      "mp_default",
                      "mp_default"
                    ],
                    "organization": "organization",
                    "sponsoring_organization": "sponsoring_organization",
                    "admin_contacts": [
                      "admin_contacts",
                      "admin_contacts"
                    ]
                  }
                ],
                "organization": {
                  "handle": "handle",
                  "name": "name",
                  "address": [
                    "address",
                    "address"
                  ],
                  "street": "street",
                  "city": "city",
                  "state": "state",
                  "zip_code": "zip_code",
                  "country": [
                    "country",
                    "country"
                  ],
                  "addressCountry": "addressCountry",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "source": "source"
                },
                "technical_contacts": [
                  {
                    "handle": "handle",
                    "name": "name",
                    "email": [
                      "email",
                      "email"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "source": "source"
                  },
                  {
                    "handle": "handle",
                    "name": "name",
                    "email": [
                      "email",
                      "email"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "source": "source"
                  }
                ],
                "abuse_contacts": [
                  {
                    "handle": "handle",
                    "name": "name",
                    "email": [
                      "email",
                      "email"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "source": "source"
                  },
                  {
                    "handle": "handle",
                    "name": "name",
                    "email": [
                      "email",
                      "email"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "source": "source"
                  }
                ],
                "query_time": "query_time",
                "r_whois_raw_response": "r_whois_raw_response",
                "whois_raw_response": "whois_raw_response"
              },
              "upstreams": [
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                },
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                }
              ],
              "peers": [
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                },
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                }
              ],
              "contacts": {
                "emailContacts": [
                  "emailContacts",
                  "emailContacts"
                ],
                "abuseContacts": [
                  "abuseContacts",
                  "abuseContacts"
                ]
              },
              "legacyRoutes": [
                "legacyRoutes",
                "legacyRoutes"
              ],
              "whois_raw_response": "whois_raw_response",
              "r_whois_raw_response": "r_whois_raw_response",
              "query_time": "query_time"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/asn/whois/live")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("asn", "asn")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AsnWhoisLookupAsync(
            new AsnWhoisLookupRequest { ApiKey = "apiKey", Asn = "asn" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "asNumber": "asNumber",
              "asName": "asName",
              "orgName": "orgName",
              "description": "description",
              "orgHandle": "orgHandle",
              "country": "country",
              "domain": "domain",
              "website": "website",
              "allocationStatus": "allocationStatus",
              "numOfIPv4Routes": "numOfIPv4Routes",
              "numOfIPv6Routes": "numOfIPv6Routes",
              "whoisHost": "whoisHost",
              "dateAllocated": "2023-01-15",
              "type": "type",
              "routeObjects": [
                {
                  "route": "route",
                  "origin": "origin",
                  "originName": "originName",
                  "isp": "isp",
                  "numberOfIps": 1.1
                }
              ],
              "whoisResponse": "whoisResponse",
              "downstreams": [
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                }
              ],
              "parsedWhoisResponse": {
                "status": true,
                "whois_server": "whois_server",
                "aut_nums": [
                  {
                    "aut_num": "aut_num",
                    "as_handle": "as_handle",
                    "as_name": "as_name",
                    "tech_contacts": [
                      "tech_contacts"
                    ],
                    "abuse_contacts": [
                      "abuse_contacts"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source"
                  }
                ],
                "organization": {
                  "handle": "handle",
                  "name": "name",
                  "address": [
                    "address"
                  ],
                  "street": "street",
                  "city": "city",
                  "state": "state",
                  "zip_code": "zip_code",
                  "country": [
                    "country"
                  ],
                  "addressCountry": "addressCountry",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "source": "source"
                },
                "technical_contacts": [
                  {
                    "handle": "handle",
                    "name": "name",
                    "email": [
                      "email"
                    ]
                  }
                ],
                "abuse_contacts": [
                  {
                    "handle": "handle",
                    "name": "name",
                    "email": [
                      "email"
                    ]
                  }
                ],
                "query_time": "query_time",
                "r_whois_raw_response": "r_whois_raw_response",
                "whois_raw_response": "whois_raw_response"
              },
              "upstreams": [
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                }
              ],
              "peers": [
                {
                  "asNumber": "asNumber",
                  "description": "description",
                  "country": "country"
                }
              ],
              "contacts": {
                "emailContacts": [
                  "emailContacts"
                ],
                "abuseContacts": [
                  "abuseContacts"
                ]
              },
              "legacyRoutes": [
                "legacyRoutes"
              ],
              "whois_raw_response": "whois_raw_response",
              "r_whois_raw_response": "r_whois_raw_response",
              "query_time": "query_time"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/asn/whois/live")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("asn", "asn")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.AsnWhoisLookupAsync(
            new AsnWhoisLookupRequest { ApiKey = "apiKey", Asn = "asn" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
