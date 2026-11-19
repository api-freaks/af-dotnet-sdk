namespace ApifreaksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class NotFoundError(object body, ApifreaksApi.RawResponse? rawResponse = null)
    : ApifreaksApiApiException("NotFoundError", 404, body, rawResponse: rawResponse);
