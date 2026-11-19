namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ProxyAuthenticationRequiredError(
    ProxyAuthenticationRequiredErrorBody body,
    ApifreaksApi.RawResponse? rawResponse = null
)
    : ApifreaksApiApiException(
        "ProxyAuthenticationRequiredError",
        407,
        body,
        rawResponse: rawResponse
    )
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ProxyAuthenticationRequiredErrorBody Body => body;
}
