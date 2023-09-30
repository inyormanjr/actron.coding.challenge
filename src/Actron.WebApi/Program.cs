using Actron.WebApi.services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

builder.Services.AddScoped<ActronChallengeService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v0", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "0",
        Title = "Actron Coding Challenge",
        Description = "Actron Coding Challenge - Form Largest Integer",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Ronilo Junior Yap",
            Email = "jryap20@gmail.com",
            Url = new Uri("https://github.com/inyormanjr"),
        },
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v0/swagger.json", "Actron Coding Challenge");
        c.RoutePrefix = "swagger"; 
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
