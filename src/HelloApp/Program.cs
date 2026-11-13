var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

var environmentName = app.Configuration["APP_ENVIRONMENT"] ?? "local";

app.MapGet("/", () => Results.Ok(new { message = "Hello from HelloApp", environment = environmentName }));
app.MapHealthChecks("/healthz");

app.Run();

// Exposes Program to WebApplicationFactory in the test project.
public partial class Program { }
