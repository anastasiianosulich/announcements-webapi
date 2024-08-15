using AnnouncementWebApi.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementWebApi.Extensions;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnnouncementConfiguration).Assembly);
    }
}