using Microsoft.AspNetCore.Authorization;
using Microsoft.Graph;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.Json;
using Microsoft.Identity.Web;

namespace API
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/data", () =>
            {
                try
                {
                    return Results.Ok("DATA!!!!");
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .RequireScope("API.Access")
            .RequireAuthorization();

            return endpoints;
        }
    }
}
