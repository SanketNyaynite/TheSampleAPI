using TheSampleAPI.Endpoints;
using TheSampleAPI.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();                          //this is dependency injection setup

var app = builder.Build();

app.UseOpenApi();                                   //this adds OpenAPI/Swagger middleware

app.UseHttpsRedirection();                          //this is mapping middleware ie routing setup

app.ApplyCorsConfig();                             //this applies the CORS configuration

app.MapAllHealthChecks();                          //this maps health check endpoints
app.AddRootEndpoints();
app.AddCourseEndpoints();

app.Run();



