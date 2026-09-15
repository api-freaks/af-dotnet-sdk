using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainReputationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "input": {
                "domain": "domain"
              },
              "assessed_at": "assessed_at",
              "version": "version",
              "processing_time_ms": 1,
              "risk_category": {
                "verdict": "safe",
                "confidence": 1.1,
                "primary_threat": "primary_threat",
                "severity": "none",
                "threat_types": [
                  "threat_types"
                ],
                "sources": [
                  {
                    "source": "source",
                    "indicator": "indicator",
                    "threat_type": "threat_type",
                    "confidence": 1.1,
                    "first_seen": "first_seen",
                    "last_seen": "last_seen"
                  }
                ],
                "pivot_matches": [
                  {
                    "pivot": "pivot",
                    "pivot_type": "pivot_type",
                    "total_related_threats": 1,
                    "confidence": 1.1
                  }
                ]
              },
              "dga_score": {
                "score": 1.1,
                "is_dga": true,
                "model": "model",
                "features": {
                  "domain_length": 1,
                  "vowel_consonant_ratio": 1.1,
                  "ngram_perplexity": 1.1,
                  "shannon_entropy": 1.1,
                  "digit_letter_ratio": 1.1,
                  "consonant_streak_max": 1,
                  "tld_in_known_dga_set": true
                },
                "interpretation": "interpretation"
              },
              "trust_signals": {
                "trust_score": 1,
                "trust_band": "trust_band",
                "signals": {
                  "positive": [
                    {
                      "code": "code",
                      "weight": 1,
                      "polarity": "positive",
                      "category": "category",
                      "evidence": "evidence",
                      "confidence": 1.1
                    }
                  ],
                  "negative": [
                    {
                      "code": "code",
                      "weight": 1,
                      "polarity": "positive",
                      "category": "category",
                      "evidence": "evidence",
                      "confidence": 1.1
                    }
                  ],
                  "neutral": [
                    {
                      "code": "code",
                      "weight": 1,
                      "polarity": "positive",
                      "category": "category",
                      "evidence": "evidence",
                      "confidence": 1.1
                    }
                  ]
                },
                "indicators": {
                  "is_newly_registered": true,
                  "uses_free_extension": true,
                  "uses_free_ssl": true,
                  "has_privacy_whois": true,
                  "ssl_age_days": 1,
                  "has_dmarc": true,
                  "has_spf": true,
                  "redirects_externally": true,
                  "javascript_obfuscated": true,
                  "domain_age_days": 1,
                  "registrar": "registrar"
                }
              },
              "email_deliverability": {
                "score": 1,
                "grade": "grade",
                "can_receive_email": true,
                "authentication": {
                  "spf": {
                    "present": true,
                    "policy": "policy",
                    "record": "record"
                  },
                  "dkim": {
                    "found": true,
                    "selectors_found": [
                      "selectors_found"
                    ],
                    "providers_detected": [
                      "providers_detected"
                    ],
                    "note": "note"
                  },
                  "dmarc": {
                    "present": true,
                    "policy": "policy",
                    "reporting_configured": true
                  }
                },
                "infrastructure": {
                  "mx_count": 1,
                  "mx_records": [
                    "mx_records"
                  ],
                  "mx_provider": "mx_provider",
                  "null_mx": true
                },
                "reputation": {
                  "spam_blacklisted": true,
                  "newly_registered": true,
                  "domain_age_days": 1
                },
                "issues": [
                  {}
                ]
              },
              "intelligence": {
                "ioc_type": "ioc_type",
                "ioc_value": "ioc_value",
                "related_iocs": [
                  {
                    "type": "type",
                    "value": "value",
                    "confidence": 1.1
                  }
                ],
                "feed_tags": [
                  "feed_tags"
                ],
                "stix_pattern": "stix_pattern",
                "recommended_action": "allow",
                "first_seen": "first_seen",
                "last_seen": "last_seen"
              },
              "evidence_summary": {
                "why_flagged": [
                  "why_flagged"
                ]
              },
              "errors": [
                "errors"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/reputation")
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

        var response = await Client.DomainReputationAsync(
            new DomainReputationRequest { ApiKey = "apiKey", DomainName = "domainName" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
