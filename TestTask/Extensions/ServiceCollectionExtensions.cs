using AnnouncementWebApi.Data;
using AnnouncementWebApi.Interfaces;
using AnnouncementWebApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

namespace AnnouncementWebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    public static void RegisterCustomServices(this IServiceCollection services)
    {
        services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddScoped<IAnnouncementService, AnnouncementService>();
    }

    public static void AddBookInventoryContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionsString = configuration.GetConnectionString("TestTaskConnectionString");

        services.AddDbContext<AnnouncementInventoryDbContext>(options => options.UseSqlServer(connectionsString));
    }
}