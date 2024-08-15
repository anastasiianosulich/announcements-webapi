using AnnouncementWebApi.Exceptions.Abstract;
using AnnouncementWebApi.Enums;
using System.Net;

namespace AnnouncementWebApi.Exceptions;

public sealed class EntityNotFoundException : RequestException
{
    public EntityNotFoundException() : base("Entity not found.", ErrorType.EntityNotFound, HttpStatusCode.BadRequest)
    {
    }
}