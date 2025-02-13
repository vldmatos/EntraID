using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.Json;

namespace API
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/informations",
                                (HttpContext httpContext) =>
                                {
                                    return "teste";
                                })
            .WithName("Informations")
            .WithTags("Informations")
            .WithOpenApi();

            endpoints.MapGet("/user", [Authorize] (HttpContext context) =>
            {
                var user = context.User;

                if (user is null)
                    return Results.Unauthorized();

                return Results.Ok(new
                {
                    Name = user.Identity?.Name,
                    TenantId = user.FindFirst("tid")?.Value,
                    Email = user.FindFirst("preferred_username")?.Value
                });
            })
            .WithName("User")
            .WithTags("User")
            .WithOpenApi();

            return endpoints;
        }
    }
}
