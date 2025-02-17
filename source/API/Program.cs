using API.Endpoints;
using Azure.Identity;
using Configurations.Extensions;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Identity.Web;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

var azureConfiguration = builder.Configuration.GetSection("AzureAd");
var graphConfiguration = builder.Configuration.GetSection("MicrosoftGraph");

builder.AddServiceDefaults();

builder.Services.AddOpenApi()
                .AddHealthChecks();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("DeviceDb"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(azureConfiguration)
                .EnableTokenAcquisitionToCallDownstreamApi()
                .AddMicrosoftGraph(graphConfiguration)
                .AddInMemoryTokenCaches();

builder.Services.AddSingleton<SignalCollector>()
                .AddScoped(serviceProvider =>
                {
                    var clientSecretCredential = new ClientSecretCredential(
                         azureConfiguration.GetSection("TenantID").Value,
                         azureConfiguration.GetSection("ClientID").Value,
                         azureConfiguration.GetSection("ClientSecret").Value);

                    return new GraphServiceClient(clientSecretCredential, [graphConfiguration.GetSection("BaseUrl").Value]);
                });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin();
    });
});


var application = builder.Build();

application.CreateDbIfNotExists();
application.MapDefaultEndpoints()
           .MapDevicesEndpoints()
           .MapUserEndpoints()
           .MapOpenApi();

application.UseCors()
           .UseAuthentication()
           .UseAuthorization()
           .UseHttpsRedirection();

application.Run();
