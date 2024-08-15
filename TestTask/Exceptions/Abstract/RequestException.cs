using System.Net;
using AnnouncementWebApi.Enums;

namespace AnnouncementWebApi.Exceptions.Abstract;

public abstract class RequestException : Exception
{
    public ErrorType ErrorType { get; }
    public HttpStatusCode StatusCode { get; }

    public RequestException(string message, ErrorType errorType, HttpStatusCode statusCode) : base(message)
    {
        ErrorType = errorType;
        StatusCode = statusCode;
    }
}