var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.API>("api");

var blazor = builder.AddProject<Projects.Blazor>("blazor")
                    .WithReference(api);

builder.Build().Run();
