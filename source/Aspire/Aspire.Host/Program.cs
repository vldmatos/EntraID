var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.API>("api");

var web = builder.AddProject<Projects.Blazor>("web")
                 .WithReference(api);

builder.Build().Run();
