using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

namespace API.Endpoints
{
    public static class Devices
    {
        public static IEndpointRouteBuilder MapDevicesEndpoints(this IEndpointRouteBuilder endpoints)
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
