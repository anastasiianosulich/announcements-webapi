using AnnouncementWebApi.Extensions;
using AnnouncementWebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddBookInventoryContext(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterCustomServices();

builder.Services.AddAutoMapper();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<GenericExceptionHandler>();

app.UseAnnouncementInventoryContext();

app.UseCors(opt => opt
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
