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
            endpoints.MapGet("/devices", (DataContext dataContext) =>
            {
                try
                {
                    var devices = dataContext.Devices.AsNoTracking()
                                                     .ToList();

                    devices.ForEach(device => device.ChangeSignal());

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
