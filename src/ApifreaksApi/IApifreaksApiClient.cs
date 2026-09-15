using OneOf;

namespace ApifreaksApi;

public partial interface IApifreaksApiClient
{
    /// <summary>
    /// Get detailed geolocation data for an IP address including country, city, timezone, currency, and optional security and user-agent information
    /// </summary>
    WithRawResponseTask<GeolocationLookupResponse> GeolocationLookupAsync(
        GeolocationLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed geolocation data for multiple IP addresses in a single request.
    /// Supports up to `50,000` IP-addresses/host-names per request.
    /// </summary>
    WithRawResponseTask<IEnumerable<BulkGeolocationLookupResponseItem>> BulkGeolocationLookupAsync(
        BulkGeolocationLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get comprehensive security information for a given IP address. Detects VPNs, proxies, Tor nodes, and other security threats.
    /// </summary>
    WithRawResponseTask<IpSecurityLookupResponse> IpSecurityLookupAsync(
        IpSecurityLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Bulk IP Security Lookup API allows you to retrieve security details for up to `50,000` IP-addresses in a single request.
    /// </summary>
    WithRawResponseTask<IEnumerable<BulkIpSecurityLookupResponseItem>> BulkIpSecurityLookupAsync(
        BulkIpSecurityLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Convert a given address or place name into geographic coordinates (latitude and longitude).
    /// </summary>
    WithRawResponseTask<IEnumerable<GeocoderSearchResponseItem>> GeocoderSearchAsync(
        GeocoderSearchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Convert geographic coordinates (latitude and longitude) into a human-readable address or place name.
    /// </summary>
    WithRawResponseTask<GeocoderReverseResponse> GeocoderReverseAsync(
        GeocoderReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve current WHOIS information for a domain name.
    /// This endpoint provides detailed registration information including registrar details,
    /// dates, nameservers, and registrant information.
    /// </summary>
    WithRawResponseTask<DomainWhoisLookupResponse> DomainWhoisLookupAsync(
        DomainWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve WHOIS information for `100 Domains per Request`.
    /// </summary>
    WithRawResponseTask<BulkDomainWhoisLookupResponse> BulkDomainWhoisLookupAsync(
        BulkDomainWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns WHOIS registration details for a specified IP address (IPv4 or IPv6).
    /// </summary>
    WithRawResponseTask<IpWhoisLookupResponse> IpWhoisLookupAsync(
        IpWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns WHOIS registration details for a specified ASN, with or without the 'as' prefix.
    /// </summary>
    WithRawResponseTask<AsnWhoisLookupResponse> AsnWhoisLookupAsync(
        AsnWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve historical WHOIS records for a domain name.
    /// This endpoint provides a timeline of all recorded changes in domain registration information.
    /// </summary>
    WithRawResponseTask<DomainWhoisHistoryResponse> DomainWhoisHistoryAsync(
        DomainWhoisHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Performs a reverse WHOIS search using one or more search parameters like keyword, email, owner, or company.
    /// </summary>
    WithRawResponseTask<DomainWhoisReverseResponse> DomainWhoisReverseAsync(
        DomainWhoisReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve real-time DNS records for any hostname. Supports multiple record types including A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records.
    /// </summary>
    WithRawResponseTask<DomainDnsLookupResponse> DomainDnsLookupAsync(
        DomainDnsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform DNS lookups for multiple hostnames in a single request. Supports up to `100 host-names per request`
    /// and returns DNS records including A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records.
    /// </summary>
    WithRawResponseTask<BulkDomainDnsLookupResponse> BulkDomainDnsLookupAsync(
        BulkDomainDnsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve historical DNS records for any hostname. Access unique historical data for A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records,
    /// including subdomains. Results are paginated with up to 100 unique records per page.
    /// </summary>
    WithRawResponseTask<DomainDnsHistoryResponse> DomainDnsHistoryAsync(
        DomainDnsHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve all the hostnames associated with any particular A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME DNS records. For instance, you can access all the hostnames hosted on any IP/CIDR notation, all the domain names using Cloudflare name servers, and all the domain names using Google Mailbox
    /// </summary>
    WithRawResponseTask<DomainDnsReverseResponse> DomainDnsReverseAsync(
        DomainDnsReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Execute a series of web scraping instructions on a target URL.
    /// Supports various operations like form filling, clicking, data extraction, and CAPTCHA solving.
    /// </summary>
    WithRawResponseTask<WebScrapeResponse> WebScrapeAsync(
        WebScrapeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validates a single email address and returns result.
    /// </summary>
    WithRawResponseTask<EmailValidateResponse> EmailValidateAsync(
        EmailValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validates a bulk of email addresses and returns result for each. Maximum `10` email addresses per request.
    /// </summary>
    WithRawResponseTask<BulkEmailValidateResponse> BulkEmailValidateAsync(
        BulkEmailValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validates a single phone number and returns detailed metadata including carrier, line type, geolocation, time zones, and standardized formats.
    /// </summary>
    WithRawResponseTask<PhoneValidateResponse> PhoneValidateAsync(
        PhoneValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validates up to 100 phone numbers in a single request. Each number is processed independently — invalid entries return per-number errors without affecting the rest of the batch.
    /// </summary>
    WithRawResponseTask<IEnumerable<BulkPhoneValidateResponseItem>> BulkPhoneValidateAsync(
        BulkPhoneValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve comprehensive SSL certificate information without the certificate chain.
    /// This endpoint provides detailed information about the SSL certificate including expiry dates, issuer details, and encryption methods.
    /// </summary>
    WithRawResponseTask<DomainSslLookupResponse> DomainSslLookupAsync(
        DomainSslLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the complete SSL certificate chain from root Certificate Authority (CA) to end-user certificate.
    /// This endpoint provides comprehensive information about each certificate in the chain.
    /// </summary>
    WithRawResponseTask<DomainSslChainLookupResponse> DomainSslChainLookupAsync(
        DomainSslChainLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Domain Search API is designed to simplify the process of finding available domain names across all top-level domains (TLDs) and second-level domains (SLDs).
    /// </summary>
    WithRawResponseTask<DomainAvailabilityCheckResponse> DomainAvailabilityCheckAsync(
        DomainAvailabilityCheckRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform Bulk Domain Availability checks using a list of domains. Supports upto `100 Domains Per Request`.
    /// </summary>
    WithRawResponseTask<BulkDomainAvailabilityCheckResponse> BulkDomainAvailabilityCheckAsync(
        BulkDomainAvailabilityCheckRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Domain Search API is designed to simplify the process of finding available domain names across all top-level domains (TLDs) and second-level domains (SLDs).
    /// </summary>
    WithRawResponseTask<DomainAvailabilitySuggestionsResponse> DomainAvailabilitySuggestionsAsync(
        DomainAvailabilitySuggestionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Subdomain Lookup API is designed to retrieve subdomains related to the given domain name. It helps you explore subdomains that are available for registration or usage.
    /// </summary>
    WithRawResponseTask<SubdomainsLookupResponse> SubdomainsLookupAsync(
        SubdomainsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Domain Typosquatting API searches for registered domains that are typo or look-alike variants of a brand keyword, or that match a wildcard pattern. Results include registration lifecycle data and drop status across 1529+ TLDs, paginated at 100 domains per page.
    /// </summary>
    WithRawResponseTask<DomainTyposquattingResponse> DomainTyposquattingAsync(
        DomainTyposquattingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The Domain Reputation API evaluates a domain against threat intelligence sources, DGA (domain generation algorithm) scoring, trust signals, and email deliverability configuration, returning a consolidated risk assessment with a verdict, severity, and supporting evidence.
    /// </summary>
    WithRawResponseTask<DomainReputationResponse> DomainReputationAsync(
        DomainReputationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve sunrise and sunset times, current position of the moon, and other related information by specifying a location address, location coordinates, IP address, or using the client IP address if no parameter is passed.
    /// </summary>
    WithRawResponseTask<AstronomyLookupV2Response> AstronomyLookupV2Async(
        AstronomyLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get current time, date, and timezone details by specifying a timezone name, location address, GPS coordinates, IP address, IATA/ICAO airport code, UN/LOCODE, or use the client IP if no parameter is provided.
    /// </summary>
    WithRawResponseTask<TimezoneLookupV2Response> TimezoneLookupV2Async(
        TimezoneLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get detailed IP geolocation data for an IP address including country, city, timezone, currency, and optional threat intelligence and user-agent information.
    /// </summary>
    WithRawResponseTask<GeolocationLookupV2Response> GeolocationLookupV2Async(
        GeolocationLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get detailed IP geolocation data for multiple IP addresses including country, city, timezone, currency, and optional threat intelligence information. Supports up to 50,000 IP addresses per request.
    /// </summary>
    WithRawResponseTask<
        IEnumerable<
            OneOf<
                BulkGeolocationLookupV2ResponseItemAbuse,
                BulkGeolocationLookupV2ResponseItemMessage
            >
        >
    > BulkGeolocationLookupV2Async(
        BulkGeolocationLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the current WHOIS record for the specified domain, including registrar details, registrant/administrative/technical/billing/reseller contacts, name servers, status codes, and raw WHOIS text.
    /// </summary>
    WithRawResponseTask<DomainWhoisLookupV2Response> DomainWhoisLookupV2Async(
        DomainWhoisLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the current WHOIS record for each requested domain, in request order. Supports up to 100 domain names per request; a domain that fails to resolve yields an error item instead of failing the whole batch.
    /// </summary>
    WithRawResponseTask<BulkDomainWhoisLookupV2Response> BulkDomainWhoisLookupV2Async(
        BulkDomainWhoisLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the current live price for the requested commodity symbols. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
    /// </summary>
    WithRawResponseTask<CommodityLatestRatesV2Response> CommodityLatestRatesV2Async(
        CommodityLatestRatesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns OHLC price data for the requested commodity symbols on a specific date. Falls back to the nearest earlier rate if none exists for the exact date. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
    /// </summary>
    WithRawResponseTask<CommodityHistoricalRatesV2Response> CommodityHistoricalRatesV2Async(
        CommodityHistoricalRatesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns price fluctuation metrics (start, end, change, percent change) for the requested commodity symbols over a date range. For monthly-updated commodities the range snaps to month boundaries. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
    /// </summary>
    WithRawResponseTask<CommodityFluctuationV2Response> CommodityFluctuationV2Async(
        CommodityFluctuationV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns day-by-day OHLC data for the requested commodity symbols within a date range, indexed by date. Non-trading days are excluded. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
    /// </summary>
    WithRawResponseTask<CommodityTimeSeriesV2Response> CommodityTimeSeriesV2Async(
        CommodityTimeSeriesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the list of supported commodity symbols with metadata. Deprecated symbols stay listed with status "inactive" and a deprecationDate.
    /// </summary>
    WithRawResponseTask<CommoditySymbolsV2Response> CommoditySymbolsV2Async(
        CommoditySymbolsV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API merges multiple PDF files into a single PDF, in the order they are provided
    /// </summary>
    WithRawResponseTask<PdfMergeResponse> PdfMergeAsync(
        PdfMergeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API removes a selection or range of pages from a PDF file.
    /// </summary>
    WithRawResponseTask<PdfRemovePagesResponse> PdfRemovePagesAsync(
        PdfRemovePagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API splits a PDF into multiple parts based on specified page numbers or ranges.
    /// </summary>
    WithRawResponseTask<PdfSplitResponse> PdfSplitAsync(
        PdfSplitRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API rotates pages of a PDF by a specified angle (in multiples of 90 degrees).
    /// </summary>
    WithRawResponseTask<PdfRotateResponse> PdfRotateAsync(
        PdfRotateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API compresses a given PDF file to reduce its file size.
    /// </summary>
    WithRawResponseTask<PdfCompressResponse> PdfCompressAsync(
        PdfCompressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API extracts specific pages or page ranges from a PDF file and returns them as a new PDF.
    /// </summary>
    WithRawResponseTask<PdfExtractPagesResponse> PdfExtractPagesAsync(
        PdfExtractPagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// API endpoint that linearizes any given PDF, restructuring it for faster loading and page-by-page viewing in web browsers.
    /// </summary>
    WithRawResponseTask<PdfLinearizeResponse> PdfLinearizeAsync(
        PdfLinearizeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API encrypts a PDF file by setting a password required to open it.
    /// </summary>
    WithRawResponseTask<PdfEncryptResponse> PdfEncryptAsync(
        PdfEncryptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API decrypts PDF files, removing all encryption, including open passwords and permission restrictions.
    /// </summary>
    WithRawResponseTask<PdfDecryptResponse> PdfDecryptAsync(
        PdfDecryptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API applies permission restrictions on a PDF file, such as disabling printing, copying, or editing. This can include password protection to enforce restrictions.
    /// </summary>
    WithRawResponseTask<PdfRestrictResponse> PdfRestrictAsync(
        PdfRestrictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API removes permission restrictions from a PDF while keeping it encrypted. If you want to remove all security (including encryption), use the `/pdf/decrypt` endpoint instead.
    /// </summary>
    WithRawResponseTask<PdfUnrestrictResponse> PdfUnrestrictAsync(
        PdfUnrestrictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API converts a given PDF file into a sequence of PNG images.
    /// </summary>
    WithRawResponseTask<PdfConvertToPngResponse> PdfConvertToPngAsync(
        PdfConvertToPngRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API converts a given PDF file into a sequence of JPG images.
    /// </summary>
    WithRawResponseTask<PdfConvertToJpgResponse> PdfConvertToJpgAsync(
        PdfConvertToJpgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API converts a given PDF file into a sequence of TIFF images. The output images can be saved as a single TIFF file, or as a sequence of TIFF files.
    /// </summary>
    WithRawResponseTask<PdfConvertToTiffResponse> PdfConvertToTiffAsync(
        PdfConvertToTiffRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Converts a PDF file to a BMP image.
    /// </summary>
    WithRawResponseTask<PdfConvertToBmpResponse> PdfConvertToBmpAsync(
        PdfConvertToBmpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API converts a given PDF file into a sequence of GIF images.
    /// </summary>
    WithRawResponseTask<PdfConvertToGifResponse> PdfConvertToGifAsync(
        PdfConvertToGifRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API uploads multiple PDF files to the API Freaks server and generates their unique file IDs.
    /// </summary>
    WithRawResponseTask<PdfUploadResourcesResponse> PdfUploadResourcesAsync(
        PdfUploadResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API uploads PDF files to the API Freaks server in binary format.
    /// </summary>
    WithRawResponseTask<PdfUploadBinaryResponse> PdfUploadBinaryAsync(
        PdfUploadBinaryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API downloads PDF files or ZIP archives from the server using their unique resource ID.
    /// </summary>
    WithRawResponseTask<global::System.IO.Stream> PdfDownloadResourceAsync(
        PdfDownloadResourceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API checks the status of a previously initiated PDF processing task using its unique task ID.
    /// </summary>
    WithRawResponseTask<PdfGetTaskStatusResponse> PdfGetTaskStatusAsync(
        PdfGetTaskStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API checks the status of a PDF file using its unique file ID, providing information about its creation and potential deletion time.
    /// </summary>
    WithRawResponseTask<PdfGetFileStatusResponse> PdfGetFileStatusAsync(
        PdfGetFileStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API retrieves a list of all PDF files uploaded and generated by a specific user. Please note that if the user is part of an organization, only the Organization Administrator can access this endpoint. Organization Members cannot access this endpoint.
    /// </summary>
    WithRawResponseTask<PdfListFilesResponse> PdfListFilesAsync(
        PdfListFilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API deletes a PDF file using its unique file ID.
    /// </summary>
    WithRawResponseTask<PdfDeleteFileResponse> PdfDeleteFileAsync(
        PdfDeleteFileRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Capture full-page screenshots and videos of websites with advanced options like device simulation, custom code injection, cookie banner blocking, and scrollable content recording.
    /// Supports multiple output formats including JSON, image, GIF, MP4, and WebM.
    /// </summary>
    WithRawResponseTask<global::System.IO.Stream> ScreenshotCaptureAsync(
        ScreenshotCaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Our Bulk Screenshot API allows you to capture screenshots of multiple webpages simultaneously, saving you time and effort. Instead of manually capturing each page one by one, you can batch process URLs and receive high-quality screenshots in the format you choose.
    ///  Maximum `50 URLs` per request.
    /// </summary>
    WithRawResponseTask<BulkScreenshotCaptureResponse> BulkScreenshotCaptureAsync(
        BulkScreenshotCaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get live forex rates for all world currencies with customizable update frequency
    /// </summary>
    WithRawResponseTask<CurrencyLatestRatesResponse> CurrencyLatestRatesAsync(
        CurrencyLatestRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get historical exchange rates for any specific date
    /// </summary>
    WithRawResponseTask<CurrencyHistoricalRatesResponse> CurrencyHistoricalRatesAsync(
        CurrencyHistoricalRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Convert amount between currencies using the latest exchange rates
    /// </summary>
    WithRawResponseTask<CurrencyConvertLatestResponse> CurrencyConvertLatestAsync(
        CurrencyConvertLatestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Convert amount between currencies using historical rates
    /// </summary>
    WithRawResponseTask<CurrencyConvertHistoricalResponse> CurrencyConvertHistoricalAsync(
        CurrencyConvertHistoricalRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get exchange rates for a time range
    /// </summary>
    WithRawResponseTask<CurrencyTimeSeriesResponse> CurrencyTimeSeriesAsync(
        CurrencyTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get currency fluctuation data for a time period
    /// </summary>
    WithRawResponseTask<CurrencyFluctuationResponse> CurrencyFluctuationAsync(
        CurrencyFluctuationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Convert amount using user's location
    /// </summary>
    WithRawResponseTask<CurrencyConvertByIpResponse> CurrencyConvertByIpAsync(
        CurrencyConvertByIpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get list of all supported currencies with their metadata
    /// </summary>
    WithRawResponseTask<CurrencySupportedResponse> CurrencySupportedAsync(
        CurrencySupportedRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get currency symbols and codes
    /// </summary>
    WithRawResponseTask<CurrencySymbolsResponse> CurrencySymbolsAsync(
        CurrencySymbolsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get information about historical data availability and limits
    /// </summary>
    WithRawResponseTask<CurrencyHistoricalLimitsResponse> CurrencyHistoricalLimitsAsync(
        CurrencyHistoricalLimitsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get live commodity rates with customizable update frequency
    /// </summary>
    WithRawResponseTask<CommodityLatestRatesResponse> CommodityLatestRatesAsync(
        CommodityLatestRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get historical commodity rates for a specific date
    /// </summary>
    WithRawResponseTask<CommodityHistoricalRatesResponse> CommodityHistoricalRatesAsync(
        CommodityHistoricalRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get commodity price fluctuation data for a time period
    /// </summary>
    WithRawResponseTask<CommodityFluctuationResponse> CommodityFluctuationAsync(
        CommodityFluctuationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get commodity rates for a time range
    /// </summary>
    WithRawResponseTask<CommodityTimeSeriesResponse> CommodityTimeSeriesAsync(
        CommodityTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get list of supported commodities
    /// </summary>
    WithRawResponseTask<CommoditySymbolsResponse> CommoditySymbolsAsync(
        CommoditySymbolsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of supported countries.
    /// </summary>
    WithRawResponseTask<VatSupportedCountriesResponse> VatSupportedCountriesAsync(
        VatSupportedCountriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches VAT rate based on the specified or originating IP address.
    /// </summary>
    WithRawResponseTask<IEnumerable<VatRateByIpResponseItem>> VatRateByIpAsync(
        VatRateByIpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches VAT rates for a single country or state provided via query parameters.
    /// </summary>
    WithRawResponseTask<IEnumerable<VatRateByCountryResponseItem>> VatRateByCountryAsync(
        VatRateByCountryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves VAT details for multiple countries or country-state combinations in a single request. Maximum of `100` entries per request are allowed.
    /// </summary>
    WithRawResponseTask<BulkVatRateByCountryResponse> BulkVatRateByCountryAsync(
        BulkVatRateByCountryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validates an EU or UK VAT number and returns registration status details.
    /// </summary>
    WithRawResponseTask<VatValidateResponse> VatValidateAsync(
        VatValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Checks an IBAN for structural validity, checksum accuracy, and bank metadata.
    /// </summary>
    WithRawResponseTask<IbanValidateResponse> IbanValidateAsync(
        IbanValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches SWIFT codes for a given country, bank, and city.
    /// </summary>
    WithRawResponseTask<IEnumerable<string>> SwiftCodeFindAsync(
        SwiftCodeFindRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches detailed information about a SWIFT code.
    /// </summary>
    WithRawResponseTask<SwiftCodeLookupResponse> SwiftCodeLookupAsync(
        SwiftCodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ZipcodeLookupResponse> ZipcodeLookupAsync(
        ZipcodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validates a bulk of ZIP/postal codes and returns result for each. Maximum `100` ZIP/postal codes per request.
    /// </summary>
    WithRawResponseTask<BulkZipcodeLookupResponse> BulkZipcodeLookupAsync(
        BulkZipcodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ZipcodeSearchByCityResponse> ZipcodeSearchByCityAsync(
        ZipcodeSearchByCityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ZipcodeSearchByRegionResponse> ZipcodeSearchByRegionAsync(
        ZipcodeSearchByRegionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ZipcodeSearchByRadiusResponse> ZipcodeSearchByRadiusAsync(
        ZipcodeSearchByRadiusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get distance between postal codes. Maximum `100` postal codes per request.
    /// </summary>
    WithRawResponseTask<ZipcodeDistanceResponse> ZipcodeDistanceAsync(
        ZipcodeDistanceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get matching ZIP/postal code pairs within a specified distance. Maximum `100` postal codes per request.
    /// </summary>
    WithRawResponseTask<ZipcodeDistanceMatchResponse> ZipcodeDistanceMatchAsync(
        ZipcodeDistanceMatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get current weather data including temperature, humidity, precipitation, wind conditions, atmospheric pressure, and air quality for any location. Accepts city names, coordinates, or IP addresses. Also includes astronomy data and timezone-aware timestamps.
    /// </summary>
    WithRawResponseTask<CurrentWeatherResponse> CurrentWeatherAsync(
        CurrentWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve current weather conditions for up to `50 locations` in a single request. A maximum of 50 locations (city names, IP addresses, or geographic coordinates) can be included in the request body.
    /// </summary>
    WithRawResponseTask<BulkCurrentWeatherResponse> BulkCurrentWeatherAsync(
        BulkCurrentWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Access comprehensive weather forecasts with customizable precision - choose from daily overviews, hourly breakdowns, or even minute-by-minute data. Configure your date ranges or use the default 7-day forecast for standard weather planning.
    /// </summary>
    WithRawResponseTask<WeatherForecastResponse> WeatherForecastAsync(
        WeatherForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Access past weather conditions for specific dates with records going back to 1940. Retrieve comprehensive historical data with both daily and hourly precision options.
    /// </summary>
    WithRawResponseTask<HistoricalWeatherResponse> HistoricalWeatherAsync(
        HistoricalWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Pull historical weather information for date ranges up to 90 days (daily data) or 7 days (hourly data). Get consistent formatting across your specified date range with reliable historical weather patterns.
    /// </summary>
    WithRawResponseTask<WeatherTimeSeriesResponse> WeatherTimeSeriesAsync(
        WeatherTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Provides hourly forecasts of marine conditions including wave heights, wave directions, wave periods, swell info, sea surface temperatures, and ocean currents. Supports multiple geographical points and returns daily max wave statistics for up to 7 days. Ideal for maritime planning, navigation, and coastal activities.
    /// </summary>
    WithRawResponseTask<MarineWeatherResponse> MarineWeatherAsync(
        MarineWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Monitor and predict air quality conditions using European and US AQI standards. Track pollutant concentrations including PM10, PM2.5, carbon monoxide, nitrogen dioxide, sulfur dioxide, ozone, and dust particles. Get current readings plus hourly forecasts up to 5 days ahead, complete with UV index and aerosol measurements for comprehensive air quality assessment.
    /// </summary>
    WithRawResponseTask<AirQualityResponse> AirQualityAsync(
        AirQualityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Provides flood forecast data for a given location, including river discharge metrics such as mean, median, maximum, minimum, and percentile values (p25, p75). Requires a startDate and endDate, with the date range limited to 16 days. Location can be specified using city name, latitude/longitude, or IP address.
    /// </summary>
    WithRawResponseTask<FloodForecastResponse> FloodForecastAsync(
        FloodForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve countries, optionally filtered by region or subregion.
    /// </summary>
    WithRawResponseTask<GetCountriesResponse> GetCountriesAsync(
        GetCountriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetCountryDetailsResponse> GetCountryDetailsAsync(
        GetCountryDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetRegionsResponse> GetRegionsAsync(
        GetRegionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetSubregionsResponse> GetSubregionsAsync(
        GetSubregionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve administrative units based on ISO 3166-1 alpha-2 country code.
    /// </summary>
    WithRawResponseTask<GetAdminLevelsResponse> GetAdminLevelsAsync(
        GetAdminLevelsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve administrative divisions for a given country using ISO 3166-1 alpha-2 country codes. You can optionally filter by administrative levels.
    /// </summary>
    WithRawResponseTask<GetAdminUnitsResponse> GetAdminUnitsAsync(
        GetAdminUnitsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed administrative unit information by country and optionally filtered by admin code.
    /// </summary>
    WithRawResponseTask<GetAdminUnitDetailsResponse> GetAdminUnitDetailsAsync(
        GetAdminUnitDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of cities within a country, optionally filtered by an administrative unit code.
    /// </summary>
    WithRawResponseTask<GetCitiesResponse> GetCitiesAsync(
        GetCitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get list of all supported flags with their metadata
    /// </summary>
    WithRawResponseTask<IEnumerable<GetSupportedFlagsResponseItem>> GetSupportedFlagsAsync(
        GetSupportedFlagsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the flag for a specific country
    /// </summary>
    WithRawResponseTask<global::System.IO.Stream> GetFlagsAsync(
        GetFlagsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve current time, date, and timezone-related information by specifying a timezone name, location address, location coordinates, IP address, or use the client IP address if no parameter is passed.
    /// </summary>
    WithRawResponseTask<TimezoneLookupResponse> TimezoneLookupAsync(
        TimezoneLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Converts a given time from one timezone to another using various input types like timezone name, coordinates, location, or codes.
    /// </summary>
    WithRawResponseTask<TimezoneConvertResponse> TimezoneConvertAsync(
        TimezoneConvertRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Parse User Agent string to get detailed browser, device, and operating system information
    /// </summary>
    WithRawResponseTask<UserAgentLookupResponse> UserAgentLookupAsync(
        UserAgentLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Parse up to `50,000 User-Agent strings` at once in a single request.
    /// </summary>
    WithRawResponseTask<IEnumerable<BulkUserAgentLookupResponseItem>> BulkUserAgentLookupAsync(
        BulkUserAgentLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform Optical Character Recognition (OCR) on images, PDFs, or ZIP archives. Supports two models: `mini-ocr-v1` for CAPTCHA-optimized OCR and `ocr-v1` for general-purpose document text extraction. Supports zonal OCR to extract text from specific regions of an image.
    ///
    /// **Notes:**
    /// - The `zone` query parameter cannot be given with .pdf and .zip types as it can only be applied to single image query.
    /// - The `page_range` query parameter cannot be given in any other type except .pdf types.
    /// - PDFs containing images in them are allowed only for processing.
    /// - The `mini-ocr-v1` model doesn’t support the following query parameters:
    ///     - `page_range` (.pdf types)
    ///     - `zone`
    /// </summary>
    WithRawResponseTask<OcrPredictResponse> OcrPredictAsync(
        OcrPredictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Analyze text for grammar errors and return the exact words flagged as grammatically incorrect with zero-based word positions.
    /// </summary>
    WithRawResponseTask<GrammarDetectResponse> GrammarDetectAsync(
        GrammarDetectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit text with grammatical issues and receive a clean grammar-corrected result for proofreading and content workflows.
    /// </summary>
    WithRawResponseTask<GrammarCorrectResponse> GrammarCorrectAsync(
        GrammarCorrectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Analyze text and return weak, vague, or filler words with zero-based word positions to help writers produce clearer and more concise content.
    /// </summary>
    WithRawResponseTask<WeakWordsDetectResponse> WeakWordsDetectAsync(
        WeakWordsDetectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Analyze text readability using industry-standard formulas including Flesch Reading Ease, Flesch-Kincaid Grade Level, Gunning Fog Index, SMOG Index, Coleman-Liau Index, and Automated Readability Index.
    /// </summary>
    WithRawResponseTask<ReadabilityScoreResponse> ReadabilityScoreAsync(
        ReadabilityScoreRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve sunrise and sunset times, current position of the moon, and other related information by specifying a location address, location coordinates, IP address, or using the client IP address if no parameter is passed.
    /// </summary>
    WithRawResponseTask<AstronomyLookupResponse> AstronomyLookupAsync(
        AstronomyLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
