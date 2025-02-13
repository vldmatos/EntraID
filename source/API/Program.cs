using API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddAuthorization();
builder.Services.AddCors();




var application = builder.Build();

application.MapDefaultEndpoints();

if (application.Environment.IsDevelopment())
{
    application.MapOpenApi();
}

application.UseCors(policy => policy
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

application.UseAuthentication();
application.UseAuthorization();

application.UseHttpsRedirection();

application.MapEndpoint();

application.Run();
