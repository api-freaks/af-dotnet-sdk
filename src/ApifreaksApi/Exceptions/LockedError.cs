namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class LockedError(LockedErrorBody body, ApifreaksApi.RawResponse? rawResponse = null)
    : ApifreaksApiApiException("LockedError", 423, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new LockedErrorBody Body => body;
}
