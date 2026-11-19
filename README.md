# Apifreaks .NET SDK

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=Apifreaks%2FDotnet)
[![NuGet shield](https://img.shields.io/nuget/v/ApifreaksApi)](https://www.nuget.org/packages/ApifreaksApi)

The Apifreaks .NET library provides convenient access to the Apifreaks APIs from C# and other .NET languages.

## Table of Contents

- [Installation](#installation)
- [Reference](#reference)
- [Usage](#usage)
- [Environments](#environments)
- [Errors](#errors)
- [Request Types](#request-types)
- [Advanced](#advanced)
  - [Retries](#retries)
  - [Timeouts](#timeouts)
  - [Additional Headers](#additional-headers)
  - [Additional Query String Parameters](#additional-query-string-parameters)
- [Contributing](#contributing)

## Installation

Install the package from NuGet:

```sh
dotnet add package ApifreaksApi
```

Or add it directly to your `.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="ApifreaksApi" Version="1.2.0" />
</ItemGroup>
```

## Reference

A full reference for this library is available [here](./reference.md).

## Usage

Instantiate and use the client with the following:

```csharp
using ApifreaksApi;

var client = new ApifreaksApiClient();

var request = new GeolocationLookupRequest
{
    ApiKey = "your_api_key",
    Ip = "8.8.8.8",
};

var response = await client.GeolocationLookupAsync(request);

Console.WriteLine(response);
```

## Environments

This SDK allows you to configure the API base URL through `ClientOptions`.

```csharp
using ApifreaksApi;

var client = new ApifreaksApiClient(
    new ClientOptions
    {
        BaseUrl = ApifreaksApiEnvironment.Default,
    }
);
```

## Errors

When the API returns a non-success status code, the SDK throws an exception.

```csharp
using ApifreaksApi;

try
{
    var response = await client.GeolocationLookupAsync(
        new GeolocationLookupRequest
        {
            ApiKey = "your_api_key",
            Ip = "8.8.8.8",
        }
    );

    Console.WriteLine(response);
}
catch (ApifreaksApiApiException e)
{
    Console.WriteLine($"API error {e.StatusCode}: {e.Body}");
}
catch (ApifreaksApiException e)
{
    Console.WriteLine($"SDK error: {e.Message}");
}
```

> **Note:** `GetCreditsUsageAsync` requires an organization admin API key. Other keys get a 403 (`ForbiddenError`).

## Request Types

The SDK exports request and response types in the `ApifreaksApi` namespace.

```csharp
using ApifreaksApi;

var request = new GeolocationLookupRequest
{
    ApiKey = "your_api_key",
    Ip = "8.8.8.8",
};
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. By default, the client retries retryable requests up to `2` times.

Configure retries globally:

```csharp
using ApifreaksApi;

var client = new ApifreaksApiClient(
    new ClientOptions
    {
        MaxRetries = 3,
    }
);
```

Configure retries for a single request:

```csharp
var response = await client.GeolocationLookupAsync(
    new GeolocationLookupRequest
    {
        ApiKey = "your_api_key",
        Ip = "8.8.8.8",
    },
    new RequestOptions
    {
        MaxRetries = 3,
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Configure timeouts globally:

```csharp
var client = new ApifreaksApiClient(
    new ClientOptions
    {
        Timeout = TimeSpan.FromSeconds(30),
    }
);
```

Configure a timeout for a single request:

```csharp
var response = await client.GeolocationLookupAsync(
    new GeolocationLookupRequest
    {
        ApiKey = "your_api_key",
        Ip = "8.8.8.8",
    },
    new RequestOptions
    {
        Timeout = TimeSpan.FromSeconds(30),
    }
);
```

### Additional Headers

Add custom headers globally:

```csharp
var client = new ApifreaksApiClient(
    new ClientOptions
    {
        AdditionalHeaders = new[]
        {
            new KeyValuePair<string, string?>("X-Custom-Header", "custom-value"),
        },
    }
);
```

Add custom headers for a single request:

```csharp
var response = await client.GeolocationLookupAsync(
    new GeolocationLookupRequest
    {
        ApiKey = "your_api_key",
        Ip = "8.8.8.8",
    },
    new RequestOptions
    {
        AdditionalHeaders = new[]
        {
            new KeyValuePair<string, string?>("X-Custom-Header", "custom-value"),
        },
    }
);
```

### Additional Query String Parameters

Add custom query parameters for a single request:

```csharp
var response = await client.GeolocationLookupAsync(
    new GeolocationLookupRequest
    {
        ApiKey = "your_api_key",
        Ip = "8.8.8.8",
    },
    new RequestOptions
    {
        AdditionalQueryParameters = new[]
        {
            new KeyValuePair<string, string>("filter", "active"),
            new KeyValuePair<string, string>("sort", "desc"),
        },
    }
);
```

### Raw Response Metadata

Directly awaiting a method returns the parsed response data. Use `.WithRawResponse()` when you need status code, headers, or URL metadata.

```csharp
var rawResponse = await client.GeolocationLookupAsync(
    new GeolocationLookupRequest
    {
        ApiKey = "your_api_key",
        Ip = "8.8.8.8",
    }
).WithRawResponse();

Console.WriteLine(rawResponse.RawResponse.StatusCode);
Console.WriteLine(rawResponse.Data);
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
