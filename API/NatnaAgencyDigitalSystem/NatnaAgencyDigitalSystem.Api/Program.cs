using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Repositories;
using NatnaAgencyDigitalSystem.Api.Services;
using NatnaAgencyDigitalSystem.Data;
using NatnaAgencyDigitalSystem.Data.Repositories;
using NatnaAgencyDigitalSystem.Service;
using Newtonsoft.Json;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//cors 
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IApplicantProfileRepository, ApplicantProfileRepository>();
builder.Services.AddScoped<ICommonJobRepository, CommonJobRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICommonJobService, CommonJobService>();
builder.Services.AddScoped<IApplicantProfileService, ApplicantProfileService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options => {

        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

// For Entity Framework
builder.Services.AddDbContext<NatnaAgencyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("NatnaAgencyCon")));

// For Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<NatnaAgencyDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});
builder.Services.AddDirectoryBrowser();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OnlyTest", new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .RequireClaim("role", "OnlyTest")
        .Build());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFileServer(enableDirectoryBrowsing: true);
app.UseRouting();
app.UseStaticFiles();

//app.UseCors(MyAllowSpecificOrigins);



app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()
                              .WithExposedHeaders("content-disposition")); // allow credentials

var cacheMaxAgeOneWeek = (60 * 60 * 24 * 7).ToString();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "NathnaDocuments")),
    RequestPath = "/NathnaDocuments",
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
             "Cache-Control", $"public, max-age={cacheMaxAgeOneWeek}");
    }
    //OnPrepareResponse = ctx =>
    //{
    //    if (!ctx.Context.User.Identity.IsAuthenticated)
    //    {
    //        ctx.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //    }
    //}


});

// Authentication & Authorization
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();