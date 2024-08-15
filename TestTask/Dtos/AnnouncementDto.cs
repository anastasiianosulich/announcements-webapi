public class AnnouncementDto
{
    public int Id { get; set; } 
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateAdded { get; set; }
}

public class AnnouncementDetailsDto : AnnouncementDto
{
    public List<AnnouncementDto> SimilarAnnouncements { get; set; }
}