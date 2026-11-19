using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainWhoisReverseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "total_Result": 1,
              "total_Pages": 1,
              "current_Page": 1,
              "whois_domains_historical": [
                {
                  "num": 1,
                  "status": true,
                  "domain_name": "domain_name",
                  "query_time": "query_time",
                  "whois_server": "whois_server",
                  "domain_registered": "yes",
                  "create_date": "2023-01-15",
                  "update_date": "2023-01-15",
                  "expiry_date": "2023-01-15",
                  "domain_registrar": {
                    "iana_id": "iana_id",
                    "registrar_name": "registrar_name",
                    "whois_server": "whois_server",
                    "website_url": "website_url",
                    "email_address": "email_address",
                    "phone_number": "phone_number",
                    "normalized_name": "normalized_name",
                    "rdap_server": "rdap_server",
                    "status": "status"
                  },
                  "reseller_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "registrant_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "administrative_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "technical_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "billing_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "name_servers": [
                    "name_servers",
                    "name_servers"
                  ],
                  "domain_status": [
                    "domain_status",
                    "domain_status"
                  ],
                  "whois_raw_domain": "whois_raw_domain",
                  "registry_data": {
                    "domain_name": "domain_name",
                    "query_time": "query_time",
                    "whois_server": "whois_server",
                    "domain_registered": "yes",
                    "create_date": "2023-01-15",
                    "update_date": "2023-01-15",
                    "expiry_date": "2023-01-15",
                    "name_servers": [
                      "name_servers",
                      "name_servers"
                    ],
                    "domain_status": [
                      "domain_status",
                      "domain_status"
                    ],
                    "whois_raw_registry": "whois_raw_registry",
                    "domain_registrar": {
                      "iana_id": "iana_id",
                      "registrar_name": "registrar_name",
                      "whois_server": "whois_server",
                      "website_url": "website_url",
                      "email_address": "email_address",
                      "phone_number": "phone_number"
                    }
                  }
                },
                {
                  "num": 1,
                  "status": true,
                  "domain_name": "domain_name",
                  "query_time": "query_time",
                  "whois_server": "whois_server",
                  "domain_registered": "yes",
                  "create_date": "2023-01-15",
                  "update_date": "2023-01-15",
                  "expiry_date": "2023-01-15",
                  "domain_registrar": {
                    "iana_id": "iana_id",
                    "registrar_name": "registrar_name",
                    "whois_server": "whois_server",
                    "website_url": "website_url",
                    "email_address": "email_address",
                    "phone_number": "phone_number",
                    "normalized_name": "normalized_name",
                    "rdap_server": "rdap_server",
                    "status": "status"
                  },
                  "reseller_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "registrant_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "administrative_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "technical_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "billing_contact": {
                    "name": "name",
                    "company": "company",
                    "street": "street",
                    "city": "city",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country_name": "country_name",
                    "country_code": "country_code",
                    "email_address": "email_address",
                    "phone": "phone",
                    "fax": "fax",
                    "mailing_address": "mailing_address",
                    "handle": "handle",
                    "id": "id"
                  },
                  "name_servers": [
                    "name_servers",
                    "name_servers"
                  ],
                  "domain_status": [
                    "domain_status",
                    "domain_status"
                  ],
                  "whois_raw_domain": "whois_raw_domain",
                  "registry_data": {
                    "domain_name": "domain_name",
                    "query_time": "query_time",
                    "whois_server": "whois_server",
                    "domain_registered": "yes",
                    "create_date": "2023-01-15",
                    "update_date": "2023-01-15",
                    "expiry_date": "2023-01-15",
                    "name_servers": [
                      "name_servers",
                      "name_servers"
                    ],
                    "domain_status": [
                      "domain_status",
                      "domain_status"
                    ],
                    "whois_raw_registry": "whois_raw_registry",
                    "domain_registrar": {
                      "iana_id": "iana_id",
                      "registrar_name": "registrar_name",
                      "whois_server": "whois_server",
                      "website_url": "website_url",
                      "email_address": "email_address",
                      "phone_number": "phone_number"
                    }
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/whois/reverse")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainWhoisReverseAsync(
            new DomainWhoisReverseRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "total_Result": 1,
              "total_Pages": 1,
              "current_Page": 1,
              "whois_domains_historical": [
                {
                  "num": 1,
                  "status": true,
                  "domain_name": "domain_name",
                  "query_time": "query_time",
                  "whois_server": "whois_server",
                  "domain_registered": "yes",
                  "create_date": "2023-01-15",
                  "update_date": "2023-01-15",
                  "expiry_date": "2023-01-15",
                  "name_servers": [
                    "name_servers"
                  ],
                  "domain_status": [
                    "domain_status"
                  ],
                  "whois_raw_domain": "whois_raw_domain"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/whois/reverse")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainWhoisReverseAsync(
            new DomainWhoisReverseRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
