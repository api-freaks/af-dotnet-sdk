namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NoResponseError(NoResponseErrorBody body, ApifreaksApi.RawResponse? rawResponse = null)
    : ApifreaksApiApiException("NoResponseError", 444, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new NoResponseErrorBody Body => body;
}
