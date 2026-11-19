namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class GatewayTimeoutError(
    GatewayTimeoutErrorBody body,
    ApifreaksApi.RawResponse? rawResponse = null
) : ApifreaksApiApiException("GatewayTimeoutError", 504, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new GatewayTimeoutErrorBody Body => body;
}
