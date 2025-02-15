using Microsoft.AspNetCore.Authorization;
using Microsoft.Graph;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.Json;
using Microsoft.Identity.Web;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/devices", (DataContext dataContext) =>
            {
                try
                {
                    var devices = dataContext.Devices.AsNoTracking()
                                                     .ToList();

                    return Results.Ok(devices);
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
