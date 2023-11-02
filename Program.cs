using Microsoft.OpenApi.Models;
using rest.Service;
using rest.Service.HomeService;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.File("logs/rest.txt", rollingInterval: RollingInterval.Hour)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddSwaggerGen(c=>
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Learning API",
            Description = "Record Management API",
            TermsOfService = new Uri("https://pragimtech.com"),
            Contact = new OpenApiContact
            {
                Name = "Redolf",
                Email = "redolkendrick@gmail.com",
                Url = new Uri("https://twitter.com/kudvenkat"),
            }
        }) 
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();