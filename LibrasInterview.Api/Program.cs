using LibrasInterview.Api.Middlewares;
using LibrasInterview.Application.Abstractions.Entrevistas;
using LibrasInterview.Application.Abstractions.Transcricoes;
using LibrasInterview.Application.Abstractions.Usuarios;
using LibrasInterview.Application.Services.Entrevistas;
using LibrasInterview.Application.Services.Transcricoes;
using LibrasInterview.Application.Services.Usuarios;
using LibrasInterview.Infrastructure.Persistence;
using LibrasInterview.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibrasInterviewDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEntrevistaRepository, EntrevistaRepository>();
builder.Services.AddScoped<ITranscricaoRepository, TranscricaoRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEntrevistaService, EntrevistaService>();
builder.Services.AddScoped<ITranscricaoService, TranscricaoService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200", "http://localhost:4201")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("PermitirAngular");

app.MapControllers();

app.Run();