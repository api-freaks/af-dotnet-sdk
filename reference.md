# Reference
<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GeolocationLookupAsync</a>(GeolocationLookupRequest { ... }) -> WithRawResponseTask&lt;GeolocationLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get detailed geolocation data for an IP address including country, city, timezone, currency, and optional security and user-agent information
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GeolocationLookupAsync(new GeolocationLookupRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GeolocationLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkGeolocationLookupAsync</a>(BulkGeolocationLookupRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;BulkGeolocationLookupResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed geolocation data for multiple IP addresses in a single request.
Supports up to `50,000` IP-addresses/host-names per request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkGeolocationLookupAsync(
    new BulkGeolocationLookupRequest
    {
        ApiKey = "apiKey",
        Ips = new List<string>() { "ips" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkGeolocationLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">IpSecurityLookupAsync</a>(IpSecurityLookupRequest { ... }) -> WithRawResponseTask&lt;IpSecurityLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get comprehensive security information for a given IP address. Detects VPNs, proxies, Tor nodes, and other security threats.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.IpSecurityLookupAsync(new IpSecurityLookupRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IpSecurityLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkIpSecurityLookupAsync</a>(BulkIpSecurityLookupRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;BulkIpSecurityLookupResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The Bulk IP Security Lookup API allows you to retrieve security details for up to `50,000` IP-addresses in a single request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkIpSecurityLookupAsync(
    new BulkIpSecurityLookupRequest
    {
        ApiKey = "apiKey",
        Ips = new List<string>() { "ips" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkIpSecurityLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GeocoderSearchAsync</a>(GeocoderSearchRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;GeocoderSearchResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Convert a given address or place name into geographic coordinates (latitude and longitude).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GeocoderSearchAsync(new GeocoderSearchRequest { ApiKey = "apiKey", Query = "query" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GeocoderSearchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GeocoderReverseAsync</a>(GeocoderReverseRequest { ... }) -> WithRawResponseTask&lt;GeocoderReverseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Convert geographic coordinates (latitude and longitude) into a human-readable address or place name.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GeocoderReverseAsync(
    new GeocoderReverseRequest
    {
        ApiKey = "apiKey",
        Lat = 1.1,
        Lon = 1.1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GeocoderReverseRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainWhoisLookupAsync</a>(DomainWhoisLookupRequest { ... }) -> WithRawResponseTask&lt;DomainWhoisLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve current WHOIS information for a domain name.
This endpoint provides detailed registration information including registrar details,
dates, nameservers, and registrant information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainWhoisLookupAsync(
    new DomainWhoisLookupRequest { ApiKey = "apiKey", DomainName = "domainName" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainWhoisLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkDomainWhoisLookupAsync</a>(BulkDomainWhoisLookupRequest { ... }) -> WithRawResponseTask&lt;BulkDomainWhoisLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve WHOIS information for `100 Domains per Request`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkDomainWhoisLookupAsync(
    new BulkDomainWhoisLookupRequest
    {
        ApiKey = "apiKey",
        DomainNames = new List<string>() { "domainNames" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkDomainWhoisLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">IpWhoisLookupAsync</a>(IpWhoisLookupRequest { ... }) -> WithRawResponseTask&lt;IpWhoisLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns WHOIS registration details for a specified IP address (IPv4 or IPv6).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.IpWhoisLookupAsync(new IpWhoisLookupRequest { ApiKey = "apiKey", Ip = "ip" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IpWhoisLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">AsnWhoisLookupAsync</a>(AsnWhoisLookupRequest { ... }) -> WithRawResponseTask&lt;AsnWhoisLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns WHOIS registration details for a specified ASN, with or without the 'as' prefix.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AsnWhoisLookupAsync(new AsnWhoisLookupRequest { ApiKey = "apiKey", Asn = "asn" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AsnWhoisLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainWhoisHistoryAsync</a>(DomainWhoisHistoryRequest { ... }) -> WithRawResponseTask&lt;DomainWhoisHistoryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve historical WHOIS records for a domain name.
This endpoint provides a timeline of all recorded changes in domain registration information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainWhoisHistoryAsync(
    new DomainWhoisHistoryRequest { ApiKey = "apiKey", DomainName = "domainName" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainWhoisHistoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainWhoisReverseAsync</a>(DomainWhoisReverseRequest { ... }) -> WithRawResponseTask&lt;DomainWhoisReverseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Performs a reverse WHOIS search using one or more search parameters like keyword, email, owner, or company.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainWhoisReverseAsync(new DomainWhoisReverseRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainWhoisReverseRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainDnsLookupAsync</a>(DomainDnsLookupRequest { ... }) -> WithRawResponseTask&lt;DomainDnsLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve real-time DNS records for any hostname. Supports multiple record types including A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainDnsLookupAsync(
    new DomainDnsLookupRequest
    {
        ApiKey = "apiKey",
        Type = new List<string>() { "type" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainDnsLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkDomainDnsLookupAsync</a>(BulkDomainDnsLookupRequest { ... }) -> WithRawResponseTask&lt;BulkDomainDnsLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Perform DNS lookups for multiple hostnames in a single request. Supports up to `100 host-names per request`
and returns DNS records including A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkDomainDnsLookupAsync(
    new BulkDomainDnsLookupRequest
    {
        ApiKey = "apiKey",
        Type = new List<string>() { "type" },
        DomainNames = new List<string>() { "domainNames" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkDomainDnsLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainDnsHistoryAsync</a>(DomainDnsHistoryRequest { ... }) -> WithRawResponseTask&lt;DomainDnsHistoryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve historical DNS records for any hostname. Access unique historical data for A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records,
including subdomains. Results are paginated with up to 100 unique records per page.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainDnsHistoryAsync(
    new DomainDnsHistoryRequest
    {
        ApiKey = "apiKey",
        HostName = "host-name",
        Type = new List<string>() { "type" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainDnsHistoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainDnsReverseAsync</a>(DomainDnsReverseRequest { ... }) -> WithRawResponseTask&lt;DomainDnsReverseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all the hostnames associated with any particular A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME DNS records. For instance, you can access all the hostnames hosted on any IP/CIDR notation, all the domain names using Cloudflare name servers, and all the domain names using Google Mailbox
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainDnsReverseAsync(
    new DomainDnsReverseRequest
    {
        ApiKey = "apiKey",
        Type = DomainDnsReverseRequestType.A,
        Value = "value",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainDnsReverseRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">WebScrapeAsync</a>(WebScrapeRequest { ... }) -> WithRawResponseTask&lt;WebScrapeResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Execute a series of web scraping instructions on a target URL. 
Supports various operations like form filling, clicking, data extraction, and CAPTCHA solving.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.WebScrapeAsync(
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
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `WebScrapeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">EmailValidateAsync</a>(EmailValidateRequest { ... }) -> WithRawResponseTask&lt;EmailValidateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Validates a single email address and returns result.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmailValidateAsync(new EmailValidateRequest { ApiKey = "apiKey", Email = "email" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EmailValidateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkEmailValidateAsync</a>(BulkEmailValidateRequest { ... }) -> WithRawResponseTask&lt;BulkEmailValidateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Validates a bulk of email addresses and returns result for each. Maximum `10` email addresses per request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkEmailValidateAsync(
    new BulkEmailValidateRequest
    {
        ApiKey = "apiKey",
        EmailData = new List<BulkEmailValidateRequestEmailDataItem>()
        {
            new BulkEmailValidateRequestEmailDataItem { Email = "email" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkEmailValidateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DisposableEmailCheckV2Async</a>(DisposableEmailCheckV2Request { ... }) -> WithRawResponseTask&lt;DisposableEmailCheckV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Validates email syntax and checks the domain for disposable, free, spam, and role-account signals, plus MX/A DNS records. Send the email (and optionally an ip) as a JSON request body. When an ip is included, the response also carries geolocation and security data for it.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DisposableEmailCheckV2Async(
    new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DisposableEmailCheckV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkDisposableEmailCheckV2Async</a>(BulkDisposableEmailCheckV2Request { ... }) -> WithRawResponseTask&lt;BulkDisposableEmailCheckV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Checks a bulk of email addresses (each with an optional ip) and returns a disposable email check result for each, in the same order as the request. Maximum `100` entries per request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkDisposableEmailCheckV2Async(
    new BulkDisposableEmailCheckV2Request
    {
        ApiKey = "apiKey",
        EmailData = new List<BulkDisposableEmailCheckV2RequestEmailDataItem>()
        {
            new BulkDisposableEmailCheckV2RequestEmailDataItem { Email = "abc" },
            new BulkDisposableEmailCheckV2RequestEmailDataItem
            {
                Email = "john@microsoft.com",
                Ip = "8.8.8.8",
            },
            new BulkDisposableEmailCheckV2RequestEmailDataItem { Email = "test@mailinator.com" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkDisposableEmailCheckV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PhoneValidateAsync</a>(PhoneValidateRequest { ... }) -> WithRawResponseTask&lt;PhoneValidateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Validates a single phone number and returns detailed metadata including carrier, line type, geolocation, time zones, and standardized formats.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PhoneValidateAsync(
    new PhoneValidateRequest { ApiKey = "apiKey", Number = "+14155552671" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PhoneValidateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkPhoneValidateAsync</a>(BulkPhoneValidateRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;BulkPhoneValidateResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Validates up to 100 phone numbers in a single request. Each number is processed independently — invalid entries return per-number errors without affecting the rest of the batch.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkPhoneValidateAsync(
    new BulkPhoneValidateRequest
    {
        ApiKey = "apiKey",
        Numbers = new List<BulkPhoneValidateRequestNumbersItem>()
        {
            new BulkPhoneValidateRequestNumbersItem { Number = "+14155552671" },
            new BulkPhoneValidateRequestNumbersItem { Number = "+447911123456" },
            new BulkPhoneValidateRequestNumbersItem { Number = "+919876543210" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkPhoneValidateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainSslLookupAsync</a>(DomainSslLookupRequest { ... }) -> WithRawResponseTask&lt;DomainSslLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve comprehensive SSL certificate information without the certificate chain.
This endpoint provides detailed information about the SSL certificate including expiry dates, issuer details, and encryption methods.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainSslLookupAsync(
    new DomainSslLookupRequest { ApiKey = "apiKey", DomainName = "domainName" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainSslLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainSslChainLookupAsync</a>(DomainSslChainLookupRequest { ... }) -> WithRawResponseTask&lt;DomainSslChainLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the complete SSL certificate chain from root Certificate Authority (CA) to end-user certificate.
This endpoint provides comprehensive information about each certificate in the chain.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainSslChainLookupAsync(
    new DomainSslChainLookupRequest { ApiKey = "apiKey", DomainName = "domainName" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainSslChainLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainAvailabilityCheckAsync</a>(DomainAvailabilityCheckRequest { ... }) -> WithRawResponseTask&lt;DomainAvailabilityCheckResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The Domain Search API is designed to simplify the process of finding available domain names across all top-level domains (TLDs) and second-level domains (SLDs).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainAvailabilityCheckAsync(
    new DomainAvailabilityCheckRequest { ApiKey = "apiKey", Domain = "domain" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainAvailabilityCheckRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkDomainAvailabilityCheckAsync</a>(BulkDomainAvailabilityCheckRequest { ... }) -> WithRawResponseTask&lt;BulkDomainAvailabilityCheckResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Perform Bulk Domain Availability checks using a list of domains. Supports upto `100 Domains Per Request`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkDomainAvailabilityCheckAsync(
    new BulkDomainAvailabilityCheckRequest
    {
        ApiKey = "apiKey",
        DomainNames = new List<string>() { "domainNames" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkDomainAvailabilityCheckRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainAvailabilitySuggestionsAsync</a>(DomainAvailabilitySuggestionsRequest { ... }) -> WithRawResponseTask&lt;OneOf&lt;DomainAvailabilitySuggestionsResponseDomain, DomainAvailabilitySuggestionsResponseDomainAvailableResponse&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The Domain Search API is designed to simplify the process of finding available domain names across all top-level domains (TLDs) and second-level domains (SLDs).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainAvailabilitySuggestionsAsync(
    new DomainAvailabilitySuggestionsRequest { ApiKey = "apiKey", Domain = "domain" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainAvailabilitySuggestionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">SubdomainsLookupAsync</a>(SubdomainsLookupRequest { ... }) -> WithRawResponseTask&lt;SubdomainsLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The Subdomain Lookup API is designed to retrieve subdomains related to the given domain name. It helps you explore subdomains that are available for registration or usage.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SubdomainsLookupAsync(
    new SubdomainsLookupRequest { ApiKey = "apiKey", Domain = "domain" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SubdomainsLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainTyposquattingAsync</a>(DomainTyposquattingRequest { ... }) -> WithRawResponseTask&lt;DomainTyposquattingResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The Domain Typosquatting API searches for registered domains that are typo or look-alike variants of a brand keyword, or that match a wildcard pattern. Results include registration lifecycle data and drop status across 1529+ TLDs, paginated at 100 domains per page.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainTyposquattingAsync(new DomainTyposquattingRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainTyposquattingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainReputationAsync</a>(DomainReputationRequest { ... }) -> WithRawResponseTask&lt;DomainReputationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

The Domain Reputation API evaluates a domain against threat intelligence sources, DGA (domain generation algorithm) scoring, trust signals, and email deliverability configuration, returning a consolidated risk assessment with a verdict, severity, and supporting evidence.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainReputationAsync(
    new DomainReputationRequest { ApiKey = "apiKey", DomainName = "domainName" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainReputationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">AstronomyLookupV2Async</a>(AstronomyLookupV2Request { ... }) -> WithRawResponseTask&lt;AstronomyLookupV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve sunrise and sunset times, current position of the moon, and other related information by specifying a location address, location coordinates, IP address, or using the client IP address if no parameter is passed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AstronomyLookupV2Async(new AstronomyLookupV2Request { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AstronomyLookupV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">TimezoneLookupV2Async</a>(TimezoneLookupV2Request { ... }) -> WithRawResponseTask&lt;TimezoneLookupV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get current time, date, and timezone details by specifying a timezone name, location address, GPS coordinates, IP address, IATA/ICAO airport code, UN/LOCODE, or use the client IP if no parameter is provided.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TimezoneLookupV2Async(new TimezoneLookupV2Request { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TimezoneLookupV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GeolocationLookupV2Async</a>(GeolocationLookupV2Request { ... }) -> WithRawResponseTask&lt;GeolocationLookupV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get detailed IP geolocation data for an IP address including country, city, timezone, currency, and optional threat intelligence and user-agent information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GeolocationLookupV2Async(new GeolocationLookupV2Request { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GeolocationLookupV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkGeolocationLookupV2Async</a>(BulkGeolocationLookupV2Request { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;OneOf&lt;BulkGeolocationLookupV2ResponseItemAbuse, BulkGeolocationLookupV2ResponseItemMessage&gt;&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get detailed IP geolocation data for multiple IP addresses including country, city, timezone, currency, and optional threat intelligence information. Supports up to 50,000 IP addresses per request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkGeolocationLookupV2Async(
    new BulkGeolocationLookupV2Request
    {
        ApiKey = "apiKey",
        Ips = new List<string>() { "ips" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkGeolocationLookupV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">DomainWhoisLookupV2Async</a>(DomainWhoisLookupV2Request { ... }) -> WithRawResponseTask&lt;DomainWhoisLookupV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the current WHOIS record for the specified domain, including registrar details, registrant/administrative/technical/billing/reseller contacts, name servers, status codes, and raw WHOIS text.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DomainWhoisLookupV2Async(
    new DomainWhoisLookupV2Request { ApiKey = "apiKey", DomainName = "domainName" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DomainWhoisLookupV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkDomainWhoisLookupV2Async</a>(BulkDomainWhoisLookupV2Request { ... }) -> WithRawResponseTask&lt;BulkDomainWhoisLookupV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the current WHOIS record for each requested domain, in request order. Supports up to 100 domain names per request; a domain that fails to resolve yields an error item instead of failing the whole batch.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkDomainWhoisLookupV2Async(
    new BulkDomainWhoisLookupV2Request
    {
        ApiKey = "apiKey",
        DomainNames = new List<string>() { "domainNames" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkDomainWhoisLookupV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityLatestRatesV2Async</a>(CommodityLatestRatesV2Request { ... }) -> WithRawResponseTask&lt;CommodityLatestRatesV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the current live price for the requested commodity symbols. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityLatestRatesV2Async(
    new CommodityLatestRatesV2Request
    {
        ApiKey = "apiKey",
        Symbols = new List<string>() { "symbols" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityLatestRatesV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityHistoricalRatesV2Async</a>(CommodityHistoricalRatesV2Request { ... }) -> WithRawResponseTask&lt;CommodityHistoricalRatesV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns OHLC price data for the requested commodity symbols on a specific date. Falls back to the nearest earlier rate if none exists for the exact date. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityHistoricalRatesV2Async(
    new CommodityHistoricalRatesV2Request
    {
        ApiKey = "apiKey",
        Symbols = new List<string>() { "symbols" },
        Date = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityHistoricalRatesV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityFluctuationV2Async</a>(CommodityFluctuationV2Request { ... }) -> WithRawResponseTask&lt;CommodityFluctuationV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns price fluctuation metrics (start, end, change, percent change) for the requested commodity symbols over a date range. For monthly-updated commodities the range snaps to month boundaries. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityFluctuationV2Async(
    new CommodityFluctuationV2Request
    {
        ApiKey = "apiKey",
        Symbols = new List<string>() { "symbols" },
        StartDate = new DateOnly(2023, 1, 15),
        EndDate = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityFluctuationV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityTimeSeriesV2Async</a>(CommodityTimeSeriesV2Request { ... }) -> WithRawResponseTask&lt;CommodityTimeSeriesV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns day-by-day OHLC data for the requested commodity symbols within a date range, indexed by date. Non-trading days are excluded. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityTimeSeriesV2Async(
    new CommodityTimeSeriesV2Request
    {
        ApiKey = "apiKey",
        Symbols = new List<string>() { "symbols" },
        StartDate = new DateOnly(2023, 1, 15),
        EndDate = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityTimeSeriesV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommoditySymbolsV2Async</a>(CommoditySymbolsV2Request { ... }) -> WithRawResponseTask&lt;CommoditySymbolsV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the list of supported commodity symbols with metadata. Deprecated symbols stay listed with status "inactive" and a deprecationDate.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommoditySymbolsV2Async(new CommoditySymbolsV2Request { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommoditySymbolsV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityIntradayRatesV2Async</a>(CommodityIntradayRatesV2Request { ... }) -> WithRawResponseTask&lt;CommodityIntradayRatesV2Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the prices of one commodity through a UTC day at the requested interval, keyed by UTC timestamp. Each request costs a flat 50 credits however many points it returns.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityIntradayRatesV2Async(
    new CommodityIntradayRatesV2Request
    {
        ApiKey = "apiKey",
        Symbols = "symbols",
        Interval = CommodityIntradayRatesV2RequestInterval.OneM,
        Date = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityIntradayRatesV2Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfMergeAsync</a>(PdfMergeRequest { ... }) -> WithRawResponseTask&lt;PdfMergeResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API merges multiple PDF files into a single PDF, in the order they are provided
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfMergeAsync(new PdfMergeRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfMergeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfRemovePagesAsync</a>(PdfRemovePagesRequest { ... }) -> WithRawResponseTask&lt;PdfRemovePagesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API removes a selection or range of pages from a PDF file.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfRemovePagesAsync(new PdfRemovePagesRequest { ApiKey = "apiKey", Pages = "pages" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfRemovePagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfSplitAsync</a>(PdfSplitRequest { ... }) -> WithRawResponseTask&lt;PdfSplitResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API splits a PDF into multiple parts based on specified page numbers or ranges.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfSplitAsync(new PdfSplitRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfSplitRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfRotateAsync</a>(PdfRotateRequest { ... }) -> WithRawResponseTask&lt;PdfRotateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API rotates pages of a PDF by a specified angle (in multiples of 90 degrees).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfRotateAsync(new PdfRotateRequest { ApiKey = "apiKey", Rotate = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfRotateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfCompressAsync</a>(PdfCompressRequest { ... }) -> WithRawResponseTask&lt;PdfCompressResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API compresses a given PDF file to reduce its file size.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfCompressAsync(
    new PdfCompressRequest
    {
        ApiKey = "apiKey",
        CompressionLevel = PdfCompressRequestCompressionLevel.Low,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfCompressRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfExtractPagesAsync</a>(PdfExtractPagesRequest { ... }) -> WithRawResponseTask&lt;PdfExtractPagesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API extracts specific pages or page ranges from a PDF file and returns them as a new PDF.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfExtractPagesAsync(
    new PdfExtractPagesRequest { ApiKey = "apiKey", Pages = "pages" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfExtractPagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfLinearizeAsync</a>(PdfLinearizeRequest { ... }) -> WithRawResponseTask&lt;PdfLinearizeResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

API endpoint that linearizes any given PDF, restructuring it for faster loading and page-by-page viewing in web browsers.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfLinearizeAsync(new PdfLinearizeRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfLinearizeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfEncryptAsync</a>(PdfEncryptRequest { ... }) -> WithRawResponseTask&lt;PdfEncryptResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API encrypts a PDF file by setting a password required to open it.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfEncryptAsync(
    new PdfEncryptRequest { ApiKey = "apiKey", UserPassword = "user_password" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfEncryptRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfDecryptAsync</a>(PdfDecryptRequest { ... }) -> WithRawResponseTask&lt;PdfDecryptResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API decrypts PDF files, removing all encryption, including open passwords and permission restrictions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfDecryptAsync(
    new PdfDecryptRequest { ApiKey = "apiKey", FilePassword = "file_password" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfDecryptRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfRestrictAsync</a>(PdfRestrictRequest { ... }) -> WithRawResponseTask&lt;PdfRestrictResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API applies permission restrictions on a PDF file, such as disabling printing, copying, or editing. This can include password protection to enforce restrictions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfRestrictAsync(
    new PdfRestrictRequest
    {
        ApiKey = "apiKey",
        UserPassword = "user_password",
        Restrictions = new List<PdfRestrictRequestRestrictionsItem>()
        {
            PdfRestrictRequestRestrictionsItem.PrintHigh,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfRestrictRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfUnrestrictAsync</a>(PdfUnrestrictRequest { ... }) -> WithRawResponseTask&lt;PdfUnrestrictResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API removes permission restrictions from a PDF while keeping it encrypted. If you want to remove all security (including encryption), use the `/pdf/decrypt` endpoint instead.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfUnrestrictAsync(
    new PdfUnrestrictRequest
    {
        ApiKey = "apiKey",
        FilePassword = "file_password",
        UserPassword = "user_password",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfUnrestrictRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfConvertToPngAsync</a>(PdfConvertToPngRequest { ... }) -> WithRawResponseTask&lt;PdfConvertToPngResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API converts a given PDF file into a sequence of PNG images.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfConvertToPngAsync(new PdfConvertToPngRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfConvertToPngRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfConvertToJpgAsync</a>(PdfConvertToJpgRequest { ... }) -> WithRawResponseTask&lt;PdfConvertToJpgResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API converts a given PDF file into a sequence of JPG images.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfConvertToJpgAsync(new PdfConvertToJpgRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfConvertToJpgRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfConvertToTiffAsync</a>(PdfConvertToTiffRequest { ... }) -> WithRawResponseTask&lt;PdfConvertToTiffResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API converts a given PDF file into a sequence of TIFF images. The output images can be saved as a single TIFF file, or as a sequence of TIFF files.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfConvertToTiffAsync(new PdfConvertToTiffRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfConvertToTiffRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfConvertToBmpAsync</a>(PdfConvertToBmpRequest { ... }) -> WithRawResponseTask&lt;PdfConvertToBmpResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Converts a PDF file to a BMP image.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfConvertToBmpAsync(new PdfConvertToBmpRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfConvertToBmpRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfConvertToGifAsync</a>(PdfConvertToGifRequest { ... }) -> WithRawResponseTask&lt;PdfConvertToGifResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API converts a given PDF file into a sequence of GIF images.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfConvertToGifAsync(new PdfConvertToGifRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfConvertToGifRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfUploadResourcesAsync</a>(PdfUploadResourcesRequest { ... }) -> WithRawResponseTask&lt;PdfUploadResourcesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API uploads multiple PDF files to the API Freaks server and generates their unique file IDs.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfUploadResourcesAsync(new PdfUploadResourcesRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfUploadResourcesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfUploadBinaryAsync</a>(PdfUploadBinaryRequest { ... }) -> WithRawResponseTask&lt;PdfUploadBinaryResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API uploads PDF files to the API Freaks server in binary format.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfUploadBinaryAsync(
    new PdfUploadBinaryRequest
    {
        ApiKey = "apiKey",
        FileName = "document.pdf",
        Body = File.OpenRead("document.pdf"),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfUploadBinaryRequest` — `Body` is the raw PDF stream, sent as `application/octet-stream`; `FileName` is sent as the `file_name` query parameter.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfDownloadResourceAsync</a>(PdfDownloadResourceRequest { ... }) -> WithRawResponseTask&lt;Stream&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API downloads PDF files or ZIP archives from the server using their unique resource ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfDownloadResourceAsync(
    new PdfDownloadResourceRequest { ApiKey = "apiKey", ResourceId = "resource_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfDownloadResourceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfGetTaskStatusAsync</a>(PdfGetTaskStatusRequest { ... }) -> WithRawResponseTask&lt;PdfGetTaskStatusResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API checks the status of a previously initiated PDF processing task using its unique task ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfGetTaskStatusAsync(
    new PdfGetTaskStatusRequest { ApiKey = "apiKey", TaskId = "task_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfGetTaskStatusRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfGetFileStatusAsync</a>(PdfGetFileStatusRequest { ... }) -> WithRawResponseTask&lt;PdfGetFileStatusResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API checks the status of a PDF file using its unique file ID, providing information about its creation and potential deletion time.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfGetFileStatusAsync(
    new PdfGetFileStatusRequest { ApiKey = "apiKey", FileId = "file_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfGetFileStatusRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfListFilesAsync</a>(PdfListFilesRequest { ... }) -> WithRawResponseTask&lt;PdfListFilesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API retrieves a list of all PDF files uploaded and generated by a specific user. Please note that if the user is part of an organization, only the Organization Administrator can access this endpoint. Organization Members cannot access this endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfListFilesAsync(new PdfListFilesRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfListFilesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfDeleteFileAsync</a>(PdfDeleteFileRequest { ... }) -> WithRawResponseTask&lt;PdfDeleteFileResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This API deletes a PDF file using its unique file ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfDeleteFileAsync(new PdfDeleteFileRequest { ApiKey = "apiKey", FileId = "file_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfDeleteFileRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">PdfGenerateFromTemplateAsync</a>(PdfGenerateFromTemplateRequest { ... }) -> WithRawResponseTask&lt;PdfGenerateFromTemplateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Renders the template identified by template_id with the JSON data supplied in the request body (or fetched from data_url). Returns a hosted URL for the generated PDF. Provide either a request body or a data_url; one of the two is required. The keys of the data object are the fields you bound when you designed the template in the APIFreaks PDF Template Builder, so the exact shape is up to you. Pin the version parameter to a specific template version (e.g. version=v2) so later design changes never touch what is already live; omit it to use the latest version.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.PdfGenerateFromTemplateAsync(
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
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PdfGenerateFromTemplateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkPdfGenerateFromTemplateAsync</a>(BulkPdfGenerateFromTemplateRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;BulkPdfGenerateFromTemplateResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Upload a CSV file where each row is one record. The API generates one PDF per row and returns an array of results, each with its own pdf_url. Rows are processed independently, so a failure in one row does not block the rest of the batch. The response gives a row-by-row breakdown of which PDFs succeeded and which failed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkPdfGenerateFromTemplateAsync(
    new BulkPdfGenerateFromTemplateRequest { ApiKey = "apiKey", TemplateId = "template_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkPdfGenerateFromTemplateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">ScreenshotCaptureAsync</a>(ScreenshotCaptureRequest { ... }) -> WithRawResponseTask&lt;ScreenshotCaptureResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Capture full-page screenshots and videos of websites with advanced options like device simulation, custom code injection, cookie banner blocking, and scrollable content recording.
Supports multiple output formats including JSON, image, GIF, MP4, and WebM.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ScreenshotCaptureAsync(
    new ScreenshotCaptureRequest { ApiKey = "apiKey", Url = "url" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ScreenshotCaptureRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkScreenshotCaptureAsync</a>(BulkScreenshotCaptureRequest { ... }) -> WithRawResponseTask&lt;BulkScreenshotCaptureResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Our Bulk Screenshot API allows you to capture screenshots of multiple webpages simultaneously, saving you time and effort. Instead of manually capturing each page one by one, you can batch process URLs and receive high-quality screenshots in the format you choose.
 Maximum `50 URLs` per request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkScreenshotCaptureAsync(
    new BulkScreenshotCaptureRequest
    {
        ApiKey = "apiKey",
        Urls = new List<BulkScreenshotCaptureRequestUrlsItem>()
        {
            new BulkScreenshotCaptureRequestUrlsItem { Url = "url" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkScreenshotCaptureRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencyLatestRatesAsync</a>(CurrencyLatestRatesRequest { ... }) -> WithRawResponseTask&lt;CurrencyLatestRatesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get live forex rates for all world currencies with customizable update frequency
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencyLatestRatesAsync(new CurrencyLatestRatesRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencyLatestRatesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencyHistoricalRatesAsync</a>(CurrencyHistoricalRatesRequest { ... }) -> WithRawResponseTask&lt;CurrencyHistoricalRatesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get historical exchange rates for any specific date
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencyHistoricalRatesAsync(
    new CurrencyHistoricalRatesRequest { ApiKey = "apiKey", Date = new DateOnly(2023, 1, 15) }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencyHistoricalRatesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencyConvertLatestAsync</a>(CurrencyConvertLatestRequest { ... }) -> WithRawResponseTask&lt;CurrencyConvertLatestResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Convert amount between currencies using the latest exchange rates
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencyConvertLatestAsync(
    new CurrencyConvertLatestRequest
    {
        ApiKey = "apiKey",
        From = "from",
        To = "to",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencyConvertLatestRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencyConvertHistoricalAsync</a>(CurrencyConvertHistoricalRequest { ... }) -> WithRawResponseTask&lt;CurrencyConvertHistoricalResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Convert amount between currencies using historical rates
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencyConvertHistoricalAsync(
    new CurrencyConvertHistoricalRequest
    {
        ApiKey = "apiKey",
        From = "from",
        To = "to",
        Date = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencyConvertHistoricalRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencyTimeSeriesAsync</a>(CurrencyTimeSeriesRequest { ... }) -> WithRawResponseTask&lt;CurrencyTimeSeriesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get exchange rates for a time range
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencyTimeSeriesAsync(
    new CurrencyTimeSeriesRequest { ApiKey = "apiKey", StartDate = new DateOnly(2023, 1, 15) }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencyTimeSeriesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencyFluctuationAsync</a>(CurrencyFluctuationRequest { ... }) -> WithRawResponseTask&lt;CurrencyFluctuationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get currency fluctuation data for a time period
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencyFluctuationAsync(
    new CurrencyFluctuationRequest
    {
        ApiKey = "apiKey",
        StartDate = new DateOnly(2023, 1, 15),
        Base = "USD",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencyFluctuationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencyConvertByIpAsync</a>(CurrencyConvertByIpRequest { ... }) -> WithRawResponseTask&lt;CurrencyConvertByIpResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Convert amount using user's location
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencyConvertByIpAsync(
    new CurrencyConvertByIpRequest { ApiKey = "apiKey", From = "from" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencyConvertByIpRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencySupportedAsync</a>(CurrencySupportedRequest { ... }) -> WithRawResponseTask&lt;CurrencySupportedResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get list of all supported currencies with their metadata
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencySupportedAsync(new CurrencySupportedRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencySupportedRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencySymbolsAsync</a>(CurrencySymbolsRequest { ... }) -> WithRawResponseTask&lt;CurrencySymbolsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get currency symbols and codes
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencySymbolsAsync(new CurrencySymbolsRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencySymbolsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrencyHistoricalLimitsAsync</a>(CurrencyHistoricalLimitsRequest { ... }) -> WithRawResponseTask&lt;CurrencyHistoricalLimitsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get information about historical data availability and limits
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrencyHistoricalLimitsAsync(
    new CurrencyHistoricalLimitsRequest { ApiKey = "apiKey" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrencyHistoricalLimitsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityLatestRatesAsync</a>(CommodityLatestRatesRequest { ... }) -> WithRawResponseTask&lt;CommodityLatestRatesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get live commodity rates with customizable update frequency
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityLatestRatesAsync(
    new CommodityLatestRatesRequest
    {
        ApiKey = "apiKey",
        Symbols = new List<string>() { "symbols" },
        Updates = CommodityLatestRatesRequestUpdates.TenM,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityLatestRatesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityHistoricalRatesAsync</a>(CommodityHistoricalRatesRequest { ... }) -> WithRawResponseTask&lt;CommodityHistoricalRatesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get historical commodity rates for a specific date
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityHistoricalRatesAsync(
    new CommodityHistoricalRatesRequest
    {
        ApiKey = "apiKey",
        Date = new DateOnly(2023, 1, 15),
        Symbols = new List<string>() { "symbols" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityHistoricalRatesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityFluctuationAsync</a>(CommodityFluctuationRequest { ... }) -> WithRawResponseTask&lt;CommodityFluctuationResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get commodity price fluctuation data for a time period
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityFluctuationAsync(
    new CommodityFluctuationRequest
    {
        ApiKey = "apiKey",
        Symbols = new List<string>() { "symbols" },
        StartDate = new DateOnly(2023, 1, 15),
        EndDate = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityFluctuationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommodityTimeSeriesAsync</a>(CommodityTimeSeriesRequest { ... }) -> WithRawResponseTask&lt;CommodityTimeSeriesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get commodity rates for a time range
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommodityTimeSeriesAsync(
    new CommodityTimeSeriesRequest
    {
        ApiKey = "apiKey",
        Symbols = new List<string>() { "symbols" },
        StartDate = new DateOnly(2023, 1, 15),
        EndDate = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommodityTimeSeriesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CommoditySymbolsAsync</a>(CommoditySymbolsRequest { ... }) -> WithRawResponseTask&lt;CommoditySymbolsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get list of supported commodities
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CommoditySymbolsAsync(new CommoditySymbolsRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CommoditySymbolsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">VatSupportedCountriesAsync</a>(VatSupportedCountriesRequest { ... }) -> WithRawResponseTask&lt;VatSupportedCountriesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of supported countries.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VatSupportedCountriesAsync(new VatSupportedCountriesRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `VatSupportedCountriesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">VatRateByIpAsync</a>(VatRateByIpRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;VatRateByIpResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches VAT rate based on the specified or originating IP address.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VatRateByIpAsync(new VatRateByIpRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `VatRateByIpRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">VatRateByCountryAsync</a>(VatRateByCountryRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;VatRateByCountryResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches VAT rates for a single country or state provided via query parameters.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VatRateByCountryAsync(
    new VatRateByCountryRequest { ApiKey = "apiKey", Country = "country" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `VatRateByCountryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkVatRateByCountryAsync</a>(BulkVatRateByCountryRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;BulkVatRateByCountryResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves VAT details for multiple countries or country-state combinations in a single request. Maximum of `100` entries per request are allowed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkVatRateByCountryAsync(
    new BulkVatRateByCountryRequest
    {
        ApiKey = "apiKey",
        Countries = new List<BulkVatRateByCountryRequestCountriesItem>()
        {
            new BulkVatRateByCountryRequestCountriesItem { Country = "PAK" },
            new BulkVatRateByCountryRequestCountriesItem
            {
                Country = "United_States",
                State = "New_York",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkVatRateByCountryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">VatValidateAsync</a>(VatValidateRequest { ... }) -> WithRawResponseTask&lt;VatValidateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Validates an EU or UK VAT number and returns registration status details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VatValidateAsync(
    new VatValidateRequest { ApiKey = "apiKey", VatNumber = "vatNumber" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `VatValidateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">IbanValidateAsync</a>(IbanValidateRequest { ... }) -> WithRawResponseTask&lt;IbanValidateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Checks an IBAN for structural validity, checksum accuracy, and bank metadata.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.IbanValidateAsync(new IbanValidateRequest { ApiKey = "apiKey", Iban = "iban" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IbanValidateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">SwiftCodeFindAsync</a>(SwiftCodeFindRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;string&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches SWIFT codes for a given country, bank, and city.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SwiftCodeFindAsync(new SwiftCodeFindRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SwiftCodeFindRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">SwiftCodeLookupAsync</a>(SwiftCodeLookupRequest { ... }) -> WithRawResponseTask&lt;SwiftCodeLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches detailed information about a SWIFT code.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SwiftCodeLookupAsync(
    new SwiftCodeLookupRequest { ApiKey = "apiKey", SwiftCode = "swiftCode" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SwiftCodeLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">ZipcodeLookupAsync</a>(ZipcodeLookupRequest { ... }) -> WithRawResponseTask&lt;ZipcodeLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ZipcodeLookupAsync(new ZipcodeLookupRequest { ApiKey = "apiKey", Code = "code" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ZipcodeLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkZipcodeLookupAsync</a>(BulkZipcodeLookupRequest { ... }) -> WithRawResponseTask&lt;BulkZipcodeLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Validates a bulk of ZIP/postal codes and returns result for each. Maximum `100` ZIP/postal codes per request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkZipcodeLookupAsync(
    new BulkZipcodeLookupRequest
    {
        ApiKey = "apiKey",
        Codes = new List<string>() { "codes" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkZipcodeLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">ZipcodeSearchByCityAsync</a>(ZipcodeSearchByCityRequest { ... }) -> WithRawResponseTask&lt;ZipcodeSearchByCityResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ZipcodeSearchByCityAsync(
    new ZipcodeSearchByCityRequest
    {
        ApiKey = "apiKey",
        City = "city",
        Country = "country",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ZipcodeSearchByCityRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">ZipcodeSearchByRegionAsync</a>(ZipcodeSearchByRegionRequest { ... }) -> WithRawResponseTask&lt;ZipcodeSearchByRegionResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ZipcodeSearchByRegionAsync(
    new ZipcodeSearchByRegionRequest { ApiKey = "apiKey", Country = "country" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ZipcodeSearchByRegionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">ZipcodeSearchByRadiusAsync</a>(ZipcodeSearchByRadiusRequest { ... }) -> WithRawResponseTask&lt;ZipcodeSearchByRadiusResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ZipcodeSearchByRadiusAsync(
    new ZipcodeSearchByRadiusRequest { ApiKey = "apiKey", Radius = 1.1f }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ZipcodeSearchByRadiusRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">ZipcodeDistanceAsync</a>(ZipcodeDistanceRequest { ... }) -> WithRawResponseTask&lt;ZipcodeDistanceResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get distance between postal codes. Maximum `100` postal codes per request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ZipcodeDistanceAsync(
    new ZipcodeDistanceRequest
    {
        ApiKey = "apiKey",
        Compare = new List<string>() { "compare" },
        Country = "country",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ZipcodeDistanceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">ZipcodeDistanceMatchAsync</a>(ZipcodeDistanceMatchRequest { ... }) -> WithRawResponseTask&lt;ZipcodeDistanceMatchResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get matching ZIP/postal code pairs within a specified distance. Maximum `100` postal codes per request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ZipcodeDistanceMatchAsync(
    new ZipcodeDistanceMatchRequest
    {
        ApiKey = "apiKey",
        Codes = new List<string>() { "codes" },
        Country = "country",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ZipcodeDistanceMatchRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">CurrentWeatherAsync</a>(CurrentWeatherRequest { ... }) -> WithRawResponseTask&lt;CurrentWeatherResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get current weather data including temperature, humidity, precipitation, wind conditions, atmospheric pressure, and air quality for any location. Accepts city names, coordinates, or IP addresses. Also includes astronomy data and timezone-aware timestamps.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CurrentWeatherAsync(new CurrentWeatherRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CurrentWeatherRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkCurrentWeatherAsync</a>(BulkCurrentWeatherRequest { ... }) -> WithRawResponseTask&lt;BulkCurrentWeatherResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve current weather conditions for up to `50 locations` in a single request. A maximum of 50 locations (city names, IP addresses, or geographic coordinates) can be included in the request body.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkCurrentWeatherAsync(
    new BulkCurrentWeatherRequest
    {
        ApiKey = "apiKey",
        Locations = new List<BulkCurrentWeatherRequestLocationsItem>()
        {
            new BulkCurrentWeatherRequestLocationsItem { Location = "lahore" },
            new BulkCurrentWeatherRequestLocationsItem { Lat = 32.5, Long = 74.5 },
            new BulkCurrentWeatherRequestLocationsItem { Ip = "8.8.8.8" },
            new BulkCurrentWeatherRequestLocationsItem { Location = "seoul" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkCurrentWeatherRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">WeatherForecastAsync</a>(WeatherForecastRequest { ... }) -> WithRawResponseTask&lt;WeatherForecastResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Access comprehensive weather forecasts with customizable precision - choose from daily overviews, hourly breakdowns, or even minute-by-minute data. Configure your date ranges or use the default 7-day forecast for standard weather planning.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.WeatherForecastAsync(new WeatherForecastRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `WeatherForecastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">HistoricalWeatherAsync</a>(HistoricalWeatherRequest { ... }) -> WithRawResponseTask&lt;HistoricalWeatherResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Access past weather conditions for specific dates with records going back to 1940. Retrieve comprehensive historical data with both daily and hourly precision options.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.HistoricalWeatherAsync(
    new HistoricalWeatherRequest { ApiKey = "apiKey", Date = new DateOnly(2023, 1, 15) }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `HistoricalWeatherRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">WeatherTimeSeriesAsync</a>(WeatherTimeSeriesRequest { ... }) -> WithRawResponseTask&lt;WeatherTimeSeriesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Pull historical weather information for date ranges up to 90 days (daily data) or 7 days (hourly data). Get consistent formatting across your specified date range with reliable historical weather patterns.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.WeatherTimeSeriesAsync(
    new WeatherTimeSeriesRequest
    {
        ApiKey = "apiKey",
        StartDate = new DateOnly(2023, 1, 15),
        EndDate = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `WeatherTimeSeriesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">MarineWeatherAsync</a>(MarineWeatherRequest { ... }) -> WithRawResponseTask&lt;MarineWeatherResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides hourly forecasts of marine conditions including wave heights, wave directions, wave periods, swell info, sea surface temperatures, and ocean currents. Supports multiple geographical points and returns daily max wave statistics for up to 7 days. Ideal for maritime planning, navigation, and coastal activities.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.MarineWeatherAsync(new MarineWeatherRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `MarineWeatherRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">AirQualityAsync</a>(AirQualityRequest { ... }) -> WithRawResponseTask&lt;AirQualityResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Monitor and predict air quality conditions using European and US AQI standards. Track pollutant concentrations including PM10, PM2.5, carbon monoxide, nitrogen dioxide, sulfur dioxide, ozone, and dust particles. Get current readings plus hourly forecasts up to 5 days ahead, complete with UV index and aerosol measurements for comprehensive air quality assessment.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AirQualityAsync(new AirQualityRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AirQualityRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">FloodForecastAsync</a>(FloodForecastRequest { ... }) -> WithRawResponseTask&lt;FloodForecastResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides flood forecast data for a given location, including river discharge metrics such as mean, median, maximum, minimum, and percentile values (p25, p75). Requires a startDate and endDate, with the date range limited to 16 days. Location can be specified using city name, latitude/longitude, or IP address.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.FloodForecastAsync(
    new FloodForecastRequest
    {
        ApiKey = "apiKey",
        StartDate = new DateOnly(2023, 1, 15),
        EndDate = new DateOnly(2023, 1, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `FloodForecastRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetCountriesAsync</a>(GetCountriesRequest { ... }) -> WithRawResponseTask&lt;GetCountriesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve countries, optionally filtered by region or subregion.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetCountriesAsync(new GetCountriesRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCountriesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetCountryDetailsAsync</a>(GetCountryDetailsRequest { ... }) -> WithRawResponseTask&lt;GetCountryDetailsResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetCountryDetailsAsync(
    new GetCountryDetailsRequest { ApiKey = "apiKey", Country = "country" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCountryDetailsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetRegionsAsync</a>(GetRegionsRequest { ... }) -> WithRawResponseTask&lt;GetRegionsResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetRegionsAsync(new GetRegionsRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetRegionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetSubregionsAsync</a>(GetSubregionsRequest { ... }) -> WithRawResponseTask&lt;GetSubregionsResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetSubregionsAsync(new GetSubregionsRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetSubregionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetAdminLevelsAsync</a>(GetAdminLevelsRequest { ... }) -> WithRawResponseTask&lt;GetAdminLevelsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve administrative units based on ISO 3166-1 alpha-2 country code.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetAdminLevelsAsync(
    new GetAdminLevelsRequest { ApiKey = "apiKey", Country = "country" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetAdminLevelsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetAdminUnitsAsync</a>(GetAdminUnitsRequest { ... }) -> WithRawResponseTask&lt;GetAdminUnitsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve administrative divisions for a given country using ISO 3166-1 alpha-2 country codes. You can optionally filter by administrative levels.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetAdminUnitsAsync(
    new GetAdminUnitsRequest { ApiKey = "apiKey", Country = "country" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetAdminUnitsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetAdminUnitDetailsAsync</a>(GetAdminUnitDetailsRequest { ... }) -> WithRawResponseTask&lt;GetAdminUnitDetailsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed administrative unit information by country and optionally filtered by admin code.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetAdminUnitDetailsAsync(
    new GetAdminUnitDetailsRequest
    {
        ApiKey = "apiKey",
        Country = "country",
        AdminUnit = "admin_unit",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetAdminUnitDetailsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetCitiesAsync</a>(GetCitiesRequest { ... }) -> WithRawResponseTask&lt;GetCitiesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of cities within a country, optionally filtered by an administrative unit code.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetCitiesAsync(new GetCitiesRequest { ApiKey = "apiKey", Country = "country" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCitiesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetSupportedFlagsAsync</a>(GetSupportedFlagsRequest { ... }) -> WithRawResponseTask&lt;GetSupportedFlagsResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get list of all supported flags with their metadata
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetSupportedFlagsAsync(new GetSupportedFlagsRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetSupportedFlagsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetFlagsAsync</a>(GetFlagsRequest { ... }) -> WithRawResponseTask&lt;Stream&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the flag for a specific country
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetFlagsAsync(
    new GetFlagsRequest
    {
        ApiKey = "apiKey",
        Name = "name",
        Shape = GetFlagsRequestShape.Flat,
        Type = GetFlagsRequestType.Country,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetFlagsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">TimezoneLookupAsync</a>(TimezoneLookupRequest { ... }) -> WithRawResponseTask&lt;TimezoneLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve current time, date, and timezone-related information by specifying a timezone name, location address, location coordinates, IP address, or use the client IP address if no parameter is passed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TimezoneLookupAsync(new TimezoneLookupRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TimezoneLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">TimezoneConvertAsync</a>(TimezoneConvertRequest { ... }) -> WithRawResponseTask&lt;TimezoneConvertResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Converts a given time from one timezone to another using various input types like timezone name, coordinates, location, or codes.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TimezoneConvertAsync(new TimezoneConvertRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TimezoneConvertRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">UserAgentLookupAsync</a>(UserAgentLookupRequest { ... }) -> WithRawResponseTask&lt;UserAgentLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Parse User Agent string to get detailed browser, device, and operating system information
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserAgentLookupAsync(new UserAgentLookupRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UserAgentLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">BulkUserAgentLookupAsync</a>(BulkUserAgentLookupRequest { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;BulkUserAgentLookupResponseItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Parse up to `20000 User-Agent strings` at once in a single request; exceeding that returns a 413, not a 400.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BulkUserAgentLookupAsync(
    new BulkUserAgentLookupRequest
    {
        ApiKey = "apiKey",
        UaStrings = new List<string>() { "uaStrings" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkUserAgentLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GrammarDetectAsync</a>(GrammarDetectRequest { ... }) -> WithRawResponseTask&lt;GrammarDetectResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Analyze text for grammar errors and return the exact words flagged as grammatically incorrect with zero-based word positions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GrammarDetectAsync(
    new GrammarDetectRequest
    {
        ApiKey = "apiKey",
        Text =
            "The global mental is health crisis is now a serious and compelex problem. It need quick and ongoing action from policymakers, healthcare workers, and the whole society.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GrammarDetectRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GrammarCorrectAsync</a>(GrammarCorrectRequest { ... }) -> WithRawResponseTask&lt;GrammarCorrectResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Submit text with grammatical issues and receive a clean grammar-corrected result for proofreading and content workflows.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GrammarCorrectAsync(
    new GrammarCorrectRequest
    {
        ApiKey = "apiKey",
        Text =
            "The global mental is health crisis is now a serious and compelex problem. It need quick and ongoing action from policymakers, healthcare workers, and the whole society.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GrammarCorrectRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">WeakWordsDetectAsync</a>(WeakWordsDetectRequest { ... }) -> WithRawResponseTask&lt;WeakWordsDetectResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Analyze text and return weak, vague, or filler words with zero-based word positions to help writers produce clearer and more concise content.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.WeakWordsDetectAsync(
    new WeakWordsDetectRequest
    {
        ApiKey = "apiKey",
        Text = "Many people cannot get the support they need to handle their conditions well.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `WeakWordsDetectRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">ReadabilityScoreAsync</a>(ReadabilityScoreRequest { ... }) -> WithRawResponseTask&lt;ReadabilityScoreResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Analyze text readability using industry-standard formulas including Flesch Reading Ease, Flesch-Kincaid Grade Level, Gunning Fog Index, SMOG Index, Coleman-Liau Index, and Automated Readability Index.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ReadabilityScoreAsync(
    new ReadabilityScoreRequest
    {
        ApiKey = "apiKey",
        Text =
            "The global mental is health crisis is now a serious and compelex problem. It needs quick and ongoing action from policymakers, healthcare workers, and the whole society.",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ReadabilityScoreRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">AstronomyLookupAsync</a>(AstronomyLookupRequest { ... }) -> WithRawResponseTask&lt;AstronomyLookupResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve sunrise and sunset times, current position of the moon, and other related information by specifying a location address, location coordinates, IP address, or using the client IP address if no parameter is passed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AstronomyLookupAsync(new AstronomyLookupRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AstronomyLookupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.<a href="/src/ApifreaksApi/ApifreaksApiClient.cs">GetCreditsUsageAsync</a>(GetCreditsUsageRequest { ... }) -> WithRawResponseTask&lt;GetCreditsUsageResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns subscription, subscription-surcharge, and one-off credit balances for the authenticated organization's account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.GetCreditsUsageAsync(new GetCreditsUsageRequest { ApiKey = "apiKey" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCreditsUsageRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

