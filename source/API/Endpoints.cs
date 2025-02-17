using Domain.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using System.Text.Json;

namespace API
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/devices", async (SignalCollector signalCollector, DataContext dataContext) =>
            {
                try
                {
                    var devices = await dataContext.Devices.AsNoTracking()
                                                           .ToArrayAsync();

                    devices = signalCollector.Collect(devices);

                    return Results.Ok(devices);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .WithTags("Devices")
            .RequireScope("API.Access")
            .RequireAuthorization();          

            return endpoints;
        }
    }
}
