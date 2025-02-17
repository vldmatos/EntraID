using Domain.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace API.Endpoints
{
    public static class User
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/user", async (string email, GraphServiceClient graphClient) =>
            {                
                try
                {
                    var users = await graphClient.Users.Request()
                                                       .Filter($"mail eq '{email}' or userPrincipalName eq '{email}'")
                                                       .GetAsync();

                    if (users.FirstOrDefault() is null)
                    {
                        return Results.NotFound();
                    }

                    var profile = new Profile
                    {
                        DisplayName = users.First().DisplayName,
                        Country = users.First().Country,
                        Surname = users.First().Surname,
                        Mail = users.First().Mail,
                        UserPrincipalName = users.First().UserPrincipalName,
                        JobTitle = users.First().JobTitle,
                        MobilePhone = users.First().MobilePhone,
                        OfficeLocation = users.First().OfficeLocation,
                        Department = users.First().Department
                    };

                    return Results.Ok(profile);
                }
                catch (ServiceException ex)
                {
                    return Results.Problem(ex.Message);
                }
            })
            .RequireAuthorization()
            .WithTags("User")
            .WithOpenApi();

            return endpoints;
        }
    }
}