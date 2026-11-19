namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(ForbiddenErrorBody body, ApifreaksApi.RawResponse? rawResponse = null)
    : ApifreaksApiApiException("ForbiddenError", 403, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ForbiddenErrorBody Body => body;
}
