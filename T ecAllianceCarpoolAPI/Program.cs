using Swashbuckle.AspNetCore.Filters;
using TecAlliance.Carpool.Business.SampleData;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TecAlliance.Carpool.Data.Interfaces;
using TecAlliance.Carpool.Data.Services;
using TecAlliance.Carpool.Business.Interfaces;
using TecAlliance.Carpool.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CarPoolAPI",
        Description = "An ASP.NET Core Web API for managing Carpools",
        TermsOfService = new Uri("https://google.com"),
        Contact = new OpenApiContact
        {
            Name = "Contact",
            Url = new Uri("https://google.com")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://google.com")
        }
    });

    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});
builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
});



builder.Services.AddScoped<ICarpoolBusinessService, CarpoolBusinessService>();
builder.Services.AddScoped<ICarpoolDataService, CarpoolDataService>();
builder.Services.AddScoped<IDriverDataService, DriverdataService>();


builder.Services.AddSingleton<DriverDtoSampleData>();
builder.Services.AddSingleton<CarpoolDtoSampleProvider>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<DriverDtoSampleData>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<CarpoolDtoSampleProvider>();
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