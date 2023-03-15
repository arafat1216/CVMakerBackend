using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Filters;
using CVMakerApiGateway.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Okta.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//start
builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

});
//End
//Okta Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://dev-64581829.okta.com/oauth2/default";
        options.Audience = "api://default";
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedSpecificOrigins", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddHttpClient<IProfileService, ProfileService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CV"]);
});

builder.Services.AddHttpClient<ISocialLinksService, SocialLinksService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CV"]);
});

builder.Services.AddHttpClient<ISummaryService, SummaryService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CV"]);
});

builder.Services.AddHttpClient<ISkillService, SkillService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CV"]);
});

builder.Services.AddHttpClient<IProjectService, ProjectService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CV"]);
});

builder.Services.AddHttpClient<ICourseService, CourseService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CV"]);
});

builder.Services.AddHttpClient<IDegreeService, DegreeService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CV"]);
});

builder.Services.AddHttpClient<IWorkExperienceService, WorkExperienceService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:CV"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowedSpecificOrigins");

app.MapControllers();

app.Run();
