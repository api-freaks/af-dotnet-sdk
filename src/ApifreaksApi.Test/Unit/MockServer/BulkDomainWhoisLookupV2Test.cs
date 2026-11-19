using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkDomainWhoisLookupV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "domainNames": [
                "domainNames",
                "domainNames"
              ]
            }
            """;

        const string mockResponse = """
            {
              "bulk_whois_response": [
                {
                  "status": true,
                  "domain_name": "domain_name",
                  "query_time": "query_time",
                  "whois_server": "whois_server",
                  "domain_registered": "yes",
                  "secure_dns": true,
                  "domain_handle": "domain_handle",
                  "create_date": "2023-01-15",
                  "update_date": "2023-01-15",
                  "expiry_date": "2023-01-15",
                  "domain_registrar": {
                    "iana_id": "iana_id",
                    "id": "id",
                    "id_type": "id_type",
                    "handle": "handle",
                    "registry_id": "registry_id",
                    "authoritative_registry_name": "authoritative_registry_name",
                    "organization_number": "organization_number",
                    "is_sponsor": true,
                    "status": "status",
                    "registrar_name": "registrar_name",
                    "normalized_name": "normalized_name",
                    "whois_server": "whois_server",
                    "rdap_server": "rdap_server",
                    "website_url": "website_url",
                    "email_address": "email_address",
                    "phone_number": "phone_number"
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
                    "mailing_address": "mailing_address"
                  },
                  "registrant_contact": {
                    "id": "id",
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
                    "mailing_address": "mailing_address"
                  },
                  "administrative_contact": {
                    "id": "id",
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
                    "mailing_address": "mailing_address"
                  },
                  "technical_contact": {
                    "id": "id",
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
                    "mailing_address": "mailing_address"
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
                    "mailing_address": "mailing_address"
                  },
                  "abuse_contact": {
                    "registrar_name": "registrar_name",
                    "email_address": "email_address",
                    "phone_number": "phone_number"
                  },
                  "eligibility_info": {
                    "id": "id",
                    "name": "name",
                    "type": "type"
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
                    "whois_raw_registery": "whois_raw_registery",
                    "domain_registrar": {
                      "iana_id": "iana_id",
                      "id": "id",
                      "id_type": "id_type",
                      "handle": "handle",
                      "registry_id": "registry_id",
                      "authoritative_registry_name": "authoritative_registry_name",
                      "organization_number": "organization_number",
                      "is_sponsor": true,
                      "status": "status",
                      "registrar_name": "registrar_name",
                      "normalized_name": "normalized_name",
                      "whois_server": "whois_server",
                      "rdap_server": "rdap_server",
                      "website_url": "website_url",
                      "email_address": "email_address",
                      "phone_number": "phone_number"
                    }
                  }
                },
                {
                  "status": true,
                  "domain_name": "domain_name",
                  "query_time": "query_time",
                  "whois_server": "whois_server",
                  "domain_registered": "yes",
                  "secure_dns": true,
                  "domain_handle": "domain_handle",
                  "create_date": "2023-01-15",
                  "update_date": "2023-01-15",
                  "expiry_date": "2023-01-15",
                  "domain_registrar": {
                    "iana_id": "iana_id",
                    "id": "id",
                    "id_type": "id_type",
                    "handle": "handle",
                    "registry_id": "registry_id",
                    "authoritative_registry_name": "authoritative_registry_name",
                    "organization_number": "organization_number",
                    "is_sponsor": true,
                    "status": "status",
                    "registrar_name": "registrar_name",
                    "normalized_name": "normalized_name",
                    "whois_server": "whois_server",
                    "rdap_server": "rdap_server",
                    "website_url": "website_url",
                    "email_address": "email_address",
                    "phone_number": "phone_number"
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
                    "mailing_address": "mailing_address"
                  },
                  "registrant_contact": {
                    "id": "id",
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
                    "mailing_address": "mailing_address"
                  },
                  "administrative_contact": {
                    "id": "id",
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
                    "mailing_address": "mailing_address"
                  },
                  "technical_contact": {
                    "id": "id",
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
                    "mailing_address": "mailing_address"
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
                    "mailing_address": "mailing_address"
                  },
                  "abuse_contact": {
                    "registrar_name": "registrar_name",
                    "email_address": "email_address",
                    "phone_number": "phone_number"
                  },
                  "eligibility_info": {
                    "id": "id",
                    "name": "name",
                    "type": "type"
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
                    "whois_raw_registery": "whois_raw_registery",
                    "domain_registrar": {
                      "iana_id": "iana_id",
                      "id": "id",
                      "id_type": "id_type",
                      "handle": "handle",
                      "registry_id": "registry_id",
                      "authoritative_registry_name": "authoritative_registry_name",
                      "organization_number": "organization_number",
                      "is_sponsor": true,
                      "status": "status",
                      "registrar_name": "registrar_name",
                      "normalized_name": "normalized_name",
                      "whois_server": "whois_server",
                      "rdap_server": "rdap_server",
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
                    .WithPath("/v2.0/domain/whois/live")
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

        var response = await Client.BulkDomainWhoisLookupV2Async(
            new BulkDomainWhoisLookupV2Request
            {
                ApiKey = "apiKey",
                DomainNames = new List<string>() { "domainNames", "domainNames" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "domainNames": [
                "domainNames"
              ]
            }
            """;

        const string mockResponse = """
            {
              "bulk_whois_response": [
                {
                  "status": true,
                  "domain_name": "domain_name",
                  "query_time": "query_time",
                  "whois_server": "whois_server",
                  "domain_registered": "yes",
                  "secure_dns": true,
                  "domain_handle": "domain_handle",
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
                    .WithPath("/v2.0/domain/whois/live")
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

        var response = await Client.BulkDomainWhoisLookupV2Async(
            new BulkDomainWhoisLookupV2Request
            {
                ApiKey = "apiKey",
                DomainNames = new List<string>() { "domainNames" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
