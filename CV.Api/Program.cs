using CV.Api.Filters;
using CVServices;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Infrastructure.Context;
using CVServices.Infrastructure.Repositories;
using CVServices.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CVContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("CVServices"));
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(ProfileMapping)));
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
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
