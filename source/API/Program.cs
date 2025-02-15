using API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
                .EnableTokenAcquisitionToCallDownstreamApi()
                .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
                .AddInMemoryTokenCaches();


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

application.MapDefaultEndpoints()
           .MapEndpoints()
           .MapOpenApi();

application.UseCors()
           .UseAuthentication()
           .UseAuthorization()
           .UseHttpsRedirection();

application.Run();
