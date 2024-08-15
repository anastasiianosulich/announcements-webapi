using AutoMapper;
using AnnouncementWebApi.Entities;

namespace AnnouncementWebApi.MappingProfiles;

public sealed class AnnouncementProfile : Profile
{
    public AnnouncementProfile()
    {
        CreateMap<Announcement, AnnouncementDto>()!.ReverseMap();
        CreateMap<Announcement, AnnouncementDetailsDto>()
        .ForMember(dest => dest.SimilarAnnouncements, opt => opt.Ignore()); 
    }
}