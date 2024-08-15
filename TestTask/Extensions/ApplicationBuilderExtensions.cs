using AnnouncementWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementWebApi.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseAnnouncementInventoryContext(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        using var context = scope?.ServiceProvider.GetRequiredService<AnnouncementInventoryDbContext>();
        context?.Database.Migrate();
    }
}
