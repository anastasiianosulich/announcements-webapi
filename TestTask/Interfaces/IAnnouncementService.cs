namespace AnnouncementWebApi.Interfaces;

public interface IAnnouncementService
{
    Task<AnnouncementDto> AddAnnouncementAsync(AnnouncementDto anouncementDto);
    Task<AnnouncementDto> UpdateAnnouncementAsync(int announcementId, AnnouncementDto announcementDto);
    Task DeleteAnnouncementAsync(int announcementId);
    Task<AnnouncementDetailsDto> GetAnnouncementDetailsAsync(int announcementId);
    Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync();
}