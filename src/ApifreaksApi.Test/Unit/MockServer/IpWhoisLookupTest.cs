using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class IpWhoisLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "status": true,
              "ip_address": "ip_address",
              "query_time": "query_time",
              "whois_server": "whois_server",
              "inet_nums": [
                {
                  "start_ip": "start_ip",
                  "end_ip": "end_ip",
                  "cidr": [
                    "cidr",
                    "cidr"
                  ],
                  "net_name": "net_name",
                  "net_handle": "net_handle",
                  "description": [
                    "description",
                    "description"
                  ],
                  "countries": [
                    "countries",
                    "countries"
                  ],
                  "geofeed": "geofeed",
                  "latitude": 1.1,
                  "longitude": 1.1,
                  "city": "city",
                  "languages": [
                    "languages",
                    "languages"
                  ],
                  "status": "status",
                  "organization": "organization",
                  "sponsoring_organization": "sponsoring_organization",
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "abuse_contacts": [
                    "abuse_contacts",
                    "abuse_contacts"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "assignment_size": "assignment_size",
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_lower": [
                    "mnt_lower",
                    "mnt_lower"
                  ],
                  "mnt_domains": [
                    "mnt_domains",
                    "mnt_domains"
                  ],
                  "mnt_routes": [
                    "mnt_routes",
                    "mnt_routes"
                  ],
                  "mnt_irt": [
                    "mnt_irt",
                    "mnt_irt"
                  ],
                  "date_created": "date_created",
                  "date_updated": "date_updated",
                  "source": "source",
                  "parents": [
                    "parents",
                    "parents"
                  ]
                },
                {
                  "start_ip": "start_ip",
                  "end_ip": "end_ip",
                  "cidr": [
                    "cidr",
                    "cidr"
                  ],
                  "net_name": "net_name",
                  "net_handle": "net_handle",
                  "description": [
                    "description",
                    "description"
                  ],
                  "countries": [
                    "countries",
                    "countries"
                  ],
                  "geofeed": "geofeed",
                  "latitude": 1.1,
                  "longitude": 1.1,
                  "city": "city",
                  "languages": [
                    "languages",
                    "languages"
                  ],
                  "status": "status",
                  "organization": "organization",
                  "sponsoring_organization": "sponsoring_organization",
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "abuse_contacts": [
                    "abuse_contacts",
                    "abuse_contacts"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "assignment_size": "assignment_size",
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_lower": [
                    "mnt_lower",
                    "mnt_lower"
                  ],
                  "mnt_domains": [
                    "mnt_domains",
                    "mnt_domains"
                  ],
                  "mnt_routes": [
                    "mnt_routes",
                    "mnt_routes"
                  ],
                  "mnt_irt": [
                    "mnt_irt",
                    "mnt_irt"
                  ],
                  "date_created": "date_created",
                  "date_updated": "date_updated",
                  "source": "source",
                  "parents": [
                    "parents",
                    "parents"
                  ]
                }
              ],
              "irt": {
                "handle": "handle",
                "address": [
                  "address",
                  "address"
                ],
                "street": "street",
                "city": "city",
                "district": "district",
                "state": "state",
                "zip_code": "zip_code",
                "country": "country",
                "email": [
                  "email",
                  "email"
                ],
                "abuse_mailbox": [
                  "abuse_mailbox",
                  "abuse_mailbox"
                ],
                "phone": [
                  "phone",
                  "phone"
                ],
                "fax_no": [
                  "fax_no",
                  "fax_no"
                ],
                "organizations": [
                  "organizations",
                  "organizations"
                ],
                "admin_contacts": [
                  "admin_contacts",
                  "admin_contacts"
                ],
                "tech_contacts": [
                  "tech_contacts",
                  "tech_contacts"
                ],
                "remarks": [
                  "remarks",
                  "remarks"
                ],
                "signature": [
                  "signature",
                  "signature"
                ],
                "encryption": [
                  "encryption",
                  "encryption"
                ],
                "auth": [
                  "auth",
                  "auth"
                ],
                "notify": [
                  "notify",
                  "notify"
                ],
                "irt_nfy": [
                  "irt_nfy",
                  "irt_nfy"
                ],
                "mnt_by": [
                  "mnt_by",
                  "mnt_by"
                ],
                "mnt_ref": [
                  "mnt_ref",
                  "mnt_ref"
                ],
                "date_created": "date_created",
                "date_updated": "date_updated",
                "source": "source",
                "abuse_contacts": [
                  {
                    "handle": "handle",
                    "name": "name",
                    "address": [
                      "address",
                      "address"
                    ],
                    "street": "street",
                    "city": "city",
                    "district": "district",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country": "country",
                    "email": [
                      "email",
                      "email"
                    ],
                    "abuse_mailbox": [
                      "abuse_mailbox",
                      "abuse_mailbox"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "fax_no": [
                      "fax_no",
                      "fax_no"
                    ],
                    "organizations": [
                      "organizations",
                      "organizations"
                    ],
                    "admin_contacts": [
                      "admin_contacts",
                      "admin_contacts"
                    ],
                    "tech_contacts": [
                      "tech_contacts",
                      "tech_contacts"
                    ],
                    "remarks": [
                      "remarks",
                      "remarks"
                    ],
                    "notify": [
                      "notify",
                      "notify"
                    ],
                    "mnt_by": [
                      "mnt_by",
                      "mnt_by"
                    ],
                    "mnt_ref": [
                      "mnt_ref",
                      "mnt_ref"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source"
                  },
                  {
                    "handle": "handle",
                    "name": "name",
                    "address": [
                      "address",
                      "address"
                    ],
                    "street": "street",
                    "city": "city",
                    "district": "district",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country": "country",
                    "email": [
                      "email",
                      "email"
                    ],
                    "abuse_mailbox": [
                      "abuse_mailbox",
                      "abuse_mailbox"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "fax_no": [
                      "fax_no",
                      "fax_no"
                    ],
                    "organizations": [
                      "organizations",
                      "organizations"
                    ],
                    "admin_contacts": [
                      "admin_contacts",
                      "admin_contacts"
                    ],
                    "tech_contacts": [
                      "tech_contacts",
                      "tech_contacts"
                    ],
                    "remarks": [
                      "remarks",
                      "remarks"
                    ],
                    "notify": [
                      "notify",
                      "notify"
                    ],
                    "mnt_by": [
                      "mnt_by",
                      "mnt_by"
                    ],
                    "mnt_ref": [
                      "mnt_ref",
                      "mnt_ref"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source"
                  }
                ],
                "administrative_contacts": [
                  {
                    "handle": "handle",
                    "name": "name",
                    "address": [
                      "address",
                      "address"
                    ],
                    "street": "street",
                    "city": "city",
                    "district": "district",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country": "country",
                    "email": [
                      "email",
                      "email"
                    ],
                    "abuse_mailbox": [
                      "abuse_mailbox",
                      "abuse_mailbox"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "fax_no": [
                      "fax_no",
                      "fax_no"
                    ],
                    "organizations": [
                      "organizations",
                      "organizations"
                    ],
                    "admin_contacts": [
                      "admin_contacts",
                      "admin_contacts"
                    ],
                    "tech_contacts": [
                      "tech_contacts",
                      "tech_contacts"
                    ],
                    "remarks": [
                      "remarks",
                      "remarks"
                    ],
                    "notify": [
                      "notify",
                      "notify"
                    ],
                    "mnt_by": [
                      "mnt_by",
                      "mnt_by"
                    ],
                    "mnt_ref": [
                      "mnt_ref",
                      "mnt_ref"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source"
                  },
                  {
                    "handle": "handle",
                    "name": "name",
                    "address": [
                      "address",
                      "address"
                    ],
                    "street": "street",
                    "city": "city",
                    "district": "district",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country": "country",
                    "email": [
                      "email",
                      "email"
                    ],
                    "abuse_mailbox": [
                      "abuse_mailbox",
                      "abuse_mailbox"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "fax_no": [
                      "fax_no",
                      "fax_no"
                    ],
                    "organizations": [
                      "organizations",
                      "organizations"
                    ],
                    "admin_contacts": [
                      "admin_contacts",
                      "admin_contacts"
                    ],
                    "tech_contacts": [
                      "tech_contacts",
                      "tech_contacts"
                    ],
                    "remarks": [
                      "remarks",
                      "remarks"
                    ],
                    "notify": [
                      "notify",
                      "notify"
                    ],
                    "mnt_by": [
                      "mnt_by",
                      "mnt_by"
                    ],
                    "mnt_ref": [
                      "mnt_ref",
                      "mnt_ref"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source"
                  }
                ],
                "organization": {
                  "handle": "handle",
                  "name": "name",
                  "type": "type",
                  "description": [
                    "description",
                    "description"
                  ],
                  "address": [
                    "address",
                    "address"
                  ],
                  "street": "street",
                  "city": "city",
                  "district": "district",
                  "state": "state",
                  "zip_code": "zip_code",
                  "country": [
                    "country",
                    "country"
                  ],
                  "latitude": 1.1,
                  "longitude": 1.1,
                  "email": [
                    "email",
                    "email"
                  ],
                  "abuse_mailbox": [
                    "abuse_mailbox",
                    "abuse_mailbox"
                  ],
                  "phone": [
                    "phone",
                    "phone"
                  ],
                  "fax_no": [
                    "fax_no",
                    "fax_no"
                  ],
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "abuse_contacts": [
                    "abuse_contacts",
                    "abuse_contacts"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "ref_nfy": [
                    "ref_nfy",
                    "ref_nfy"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref",
                    "mnt_ref"
                  ],
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "source": "source"
                },
                "technical_contacts": [
                  {
                    "handle": "handle",
                    "name": "name",
                    "address": [
                      "address",
                      "address"
                    ],
                    "street": "street",
                    "city": "city",
                    "district": "district",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country": "country",
                    "email": [
                      "email",
                      "email"
                    ],
                    "abuse_mailbox": [
                      "abuse_mailbox",
                      "abuse_mailbox"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "fax_no": [
                      "fax_no",
                      "fax_no"
                    ],
                    "organizations": [
                      "organizations",
                      "organizations"
                    ],
                    "admin_contacts": [
                      "admin_contacts",
                      "admin_contacts"
                    ],
                    "tech_contacts": [
                      "tech_contacts",
                      "tech_contacts"
                    ],
                    "remarks": [
                      "remarks",
                      "remarks"
                    ],
                    "notify": [
                      "notify",
                      "notify"
                    ],
                    "mnt_by": [
                      "mnt_by",
                      "mnt_by"
                    ],
                    "mnt_ref": [
                      "mnt_ref",
                      "mnt_ref"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source"
                  },
                  {
                    "handle": "handle",
                    "name": "name",
                    "address": [
                      "address",
                      "address"
                    ],
                    "street": "street",
                    "city": "city",
                    "district": "district",
                    "state": "state",
                    "zip_code": "zip_code",
                    "country": "country",
                    "email": [
                      "email",
                      "email"
                    ],
                    "abuse_mailbox": [
                      "abuse_mailbox",
                      "abuse_mailbox"
                    ],
                    "phone": [
                      "phone",
                      "phone"
                    ],
                    "fax_no": [
                      "fax_no",
                      "fax_no"
                    ],
                    "organizations": [
                      "organizations",
                      "organizations"
                    ],
                    "admin_contacts": [
                      "admin_contacts",
                      "admin_contacts"
                    ],
                    "tech_contacts": [
                      "tech_contacts",
                      "tech_contacts"
                    ],
                    "remarks": [
                      "remarks",
                      "remarks"
                    ],
                    "notify": [
                      "notify",
                      "notify"
                    ],
                    "mnt_by": [
                      "mnt_by",
                      "mnt_by"
                    ],
                    "mnt_ref": [
                      "mnt_ref",
                      "mnt_ref"
                    ],
                    "date_created": "2023-01-15",
                    "date_updated": "2023-01-15",
                    "source": "source"
                  }
                ]
              },
              "organization": {
                "handle": "handle",
                "name": "name",
                "type": "type",
                "description": [
                  "description",
                  "description"
                ],
                "address": [
                  "address",
                  "address"
                ],
                "street": "street",
                "city": "city",
                "district": "district",
                "state": "state",
                "zip_code": "zip_code",
                "country": [
                  "country",
                  "country"
                ],
                "latitude": 1.1,
                "longitude": 1.1,
                "email": [
                  "email",
                  "email"
                ],
                "abuse_mailbox": [
                  "abuse_mailbox",
                  "abuse_mailbox"
                ],
                "phone": [
                  "phone",
                  "phone"
                ],
                "fax_no": [
                  "fax_no",
                  "fax_no"
                ],
                "organizations": [
                  "organizations",
                  "organizations"
                ],
                "admin_contacts": [
                  "admin_contacts",
                  "admin_contacts"
                ],
                "tech_contacts": [
                  "tech_contacts",
                  "tech_contacts"
                ],
                "abuse_contacts": [
                  "abuse_contacts",
                  "abuse_contacts"
                ],
                "languages": [
                  "languages",
                  "languages"
                ],
                "remarks": [
                  "remarks",
                  "remarks"
                ],
                "notify": [
                  "notify",
                  "notify"
                ],
                "ref_nfy": [
                  "ref_nfy",
                  "ref_nfy"
                ],
                "mnt_by": [
                  "mnt_by",
                  "mnt_by"
                ],
                "mnt_ref": [
                  "mnt_ref",
                  "mnt_ref"
                ],
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
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox",
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address",
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no",
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref",
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "organizations": [
                    "organizations",
                    "organizations"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
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
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox",
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address",
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no",
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref",
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "organizations": [
                    "organizations",
                    "organizations"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
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
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox",
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address",
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no",
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref",
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "organizations": [
                    "organizations",
                    "organizations"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
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
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox",
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address",
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no",
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref",
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "organizations": [
                    "organizations",
                    "organizations"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
                }
              ],
              "administrative_contacts": [
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
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox",
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address",
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no",
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref",
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "organizations": [
                    "organizations",
                    "organizations"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
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
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox",
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address",
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts",
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no",
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref",
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "organizations": [
                    "organizations",
                    "organizations"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts",
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
                }
              ],
              "whois_raw_response": "whois_raw_response",
              "routes": [
                {
                  "route": "route",
                  "origin": "origin",
                  "description": [
                    "description",
                    "description"
                  ],
                  "country": "country",
                  "pingable": [
                    "pingable",
                    "pingable"
                  ],
                  "ping_hdl": [
                    "ping_hdl",
                    "ping_hdl"
                  ],
                  "holes": [
                    "holes",
                    "holes"
                  ],
                  "member_of": [
                    "member_of",
                    "member_of"
                  ],
                  "inject": [
                    "inject",
                    "inject"
                  ],
                  "aggr_mtd": "aggr_mtd",
                  "aggr_bndry": "aggr_bndry",
                  "export_comps": "export_comps",
                  "components": "components",
                  "organizations": [
                    "organizations",
                    "organizations"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "mnt_lower": [
                    "mnt_lower",
                    "mnt_lower"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "source": "source"
                },
                {
                  "route": "route",
                  "origin": "origin",
                  "description": [
                    "description",
                    "description"
                  ],
                  "country": "country",
                  "pingable": [
                    "pingable",
                    "pingable"
                  ],
                  "ping_hdl": [
                    "ping_hdl",
                    "ping_hdl"
                  ],
                  "holes": [
                    "holes",
                    "holes"
                  ],
                  "member_of": [
                    "member_of",
                    "member_of"
                  ],
                  "inject": [
                    "inject",
                    "inject"
                  ],
                  "aggr_mtd": "aggr_mtd",
                  "aggr_bndry": "aggr_bndry",
                  "export_comps": "export_comps",
                  "components": "components",
                  "organizations": [
                    "organizations",
                    "organizations"
                  ],
                  "remarks": [
                    "remarks",
                    "remarks"
                  ],
                  "notify": [
                    "notify",
                    "notify"
                  ],
                  "mnt_lower": [
                    "mnt_lower",
                    "mnt_lower"
                  ],
                  "mnt_by": [
                    "mnt_by",
                    "mnt_by"
                  ],
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "source": "source"
                }
              ],
              "r_whois_raw_response": "r_whois_raw_response"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/ip/whois/live")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("ip", "ip")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.IpWhoisLookupAsync(
            new IpWhoisLookupRequest { ApiKey = "apiKey", Ip = "ip" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "status": true,
              "ip_address": "ip_address",
              "query_time": "query_time",
              "whois_server": "whois_server",
              "inet_nums": [
                {
                  "start_ip": "start_ip",
                  "end_ip": "end_ip",
                  "cidr": [
                    "cidr"
                  ],
                  "net_name": "net_name",
                  "net_handle": "net_handle",
                  "description": [
                    "description"
                  ],
                  "countries": [
                    "countries"
                  ],
                  "geofeed": "geofeed",
                  "latitude": 1.1,
                  "longitude": 1.1,
                  "city": "city",
                  "languages": [
                    "languages"
                  ],
                  "status": "status",
                  "organization": "organization",
                  "sponsoring_organization": "sponsoring_organization",
                  "admin_contacts": [
                    "admin_contacts"
                  ],
                  "tech_contacts": [
                    "tech_contacts"
                  ],
                  "abuse_contacts": [
                    "abuse_contacts"
                  ],
                  "remarks": [
                    "remarks"
                  ],
                  "assignment_size": "assignment_size",
                  "notify": [
                    "notify"
                  ],
                  "mnt_by": [
                    "mnt_by"
                  ],
                  "mnt_lower": [
                    "mnt_lower"
                  ],
                  "mnt_domains": [
                    "mnt_domains"
                  ],
                  "mnt_routes": [
                    "mnt_routes"
                  ],
                  "mnt_irt": [
                    "mnt_irt"
                  ],
                  "date_created": "date_created",
                  "date_updated": "date_updated",
                  "source": "source",
                  "parents": [
                    "parents"
                  ]
                }
              ],
              "irt": {
                "handle": "handle",
                "address": [
                  "address"
                ],
                "street": "street",
                "city": "city",
                "district": "district",
                "state": "state",
                "zip_code": "zip_code",
                "country": "country",
                "email": [
                  "email"
                ],
                "abuse_mailbox": [
                  "abuse_mailbox"
                ],
                "phone": [
                  "phone"
                ],
                "fax_no": [
                  "fax_no"
                ],
                "organizations": [
                  "organizations"
                ],
                "admin_contacts": [
                  "admin_contacts"
                ],
                "tech_contacts": [
                  "tech_contacts"
                ],
                "remarks": [
                  "remarks"
                ],
                "signature": [
                  "signature"
                ],
                "encryption": [
                  "encryption"
                ],
                "auth": [
                  "auth"
                ],
                "notify": [
                  "notify"
                ],
                "irt_nfy": [
                  "irt_nfy"
                ],
                "mnt_by": [
                  "mnt_by"
                ],
                "mnt_ref": [
                  "mnt_ref"
                ],
                "date_created": "date_created",
                "date_updated": "date_updated",
                "source": "source",
                "abuse_contacts": [
                  {
                    "handle": "handle",
                    "source": "source"
                  }
                ],
                "administrative_contacts": [
                  {
                    "handle": "handle",
                    "source": "source"
                  }
                ],
                "organization": {
                  "handle": "handle",
                  "name": "name",
                  "type": "type",
                  "description": [
                    "description"
                  ],
                  "address": [
                    "address"
                  ],
                  "street": "street",
                  "city": "city",
                  "district": "district",
                  "state": "state",
                  "zip_code": "zip_code",
                  "country": [
                    "country"
                  ],
                  "latitude": 1.1,
                  "longitude": 1.1,
                  "email": [
                    "email"
                  ],
                  "abuse_mailbox": [
                    "abuse_mailbox"
                  ],
                  "phone": [
                    "phone"
                  ],
                  "fax_no": [
                    "fax_no"
                  ],
                  "admin_contacts": [
                    "admin_contacts"
                  ],
                  "tech_contacts": [
                    "tech_contacts"
                  ],
                  "abuse_contacts": [
                    "abuse_contacts"
                  ],
                  "remarks": [
                    "remarks"
                  ],
                  "notify": [
                    "notify"
                  ],
                  "ref_nfy": [
                    "ref_nfy"
                  ],
                  "mnt_by": [
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref"
                  ],
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "source": "source"
                },
                "technical_contacts": [
                  {
                    "handle": "handle",
                    "source": "source"
                  }
                ]
              },
              "organization": {
                "handle": "handle",
                "name": "name",
                "type": "type",
                "description": [
                  "description"
                ],
                "address": [
                  "address"
                ],
                "street": "street",
                "city": "city",
                "district": "district",
                "state": "state",
                "zip_code": "zip_code",
                "country": [
                  "country"
                ],
                "latitude": 1.1,
                "longitude": 1.1,
                "email": [
                  "email"
                ],
                "abuse_mailbox": [
                  "abuse_mailbox"
                ],
                "phone": [
                  "phone"
                ],
                "fax_no": [
                  "fax_no"
                ],
                "organizations": [
                  "organizations"
                ],
                "admin_contacts": [
                  "admin_contacts"
                ],
                "tech_contacts": [
                  "tech_contacts"
                ],
                "abuse_contacts": [
                  "abuse_contacts"
                ],
                "languages": [
                  "languages"
                ],
                "remarks": [
                  "remarks"
                ],
                "notify": [
                  "notify"
                ],
                "ref_nfy": [
                  "ref_nfy"
                ],
                "mnt_by": [
                  "mnt_by"
                ],
                "mnt_ref": [
                  "mnt_ref"
                ],
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
                  ],
                  "phone": [
                    "phone"
                  ],
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify"
                  ],
                  "organizations": [
                    "organizations"
                  ],
                  "remarks": [
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
                }
              ],
              "abuse_contacts": [
                {
                  "handle": "handle",
                  "name": "name",
                  "email": [
                    "email"
                  ],
                  "phone": [
                    "phone"
                  ],
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify"
                  ],
                  "organizations": [
                    "organizations"
                  ],
                  "remarks": [
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
                }
              ],
              "administrative_contacts": [
                {
                  "handle": "handle",
                  "name": "name",
                  "email": [
                    "email"
                  ],
                  "phone": [
                    "phone"
                  ],
                  "source": "source",
                  "abuse_mailbox": [
                    "abuse_mailbox"
                  ],
                  "address": [
                    "address"
                  ],
                  "admin_contacts": [
                    "admin_contacts"
                  ],
                  "city": "city",
                  "country": "country",
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "district": "district",
                  "fax_no": [
                    "fax_no"
                  ],
                  "mnt_by": [
                    "mnt_by"
                  ],
                  "mnt_ref": [
                    "mnt_ref"
                  ],
                  "notify": [
                    "notify"
                  ],
                  "organizations": [
                    "organizations"
                  ],
                  "remarks": [
                    "remarks"
                  ],
                  "state": "state",
                  "street": "street",
                  "tech_contacts": [
                    "tech_contacts"
                  ],
                  "zip_code": "zip_code"
                }
              ],
              "whois_raw_response": "whois_raw_response",
              "routes": [
                {
                  "route": "route",
                  "origin": "origin",
                  "description": [
                    "description"
                  ],
                  "country": "country",
                  "pingable": [
                    "pingable"
                  ],
                  "ping_hdl": [
                    "ping_hdl"
                  ],
                  "holes": [
                    "holes"
                  ],
                  "member_of": [
                    "member_of"
                  ],
                  "inject": [
                    "inject"
                  ],
                  "aggr_mtd": "aggr_mtd",
                  "aggr_bndry": "aggr_bndry",
                  "export_comps": "export_comps",
                  "components": "components",
                  "organizations": [
                    "organizations"
                  ],
                  "remarks": [
                    "remarks"
                  ],
                  "notify": [
                    "notify"
                  ],
                  "mnt_lower": [
                    "mnt_lower"
                  ],
                  "mnt_by": [
                    "mnt_by"
                  ],
                  "date_created": "2023-01-15",
                  "date_updated": "2023-01-15",
                  "source": "source"
                }
              ],
              "r_whois_raw_response": "r_whois_raw_response"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/ip/whois/live")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("ip", "ip")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.IpWhoisLookupAsync(
            new IpWhoisLookupRequest { ApiKey = "apiKey", Ip = "ip" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
