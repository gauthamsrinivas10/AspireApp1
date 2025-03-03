var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var sql = builder.AddSqlServer("sql")
                 .AddDatabase("sqldata");


var apiService = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice")
    .WithReference(sql);

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
