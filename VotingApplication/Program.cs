using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Face Recognition API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Face Recognition API V1");

        // The key part for automatic redirect to Swagger UI
        c.RoutePrefix = string.Empty; // Set route prefix to ""
    });
}

app.UseHttpsRedirection();

app.UseRouting(); // VERY IMPORTANT

app.UseAuthorization();

app.MapControllers();

app.Run();
