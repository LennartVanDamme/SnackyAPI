using FluentValidation;
using FluentValidation.AspNetCore;
using SnackyAPI.Models.DTO.Profiles;
using SnackyAPI.Models.Validation;
using SnackyAPI.Repositories;
using SnackyAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<SnackCreationValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<SnackyDbContext>();

builder.Services.AddScoped<ISnacksService, SnacksService>();
builder.Services.AddScoped<ISnacksRepository, SnacksRepository>();

builder.Services.AddAutoMapper(typeof(SnackProfile));

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

public partial class Program() { }
