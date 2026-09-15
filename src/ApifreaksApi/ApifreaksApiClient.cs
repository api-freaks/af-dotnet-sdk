using ApifreaksApi.Core;
using global::System.Text.Json;
using OneOf;

namespace ApifreaksApi;

public partial class ApifreaksApiClient : IApifreaksApiClient
{
    private readonly RawClient _client;

    public ApifreaksApiClient(ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(new Dictionary<string, string>() { });
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
    }

    private async Task<WithRawResponse<GeolocationLookupResponse>> GeolocationLookupAsyncCore(
        GeolocationLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("ip", request.Ip)
            .Add("lang", request.Lang)
            .Add("fields", request.Fields)
            .Add("excludes", request.Excludes)
            .Add("include", request.Include)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geolocation/lookup",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GeolocationLookupResponse>(responseBody)!;
                return new WithRawResponse<GeolocationLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 423:
                        throw new LockedError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<IEnumerable<BulkGeolocationLookupResponseItem>>
    > BulkGeolocationLookupAsyncCore(
        BulkGeolocationLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("lang", request.Lang)
            .Add("fields", request.Fields)
            .Add("excludes", request.Excludes)
            .Add("include", request.Include)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/geolocation/lookup",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<BulkGeolocationLookupResponseItem>
                >(responseBody)!;
                return new WithRawResponse<IEnumerable<BulkGeolocationLookupResponseItem>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<IpSecurityLookupResponse>> IpSecurityLookupAsyncCore(
        IpSecurityLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("ip", request.Ip)
            .Add("fields", request.Fields)
            .Add("excludes", request.Excludes)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/ip/security",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IpSecurityLookupResponse>(responseBody)!;
                return new WithRawResponse<IpSecurityLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 423:
                        throw new LockedError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<IEnumerable<BulkIpSecurityLookupResponseItem>>
    > BulkIpSecurityLookupAsyncCore(
        BulkIpSecurityLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("fields", request.Fields)
            .Add("excludes", request.Excludes)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/ip/security",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<BulkIpSecurityLookupResponseItem>
                >(responseBody)!;
                return new WithRawResponse<IEnumerable<BulkIpSecurityLookupResponseItem>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<IEnumerable<GeocoderSearchResponseItem>>
    > GeocoderSearchAsyncCore(
        GeocoderSearchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 8)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("query", request.Query)
            .Add("limit", request.Limit)
            .Add("min_lat", request.MinLat)
            .Add("max_lat", request.MaxLat)
            .Add("min_lon", request.MinLon)
            .Add("max_lon", request.MaxLon)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("Accept-Language", request.AcceptLanguage)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geocoder/search",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IEnumerable<GeocoderSearchResponseItem>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<GeocoderSearchResponseItem>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GeocoderReverseResponse>> GeocoderReverseAsyncCore(
        GeocoderReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("lat", request.Lat)
            .Add("lon", request.Lon)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("Accept-Language", request.AcceptLanguage)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geocoder/reverse",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GeocoderReverseResponse>(responseBody)!;
                return new WithRawResponse<GeocoderReverseResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainWhoisLookupResponse>> DomainWhoisLookupAsyncCore(
        DomainWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domainName", request.DomainName)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/whois/live",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainWhoisLookupResponse>(responseBody)!;
                return new WithRawResponse<DomainWhoisLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 408:
                        throw new RequestTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<BulkDomainWhoisLookupResponse>
    > BulkDomainWhoisLookupAsyncCore(
        BulkDomainWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/domain/whois/live",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkDomainWhoisLookupResponse>(
                    responseBody
                )!;
                return new WithRawResponse<BulkDomainWhoisLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<IpWhoisLookupResponse>> IpWhoisLookupAsyncCore(
        IpWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("ip", request.Ip)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/ip/whois/live",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IpWhoisLookupResponse>(responseBody)!;
                return new WithRawResponse<IpWhoisLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<AsnWhoisLookupResponse>> AsnWhoisLookupAsyncCore(
        AsnWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("asn", request.Asn)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/asn/whois/live",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<AsnWhoisLookupResponse>(responseBody)!;
                return new WithRawResponse<AsnWhoisLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainWhoisHistoryResponse>> DomainWhoisHistoryAsyncCore(
        DomainWhoisHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domainName", request.DomainName)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/whois/history",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainWhoisHistoryResponse>(responseBody)!;
                return new WithRawResponse<DomainWhoisHistoryResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainWhoisReverseResponse>> DomainWhoisReverseAsyncCore(
        DomainWhoisReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("keyword", request.Keyword)
            .Add("email", request.Email)
            .Add("owner", request.Owner)
            .Add("company", request.Company)
            .Add("exact", request.Exact)
            .Add("mode", request.Mode)
            .Add("page", request.Page)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/whois/reverse",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainWhoisReverseResponse>(responseBody)!;
                return new WithRawResponse<DomainWhoisReverseResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainDnsLookupResponse>> DomainDnsLookupAsyncCore(
        DomainDnsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("host-name", request.HostName)
            .Add("ipAddress", request.IpAddress)
            .Add("type", request.Type)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/dns/live",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainDnsLookupResponse>(responseBody)!;
                return new WithRawResponse<DomainDnsLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 408:
                        throw new RequestTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<BulkDomainDnsLookupResponse>> BulkDomainDnsLookupAsyncCore(
        BulkDomainDnsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("type", request.Type)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/domain/dns/live",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkDomainDnsLookupResponse>(
                    responseBody
                )!;
                return new WithRawResponse<BulkDomainDnsLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 408:
                        throw new RequestTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainDnsHistoryResponse>> DomainDnsHistoryAsyncCore(
        DomainDnsHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("host-name", request.HostName)
            .Add("type", request.Type)
            .Add("page", request.Page)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/dns/history",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainDnsHistoryResponse>(responseBody)!;
                return new WithRawResponse<DomainDnsHistoryResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 408:
                        throw new RequestTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainDnsReverseResponse>> DomainDnsReverseAsyncCore(
        DomainDnsReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("type", request.Type)
            .Add("value", request.Value)
            .Add("exact", request.Exact)
            .Add("page", request.Page)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/dns/reverse",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainDnsReverseResponse>(responseBody)!;
                return new WithRawResponse<DomainDnsReverseResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 408:
                        throw new RequestTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<WebScrapeResponse>> WebScrapeAsyncCore(
        WebScrapeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("url", request.Url)
            .Add("text", request.Text)
            .Add("jsEnabled", request.JsEnabled)
            .AddDeepObject("proxy", request.Proxy)
            .Add("sslIgnore", request.SslIgnore)
            .Add("windowSize", request.WindowSize)
            .Add("adBlock", request.AdBlock)
            .Add("captcha", request.Captcha)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/scraping",
                    Body = request.Body,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<WebScrapeResponse>(responseBody)!;
                return new WithRawResponse<WebScrapeResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 405:
                        throw new MethodNotAllowedError(
                            JsonUtils.Deserialize<MethodNotAllowedErrorBody>(responseBody)
                        );
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 408:
                        throw new RequestTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<EmailValidateResponse>> EmailValidateAsyncCore(
        EmailValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/email-validation/single",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<EmailValidateResponse>(responseBody)!;
                return new WithRawResponse<EmailValidateResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<BulkEmailValidateResponse>> BulkEmailValidateAsyncCore(
        BulkEmailValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/email-validation/bulk",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkEmailValidateResponse>(responseBody)!;
                return new WithRawResponse<BulkEmailValidateResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PhoneValidateResponse>> PhoneValidateAsyncCore(
        PhoneValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/phone/validation",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PhoneValidateResponse>(responseBody)!;
                return new WithRawResponse<PhoneValidateResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<IEnumerable<BulkPhoneValidateResponseItem>>
    > BulkPhoneValidateAsyncCore(
        BulkPhoneValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/phone/validation/bulk",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<BulkPhoneValidateResponseItem>
                >(responseBody)!;
                return new WithRawResponse<IEnumerable<BulkPhoneValidateResponseItem>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainSslLookupResponse>> DomainSslLookupAsyncCore(
        DomainSslLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domainName", request.DomainName)
            .Add("sslRaw", request.SslRaw)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/ssl/live",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainSslLookupResponse>(responseBody)!;
                return new WithRawResponse<DomainSslLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainSslChainLookupResponse>> DomainSslChainLookupAsyncCore(
        DomainSslChainLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domainName", request.DomainName)
            .Add("sslRaw", request.SslRaw)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/ssl/live/chain",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainSslChainLookupResponse>(
                    responseBody
                )!;
                return new WithRawResponse<DomainSslChainLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<DomainAvailabilityCheckResponse>
    > DomainAvailabilityCheckAsyncCore(
        DomainAvailabilityCheckRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domain", request.Domain)
            .Add("source", request.Source)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/availability",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainAvailabilityCheckResponse>(
                    responseBody
                )!;
                return new WithRawResponse<DomainAvailabilityCheckResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 408:
                        throw new RequestTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<BulkDomainAvailabilityCheckResponse>
    > BulkDomainAvailabilityCheckAsyncCore(
        BulkDomainAvailabilityCheckRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("source", request.Source)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/domain/availability",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkDomainAvailabilityCheckResponse>(
                    responseBody
                )!;
                return new WithRawResponse<BulkDomainAvailabilityCheckResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<DomainAvailabilitySuggestionsResponse>
    > DomainAvailabilitySuggestionsAsyncCore(
        DomainAvailabilitySuggestionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domain", request.Domain)
            .Add("source", request.Source)
            .Add("count", request.Count)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/availability/suggestions",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainAvailabilitySuggestionsResponse>(
                    responseBody
                )!;
                return new WithRawResponse<DomainAvailabilitySuggestionsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<SubdomainsLookupResponse>> SubdomainsLookupAsyncCore(
        SubdomainsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domain", request.Domain)
            .Add("after", request.After)
            .Add("before", request.Before)
            .Add("status", request.Status)
            .Add("page", request.Page)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/subdomains/lookup",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubdomainsLookupResponse>(responseBody)!;
                return new WithRawResponse<SubdomainsLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainTyposquattingResponse>> DomainTyposquattingAsyncCore(
        DomainTyposquattingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("keyword", request.Keyword)
            .Add("pattern", request.Pattern)
            .Add("pageToken", request.PageToken)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/typosquatting",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainTyposquattingResponse>(
                    responseBody
                )!;
                return new WithRawResponse<DomainTyposquattingResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainReputationResponse>> DomainReputationAsyncCore(
        DomainReputationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domainName", request.DomainName)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/domain/reputation",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainReputationResponse>(responseBody)!;
                return new WithRawResponse<DomainReputationResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<AstronomyLookupV2Response>> AstronomyLookupV2AsyncCore(
        AstronomyLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("lang", request.Lang)
            .Add("date", request.Date)
            .Add("elevation", request.Elevation)
            .Add("time_zone", request.TimeZone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/geolocation/astronomy",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<AstronomyLookupV2Response>(responseBody)!;
                return new WithRawResponse<AstronomyLookupV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<TimezoneLookupV2Response>> TimezoneLookupV2AsyncCore(
        TimezoneLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("ip", request.Ip)
            .Add("tz", request.Tz)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("lang", request.Lang)
            .Add("iata_code", request.IataCode)
            .Add("icao_code", request.IcaoCode)
            .Add("lo_code", request.LoCode)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/geolocation/timezone",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<TimezoneLookupV2Response>(responseBody)!;
                return new WithRawResponse<TimezoneLookupV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GeolocationLookupV2Response>> GeolocationLookupV2AsyncCore(
        GeolocationLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("ip", request.Ip)
            .Add("lang", request.Lang)
            .Add("fields", request.Fields)
            .Add("excludes", request.Excludes)
            .Add("include", request.Include)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/geolocation/lookup",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GeolocationLookupV2Response>(
                    responseBody
                )!;
                return new WithRawResponse<GeolocationLookupV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 423:
                        throw new LockedError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<
            IEnumerable<
                OneOf<
                    BulkGeolocationLookupV2ResponseItemAbuse,
                    BulkGeolocationLookupV2ResponseItemMessage
                >
            >
        >
    > BulkGeolocationLookupV2AsyncCore(
        BulkGeolocationLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("lang", request.Lang)
            .Add("fields", request.Fields)
            .Add("excludes", request.Excludes)
            .Add("include", request.Include)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v2.0/geolocation/lookup",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<
                        OneOf<
                            BulkGeolocationLookupV2ResponseItemAbuse,
                            BulkGeolocationLookupV2ResponseItemMessage
                        >
                    >
                >(responseBody)!;
                return new WithRawResponse<
                    IEnumerable<
                        OneOf<
                            BulkGeolocationLookupV2ResponseItemAbuse,
                            BulkGeolocationLookupV2ResponseItemMessage
                        >
                    >
                >()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<DomainWhoisLookupV2Response>> DomainWhoisLookupV2AsyncCore(
        DomainWhoisLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("domainName", request.DomainName)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/domain/whois/live",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<DomainWhoisLookupV2Response>(
                    responseBody
                )!;
                return new WithRawResponse<DomainWhoisLookupV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<BulkDomainWhoisLookupV2Response>
    > BulkDomainWhoisLookupV2AsyncCore(
        BulkDomainWhoisLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v2.0/domain/whois/live",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkDomainWhoisLookupV2Response>(
                    responseBody
                )!;
                return new WithRawResponse<BulkDomainWhoisLookupV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CommodityLatestRatesV2Response>
    > CommodityLatestRatesV2AsyncCore(
        CommodityLatestRatesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("symbols", request.Symbols)
            .Add("quote", request.Quote)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/commodity/rates/latest",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommodityLatestRatesV2Response>(
                    responseBody
                )!;
                return new WithRawResponse<CommodityLatestRatesV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CommodityHistoricalRatesV2Response>
    > CommodityHistoricalRatesV2AsyncCore(
        CommodityHistoricalRatesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("symbols", request.Symbols)
            .Add("date", request.Date)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/commodity/rates/historical",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommodityHistoricalRatesV2Response>(
                    responseBody
                )!;
                return new WithRawResponse<CommodityHistoricalRatesV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CommodityFluctuationV2Response>
    > CommodityFluctuationV2AsyncCore(
        CommodityFluctuationV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("symbols", request.Symbols)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/commodity/fluctuation",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommodityFluctuationV2Response>(
                    responseBody
                )!;
                return new WithRawResponse<CommodityFluctuationV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CommodityTimeSeriesV2Response>
    > CommodityTimeSeriesV2AsyncCore(
        CommodityTimeSeriesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("symbols", request.Symbols)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/commodity/time-series",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommodityTimeSeriesV2Response>(
                    responseBody
                )!;
                return new WithRawResponse<CommodityTimeSeriesV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CommoditySymbolsV2Response>> CommoditySymbolsV2AsyncCore(
        CommoditySymbolsV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v2.0/commodity/symbols",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommoditySymbolsV2Response>(responseBody)!;
                return new WithRawResponse<CommoditySymbolsV2Response>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfMergeResponse>> PdfMergeAsyncCore(
        PdfMergeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/merge",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterParts("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfMergeResponse>(responseBody)!;
                return new WithRawResponse<PdfMergeResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfRemovePagesResponse>> PdfRemovePagesAsyncCore(
        PdfRemovePagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 8)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("pages", request.Pages)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/remove-pages",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfRemovePagesResponse>(responseBody)!;
                return new WithRawResponse<PdfRemovePagesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfSplitResponse>> PdfSplitAsyncCore(
        PdfSplitRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 8)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("pages", request.Pages)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/split",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfSplitResponse>(responseBody)!;
                return new WithRawResponse<PdfSplitResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfRotateResponse>> PdfRotateAsyncCore(
        PdfRotateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("pages", request.Pages)
            .Add("rotate", request.Rotate)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/rotate",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfRotateResponse>(responseBody)!;
                return new WithRawResponse<PdfRotateResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfCompressResponse>> PdfCompressAsyncCore(
        PdfCompressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 8)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("output", request.Output)
            .Add("compression_level", request.CompressionLevel)
            .Add("destroy", request.Destroy)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/compress",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfCompressResponse>(responseBody)!;
                return new WithRawResponse<PdfCompressResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfExtractPagesResponse>> PdfExtractPagesAsyncCore(
        PdfExtractPagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("pages", request.Pages)
            .Add("separated", request.Separated)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/extract-pages",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfExtractPagesResponse>(responseBody)!;
                return new WithRawResponse<PdfExtractPagesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfLinearizeResponse>> PdfLinearizeAsyncCore(
        PdfLinearizeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/linearize",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfLinearizeResponse>(responseBody)!;
                return new WithRawResponse<PdfLinearizeResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfEncryptResponse>> PdfEncryptAsyncCore(
        PdfEncryptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("file_password", request.FilePassword)
            .Add("user_password", request.UserPassword)
            .Add("owner_password", request.OwnerPassword)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/encrypt",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfEncryptResponse>(responseBody)!;
                return new WithRawResponse<PdfEncryptResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfDecryptResponse>> PdfDecryptAsyncCore(
        PdfDecryptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 8)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("file_password", request.FilePassword)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/decrypt",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfDecryptResponse>(responseBody)!;
                return new WithRawResponse<PdfDecryptResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfRestrictResponse>> PdfRestrictAsyncCore(
        PdfRestrictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("file_password", request.FilePassword)
            .Add("user_password", request.UserPassword)
            .Add("owner_password", request.OwnerPassword)
            .Add("restrictions", request.Restrictions)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/restrict",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfRestrictResponse>(responseBody)!;
                return new WithRawResponse<PdfRestrictResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfUnrestrictResponse>> PdfUnrestrictAsyncCore(
        PdfUnrestrictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("file_password", request.FilePassword)
            .Add("user_password", request.UserPassword)
            .Add("owner_password", request.OwnerPassword)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/unrestrict",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfUnrestrictResponse>(responseBody)!;
                return new WithRawResponse<PdfUnrestrictResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfConvertToPngResponse>> PdfConvertToPngAsyncCore(
        PdfConvertToPngRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("pages", request.Pages)
            .Add("resolution", request.Resolution)
            .Add("image_smoothing", request.ImageSmoothing)
            .Add("profile", request.Profile)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/png",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfConvertToPngResponse>(responseBody)!;
                return new WithRawResponse<PdfConvertToPngResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfConvertToJpgResponse>> PdfConvertToJpgAsyncCore(
        PdfConvertToJpgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 12)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("quality", request.Quality)
            .Add("pages", request.Pages)
            .Add("resolution", request.Resolution)
            .Add("image_smoothing", request.ImageSmoothing)
            .Add("profile", request.Profile)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/jpg",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfConvertToJpgResponse>(responseBody)!;
                return new WithRawResponse<PdfConvertToJpgResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfConvertToTiffResponse>> PdfConvertToTiffAsyncCore(
        PdfConvertToTiffRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("pages", request.Pages)
            .Add("resolution", request.Resolution)
            .Add("image_smoothing", request.ImageSmoothing)
            .Add("profile", request.Profile)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/tif",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfConvertToTiffResponse>(responseBody)!;
                return new WithRawResponse<PdfConvertToTiffResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfConvertToBmpResponse>> PdfConvertToBmpAsyncCore(
        PdfConvertToBmpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("pages", request.Pages)
            .Add("resolution", request.Resolution)
            .Add("image_smoothing", request.ImageSmoothing)
            .Add("profile", request.Profile)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/bmp",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfConvertToBmpResponse>(responseBody)!;
                return new WithRawResponse<PdfConvertToBmpResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfConvertToGifResponse>> PdfConvertToGifAsyncCore(
        PdfConvertToGifRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .Add("destroy", request.Destroy)
            .Add("output", request.Output)
            .Add("pages", request.Pages)
            .Add("resolution", request.Resolution)
            .Add("image_smoothing", request.ImageSmoothing)
            .Add("profile", request.Profile)
            .Add("webhook_url", request.WebhookUrl)
            .Add("webhook_failure_notification", request.WebhookFailureNotification)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("X-Webhook-Authorization", request.WebhookAuthorization)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/gif",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterPart("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfConvertToGifResponse>(responseBody)!;
                return new WithRawResponse<PdfConvertToGifResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfUploadResourcesResponse>> PdfUploadResourcesAsyncCore(
        PdfUploadResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var multipartFormRequest_ = new MultipartFormRequest
        {
            Method = HttpMethod.Post,
            Path = "v1.0/pdf/resource/upload",
            QueryString = _queryString,
            Headers = _headers,
            Options = options,
        };
        multipartFormRequest_.AddFileParameterParts("file", request.File);
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfUploadResourcesResponse>(responseBody)!;
                return new WithRawResponse<PdfUploadResourcesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfUploadBinaryResponse>> PdfUploadBinaryAsyncCore(
        PdfUploadBinaryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_name", request.FileName)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new StreamRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/pdf/resource/upload-binary",
                    Body = request.Body,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/octet-stream",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfUploadBinaryResponse>(responseBody)!;
                return new WithRawResponse<PdfUploadBinaryResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 415:
                        throw new UnsupportedMediaTypeError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<global::System.IO.Stream>> PdfDownloadResourceAsyncCore(
        PdfDownloadResourceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("resource_id", request.ResourceId)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/pdf/resource/download",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var stream = await response.Raw.Content.ReadAsStreamAsync();
            return new WithRawResponse<global::System.IO.Stream>()
            {
                Data = stream,
                RawResponse = new RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                },
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfGetTaskStatusResponse>> PdfGetTaskStatusAsyncCore(
        PdfGetTaskStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("task_id", request.TaskId)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/pdf/task-status",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfGetTaskStatusResponse>(responseBody)!;
                return new WithRawResponse<PdfGetTaskStatusResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfGetFileStatusResponse>> PdfGetFileStatusAsyncCore(
        PdfGetFileStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/pdf/file-status",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfGetFileStatusResponse>(responseBody)!;
                return new WithRawResponse<PdfGetFileStatusResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfListFilesResponse>> PdfListFilesAsyncCore(
        PdfListFilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/pdf/files",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfListFilesResponse>(responseBody)!;
                return new WithRawResponse<PdfListFilesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PdfDeleteFileResponse>> PdfDeleteFileAsyncCore(
        PdfDeleteFileRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("file_id", request.FileId)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = "v1.0/pdf/file",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<PdfDeleteFileResponse>(responseBody)!;
                return new WithRawResponse<PdfDeleteFileResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<global::System.IO.Stream>> ScreenshotCaptureAsyncCore(
        ScreenshotCaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 70)
            .Add("apiKey", request.ApiKey)
            .Add("output", request.Output)
            .Add("file_type", request.FileType)
            .Add("url", request.Url)
            .Add("width", request.Width)
            .Add("height", request.Height)
            .Add("full_page", request.FullPage)
            .Add("fresh", request.Fresh)
            .Add("no_cookie_banners", request.NoCookieBanners)
            .Add("enable_caching", request.EnableCaching)
            .Add("block_ads", request.BlockAds)
            .Add("block_chat_widgets", request.BlockChatWidgets)
            .Add("extract_text", request.ExtractText)
            .Add("extract_html", request.ExtractHtml)
            .Add("destroy_screenshot", request.DestroyScreenshot)
            .Add("lazy_load", request.LazyLoad)
            .Add("retina", request.Retina)
            .Add("dark_mode", request.DarkMode)
            .Add("block_tracking", request.BlockTracking)
            .Add("enable_incognito", request.EnableIncognito)
            .Add("omit_background", request.OmitBackground)
            .Add("thumbnail_width", request.ThumbnailWidth)
            .Add("adjust_top", request.AdjustTop)
            .Add("wait_for_event", request.WaitForEvent)
            .Add("grayscale", request.Grayscale)
            .Add("delay", request.Delay)
            .Add("timeout", request.Timeout)
            .Add("ttl", request.Ttl)
            .Add("clip[x]", request.ClipX)
            .Add("clip[y]", request.ClipY)
            .Add("clip[width]", request.ClipWidth)
            .Add("clip[height]", request.ClipHeight)
            .Add("css_url", request.CssUrl)
            .Add("css", request.Css)
            .Add("js_url", request.JsUrl)
            .Add("js", request.Js)
            .Add("block_js", request.BlockJs)
            .Add("block_stylesheets", request.BlockStylesheets)
            .Add("block_images", request.BlockImages)
            .Add("block_media", request.BlockMedia)
            .Add("block_font", request.BlockFont)
            .Add("block_text_track", request.BlockTextTrack)
            .Add("block_xhr", request.BlockXhr)
            .Add("block_fetch", request.BlockFetch)
            .Add("block_event_source", request.BlockEventSource)
            .Add("block_web_socket", request.BlockWebSocket)
            .Add("block_manifest", request.BlockManifest)
            .Add("block_specific_requests", request.BlockSpecificRequests)
            .Add("blur_selector", request.BlurSelector)
            .Add("remove_selector", request.RemoveSelector)
            .Add("result_file_name", request.ResultFileName)
            .Add("scrolling_screenshot", request.ScrollingScreenshot)
            .Add("scroll_speed", request.ScrollSpeed)
            .Add("scroll_back", request.ScrollBack)
            .Add("start_immediately", request.StartImmediately)
            .Add("multiple_scrolling", request.MultipleScrolling)
            .Add("sizes", request.Sizes)
            .Add("duration", request.Duration)
            .Add("fail_on_error", request.FailOnError)
            .Add("longitude", request.Longitude)
            .Add("latitude", request.Latitude)
            .Add("proxy", request.Proxy)
            .Add("headers", request.Headers)
            .Add("cookies", request.Cookies)
            .Add("scroll_to_element", request.ScrollToElement)
            .Add("selector", request.Selector)
            .Add("user_agent", request.UserAgent)
            .Add("accept_languages", request.AcceptLanguages)
            .Add("custom_html", request.CustomHtml)
            .Add("image_quality", request.ImageQuality)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/screenshot",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var stream = await response.Raw.Content.ReadAsStreamAsync();
            return new WithRawResponse<global::System.IO.Stream>()
            {
                Data = stream,
                RawResponse = new RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                },
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 407:
                        throw new ProxyAuthenticationRequiredError(
                            JsonUtils.Deserialize<ProxyAuthenticationRequiredErrorBody>(
                                responseBody
                            )
                        );
                    case 408:
                        throw new RequestTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 444:
                        throw new NoResponseError(
                            JsonUtils.Deserialize<NoResponseErrorBody>(responseBody)
                        );
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<BulkScreenshotCaptureResponse>
    > BulkScreenshotCaptureAsyncCore(
        BulkScreenshotCaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/screenshot",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkScreenshotCaptureResponse>(
                    responseBody
                )!;
                return new WithRawResponse<BulkScreenshotCaptureResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CurrencyLatestRatesResponse>> CurrencyLatestRatesAsyncCore(
        CurrencyLatestRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("base", request.Base)
            .Add("symbols", request.Symbols)
            .Add("updates", request.Updates)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/rates/latest",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencyLatestRatesResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CurrencyLatestRatesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CurrencyHistoricalRatesResponse>
    > CurrencyHistoricalRatesAsyncCore(
        CurrencyHistoricalRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("base", request.Base)
            .Add("symbols", request.Symbols)
            .Add("date", request.Date)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/rates/historical",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencyHistoricalRatesResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CurrencyHistoricalRatesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CurrencyConvertLatestResponse>
    > CurrencyConvertLatestAsyncCore(
        CurrencyConvertLatestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("from", request.From)
            .Add("to", request.To)
            .Add("amount", request.Amount)
            .Add("updates", request.Updates)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/converter/latest/prices",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencyConvertLatestResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CurrencyConvertLatestResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CurrencyConvertHistoricalResponse>
    > CurrencyConvertHistoricalAsyncCore(
        CurrencyConvertHistoricalRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("from", request.From)
            .Add("to", request.To)
            .Add("amount", request.Amount)
            .Add("date", request.Date)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/converter/historical/prices",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencyConvertHistoricalResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CurrencyConvertHistoricalResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CurrencyTimeSeriesResponse>> CurrencyTimeSeriesAsyncCore(
        CurrencyTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .Add("base", request.Base)
            .Add("symbols", request.Symbols)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/time-series",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencyTimeSeriesResponse>(responseBody)!;
                return new WithRawResponse<CurrencyTimeSeriesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CurrencyFluctuationResponse>> CurrencyFluctuationAsyncCore(
        CurrencyFluctuationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .Add("base", request.Base)
            .Add("symbols", request.Symbols)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/fluctuation",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencyFluctuationResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CurrencyFluctuationResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CurrencyConvertByIpResponse>> CurrencyConvertByIpAsyncCore(
        CurrencyConvertByIpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("updates", request.Updates)
            .Add("from", request.From)
            .Add("ip", request.Ip)
            .Add("amount", request.Amount)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/converter/ip-to-currency",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencyConvertByIpResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CurrencyConvertByIpResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CurrencySupportedResponse>> CurrencySupportedAsyncCore(
        CurrencySupportedRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/supported",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencySupportedResponse>(responseBody)!;
                return new WithRawResponse<CurrencySupportedResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CurrencySymbolsResponse>> CurrencySymbolsAsyncCore(
        CurrencySymbolsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/symbols",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencySymbolsResponse>(responseBody)!;
                return new WithRawResponse<CurrencySymbolsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CurrencyHistoricalLimitsResponse>
    > CurrencyHistoricalLimitsAsyncCore(
        CurrencyHistoricalLimitsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/currency/historical/data/limits",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrencyHistoricalLimitsResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CurrencyHistoricalLimitsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CommodityLatestRatesResponse>> CommodityLatestRatesAsyncCore(
        CommodityLatestRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("symbols", request.Symbols)
            .Add("updates", request.Updates)
            .Add("quote", request.Quote)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/commodity/rates/latest",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommodityLatestRatesResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CommodityLatestRatesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<CommodityHistoricalRatesResponse>
    > CommodityHistoricalRatesAsyncCore(
        CommodityHistoricalRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("date", request.Date)
            .Add("symbols", request.Symbols)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/commodity/rates/historical",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommodityHistoricalRatesResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CommodityHistoricalRatesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CommodityFluctuationResponse>> CommodityFluctuationAsyncCore(
        CommodityFluctuationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("symbols", request.Symbols)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/commodity/fluctuation",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommodityFluctuationResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CommodityFluctuationResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CommodityTimeSeriesResponse>> CommodityTimeSeriesAsyncCore(
        CommodityTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("symbols", request.Symbols)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/commodity/time-series",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommodityTimeSeriesResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CommodityTimeSeriesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CommoditySymbolsResponse>> CommoditySymbolsAsyncCore(
        CommoditySymbolsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/commodity/symbols",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CommoditySymbolsResponse>(responseBody)!;
                return new WithRawResponse<CommoditySymbolsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<VatSupportedCountriesResponse>
    > VatSupportedCountriesAsyncCore(
        VatSupportedCountriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("type", request.Type)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/vat/supported-countries",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<VatSupportedCountriesResponse>(
                    responseBody
                )!;
                return new WithRawResponse<VatSupportedCountriesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<IEnumerable<VatRateByIpResponseItem>>> VatRateByIpAsyncCore(
        VatRateByIpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("ipAddress", request.IpAddress)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/vat/rates/ip-address",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IEnumerable<VatRateByIpResponseItem>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<VatRateByIpResponseItem>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<IEnumerable<VatRateByCountryResponseItem>>
    > VatRateByCountryAsyncCore(
        VatRateByCountryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("country", request.Country)
            .Add("state", request.State)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/vat/rates/country",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IEnumerable<VatRateByCountryResponseItem>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<VatRateByCountryResponseItem>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<BulkVatRateByCountryResponse>> BulkVatRateByCountryAsyncCore(
        BulkVatRateByCountryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/vat/rates/country",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkVatRateByCountryResponse>(
                    responseBody
                )!;
                return new WithRawResponse<BulkVatRateByCountryResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<VatValidateResponse>> VatValidateAsyncCore(
        VatValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("vatNumber", request.VatNumber)
            .Add("requesterVatNumber", request.RequesterVatNumber)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/vat/validation",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<VatValidateResponse>(responseBody)!;
                return new WithRawResponse<VatValidateResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<IbanValidateResponse>> IbanValidateAsyncCore(
        IbanValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("iban", request.Iban)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/iban/validation",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IbanValidateResponse>(responseBody)!;
                return new WithRawResponse<IbanValidateResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<IEnumerable<string>>> SwiftCodeFindAsyncCore(
        SwiftCodeFindRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("country", request.Country)
            .Add("bank", request.Bank)
            .Add("city", request.City)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/swift-code/finder",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IEnumerable<string>>(responseBody)!;
                return new WithRawResponse<IEnumerable<string>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<SwiftCodeLookupResponse>> SwiftCodeLookupAsyncCore(
        SwiftCodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("swiftCode", request.SwiftCode)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/swift-code/lookup",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SwiftCodeLookupResponse>(responseBody)!;
                return new WithRawResponse<SwiftCodeLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ZipcodeLookupResponse>> ZipcodeLookupAsyncCore(
        ZipcodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("code", request.Code)
            .Add("country", request.Country)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/zipcode/lookup",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ZipcodeLookupResponse>(responseBody)!;
                return new WithRawResponse<ZipcodeLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<BulkZipcodeLookupResponse>> BulkZipcodeLookupAsyncCore(
        BulkZipcodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/zipcode/lookup",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkZipcodeLookupResponse>(responseBody)!;
                return new WithRawResponse<BulkZipcodeLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ZipcodeSearchByCityResponse>> ZipcodeSearchByCityAsyncCore(
        ZipcodeSearchByCityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("city", request.City)
            .Add("country", request.Country)
            .Add("state_name", request.StateName)
            .Add("page", request.Page)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/zipcode/search/city",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ZipcodeSearchByCityResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ZipcodeSearchByCityResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<ZipcodeSearchByRegionResponse>
    > ZipcodeSearchByRegionAsyncCore(
        ZipcodeSearchByRegionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 5)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("country", request.Country)
            .Add("region", request.Region)
            .Add("page", request.Page)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/zipcode/search/region",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ZipcodeSearchByRegionResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ZipcodeSearchByRegionResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<ZipcodeSearchByRadiusResponse>
    > ZipcodeSearchByRadiusAsyncCore(
        ZipcodeSearchByRadiusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("code", request.Code)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("country", request.Country)
            .Add("radius", request.Radius)
            .Add("unit", request.Unit)
            .Add("page", request.Page)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/zipcode/search/radius",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ZipcodeSearchByRadiusResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ZipcodeSearchByRadiusResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ZipcodeDistanceResponse>> ZipcodeDistanceAsyncCore(
        ZipcodeDistanceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/zipcode/distance",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ZipcodeDistanceResponse>(responseBody)!;
                return new WithRawResponse<ZipcodeDistanceResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ZipcodeDistanceMatchResponse>> ZipcodeDistanceMatchAsyncCore(
        ZipcodeDistanceMatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/zipcode/distance/match",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ZipcodeDistanceMatchResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ZipcodeDistanceMatchResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<CurrentWeatherResponse>> CurrentWeatherAsyncCore(
        CurrentWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 7)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("timezone", request.Timezone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/weather/current",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<CurrentWeatherResponse>(responseBody)!;
                return new WithRawResponse<CurrentWeatherResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<BulkCurrentWeatherResponse>> BulkCurrentWeatherAsyncCore(
        BulkCurrentWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("timezone", request.Timezone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/weather/current",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<BulkCurrentWeatherResponse>(responseBody)!;
                return new WithRawResponse<BulkCurrentWeatherResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<WeatherForecastResponse>> WeatherForecastAsyncCore(
        WeatherForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .Add("forecastDays", request.ForecastDays)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("precision", request.Precision)
            .Add("timezone", request.Timezone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/weather/forecast",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<WeatherForecastResponse>(responseBody)!;
                return new WithRawResponse<WeatherForecastResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<HistoricalWeatherResponse>> HistoricalWeatherAsyncCore(
        HistoricalWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("date", request.Date)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("precision", request.Precision)
            .Add("timezone", request.Timezone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/weather/historical",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<HistoricalWeatherResponse>(responseBody)!;
                return new WithRawResponse<HistoricalWeatherResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<WeatherTimeSeriesResponse>> WeatherTimeSeriesAsyncCore(
        WeatherTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("precision", request.Precision)
            .Add("timezone", request.Timezone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/weather/time-series",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<WeatherTimeSeriesResponse>(responseBody)!;
                return new WithRawResponse<WeatherTimeSeriesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<MarineWeatherResponse>> MarineWeatherAsyncCore(
        MarineWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("precision", request.Precision)
            .Add("timezone", request.Timezone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/weather/marine",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<MarineWeatherResponse>(responseBody)!;
                return new WithRawResponse<MarineWeatherResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<AirQualityResponse>> AirQualityAsyncCore(
        AirQualityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("precision", request.Precision)
            .Add("timezone", request.Timezone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/weather/air-quality",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<AirQualityResponse>(responseBody)!;
                return new WithRawResponse<AirQualityResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<FloodForecastResponse>> FloodForecastAsyncCore(
        FloodForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("startDate", request.StartDate)
            .Add("endDate", request.EndDate)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("precision", request.Precision)
            .Add("timezone", request.Timezone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/weather/flood",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<FloodForecastResponse>(responseBody)!;
                return new WithRawResponse<FloodForecastResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetCountriesResponse>> GetCountriesAsyncCore(
        GetCountriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("region", request.Region)
            .Add("subregion", request.Subregion)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geo/countries",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetCountriesResponse>(responseBody)!;
                return new WithRawResponse<GetCountriesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetCountryDetailsResponse>> GetCountryDetailsAsyncCore(
        GetCountryDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("country", request.Country)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geo/country/details",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetCountryDetailsResponse>(responseBody)!;
                return new WithRawResponse<GetCountryDetailsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetRegionsResponse>> GetRegionsAsyncCore(
        GetRegionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geo/regions",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetRegionsResponse>(responseBody)!;
                return new WithRawResponse<GetRegionsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetSubregionsResponse>> GetSubregionsAsyncCore(
        GetSubregionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("region", request.Region)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geo/subregions",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetSubregionsResponse>(responseBody)!;
                return new WithRawResponse<GetSubregionsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetAdminLevelsResponse>> GetAdminLevelsAsyncCore(
        GetAdminLevelsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("country", request.Country)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geo/admin-levels",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetAdminLevelsResponse>(responseBody)!;
                return new WithRawResponse<GetAdminLevelsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetAdminUnitsResponse>> GetAdminUnitsAsyncCore(
        GetAdminUnitsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("country", request.Country)
            .Add("adminLevels", request.AdminLevels)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geo/admin-units",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetAdminUnitsResponse>(responseBody)!;
                return new WithRawResponse<GetAdminUnitsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetAdminUnitDetailsResponse>> GetAdminUnitDetailsAsyncCore(
        GetAdminUnitDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("country", request.Country)
            .Add("admin_unit", request.AdminUnit)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geo/admin-unit/details",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetAdminUnitDetailsResponse>(
                    responseBody
                )!;
                return new WithRawResponse<GetAdminUnitDetailsResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GetCitiesResponse>> GetCitiesAsyncCore(
        GetCitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("country", request.Country)
            .Add("admin_unit", request.AdminUnit)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geo/cities",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GetCitiesResponse>(responseBody)!;
                return new WithRawResponse<GetCitiesResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<IEnumerable<GetSupportedFlagsResponseItem>>
    > GetSupportedFlagsAsyncCore(
        GetSupportedFlagsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("apiKey", request.ApiKey)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/flags/supported",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<GetSupportedFlagsResponseItem>
                >(responseBody)!;
                return new WithRawResponse<IEnumerable<GetSupportedFlagsResponseItem>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<global::System.IO.Stream>> GetFlagsAsyncCore(
        GetFlagsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 6)
            .Add("apiKey", request.ApiKey)
            .Add("name", request.Name)
            .Add("shape", request.Shape)
            .Add("format", request.Format)
            .Add("size", request.Size)
            .Add("type", request.Type)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/flags",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var stream = await response.Raw.Content.ReadAsStreamAsync();
            return new WithRawResponse<global::System.IO.Stream>()
            {
                Data = stream,
                RawResponse = new RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                },
            };
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<TimezoneLookupResponse>> TimezoneLookupAsyncCore(
        TimezoneLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 11)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("ip", request.Ip)
            .Add("tz", request.Tz)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("lang", request.Lang)
            .Add("iata_code", request.IataCode)
            .Add("icao_code", request.IcaoCode)
            .Add("lo_code", request.LoCode)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geolocation/timezone",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<TimezoneLookupResponse>(responseBody)!;
                return new WithRawResponse<TimezoneLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<TimezoneConvertResponse>> TimezoneConvertAsyncCore(
        TimezoneConvertRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 17)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("time", request.Time)
            .Add("tz_from", request.TzFrom)
            .Add("tz_to", request.TzTo)
            .Add("lat_from", request.LatFrom)
            .Add("long_from", request.LongFrom)
            .Add("lat_to", request.LatTo)
            .Add("long_to", request.LongTo)
            .Add("location_from", request.LocationFrom)
            .Add("location_to", request.LocationTo)
            .Add("iata_from", request.IataFrom)
            .Add("iata_to", request.IataTo)
            .Add("icao_from", request.IcaoFrom)
            .Add("icao_to", request.IcaoTo)
            .Add("locode_from", request.LocodeFrom)
            .Add("locode_to", request.LocodeTo)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/timezone/converter",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<TimezoneConvertResponse>(responseBody)!;
                return new WithRawResponse<TimezoneConvertResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<UserAgentLookupResponse>> UserAgentLookupAsyncCore(
        UserAgentLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add("User-Agent", request.UserAgent)
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/user-agent/lookup",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<UserAgentLookupResponse>(responseBody)!;
                return new WithRawResponse<UserAgentLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<
        WithRawResponse<IEnumerable<BulkUserAgentLookupResponseItem>>
    > BulkUserAgentLookupAsyncCore(
        BulkUserAgentLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/user-agent/lookup",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<BulkUserAgentLookupResponseItem>
                >(responseBody)!;
                return new WithRawResponse<IEnumerable<BulkUserAgentLookupResponseItem>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<OcrPredictResponse>> OcrPredictAsyncCore(
        OcrPredictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("apiKey", request.ApiKey)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/ocr/predict",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<OcrPredictResponse>(responseBody)!;
                return new WithRawResponse<OcrPredictResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GrammarDetectResponse>> GrammarDetectAsyncCore(
        GrammarDetectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("apiKey", request.ApiKey)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/readability/grammar/detect",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GrammarDetectResponse>(responseBody)!;
                return new WithRawResponse<GrammarDetectResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<GrammarCorrectResponse>> GrammarCorrectAsyncCore(
        GrammarCorrectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("apiKey", request.ApiKey)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/readability/grammar/correct",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<GrammarCorrectResponse>(responseBody)!;
                return new WithRawResponse<GrammarCorrectResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<WeakWordsDetectResponse>> WeakWordsDetectAsyncCore(
        WeakWordsDetectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("apiKey", request.ApiKey)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/readability/weak-words",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<WeakWordsDetectResponse>(responseBody)!;
                return new WithRawResponse<WeakWordsDetectResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ReadabilityScoreResponse>> ReadabilityScoreAsyncCore(
        ReadabilityScoreRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("apiKey", request.ApiKey)
            .Add("target", request.Target)
            .Add("exclude", request.Exclude)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "v1.0/readability/score",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ReadabilityScoreResponse>(responseBody)!;
                return new WithRawResponse<ReadabilityScoreResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<AstronomyLookupResponse>> AstronomyLookupAsyncCore(
        AstronomyLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new ApifreaksApi.Core.QueryStringBuilder.Builder(capacity: 10)
            .Add("apiKey", request.ApiKey)
            .Add("format", request.Format)
            .Add("location", request.Location)
            .Add("lat", request.Lat)
            .Add("long", request.Long)
            .Add("ip", request.Ip)
            .Add("lang", request.Lang)
            .Add("date", request.Date)
            .Add("elevation", request.Elevation)
            .Add("time_zone", request.TimeZone)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new ApifreaksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "v1.0/geolocation/astronomy",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<AstronomyLookupResponse>(responseBody)!;
                return new WithRawResponse<AstronomyLookupResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new ApifreaksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<object>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
                    case 406:
                        throw new NotAcceptableError(JsonUtils.Deserialize<object>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<object>(responseBody));
                    case 429:
                        throw new TooManyRequestsError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new ApifreaksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Get detailed geolocation data for an IP address including country, city, timezone, currency, and optional security and user-agent information
    /// </summary>
    /// <example><code>
    /// await client.GeolocationLookupAsync(new GeolocationLookupRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<GeolocationLookupResponse> GeolocationLookupAsync(
        GeolocationLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GeolocationLookupResponse>(
            GeolocationLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve detailed geolocation data for multiple IP addresses in a single request.
    /// Supports up to `50,000` IP-addresses/host-names per request.
    /// </summary>
    /// <example><code>
    /// await client.BulkGeolocationLookupAsync(
    ///     new BulkGeolocationLookupRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Ips = new List&lt;string&gt;() { "ips" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        IEnumerable<BulkGeolocationLookupResponseItem>
    > BulkGeolocationLookupAsync(
        BulkGeolocationLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<BulkGeolocationLookupResponseItem>>(
            BulkGeolocationLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get comprehensive security information for a given IP address. Detects VPNs, proxies, Tor nodes, and other security threats.
    /// </summary>
    /// <example><code>
    /// await client.IpSecurityLookupAsync(new IpSecurityLookupRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<IpSecurityLookupResponse> IpSecurityLookupAsync(
        IpSecurityLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IpSecurityLookupResponse>(
            IpSecurityLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The Bulk IP Security Lookup API allows you to retrieve security details for up to `50,000` IP-addresses in a single request.
    /// </summary>
    /// <example><code>
    /// await client.BulkIpSecurityLookupAsync(
    ///     new BulkIpSecurityLookupRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Ips = new List&lt;string&gt;() { "ips" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        IEnumerable<BulkIpSecurityLookupResponseItem>
    > BulkIpSecurityLookupAsync(
        BulkIpSecurityLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<BulkIpSecurityLookupResponseItem>>(
            BulkIpSecurityLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Convert a given address or place name into geographic coordinates (latitude and longitude).
    /// </summary>
    /// <example><code>
    /// await client.GeocoderSearchAsync(new GeocoderSearchRequest { ApiKey = "apiKey", Query = "query" });
    /// </code></example>
    public WithRawResponseTask<IEnumerable<GeocoderSearchResponseItem>> GeocoderSearchAsync(
        GeocoderSearchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<GeocoderSearchResponseItem>>(
            GeocoderSearchAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Convert geographic coordinates (latitude and longitude) into a human-readable address or place name.
    /// </summary>
    /// <example><code>
    /// await client.GeocoderReverseAsync(
    ///     new GeocoderReverseRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Lat = 1.1,
    ///         Lon = 1.1,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GeocoderReverseResponse> GeocoderReverseAsync(
        GeocoderReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GeocoderReverseResponse>(
            GeocoderReverseAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve current WHOIS information for a domain name.
    /// This endpoint provides detailed registration information including registrar details,
    /// dates, nameservers, and registrant information.
    /// </summary>
    /// <example><code>
    /// await client.DomainWhoisLookupAsync(
    ///     new DomainWhoisLookupRequest { ApiKey = "apiKey", DomainName = "domainName" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainWhoisLookupResponse> DomainWhoisLookupAsync(
        DomainWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainWhoisLookupResponse>(
            DomainWhoisLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve WHOIS information for `100 Domains per Request`.
    /// </summary>
    /// <example><code>
    /// await client.BulkDomainWhoisLookupAsync(
    ///     new BulkDomainWhoisLookupRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         DomainNames = new List&lt;string&gt;() { "domainNames" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkDomainWhoisLookupResponse> BulkDomainWhoisLookupAsync(
        BulkDomainWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkDomainWhoisLookupResponse>(
            BulkDomainWhoisLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns WHOIS registration details for a specified IP address (IPv4 or IPv6).
    /// </summary>
    /// <example><code>
    /// await client.IpWhoisLookupAsync(new IpWhoisLookupRequest { ApiKey = "apiKey", Ip = "ip" });
    /// </code></example>
    public WithRawResponseTask<IpWhoisLookupResponse> IpWhoisLookupAsync(
        IpWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IpWhoisLookupResponse>(
            IpWhoisLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns WHOIS registration details for a specified ASN, with or without the 'as' prefix.
    /// </summary>
    /// <example><code>
    /// await client.AsnWhoisLookupAsync(new AsnWhoisLookupRequest { ApiKey = "apiKey", Asn = "asn" });
    /// </code></example>
    public WithRawResponseTask<AsnWhoisLookupResponse> AsnWhoisLookupAsync(
        AsnWhoisLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AsnWhoisLookupResponse>(
            AsnWhoisLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve historical WHOIS records for a domain name.
    /// This endpoint provides a timeline of all recorded changes in domain registration information.
    /// </summary>
    /// <example><code>
    /// await client.DomainWhoisHistoryAsync(
    ///     new DomainWhoisHistoryRequest { ApiKey = "apiKey", DomainName = "domainName" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainWhoisHistoryResponse> DomainWhoisHistoryAsync(
        DomainWhoisHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainWhoisHistoryResponse>(
            DomainWhoisHistoryAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Performs a reverse WHOIS search using one or more search parameters like keyword, email, owner, or company.
    /// </summary>
    /// <example><code>
    /// await client.DomainWhoisReverseAsync(new DomainWhoisReverseRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<DomainWhoisReverseResponse> DomainWhoisReverseAsync(
        DomainWhoisReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainWhoisReverseResponse>(
            DomainWhoisReverseAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve real-time DNS records for any hostname. Supports multiple record types including A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records.
    /// </summary>
    /// <example><code>
    /// await client.DomainDnsLookupAsync(
    ///     new DomainDnsLookupRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Type = new List&lt;string&gt;() { "type" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainDnsLookupResponse> DomainDnsLookupAsync(
        DomainDnsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainDnsLookupResponse>(
            DomainDnsLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Perform DNS lookups for multiple hostnames in a single request. Supports up to `100 host-names per request`
    /// and returns DNS records including A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records.
    /// </summary>
    /// <example><code>
    /// await client.BulkDomainDnsLookupAsync(
    ///     new BulkDomainDnsLookupRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Type = new List&lt;string&gt;() { "type" },
    ///         DomainNames = new List&lt;string&gt;() { "domainNames" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkDomainDnsLookupResponse> BulkDomainDnsLookupAsync(
        BulkDomainDnsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkDomainDnsLookupResponse>(
            BulkDomainDnsLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve historical DNS records for any hostname. Access unique historical data for A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME records,
    /// including subdomains. Results are paginated with up to 100 unique records per page.
    /// </summary>
    /// <example><code>
    /// await client.DomainDnsHistoryAsync(
    ///     new DomainDnsHistoryRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         HostName = "host-name",
    ///         Type = new List&lt;string&gt;() { "type" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainDnsHistoryResponse> DomainDnsHistoryAsync(
        DomainDnsHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainDnsHistoryResponse>(
            DomainDnsHistoryAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve all the hostnames associated with any particular A, AAAA, MX, NS, SOA, SPF, TXT, and CNAME DNS records. For instance, you can access all the hostnames hosted on any IP/CIDR notation, all the domain names using Cloudflare name servers, and all the domain names using Google Mailbox
    /// </summary>
    /// <example><code>
    /// await client.DomainDnsReverseAsync(
    ///     new DomainDnsReverseRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Type = DomainDnsReverseRequestType.A,
    ///         Value = "value",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainDnsReverseResponse> DomainDnsReverseAsync(
        DomainDnsReverseRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainDnsReverseResponse>(
            DomainDnsReverseAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Execute a series of web scraping instructions on a target URL.
    /// Supports various operations like form filling, clicking, data extraction, and CAPTCHA solving.
    /// </summary>
    /// <example><code>
    /// await client.WebScrapeAsync(
    ///     new WebScrapeRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Url = "https://example.com",
    ///         Body = new WebScrapeRequestBodyBlockUrl
    ///         {
    ///             BlockUrl = new List&lt;string&gt;()
    ///             {
    ///                 "https://example.com/ads.js",
    ///                 "https://tracker.example.com/*",
    ///             },
    ///             Cookies = new List&lt;WebScrapeRequestBodyBlockUrlCookiesItem&gt;()
    ///             {
    ///                 new WebScrapeRequestBodyBlockUrlCookiesItem
    ///                 {
    ///                     Name = "sessionid",
    ///                     Value = "abc123",
    ///                 },
    ///                 new WebScrapeRequestBodyBlockUrlCookiesItem
    ///                 {
    ///                     Name = "user_pref",
    ///                     Value = "darkmode",
    ///                 },
    ///             },
    ///             Instructions = new List&lt;
    ///                 OneOf&lt;
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemFill,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemClick,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemClickIfExist,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemEnter,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemNewTab,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemMoveToRelativeTab,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemWait,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemWaitFor,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemSelect,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemJsExe,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemConditionalCheck,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemClickButtonByValue,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptcha,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemBlockElement,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemExtract,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemFillImageCaptcha,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemSwitchToIframe,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemSwitchToParentFrame,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemResolveAudioCaptcha,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemScreenshot,
    ///                     WebScrapeRequestBodyBlockUrlInstructionsItemSaveimage
    ///                 &gt;
    ///             &gt;()
    ///             {
    ///                 new WebScrapeRequestBodyBlockUrlInstructionsItemFill
    ///                 {
    ///                     Fill = new WebScrapeRequestBodyBlockUrlInstructionsItemFillFill
    ///                     {
    ///                         Place = "#username",
    ///                         Value = "myuser",
    ///                     },
    ///                 },
    ///                 new WebScrapeRequestBodyBlockUrlInstructionsItemFill
    ///                 {
    ///                     Fill = new WebScrapeRequestBodyBlockUrlInstructionsItemFillFill
    ///                     {
    ///                         Place = "#password",
    ///                         Value = "mypassword",
    ///                     },
    ///                 },
    ///                 new WebScrapeRequestBodyBlockUrlInstructionsItemClick { Click = "#loginButton" },
    ///                 new WebScrapeRequestBodyBlockUrlInstructionsItemWait { Wait = 2000 },
    ///                 new WebScrapeRequestBodyBlockUrlInstructionsItemExtract
    ///                 {
    ///                     Extract = new WebScrapeRequestBodyBlockUrlInstructionsItemExtractExtract
    ///                     {
    ///                         Html = "#profile",
    ///                         Text = "#welcome-message",
    ///                         UserData = "#user-info",
    ///                     },
    ///                 },
    ///                 new WebScrapeRequestBodyBlockUrlInstructionsItemBlockElement
    ///                 {
    ///                     BlockElement = new List&lt;string&gt;() { ".ad-banner", "//div[@class='popup']" },
    ///                 },
    ///                 new WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptcha
    ///                 {
    ///                     GeneralImageCaptcha =
    ///                         new List&lt;WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaGeneralImageCaptchaItem&gt;()
    ///                         {
    ///                             new WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaGeneralImageCaptchaItem
    ///                             {
    ///                                 ImagePath = "#captcha-img",
    ///                                 TextField = "#captcha-input",
    ///                                 ImageUpdatePath = "#refresh-captcha",
    ///                                 CaptchaFailedPath = "#captcha-error",
    ///                                 Model =
    ///                                     WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaGeneralImageCaptchaItemModel.MiniOcrV1,
    ///                             },
    ///                         },
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<WebScrapeResponse> WebScrapeAsync(
        WebScrapeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WebScrapeResponse>(
            WebScrapeAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Validates a single email address and returns result.
    /// </summary>
    /// <example><code>
    /// await client.EmailValidateAsync(new EmailValidateRequest { ApiKey = "apiKey", Email = "email" });
    /// </code></example>
    public WithRawResponseTask<EmailValidateResponse> EmailValidateAsync(
        EmailValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<EmailValidateResponse>(
            EmailValidateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Validates a bulk of email addresses and returns result for each. Maximum `10` email addresses per request.
    /// </summary>
    /// <example><code>
    /// await client.BulkEmailValidateAsync(
    ///     new BulkEmailValidateRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         EmailData = new List&lt;BulkEmailValidateRequestEmailDataItem&gt;()
    ///         {
    ///             new BulkEmailValidateRequestEmailDataItem { Email = "email" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkEmailValidateResponse> BulkEmailValidateAsync(
        BulkEmailValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkEmailValidateResponse>(
            BulkEmailValidateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Validates a single phone number and returns detailed metadata including carrier, line type, geolocation, time zones, and standardized formats.
    /// </summary>
    /// <example><code>
    /// await client.PhoneValidateAsync(
    ///     new PhoneValidateRequest { ApiKey = "apiKey", Number = "+14155552671" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PhoneValidateResponse> PhoneValidateAsync(
        PhoneValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PhoneValidateResponse>(
            PhoneValidateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Validates up to 100 phone numbers in a single request. Each number is processed independently — invalid entries return per-number errors without affecting the rest of the batch.
    /// </summary>
    /// <example><code>
    /// await client.BulkPhoneValidateAsync(
    ///     new BulkPhoneValidateRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Numbers = new List&lt;BulkPhoneValidateRequestNumbersItem&gt;()
    ///         {
    ///             new BulkPhoneValidateRequestNumbersItem { Number = "+14155552671" },
    ///             new BulkPhoneValidateRequestNumbersItem { Number = "+447911123456" },
    ///             new BulkPhoneValidateRequestNumbersItem { Number = "+919876543210" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<BulkPhoneValidateResponseItem>> BulkPhoneValidateAsync(
        BulkPhoneValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<BulkPhoneValidateResponseItem>>(
            BulkPhoneValidateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve comprehensive SSL certificate information without the certificate chain.
    /// This endpoint provides detailed information about the SSL certificate including expiry dates, issuer details, and encryption methods.
    /// </summary>
    /// <example><code>
    /// await client.DomainSslLookupAsync(
    ///     new DomainSslLookupRequest { ApiKey = "apiKey", DomainName = "domainName" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainSslLookupResponse> DomainSslLookupAsync(
        DomainSslLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainSslLookupResponse>(
            DomainSslLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve the complete SSL certificate chain from root Certificate Authority (CA) to end-user certificate.
    /// This endpoint provides comprehensive information about each certificate in the chain.
    /// </summary>
    /// <example><code>
    /// await client.DomainSslChainLookupAsync(
    ///     new DomainSslChainLookupRequest { ApiKey = "apiKey", DomainName = "domainName" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainSslChainLookupResponse> DomainSslChainLookupAsync(
        DomainSslChainLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainSslChainLookupResponse>(
            DomainSslChainLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The Domain Search API is designed to simplify the process of finding available domain names across all top-level domains (TLDs) and second-level domains (SLDs).
    /// </summary>
    /// <example><code>
    /// await client.DomainAvailabilityCheckAsync(
    ///     new DomainAvailabilityCheckRequest { ApiKey = "apiKey", Domain = "domain" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainAvailabilityCheckResponse> DomainAvailabilityCheckAsync(
        DomainAvailabilityCheckRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainAvailabilityCheckResponse>(
            DomainAvailabilityCheckAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Perform Bulk Domain Availability checks using a list of domains. Supports upto `100 Domains Per Request`.
    /// </summary>
    /// <example><code>
    /// await client.BulkDomainAvailabilityCheckAsync(
    ///     new BulkDomainAvailabilityCheckRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         DomainNames = new List&lt;string&gt;() { "domainNames" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkDomainAvailabilityCheckResponse> BulkDomainAvailabilityCheckAsync(
        BulkDomainAvailabilityCheckRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkDomainAvailabilityCheckResponse>(
            BulkDomainAvailabilityCheckAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The Domain Search API is designed to simplify the process of finding available domain names across all top-level domains (TLDs) and second-level domains (SLDs).
    /// </summary>
    /// <example><code>
    /// await client.DomainAvailabilitySuggestionsAsync(
    ///     new DomainAvailabilitySuggestionsRequest { ApiKey = "apiKey", Domain = "domain" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainAvailabilitySuggestionsResponse> DomainAvailabilitySuggestionsAsync(
        DomainAvailabilitySuggestionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainAvailabilitySuggestionsResponse>(
            DomainAvailabilitySuggestionsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The Subdomain Lookup API is designed to retrieve subdomains related to the given domain name. It helps you explore subdomains that are available for registration or usage.
    /// </summary>
    /// <example><code>
    /// await client.SubdomainsLookupAsync(
    ///     new SubdomainsLookupRequest { ApiKey = "apiKey", Domain = "domain" }
    /// );
    /// </code></example>
    public WithRawResponseTask<SubdomainsLookupResponse> SubdomainsLookupAsync(
        SubdomainsLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubdomainsLookupResponse>(
            SubdomainsLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The Domain Typosquatting API searches for registered domains that are typo or look-alike variants of a brand keyword, or that match a wildcard pattern. Results include registration lifecycle data and drop status across 1529+ TLDs, paginated at 100 domains per page.
    /// </summary>
    /// <example><code>
    /// await client.DomainTyposquattingAsync(new DomainTyposquattingRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<DomainTyposquattingResponse> DomainTyposquattingAsync(
        DomainTyposquattingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainTyposquattingResponse>(
            DomainTyposquattingAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The Domain Reputation API evaluates a domain against threat intelligence sources, DGA (domain generation algorithm) scoring, trust signals, and email deliverability configuration, returning a consolidated risk assessment with a verdict, severity, and supporting evidence.
    /// </summary>
    /// <example><code>
    /// await client.DomainReputationAsync(
    ///     new DomainReputationRequest { ApiKey = "apiKey", DomainName = "domainName" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainReputationResponse> DomainReputationAsync(
        DomainReputationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainReputationResponse>(
            DomainReputationAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve sunrise and sunset times, current position of the moon, and other related information by specifying a location address, location coordinates, IP address, or using the client IP address if no parameter is passed.
    /// </summary>
    /// <example><code>
    /// await client.AstronomyLookupV2Async(new AstronomyLookupV2Request { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<AstronomyLookupV2Response> AstronomyLookupV2Async(
        AstronomyLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AstronomyLookupV2Response>(
            AstronomyLookupV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get current time, date, and timezone details by specifying a timezone name, location address, GPS coordinates, IP address, IATA/ICAO airport code, UN/LOCODE, or use the client IP if no parameter is provided.
    /// </summary>
    /// <example><code>
    /// await client.TimezoneLookupV2Async(new TimezoneLookupV2Request { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<TimezoneLookupV2Response> TimezoneLookupV2Async(
        TimezoneLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TimezoneLookupV2Response>(
            TimezoneLookupV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get detailed IP geolocation data for an IP address including country, city, timezone, currency, and optional threat intelligence and user-agent information.
    /// </summary>
    /// <example><code>
    /// await client.GeolocationLookupV2Async(new GeolocationLookupV2Request { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<GeolocationLookupV2Response> GeolocationLookupV2Async(
        GeolocationLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GeolocationLookupV2Response>(
            GeolocationLookupV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get detailed IP geolocation data for multiple IP addresses including country, city, timezone, currency, and optional threat intelligence information. Supports up to 50,000 IP addresses per request.
    /// </summary>
    /// <example><code>
    /// await client.BulkGeolocationLookupV2Async(
    ///     new BulkGeolocationLookupV2Request
    ///     {
    ///         ApiKey = "apiKey",
    ///         Ips = new List&lt;string&gt;() { "ips" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<
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
    )
    {
        return new WithRawResponseTask<
            IEnumerable<
                OneOf<
                    BulkGeolocationLookupV2ResponseItemAbuse,
                    BulkGeolocationLookupV2ResponseItemMessage
                >
            >
        >(BulkGeolocationLookupV2AsyncCore(request, options, cancellationToken));
    }

    /// <summary>
    /// Returns the current WHOIS record for the specified domain, including registrar details, registrant/administrative/technical/billing/reseller contacts, name servers, status codes, and raw WHOIS text.
    /// </summary>
    /// <example><code>
    /// await client.DomainWhoisLookupV2Async(
    ///     new DomainWhoisLookupV2Request { ApiKey = "apiKey", DomainName = "domainName" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DomainWhoisLookupV2Response> DomainWhoisLookupV2Async(
        DomainWhoisLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DomainWhoisLookupV2Response>(
            DomainWhoisLookupV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns the current WHOIS record for each requested domain, in request order. Supports up to 100 domain names per request; a domain that fails to resolve yields an error item instead of failing the whole batch.
    /// </summary>
    /// <example><code>
    /// await client.BulkDomainWhoisLookupV2Async(
    ///     new BulkDomainWhoisLookupV2Request
    ///     {
    ///         ApiKey = "apiKey",
    ///         DomainNames = new List&lt;string&gt;() { "domainNames" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkDomainWhoisLookupV2Response> BulkDomainWhoisLookupV2Async(
        BulkDomainWhoisLookupV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkDomainWhoisLookupV2Response>(
            BulkDomainWhoisLookupV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns the current live price for the requested commodity symbols. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
    /// </summary>
    /// <example><code>
    /// await client.CommodityLatestRatesV2Async(
    ///     new CommodityLatestRatesV2Request
    ///     {
    ///         ApiKey = "apiKey",
    ///         Symbols = new List&lt;string&gt;() { "symbols" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommodityLatestRatesV2Response> CommodityLatestRatesV2Async(
        CommodityLatestRatesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommodityLatestRatesV2Response>(
            CommodityLatestRatesV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns OHLC price data for the requested commodity symbols on a specific date. Falls back to the nearest earlier rate if none exists for the exact date. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
    /// </summary>
    /// <example><code>
    /// await client.CommodityHistoricalRatesV2Async(
    ///     new CommodityHistoricalRatesV2Request
    ///     {
    ///         ApiKey = "apiKey",
    ///         Symbols = new List&lt;string&gt;() { "symbols" },
    ///         Date = new DateOnly(2023, 1, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommodityHistoricalRatesV2Response> CommodityHistoricalRatesV2Async(
        CommodityHistoricalRatesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommodityHistoricalRatesV2Response>(
            CommodityHistoricalRatesV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns price fluctuation metrics (start, end, change, percent change) for the requested commodity symbols over a date range. For monthly-updated commodities the range snaps to month boundaries. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
    /// </summary>
    /// <example><code>
    /// await client.CommodityFluctuationV2Async(
    ///     new CommodityFluctuationV2Request
    ///     {
    ///         ApiKey = "apiKey",
    ///         Symbols = new List&lt;string&gt;() { "symbols" },
    ///         StartDate = new DateOnly(2023, 1, 15),
    ///         EndDate = new DateOnly(2023, 1, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommodityFluctuationV2Response> CommodityFluctuationV2Async(
        CommodityFluctuationV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommodityFluctuationV2Response>(
            CommodityFluctuationV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns day-by-day OHLC data for the requested commodity symbols within a date range, indexed by date. Non-trading days are excluded. Unresolved symbols degrade to a 206 partial response instead of failing the whole request.
    /// </summary>
    /// <example><code>
    /// await client.CommodityTimeSeriesV2Async(
    ///     new CommodityTimeSeriesV2Request
    ///     {
    ///         ApiKey = "apiKey",
    ///         Symbols = new List&lt;string&gt;() { "symbols" },
    ///         StartDate = new DateOnly(2023, 1, 15),
    ///         EndDate = new DateOnly(2023, 1, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommodityTimeSeriesV2Response> CommodityTimeSeriesV2Async(
        CommodityTimeSeriesV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommodityTimeSeriesV2Response>(
            CommodityTimeSeriesV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Returns the list of supported commodity symbols with metadata. Deprecated symbols stay listed with status "inactive" and a deprecationDate.
    /// </summary>
    /// <example><code>
    /// await client.CommoditySymbolsV2Async(new CommoditySymbolsV2Request { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<CommoditySymbolsV2Response> CommoditySymbolsV2Async(
        CommoditySymbolsV2Request request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommoditySymbolsV2Response>(
            CommoditySymbolsV2AsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API merges multiple PDF files into a single PDF, in the order they are provided
    /// </summary>
    /// <example><code>
    /// await client.PdfMergeAsync(new PdfMergeRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfMergeResponse> PdfMergeAsync(
        PdfMergeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfMergeResponse>(
            PdfMergeAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API removes a selection or range of pages from a PDF file.
    /// </summary>
    /// <example><code>
    /// await client.PdfRemovePagesAsync(new PdfRemovePagesRequest { ApiKey = "apiKey", Pages = "pages" });
    /// </code></example>
    public WithRawResponseTask<PdfRemovePagesResponse> PdfRemovePagesAsync(
        PdfRemovePagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfRemovePagesResponse>(
            PdfRemovePagesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API splits a PDF into multiple parts based on specified page numbers or ranges.
    /// </summary>
    /// <example><code>
    /// await client.PdfSplitAsync(new PdfSplitRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfSplitResponse> PdfSplitAsync(
        PdfSplitRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfSplitResponse>(
            PdfSplitAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API rotates pages of a PDF by a specified angle (in multiples of 90 degrees).
    /// </summary>
    /// <example><code>
    /// await client.PdfRotateAsync(new PdfRotateRequest { ApiKey = "apiKey", Rotate = 1 });
    /// </code></example>
    public WithRawResponseTask<PdfRotateResponse> PdfRotateAsync(
        PdfRotateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfRotateResponse>(
            PdfRotateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API compresses a given PDF file to reduce its file size.
    /// </summary>
    /// <example><code>
    /// await client.PdfCompressAsync(
    ///     new PdfCompressRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         CompressionLevel = PdfCompressRequestCompressionLevel.Low,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PdfCompressResponse> PdfCompressAsync(
        PdfCompressRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfCompressResponse>(
            PdfCompressAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API extracts specific pages or page ranges from a PDF file and returns them as a new PDF.
    /// </summary>
    /// <example><code>
    /// await client.PdfExtractPagesAsync(
    ///     new PdfExtractPagesRequest { ApiKey = "apiKey", Pages = "pages" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PdfExtractPagesResponse> PdfExtractPagesAsync(
        PdfExtractPagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfExtractPagesResponse>(
            PdfExtractPagesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// API endpoint that linearizes any given PDF, restructuring it for faster loading and page-by-page viewing in web browsers.
    /// </summary>
    /// <example><code>
    /// await client.PdfLinearizeAsync(new PdfLinearizeRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfLinearizeResponse> PdfLinearizeAsync(
        PdfLinearizeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfLinearizeResponse>(
            PdfLinearizeAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API encrypts a PDF file by setting a password required to open it.
    /// </summary>
    /// <example><code>
    /// await client.PdfEncryptAsync(
    ///     new PdfEncryptRequest { ApiKey = "apiKey", UserPassword = "user_password" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PdfEncryptResponse> PdfEncryptAsync(
        PdfEncryptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfEncryptResponse>(
            PdfEncryptAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API decrypts PDF files, removing all encryption, including open passwords and permission restrictions.
    /// </summary>
    /// <example><code>
    /// await client.PdfDecryptAsync(
    ///     new PdfDecryptRequest { ApiKey = "apiKey", FilePassword = "file_password" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PdfDecryptResponse> PdfDecryptAsync(
        PdfDecryptRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfDecryptResponse>(
            PdfDecryptAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API applies permission restrictions on a PDF file, such as disabling printing, copying, or editing. This can include password protection to enforce restrictions.
    /// </summary>
    /// <example><code>
    /// await client.PdfRestrictAsync(
    ///     new PdfRestrictRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         UserPassword = "user_password",
    ///         Restrictions = new List&lt;PdfRestrictRequestRestrictionsItem&gt;()
    ///         {
    ///             PdfRestrictRequestRestrictionsItem.PrintHigh,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PdfRestrictResponse> PdfRestrictAsync(
        PdfRestrictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfRestrictResponse>(
            PdfRestrictAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API removes permission restrictions from a PDF while keeping it encrypted. If you want to remove all security (including encryption), use the `/pdf/decrypt` endpoint instead.
    /// </summary>
    /// <example><code>
    /// await client.PdfUnrestrictAsync(
    ///     new PdfUnrestrictRequest { ApiKey = "apiKey", FilePassword = "file_password" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PdfUnrestrictResponse> PdfUnrestrictAsync(
        PdfUnrestrictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfUnrestrictResponse>(
            PdfUnrestrictAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API converts a given PDF file into a sequence of PNG images.
    /// </summary>
    /// <example><code>
    /// await client.PdfConvertToPngAsync(new PdfConvertToPngRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfConvertToPngResponse> PdfConvertToPngAsync(
        PdfConvertToPngRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfConvertToPngResponse>(
            PdfConvertToPngAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API converts a given PDF file into a sequence of JPG images.
    /// </summary>
    /// <example><code>
    /// await client.PdfConvertToJpgAsync(new PdfConvertToJpgRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfConvertToJpgResponse> PdfConvertToJpgAsync(
        PdfConvertToJpgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfConvertToJpgResponse>(
            PdfConvertToJpgAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API converts a given PDF file into a sequence of TIFF images. The output images can be saved as a single TIFF file, or as a sequence of TIFF files.
    /// </summary>
    /// <example><code>
    /// await client.PdfConvertToTiffAsync(new PdfConvertToTiffRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfConvertToTiffResponse> PdfConvertToTiffAsync(
        PdfConvertToTiffRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfConvertToTiffResponse>(
            PdfConvertToTiffAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Converts a PDF file to a BMP image.
    /// </summary>
    /// <example><code>
    /// await client.PdfConvertToBmpAsync(new PdfConvertToBmpRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfConvertToBmpResponse> PdfConvertToBmpAsync(
        PdfConvertToBmpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfConvertToBmpResponse>(
            PdfConvertToBmpAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API converts a given PDF file into a sequence of GIF images.
    /// </summary>
    /// <example><code>
    /// await client.PdfConvertToGifAsync(new PdfConvertToGifRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfConvertToGifResponse> PdfConvertToGifAsync(
        PdfConvertToGifRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfConvertToGifResponse>(
            PdfConvertToGifAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API uploads multiple PDF files to the API Freaks server and generates their unique file IDs.
    /// </summary>
    /// <example><code>
    /// await client.PdfUploadResourcesAsync(new PdfUploadResourcesRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfUploadResourcesResponse> PdfUploadResourcesAsync(
        PdfUploadResourcesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfUploadResourcesResponse>(
            PdfUploadResourcesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API uploads PDF files to the API Freaks server in binary format.
    /// </summary>
    public WithRawResponseTask<PdfUploadBinaryResponse> PdfUploadBinaryAsync(
        PdfUploadBinaryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfUploadBinaryResponse>(
            PdfUploadBinaryAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API downloads PDF files or ZIP archives from the server using their unique resource ID.
    /// </summary>
    /// <example><code>
    /// await client.PdfDownloadResourceAsync(
    ///     new PdfDownloadResourceRequest { ApiKey = "apiKey", ResourceId = "resource_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<global::System.IO.Stream> PdfDownloadResourceAsync(
        PdfDownloadResourceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<global::System.IO.Stream>(
            PdfDownloadResourceAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API checks the status of a previously initiated PDF processing task using its unique task ID.
    /// </summary>
    /// <example><code>
    /// await client.PdfGetTaskStatusAsync(
    ///     new PdfGetTaskStatusRequest { ApiKey = "apiKey", TaskId = "task_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PdfGetTaskStatusResponse> PdfGetTaskStatusAsync(
        PdfGetTaskStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfGetTaskStatusResponse>(
            PdfGetTaskStatusAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API checks the status of a PDF file using its unique file ID, providing information about its creation and potential deletion time.
    /// </summary>
    /// <example><code>
    /// await client.PdfGetFileStatusAsync(
    ///     new PdfGetFileStatusRequest { ApiKey = "apiKey", FileId = "file_id" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PdfGetFileStatusResponse> PdfGetFileStatusAsync(
        PdfGetFileStatusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfGetFileStatusResponse>(
            PdfGetFileStatusAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API retrieves a list of all PDF files uploaded and generated by a specific user. Please note that if the user is part of an organization, only the Organization Administrator can access this endpoint. Organization Members cannot access this endpoint.
    /// </summary>
    /// <example><code>
    /// await client.PdfListFilesAsync(new PdfListFilesRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<PdfListFilesResponse> PdfListFilesAsync(
        PdfListFilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfListFilesResponse>(
            PdfListFilesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API deletes a PDF file using its unique file ID.
    /// </summary>
    /// <example><code>
    /// await client.PdfDeleteFileAsync(new PdfDeleteFileRequest { ApiKey = "apiKey", FileId = "file_id" });
    /// </code></example>
    public WithRawResponseTask<PdfDeleteFileResponse> PdfDeleteFileAsync(
        PdfDeleteFileRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PdfDeleteFileResponse>(
            PdfDeleteFileAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Capture full-page screenshots and videos of websites with advanced options like device simulation, custom code injection, cookie banner blocking, and scrollable content recording.
    /// Supports multiple output formats including JSON, image, GIF, MP4, and WebM.
    /// </summary>
    /// <example><code>
    /// await client.ScreenshotCaptureAsync(
    ///     new ScreenshotCaptureRequest { ApiKey = "apiKey", Url = "url" }
    /// );
    /// </code></example>
    public WithRawResponseTask<global::System.IO.Stream> ScreenshotCaptureAsync(
        ScreenshotCaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<global::System.IO.Stream>(
            ScreenshotCaptureAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Our Bulk Screenshot API allows you to capture screenshots of multiple webpages simultaneously, saving you time and effort. Instead of manually capturing each page one by one, you can batch process URLs and receive high-quality screenshots in the format you choose.
    ///  Maximum `50 URLs` per request.
    /// </summary>
    /// <example><code>
    /// await client.BulkScreenshotCaptureAsync(
    ///     new BulkScreenshotCaptureRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Urls = new List&lt;BulkScreenshotCaptureRequestUrlsItem&gt;()
    ///         {
    ///             new BulkScreenshotCaptureRequestUrlsItem { Url = "url" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkScreenshotCaptureResponse> BulkScreenshotCaptureAsync(
        BulkScreenshotCaptureRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkScreenshotCaptureResponse>(
            BulkScreenshotCaptureAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get live forex rates for all world currencies with customizable update frequency
    /// </summary>
    /// <example><code>
    /// await client.CurrencyLatestRatesAsync(new CurrencyLatestRatesRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<CurrencyLatestRatesResponse> CurrencyLatestRatesAsync(
        CurrencyLatestRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencyLatestRatesResponse>(
            CurrencyLatestRatesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get historical exchange rates for any specific date
    /// </summary>
    /// <example><code>
    /// await client.CurrencyHistoricalRatesAsync(
    ///     new CurrencyHistoricalRatesRequest { ApiKey = "apiKey", Date = new DateOnly(2023, 1, 15) }
    /// );
    /// </code></example>
    public WithRawResponseTask<CurrencyHistoricalRatesResponse> CurrencyHistoricalRatesAsync(
        CurrencyHistoricalRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencyHistoricalRatesResponse>(
            CurrencyHistoricalRatesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Convert amount between currencies using the latest exchange rates
    /// </summary>
    /// <example><code>
    /// await client.CurrencyConvertLatestAsync(
    ///     new CurrencyConvertLatestRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         From = "from",
    ///         To = "to",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CurrencyConvertLatestResponse> CurrencyConvertLatestAsync(
        CurrencyConvertLatestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencyConvertLatestResponse>(
            CurrencyConvertLatestAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Convert amount between currencies using historical rates
    /// </summary>
    /// <example><code>
    /// await client.CurrencyConvertHistoricalAsync(
    ///     new CurrencyConvertHistoricalRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         From = "from",
    ///         To = "to",
    ///         Date = new DateOnly(2023, 1, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CurrencyConvertHistoricalResponse> CurrencyConvertHistoricalAsync(
        CurrencyConvertHistoricalRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencyConvertHistoricalResponse>(
            CurrencyConvertHistoricalAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get exchange rates for a time range
    /// </summary>
    /// <example><code>
    /// await client.CurrencyTimeSeriesAsync(
    ///     new CurrencyTimeSeriesRequest { ApiKey = "apiKey", StartDate = new DateOnly(2023, 1, 15) }
    /// );
    /// </code></example>
    public WithRawResponseTask<CurrencyTimeSeriesResponse> CurrencyTimeSeriesAsync(
        CurrencyTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencyTimeSeriesResponse>(
            CurrencyTimeSeriesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get currency fluctuation data for a time period
    /// </summary>
    /// <example><code>
    /// await client.CurrencyFluctuationAsync(
    ///     new CurrencyFluctuationRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         StartDate = new DateOnly(2023, 1, 15),
    ///         Base = "USD",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CurrencyFluctuationResponse> CurrencyFluctuationAsync(
        CurrencyFluctuationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencyFluctuationResponse>(
            CurrencyFluctuationAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Convert amount using user's location
    /// </summary>
    /// <example><code>
    /// await client.CurrencyConvertByIpAsync(
    ///     new CurrencyConvertByIpRequest { ApiKey = "apiKey", From = "from" }
    /// );
    /// </code></example>
    public WithRawResponseTask<CurrencyConvertByIpResponse> CurrencyConvertByIpAsync(
        CurrencyConvertByIpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencyConvertByIpResponse>(
            CurrencyConvertByIpAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get list of all supported currencies with their metadata
    /// </summary>
    /// <example><code>
    /// await client.CurrencySupportedAsync(new CurrencySupportedRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<CurrencySupportedResponse> CurrencySupportedAsync(
        CurrencySupportedRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencySupportedResponse>(
            CurrencySupportedAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get currency symbols and codes
    /// </summary>
    /// <example><code>
    /// await client.CurrencySymbolsAsync(new CurrencySymbolsRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<CurrencySymbolsResponse> CurrencySymbolsAsync(
        CurrencySymbolsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencySymbolsResponse>(
            CurrencySymbolsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get information about historical data availability and limits
    /// </summary>
    /// <example><code>
    /// await client.CurrencyHistoricalLimitsAsync(
    ///     new CurrencyHistoricalLimitsRequest { ApiKey = "apiKey" }
    /// );
    /// </code></example>
    public WithRawResponseTask<CurrencyHistoricalLimitsResponse> CurrencyHistoricalLimitsAsync(
        CurrencyHistoricalLimitsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrencyHistoricalLimitsResponse>(
            CurrencyHistoricalLimitsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get live commodity rates with customizable update frequency
    /// </summary>
    /// <example><code>
    /// await client.CommodityLatestRatesAsync(
    ///     new CommodityLatestRatesRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Symbols = new List&lt;string&gt;() { "symbols" },
    ///         Updates = CommodityLatestRatesRequestUpdates.TenM,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommodityLatestRatesResponse> CommodityLatestRatesAsync(
        CommodityLatestRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommodityLatestRatesResponse>(
            CommodityLatestRatesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get historical commodity rates for a specific date
    /// </summary>
    /// <example><code>
    /// await client.CommodityHistoricalRatesAsync(
    ///     new CommodityHistoricalRatesRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Date = new DateOnly(2023, 1, 15),
    ///         Symbols = new List&lt;string&gt;() { "symbols" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommodityHistoricalRatesResponse> CommodityHistoricalRatesAsync(
        CommodityHistoricalRatesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommodityHistoricalRatesResponse>(
            CommodityHistoricalRatesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get commodity price fluctuation data for a time period
    /// </summary>
    /// <example><code>
    /// await client.CommodityFluctuationAsync(
    ///     new CommodityFluctuationRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Symbols = new List&lt;string&gt;() { "symbols" },
    ///         StartDate = new DateOnly(2023, 1, 15),
    ///         EndDate = new DateOnly(2023, 1, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommodityFluctuationResponse> CommodityFluctuationAsync(
        CommodityFluctuationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommodityFluctuationResponse>(
            CommodityFluctuationAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get commodity rates for a time range
    /// </summary>
    /// <example><code>
    /// await client.CommodityTimeSeriesAsync(
    ///     new CommodityTimeSeriesRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Symbols = new List&lt;string&gt;() { "symbols" },
    ///         StartDate = new DateOnly(2023, 1, 15),
    ///         EndDate = new DateOnly(2023, 1, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CommodityTimeSeriesResponse> CommodityTimeSeriesAsync(
        CommodityTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommodityTimeSeriesResponse>(
            CommodityTimeSeriesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get list of supported commodities
    /// </summary>
    /// <example><code>
    /// await client.CommoditySymbolsAsync(new CommoditySymbolsRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<CommoditySymbolsResponse> CommoditySymbolsAsync(
        CommoditySymbolsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CommoditySymbolsResponse>(
            CommoditySymbolsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves a list of supported countries.
    /// </summary>
    /// <example><code>
    /// await client.VatSupportedCountriesAsync(new VatSupportedCountriesRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<VatSupportedCountriesResponse> VatSupportedCountriesAsync(
        VatSupportedCountriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<VatSupportedCountriesResponse>(
            VatSupportedCountriesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Fetches VAT rate based on the specified or originating IP address.
    /// </summary>
    /// <example><code>
    /// await client.VatRateByIpAsync(new VatRateByIpRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<IEnumerable<VatRateByIpResponseItem>> VatRateByIpAsync(
        VatRateByIpRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<VatRateByIpResponseItem>>(
            VatRateByIpAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Fetches VAT rates for a single country or state provided via query parameters.
    /// </summary>
    /// <example><code>
    /// await client.VatRateByCountryAsync(
    ///     new VatRateByCountryRequest { ApiKey = "apiKey", Country = "country" }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<VatRateByCountryResponseItem>> VatRateByCountryAsync(
        VatRateByCountryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<VatRateByCountryResponseItem>>(
            VatRateByCountryAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves VAT details for multiple countries or country-state combinations in a single request. Maximum of `100` entries per request are allowed.
    /// </summary>
    /// <example><code>
    /// await client.BulkVatRateByCountryAsync(
    ///     new BulkVatRateByCountryRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Countries = new List&lt;BulkVatRateByCountryRequestCountriesItem&gt;()
    ///         {
    ///             new BulkVatRateByCountryRequestCountriesItem { Country = "PAK" },
    ///             new BulkVatRateByCountryRequestCountriesItem
    ///             {
    ///                 Country = "United_States",
    ///                 State = "New_York",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkVatRateByCountryResponse> BulkVatRateByCountryAsync(
        BulkVatRateByCountryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkVatRateByCountryResponse>(
            BulkVatRateByCountryAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Validates an EU or UK VAT number and returns registration status details.
    /// </summary>
    /// <example><code>
    /// await client.VatValidateAsync(
    ///     new VatValidateRequest { ApiKey = "apiKey", VatNumber = "vatNumber" }
    /// );
    /// </code></example>
    public WithRawResponseTask<VatValidateResponse> VatValidateAsync(
        VatValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<VatValidateResponse>(
            VatValidateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Checks an IBAN for structural validity, checksum accuracy, and bank metadata.
    /// </summary>
    /// <example><code>
    /// await client.IbanValidateAsync(new IbanValidateRequest { ApiKey = "apiKey", Iban = "iban" });
    /// </code></example>
    public WithRawResponseTask<IbanValidateResponse> IbanValidateAsync(
        IbanValidateRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IbanValidateResponse>(
            IbanValidateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Fetches SWIFT codes for a given country, bank, and city.
    /// </summary>
    /// <example><code>
    /// await client.SwiftCodeFindAsync(new SwiftCodeFindRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<IEnumerable<string>> SwiftCodeFindAsync(
        SwiftCodeFindRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<string>>(
            SwiftCodeFindAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Fetches detailed information about a SWIFT code.
    /// </summary>
    /// <example><code>
    /// await client.SwiftCodeLookupAsync(
    ///     new SwiftCodeLookupRequest { ApiKey = "apiKey", SwiftCode = "swiftCode" }
    /// );
    /// </code></example>
    public WithRawResponseTask<SwiftCodeLookupResponse> SwiftCodeLookupAsync(
        SwiftCodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SwiftCodeLookupResponse>(
            SwiftCodeLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.ZipcodeLookupAsync(new ZipcodeLookupRequest { ApiKey = "apiKey", Code = "code" });
    /// </code></example>
    public WithRawResponseTask<ZipcodeLookupResponse> ZipcodeLookupAsync(
        ZipcodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ZipcodeLookupResponse>(
            ZipcodeLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Validates a bulk of ZIP/postal codes and returns result for each. Maximum `100` ZIP/postal codes per request.
    /// </summary>
    /// <example><code>
    /// await client.BulkZipcodeLookupAsync(
    ///     new BulkZipcodeLookupRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Codes = new List&lt;string&gt;() { "codes" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkZipcodeLookupResponse> BulkZipcodeLookupAsync(
        BulkZipcodeLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkZipcodeLookupResponse>(
            BulkZipcodeLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.ZipcodeSearchByCityAsync(
    ///     new ZipcodeSearchByCityRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         City = "city",
    ///         Country = "country",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ZipcodeSearchByCityResponse> ZipcodeSearchByCityAsync(
        ZipcodeSearchByCityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ZipcodeSearchByCityResponse>(
            ZipcodeSearchByCityAsyncCore(request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.ZipcodeSearchByRegionAsync(
    ///     new ZipcodeSearchByRegionRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Country = "country",
    ///         Region = "region",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ZipcodeSearchByRegionResponse> ZipcodeSearchByRegionAsync(
        ZipcodeSearchByRegionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ZipcodeSearchByRegionResponse>(
            ZipcodeSearchByRegionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.ZipcodeSearchByRadiusAsync(
    ///     new ZipcodeSearchByRadiusRequest { ApiKey = "apiKey", Radius = 1.1f }
    /// );
    /// </code></example>
    public WithRawResponseTask<ZipcodeSearchByRadiusResponse> ZipcodeSearchByRadiusAsync(
        ZipcodeSearchByRadiusRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ZipcodeSearchByRadiusResponse>(
            ZipcodeSearchByRadiusAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get distance between postal codes. Maximum `100` postal codes per request.
    /// </summary>
    /// <example><code>
    /// await client.ZipcodeDistanceAsync(
    ///     new ZipcodeDistanceRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Compare = new List&lt;string&gt;() { "compare" },
    ///         Country = "country",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ZipcodeDistanceResponse> ZipcodeDistanceAsync(
        ZipcodeDistanceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ZipcodeDistanceResponse>(
            ZipcodeDistanceAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get matching ZIP/postal code pairs within a specified distance. Maximum `100` postal codes per request.
    /// </summary>
    /// <example><code>
    /// await client.ZipcodeDistanceMatchAsync(
    ///     new ZipcodeDistanceMatchRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Codes = new List&lt;string&gt;() { "codes" },
    ///         Country = "country",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ZipcodeDistanceMatchResponse> ZipcodeDistanceMatchAsync(
        ZipcodeDistanceMatchRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ZipcodeDistanceMatchResponse>(
            ZipcodeDistanceMatchAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get current weather data including temperature, humidity, precipitation, wind conditions, atmospheric pressure, and air quality for any location. Accepts city names, coordinates, or IP addresses. Also includes astronomy data and timezone-aware timestamps.
    /// </summary>
    /// <example><code>
    /// await client.CurrentWeatherAsync(new CurrentWeatherRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<CurrentWeatherResponse> CurrentWeatherAsync(
        CurrentWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CurrentWeatherResponse>(
            CurrentWeatherAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve current weather conditions for up to `50 locations` in a single request. A maximum of 50 locations (city names, IP addresses, or geographic coordinates) can be included in the request body.
    /// </summary>
    /// <example><code>
    /// await client.BulkCurrentWeatherAsync(
    ///     new BulkCurrentWeatherRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Locations = new List&lt;BulkCurrentWeatherRequestLocationsItem&gt;()
    ///         {
    ///             new BulkCurrentWeatherRequestLocationsItem { Location = "lahore" },
    ///             new BulkCurrentWeatherRequestLocationsItem { Lat = 32.5, Long = 74.5 },
    ///             new BulkCurrentWeatherRequestLocationsItem { Ip = "8.8.8.8" },
    ///             new BulkCurrentWeatherRequestLocationsItem { Location = "seoul" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<BulkCurrentWeatherResponse> BulkCurrentWeatherAsync(
        BulkCurrentWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<BulkCurrentWeatherResponse>(
            BulkCurrentWeatherAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Access comprehensive weather forecasts with customizable precision - choose from daily overviews, hourly breakdowns, or even minute-by-minute data. Configure your date ranges or use the default 7-day forecast for standard weather planning.
    /// </summary>
    /// <example><code>
    /// await client.WeatherForecastAsync(new WeatherForecastRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<WeatherForecastResponse> WeatherForecastAsync(
        WeatherForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WeatherForecastResponse>(
            WeatherForecastAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Access past weather conditions for specific dates with records going back to 1940. Retrieve comprehensive historical data with both daily and hourly precision options.
    /// </summary>
    /// <example><code>
    /// await client.HistoricalWeatherAsync(
    ///     new HistoricalWeatherRequest { ApiKey = "apiKey", Date = new DateOnly(2023, 1, 15) }
    /// );
    /// </code></example>
    public WithRawResponseTask<HistoricalWeatherResponse> HistoricalWeatherAsync(
        HistoricalWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<HistoricalWeatherResponse>(
            HistoricalWeatherAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Pull historical weather information for date ranges up to 90 days (daily data) or 7 days (hourly data). Get consistent formatting across your specified date range with reliable historical weather patterns.
    /// </summary>
    /// <example><code>
    /// await client.WeatherTimeSeriesAsync(
    ///     new WeatherTimeSeriesRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         StartDate = new DateOnly(2023, 1, 15),
    ///         EndDate = new DateOnly(2023, 1, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<WeatherTimeSeriesResponse> WeatherTimeSeriesAsync(
        WeatherTimeSeriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WeatherTimeSeriesResponse>(
            WeatherTimeSeriesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Provides hourly forecasts of marine conditions including wave heights, wave directions, wave periods, swell info, sea surface temperatures, and ocean currents. Supports multiple geographical points and returns daily max wave statistics for up to 7 days. Ideal for maritime planning, navigation, and coastal activities.
    /// </summary>
    /// <example><code>
    /// await client.MarineWeatherAsync(new MarineWeatherRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<MarineWeatherResponse> MarineWeatherAsync(
        MarineWeatherRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<MarineWeatherResponse>(
            MarineWeatherAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Monitor and predict air quality conditions using European and US AQI standards. Track pollutant concentrations including PM10, PM2.5, carbon monoxide, nitrogen dioxide, sulfur dioxide, ozone, and dust particles. Get current readings plus hourly forecasts up to 5 days ahead, complete with UV index and aerosol measurements for comprehensive air quality assessment.
    /// </summary>
    /// <example><code>
    /// await client.AirQualityAsync(new AirQualityRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<AirQualityResponse> AirQualityAsync(
        AirQualityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AirQualityResponse>(
            AirQualityAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Provides flood forecast data for a given location, including river discharge metrics such as mean, median, maximum, minimum, and percentile values (p25, p75). Requires a startDate and endDate, with the date range limited to 16 days. Location can be specified using city name, latitude/longitude, or IP address.
    /// </summary>
    /// <example><code>
    /// await client.FloodForecastAsync(
    ///     new FloodForecastRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         StartDate = new DateOnly(2023, 1, 15),
    ///         EndDate = new DateOnly(2023, 1, 15),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<FloodForecastResponse> FloodForecastAsync(
        FloodForecastRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<FloodForecastResponse>(
            FloodForecastAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve countries, optionally filtered by region or subregion.
    /// </summary>
    /// <example><code>
    /// await client.GetCountriesAsync(new GetCountriesRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<GetCountriesResponse> GetCountriesAsync(
        GetCountriesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetCountriesResponse>(
            GetCountriesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.GetCountryDetailsAsync(
    ///     new GetCountryDetailsRequest { ApiKey = "apiKey", Country = "country" }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetCountryDetailsResponse> GetCountryDetailsAsync(
        GetCountryDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetCountryDetailsResponse>(
            GetCountryDetailsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.GetRegionsAsync(new GetRegionsRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<GetRegionsResponse> GetRegionsAsync(
        GetRegionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetRegionsResponse>(
            GetRegionsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <example><code>
    /// await client.GetSubregionsAsync(new GetSubregionsRequest { ApiKey = "apiKey", Region = "region" });
    /// </code></example>
    public WithRawResponseTask<GetSubregionsResponse> GetSubregionsAsync(
        GetSubregionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetSubregionsResponse>(
            GetSubregionsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve administrative units based on ISO 3166-1 alpha-2 country code.
    /// </summary>
    /// <example><code>
    /// await client.GetAdminLevelsAsync(
    ///     new GetAdminLevelsRequest { ApiKey = "apiKey", Country = "country" }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetAdminLevelsResponse> GetAdminLevelsAsync(
        GetAdminLevelsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetAdminLevelsResponse>(
            GetAdminLevelsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve administrative divisions for a given country using ISO 3166-1 alpha-2 country codes. You can optionally filter by administrative levels.
    /// </summary>
    /// <example><code>
    /// await client.GetAdminUnitsAsync(
    ///     new GetAdminUnitsRequest { ApiKey = "apiKey", Country = "country" }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetAdminUnitsResponse> GetAdminUnitsAsync(
        GetAdminUnitsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetAdminUnitsResponse>(
            GetAdminUnitsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve detailed administrative unit information by country and optionally filtered by admin code.
    /// </summary>
    /// <example><code>
    /// await client.GetAdminUnitDetailsAsync(
    ///     new GetAdminUnitDetailsRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Country = "country",
    ///         AdminUnit = "admin_unit",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetAdminUnitDetailsResponse> GetAdminUnitDetailsAsync(
        GetAdminUnitDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetAdminUnitDetailsResponse>(
            GetAdminUnitDetailsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve a list of cities within a country, optionally filtered by an administrative unit code.
    /// </summary>
    /// <example><code>
    /// await client.GetCitiesAsync(new GetCitiesRequest { ApiKey = "apiKey", Country = "country" });
    /// </code></example>
    public WithRawResponseTask<GetCitiesResponse> GetCitiesAsync(
        GetCitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetCitiesResponse>(
            GetCitiesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get list of all supported flags with their metadata
    /// </summary>
    /// <example><code>
    /// await client.GetSupportedFlagsAsync(new GetSupportedFlagsRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<IEnumerable<GetSupportedFlagsResponseItem>> GetSupportedFlagsAsync(
        GetSupportedFlagsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<GetSupportedFlagsResponseItem>>(
            GetSupportedFlagsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve the flag for a specific country
    /// </summary>
    /// <example><code>
    /// await client.GetFlagsAsync(
    ///     new GetFlagsRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Name = "name",
    ///         Shape = GetFlagsRequestShape.Flat,
    ///         Type = GetFlagsRequestType.Country,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<global::System.IO.Stream> GetFlagsAsync(
        GetFlagsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<global::System.IO.Stream>(
            GetFlagsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve current time, date, and timezone-related information by specifying a timezone name, location address, location coordinates, IP address, or use the client IP address if no parameter is passed.
    /// </summary>
    /// <example><code>
    /// await client.TimezoneLookupAsync(new TimezoneLookupRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<TimezoneLookupResponse> TimezoneLookupAsync(
        TimezoneLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TimezoneLookupResponse>(
            TimezoneLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Converts a given time from one timezone to another using various input types like timezone name, coordinates, location, or codes.
    /// </summary>
    /// <example><code>
    /// await client.TimezoneConvertAsync(new TimezoneConvertRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<TimezoneConvertResponse> TimezoneConvertAsync(
        TimezoneConvertRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TimezoneConvertResponse>(
            TimezoneConvertAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Parse User Agent string to get detailed browser, device, and operating system information
    /// </summary>
    /// <example><code>
    /// await client.UserAgentLookupAsync(new UserAgentLookupRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<UserAgentLookupResponse> UserAgentLookupAsync(
        UserAgentLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UserAgentLookupResponse>(
            UserAgentLookupAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Parse up to `50,000 User-Agent strings` at once in a single request.
    /// </summary>
    /// <example><code>
    /// await client.BulkUserAgentLookupAsync(
    ///     new BulkUserAgentLookupRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         UaStrings = new List&lt;string&gt;() { "uaStrings" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        IEnumerable<BulkUserAgentLookupResponseItem>
    > BulkUserAgentLookupAsync(
        BulkUserAgentLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<BulkUserAgentLookupResponseItem>>(
            BulkUserAgentLookupAsyncCore(request, options, cancellationToken)
        );
    }

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
    /// <example><code>
    /// await client.OcrPredictAsync(
    ///     new OcrPredictRequest { ApiKey = "apiKey", Model = OcrPredictRequestModel.MiniOcrV1 }
    /// );
    /// </code></example>
    public WithRawResponseTask<OcrPredictResponse> OcrPredictAsync(
        OcrPredictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<OcrPredictResponse>(
            OcrPredictAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Analyze text for grammar errors and return the exact words flagged as grammatically incorrect with zero-based word positions.
    /// </summary>
    /// <example><code>
    /// await client.GrammarDetectAsync(
    ///     new GrammarDetectRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Text =
    ///             "The global mental is health crisis is now a serious and compelex problem. It need quick and ongoing action from policymakers, healthcare workers, and the whole society.",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GrammarDetectResponse> GrammarDetectAsync(
        GrammarDetectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GrammarDetectResponse>(
            GrammarDetectAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Submit text with grammatical issues and receive a clean grammar-corrected result for proofreading and content workflows.
    /// </summary>
    /// <example><code>
    /// await client.GrammarCorrectAsync(
    ///     new GrammarCorrectRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Text =
    ///             "The global mental is health crisis is now a serious and compelex problem. It need quick and ongoing action from policymakers, healthcare workers, and the whole society.",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GrammarCorrectResponse> GrammarCorrectAsync(
        GrammarCorrectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GrammarCorrectResponse>(
            GrammarCorrectAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Analyze text and return weak, vague, or filler words with zero-based word positions to help writers produce clearer and more concise content.
    /// </summary>
    /// <example><code>
    /// await client.WeakWordsDetectAsync(
    ///     new WeakWordsDetectRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Text = "Many people cannot get the support they need to handle their conditions well.",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<WeakWordsDetectResponse> WeakWordsDetectAsync(
        WeakWordsDetectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WeakWordsDetectResponse>(
            WeakWordsDetectAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Analyze text readability using industry-standard formulas including Flesch Reading Ease, Flesch-Kincaid Grade Level, Gunning Fog Index, SMOG Index, Coleman-Liau Index, and Automated Readability Index.
    /// </summary>
    /// <example><code>
    /// await client.ReadabilityScoreAsync(
    ///     new ReadabilityScoreRequest
    ///     {
    ///         ApiKey = "apiKey",
    ///         Text =
    ///             "The global mental is health crisis is now a serious and compelex problem. It needs quick and ongoing action from policymakers, healthcare workers, and the whole society.",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ReadabilityScoreResponse> ReadabilityScoreAsync(
        ReadabilityScoreRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ReadabilityScoreResponse>(
            ReadabilityScoreAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve sunrise and sunset times, current position of the moon, and other related information by specifying a location address, location coordinates, IP address, or using the client IP address if no parameter is passed.
    /// </summary>
    /// <example><code>
    /// await client.AstronomyLookupAsync(new AstronomyLookupRequest { ApiKey = "apiKey" });
    /// </code></example>
    public WithRawResponseTask<AstronomyLookupResponse> AstronomyLookupAsync(
        AstronomyLookupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<AstronomyLookupResponse>(
            AstronomyLookupAsyncCore(request, options, cancellationToken)
        );
    }
}
