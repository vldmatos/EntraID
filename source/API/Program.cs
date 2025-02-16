using API;
using Configurations.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi()
                .AddHealthChecks();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("DeviceDb"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

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
           .MapEndpoints()
           .MapOpenApi();

application.UseCors()
           .UseAuthentication()
           .UseAuthorization()
           .UseHttpsRedirection();

application.Run();
