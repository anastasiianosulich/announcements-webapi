using System.Net;
using AnnouncementWebApi.Dtos;
using AnnouncementWebApi.Enums;
using AnnouncementWebApi.Exceptions.Abstract;

namespace AnnouncementWebApi.Extensions;

public static class ExceptionExtensions
{
    public static (ErrorDetailsDto, HttpStatusCode) GetErrorDetailsAndStatusCode(this Exception exception)
    {
        return exception switch
        {
            RequestException e => (new ErrorDetailsDto(e.Message, e.ErrorType), e.StatusCode),
            _ => (new ErrorDetailsDto(exception.Message, ErrorType.Internal), HttpStatusCode.InternalServerError)
        };
    }
}