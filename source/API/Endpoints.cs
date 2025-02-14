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
        public static IEndpointRouteBuilder MapEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/me", (GraphServiceClient graphClient) =>
            {
                try
                {
                    var user = graphClient.Me;
                    return Results.Ok(user);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();

            return endpoints;
        }
    }
}
