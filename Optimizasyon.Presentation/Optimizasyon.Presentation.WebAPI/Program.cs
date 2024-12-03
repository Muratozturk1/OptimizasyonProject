
using Microsoft.OpenApi.Models;
using Optimizasyon.Core.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMarangozOptimizationService, MarangozOptimizationService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Optimizasyon API",
        Version = "v1",
        Description = "Optimizasyon Projesi için API"
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Optimizasyon API v1");
    });
    
    
}


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();




app.Run();

