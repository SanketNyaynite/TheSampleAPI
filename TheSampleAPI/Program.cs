using TheSampleAPI.Endpoints;
using TheSampleAPI.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();                          //this is dependency injection setup

var app = builder.Build();

app.UseOpenApi();                                   //this adds OpenAPI/Swagger middleware

app.UseHttpsRedirection();                          //this is mapping middleware ie routing setup

app.AddRootEndpoints();

app.Run();

