using DeveloperCodingTestFGM.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

/// Registers an HttpClient service for the HackerNewsService.
/// This allows the service to make HTTP requests to external APIs like Hacker News.
builder.Services.AddHttpClient<HackerNewsService>();

/// Adds services to support API endpoint exploration.
/// Generates metadata for the API's endpoints, which is used by tools like Swagger for documentation.
builder.Services.AddEndpointsApiExplorer();

/// Registers the Swagger generator, which creates the API documentation.
/// Swagger is a tool that provides a user-friendly interface to interact with the API.
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/// Enforces the use of HTTPS for all incoming requests, ensuring secure communication.
app.UseHttpsRedirection();

/// Applies authorization middleware to ensure that any endpoints requiring authorization are properly secured.
app.UseAuthorization();

/// Maps controller endpoints to routes, enabling the API to handle incoming HTTP requests.
app.MapControllers();

/// Starts the application and begins listening for incoming HTTP requests.
app.Run();
