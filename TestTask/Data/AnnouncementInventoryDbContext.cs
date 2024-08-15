using AnnouncementWebApi.Entities;
using AnnouncementWebApi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementWebApi.Data;

public class AnnouncementInventoryDbContext : DbContext
{
    public AnnouncementInventoryDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
    }

    public DbSet<Announcement> Announcements { get; set; }
}
