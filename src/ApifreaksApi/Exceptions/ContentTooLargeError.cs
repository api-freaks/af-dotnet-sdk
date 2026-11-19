namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ContentTooLargeError(
    ContentTooLargeErrorBody body,
    ApifreaksApi.RawResponse? rawResponse = null
) : ApifreaksApiApiException("ContentTooLargeError", 413, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ContentTooLargeErrorBody Body => body;
}
