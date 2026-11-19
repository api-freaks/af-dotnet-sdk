using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PdfGenerateFromTemplateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "string": {
                "key": "value"
              }
            }
            """;

        const string mockResponse = """
            {
              "template_id": "template_id",
              "pdf_url": "pdf_url",
              "created_at": "2024-01-15T09:30:00.000Z",
              "expiration_time": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/pdf/template/generate")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("template_id", "template_id")
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

        var response = await Client.PdfGenerateFromTemplateAsync(
            new PdfGenerateFromTemplateRequest
            {
                ApiKey = "apiKey",
                TemplateId = "template_id",
                Body = new Dictionary<string, object?>()
                {
                    {
                        "string",
                        new Dictionary<object, object?>() { { "key", "value" } }
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
              "candidate_name": "Ava Thompson",
              "candidate_title": "Senior Operations Analyst",
              "email": "ava.thompson@example.com",
              "phone": "+1 (555) 381-2048",
              "city": "Austin, TX",
              "portfolio_url": "portfolio.example.com",
              "profile_summary": "Analytical operations professional with 8+ years of experience improving reporting pipelines, streamlining process documentation, and coordinating cross-functional delivery for distributed teams across multiple time zones.",
              "company_name": "Northwind Logistics",
              "job_title": "Operations Analyst",
              "employment_period": "2021 - Present",
              "job_achievement_1": "Led weekly KPI reporting for finance, fulfillment, and customer success stakeholders across three business units.",
              "job_achievement_2": "Reduced manual reconciliation work by 35% through workflow redesign and documentation automation.",
              "job_achievement_3": "Spearheaded a cross-team initiative that improved on-time delivery metrics by 18% within six months.",
              "skills": [
                {
                  "skill": "Process Improvement",
                  "level": "Advanced",
                  "years": "7"
                },
                {
                  "skill": "Stakeholder Reporting",
                  "level": "Expert",
                  "years": "8"
                },
                {
                  "skill": "Cross-functional Coordination",
                  "level": "Advanced",
                  "years": "5"
                },
                {
                  "skill": "Workflow Documentation",
                  "level": "Advanced",
                  "years": "6"
                }
              ],
              "degree": "B.S. in Information Systems",
              "institution": "University of Texas",
              "graduation_year": "2018",
              "certification_1": "Certified Business Analysis Professional (CBAP)",
              "certification_2": "Six Sigma Green Belt",
              "languages": "English (Native), Spanish (Professional)"
            }
            """;

        const string mockResponse = """
            {
              "template_id": "73691bce-1c58-4370-acc6-64b2dd14f81c",
              "pdf_url": "https://s3.eu-central-2.wasabisys.com/w.storage.apifreaks.com/pdf_templates/73691bce-1c58-4370-acc6-64b2dd14f81c/Candidate%20Resume_20260810141214723405.pdf",
              "created_at": "2026-08-10T14:12:17.000Z",
              "expiration_time": "2026-11-10T14:12:17.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/pdf/template/generate")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("template_id", "template_id")
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

        var response = await Client.PdfGenerateFromTemplateAsync(
            new PdfGenerateFromTemplateRequest
            {
                ApiKey = "apiKey",
                TemplateId = "template_id",
                Body = new Dictionary<string, object?>()
                {
                    { "candidate_name", "Ava Thompson" },
                    { "candidate_title", "Senior Operations Analyst" },
                    { "email", "ava.thompson@example.com" },
                    { "phone", "+1 (555) 381-2048" },
                    { "city", "Austin, TX" },
                    { "portfolio_url", "portfolio.example.com" },
                    {
                        "profile_summary",
                        "Analytical operations professional with 8+ years of experience improving reporting pipelines, streamlining process documentation, and coordinating cross-functional delivery for distributed teams across multiple time zones."
                    },
                    { "company_name", "Northwind Logistics" },
                    { "job_title", "Operations Analyst" },
                    { "employment_period", "2021 - Present" },
                    {
                        "job_achievement_1",
                        "Led weekly KPI reporting for finance, fulfillment, and customer success stakeholders across three business units."
                    },
                    {
                        "job_achievement_2",
                        "Reduced manual reconciliation work by 35% through workflow redesign and documentation automation."
                    },
                    {
                        "job_achievement_3",
                        "Spearheaded a cross-team initiative that improved on-time delivery metrics by 18% within six months."
                    },
                    {
                        "skills",
                        new List<object?>()
                        {
                            new Dictionary<object, object?>()
                            {
                                { "level", "Advanced" },
                                { "skill", "Process Improvement" },
                                { "years", "7" },
                            },
                            new Dictionary<object, object?>()
                            {
                                { "level", "Expert" },
                                { "skill", "Stakeholder Reporting" },
                                { "years", "8" },
                            },
                            new Dictionary<object, object?>()
                            {
                                { "level", "Advanced" },
                                { "skill", "Cross-functional Coordination" },
                                { "years", "5" },
                            },
                            new Dictionary<object, object?>()
                            {
                                { "level", "Advanced" },
                                { "skill", "Workflow Documentation" },
                                { "years", "6" },
                            },
                        }
                    },
                    { "degree", "B.S. in Information Systems" },
                    { "institution", "University of Texas" },
                    { "graduation_year", "2018" },
                    { "certification_1", "Certified Business Analysis Professional (CBAP)" },
                    { "certification_2", "Six Sigma Green Belt" },
                    { "languages", "English (Native), Spanish (Professional)" },
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
              "report_title": "Quarterly Business Report",
              "report_period": "Q4 2024",
              "prepared_by": "Marketing Team",
              "revenue": 125000,
              "growth_rate": 15,
              "customer_count": 520,
              "monthly_comparison": [
                {
                  "metric": "Revenue",
                  "previous": "$108,000",
                  "current": "$125,000",
                  "change": "+15.7%"
                },
                {
                  "metric": "Active Customers",
                  "previous": "480",
                  "current": "520",
                  "change": "+8.3%"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "template_id": "73691bce-1c58-4370-acc6-64b2dd14f81c",
              "pdf_url": "https://s3.eu-central-2.wasabisys.com/w.storage.apifreaks.com/pdf_templates/73691bce-1c58-4370-acc6-64b2dd14f81c/Candidate%20Resume_20260810141214723405.pdf",
              "created_at": "2026-08-10T14:12:17.000Z",
              "expiration_time": "2026-11-10T14:12:17.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/pdf/template/generate")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("template_id", "template_id")
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

        var response = await Client.PdfGenerateFromTemplateAsync(
            new PdfGenerateFromTemplateRequest
            {
                ApiKey = "apiKey",
                TemplateId = "template_id",
                Body = new Dictionary<string, object?>()
                {
                    { "report_title", "Quarterly Business Report" },
                    { "report_period", "Q4 2024" },
                    { "prepared_by", "Marketing Team" },
                    { "revenue", 125000 },
                    { "growth_rate", 15 },
                    { "customer_count", 520 },
                    {
                        "monthly_comparison",
                        new List<object?>()
                        {
                            new Dictionary<object, object?>()
                            {
                                { "change", "+15.7%" },
                                { "current", "$125,000" },
                                { "metric", "Revenue" },
                                { "previous", "$108,000" },
                            },
                            new Dictionary<object, object?>()
                            {
                                { "change", "+8.3%" },
                                { "current", "520" },
                                { "metric", "Active Customers" },
                                { "previous", "480" },
                            },
                        }
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
