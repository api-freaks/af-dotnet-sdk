using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainSslLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "domainName": "domainName",
              "queryTime": "queryTime",
              "sslCertificates": [
                {
                  "chainOrder": "chainOrder",
                  "authenticationType": "authenticationType",
                  "validityStartDate": "validityStartDate",
                  "validityEndDate": "validityEndDate",
                  "serialNumber": "serialNumber",
                  "signatureAlgorithm": "signatureAlgorithm",
                  "subject": {
                    "commonName": "commonName",
                    "organization": "organization",
                    "organizationalUnit": "organizationalUnit",
                    "locality": "locality",
                    "state": "state",
                    "country": "country",
                    "incCountry": "incCountry",
                    "incState": "incState",
                    "businessCategory": "businessCategory",
                    "street": "street",
                    "postalCode": "postalCode",
                    "serialNumber": "serialNumber"
                  },
                  "issuer": {
                    "commonName": "commonName",
                    "organization": "organization",
                    "organizationalUnit": "organizationalUnit",
                    "locality": "locality",
                    "state": "state",
                    "country": "country",
                    "incCountry": "incCountry",
                    "incState": "incState",
                    "businessCategory": "businessCategory",
                    "street": "street",
                    "postalCode": "postalCode",
                    "serialNumber": "serialNumber"
                  },
                  "publicKey": {
                    "keySize": "keySize",
                    "keyAlgorithm": "keyAlgorithm",
                    "pemRaw": "pemRaw"
                  },
                  "extensions": {
                    "authorityKeyIdentifier": "authorityKeyIdentifier",
                    "subjectKeyIdentifier": "subjectKeyIdentifier",
                    "keyUsages": [
                      "keyUsages",
                      "keyUsages"
                    ],
                    "extendedKeyUsages": [
                      "extendedKeyUsages",
                      "extendedKeyUsages"
                    ],
                    "crlDistributionPoints": [
                      "crlDistributionPoints",
                      "crlDistributionPoints"
                    ],
                    "authorityInfoAccess": {
                      "issuers": [
                        "issuers",
                        "issuers"
                      ],
                      "ocsp": [
                        "ocsp",
                        "ocsp"
                      ]
                    },
                    "subjectAlternativeNames": {
                      "dnsNames": [
                        "dnsNames",
                        "dnsNames"
                      ],
                      "emailAddresses": [
                        "emailAddresses",
                        "emailAddresses"
                      ],
                      "ipAddresses": [
                        "ipAddresses",
                        "ipAddresses"
                      ],
                      "uris": [
                        "uris",
                        "uris"
                      ]
                    },
                    "certificatePolicies": [
                      {
                        "policyId": "policyId",
                        "policyQualifier": {
                          "oid": "oid",
                          "cpsUri": "cpsUri",
                          "userNotice": {}
                        }
                      },
                      {
                        "policyId": "policyId",
                        "policyQualifier": {
                          "oid": "oid",
                          "cpsUri": "cpsUri",
                          "userNotice": {}
                        }
                      }
                    ]
                  },
                  "pemRaw": "pemRaw"
                },
                {
                  "chainOrder": "chainOrder",
                  "authenticationType": "authenticationType",
                  "validityStartDate": "validityStartDate",
                  "validityEndDate": "validityEndDate",
                  "serialNumber": "serialNumber",
                  "signatureAlgorithm": "signatureAlgorithm",
                  "subject": {
                    "commonName": "commonName",
                    "organization": "organization",
                    "organizationalUnit": "organizationalUnit",
                    "locality": "locality",
                    "state": "state",
                    "country": "country",
                    "incCountry": "incCountry",
                    "incState": "incState",
                    "businessCategory": "businessCategory",
                    "street": "street",
                    "postalCode": "postalCode",
                    "serialNumber": "serialNumber"
                  },
                  "issuer": {
                    "commonName": "commonName",
                    "organization": "organization",
                    "organizationalUnit": "organizationalUnit",
                    "locality": "locality",
                    "state": "state",
                    "country": "country",
                    "incCountry": "incCountry",
                    "incState": "incState",
                    "businessCategory": "businessCategory",
                    "street": "street",
                    "postalCode": "postalCode",
                    "serialNumber": "serialNumber"
                  },
                  "publicKey": {
                    "keySize": "keySize",
                    "keyAlgorithm": "keyAlgorithm",
                    "pemRaw": "pemRaw"
                  },
                  "extensions": {
                    "authorityKeyIdentifier": "authorityKeyIdentifier",
                    "subjectKeyIdentifier": "subjectKeyIdentifier",
                    "keyUsages": [
                      "keyUsages",
                      "keyUsages"
                    ],
                    "extendedKeyUsages": [
                      "extendedKeyUsages",
                      "extendedKeyUsages"
                    ],
                    "crlDistributionPoints": [
                      "crlDistributionPoints",
                      "crlDistributionPoints"
                    ],
                    "authorityInfoAccess": {
                      "issuers": [
                        "issuers",
                        "issuers"
                      ],
                      "ocsp": [
                        "ocsp",
                        "ocsp"
                      ]
                    },
                    "subjectAlternativeNames": {
                      "dnsNames": [
                        "dnsNames",
                        "dnsNames"
                      ],
                      "emailAddresses": [
                        "emailAddresses",
                        "emailAddresses"
                      ],
                      "ipAddresses": [
                        "ipAddresses",
                        "ipAddresses"
                      ],
                      "uris": [
                        "uris",
                        "uris"
                      ]
                    },
                    "certificatePolicies": [
                      {
                        "policyId": "policyId",
                        "policyQualifier": {
                          "oid": "oid",
                          "cpsUri": "cpsUri",
                          "userNotice": {}
                        }
                      },
                      {
                        "policyId": "policyId",
                        "policyQualifier": {
                          "oid": "oid",
                          "cpsUri": "cpsUri",
                          "userNotice": {}
                        }
                      }
                    ]
                  },
                  "pemRaw": "pemRaw"
                }
              ],
              "sslRaw": "sslRaw"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/ssl/live")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("domainName", "domainName")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainSslLookupAsync(
            new DomainSslLookupRequest { ApiKey = "apiKey", DomainName = "domainName" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "domainName": "domainName",
              "queryTime": "queryTime",
              "sslCertificates": [
                {
                  "chainOrder": "chainOrder",
                  "authenticationType": "authenticationType",
                  "validityStartDate": "validityStartDate",
                  "validityEndDate": "validityEndDate",
                  "serialNumber": "serialNumber",
                  "signatureAlgorithm": "signatureAlgorithm",
                  "subject": {
                    "commonName": "commonName"
                  },
                  "issuer": {
                    "commonName": "commonName"
                  },
                  "publicKey": {
                    "keySize": "keySize",
                    "keyAlgorithm": "keyAlgorithm",
                    "pemRaw": "pemRaw"
                  },
                  "extensions": {
                    "authorityKeyIdentifier": "authorityKeyIdentifier",
                    "subjectKeyIdentifier": "subjectKeyIdentifier",
                    "keyUsages": [
                      "keyUsages"
                    ]
                  },
                  "pemRaw": "pemRaw"
                }
              ],
              "sslRaw": "sslRaw"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/ssl/live")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("domainName", "domainName")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainSslLookupAsync(
            new DomainSslLookupRequest { ApiKey = "apiKey", DomainName = "domainName" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
