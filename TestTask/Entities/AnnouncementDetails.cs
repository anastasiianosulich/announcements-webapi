namespace AnnouncementWebApi.Entities;

public class AnnouncementDetails: Announcement
{
    public List<Announcement> SimilarAnnouncements { get; set; }
}
