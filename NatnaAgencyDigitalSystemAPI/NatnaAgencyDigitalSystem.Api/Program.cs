using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Repositories;
using NatnaAgencyDigitalSystem.Service.Services;
using NatnaAgencyDigitalSystem.Data;
using NatnaAgencyDigitalSystem.Data.Repositories;
using NatnaAgencyDigitalSystem.Service;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;

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
builder.Services.AddDbContext<NatnaAgencyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("NatnaAgencyCon"), op =>
        op.CommandTimeout(120)));

// For Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<NatnaAgencyDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddDataProtection();
//        .PersistKeysToFileSystem(new DirectoryInfo(@"c:\temp-keys\"));

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


var reportsPath = System.IO.Path.Combine(builder.Environment.ContentRootPath, "Letters");
// Configure dependencies for ReportsController.
builder.Services.TryAddSingleton<IReportServiceConfiguration>(sp =>
    new ReportServiceConfiguration
    {
        // The default ReportingEngineConfiguration will be initialized from appsettings.json or appsettings.{EnvironmentName}.json:
        ReportingEngineConfiguration = sp.GetService<IConfiguration>(),

        // In case the ReportingEngineConfiguration needs to be loaded from a specific configuration file, use the approach below:
        //ReportingEngineConfiguration = ResolveSpecificReportingConfiguration(sp.GetService<IWebHostEnvironment>()),
        HostAppId = "ERAMSReportService",
        Storage = new FileStorage(),
        ReportSourceResolver = new TypeReportSourceResolver()
                                    .AddFallbackResolver(
                                        new UriReportSourceResolver(reportsPath))
    });

builder.Services.TryAddSingleton<IReportDesignerServiceConfiguration>(sp => new ReportDesignerServiceConfiguration
{
    DefinitionStorage = new FileDefinitionStorage(
        reportsPath),
    ResourceStorage = new ResourceStorage(
        System.IO.Path.Combine(builder.Environment.ContentRootPath, "Resources")),
    SharedDataSourceStorage = new FileSharedDataSourceStorage(
        System.IO.Path.Combine(builder.Environment.ContentRootPath, "Shared Data Sources")),
    SettingsStorage = new FileSettingsStorage(
        System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Telerik Reporting")),
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost",
                "http://localhost:4200",
                "https://nathanjobs.com",
                "http://localhost:5050",
                "https://localhost:7230",
                "http://localhost:90")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
    app.UseFileServer(enableDirectoryBrowsing: true);
var cacheMaxAgeOneWeek = (60 * 60 * 24 * 7).ToString();
app.UseStaticFiles();
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



});

//app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();