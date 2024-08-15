namespace AnnouncementWebApi.Entities;

public class BaseEntity
{
    public int Id { get; set; }
}

public class Announcement : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateAdded { get; set; }
}
