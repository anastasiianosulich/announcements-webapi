using AnnouncementWebApi.Enums;

namespace AnnouncementWebApi.Dtos;

public record ErrorDetailsDto(string Message, ErrorType ErrorType);
