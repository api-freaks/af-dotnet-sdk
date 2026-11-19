namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class MethodNotAllowedError(
    MethodNotAllowedErrorBody body,
    ApifreaksApi.RawResponse? rawResponse = null
) : ApifreaksApiApiException("MethodNotAllowedError", 405, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new MethodNotAllowedErrorBody Body => body;
}
