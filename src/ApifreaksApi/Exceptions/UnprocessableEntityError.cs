namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnprocessableEntityError(
    UnprocessableEntityErrorBody body,
    ApifreaksApi.RawResponse? rawResponse = null
) : ApifreaksApiApiException("UnprocessableEntityError", 422, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new UnprocessableEntityErrorBody Body => body;
}
