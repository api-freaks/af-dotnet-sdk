namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class InternalServerError(
    InternalServerErrorBody body,
    ApifreaksApi.RawResponse? rawResponse = null
) : ApifreaksApiApiException("InternalServerError", 500, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new InternalServerErrorBody Body => body;
}
