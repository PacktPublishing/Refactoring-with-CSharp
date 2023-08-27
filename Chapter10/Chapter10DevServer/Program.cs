using Packt.CloudySkiesAir.Chapter10.DevServer;
using System.Net;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IFlightProvider, RandomFlightDataProvider>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();
            
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use((context, next) => {
    string apiKey = context.Request.Headers["x-api-key"];
    if (apiKey != "RefactoringWithCSharpBook") {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        return Task.CompletedTask;
    }
    return next();
});

app.UseHttpsRedirection();

// Endpoints
app.MapGet("/flights/active", (IFlightProvider flightProvider) => flightProvider.GetActiveFlights());
app.MapGet("/flights/completed", (IFlightProvider flightProvider) => flightProvider.GetCompletedFlights());
app.MapGet("/flights/pending", (IFlightProvider flightProvider) => flightProvider.GetPendingFlights());
app.MapGet("/flights/{id}", (IFlightProvider flightProvider, string id) => flightProvider.FindFlight(id));
app.MapGet("/flights/uptodistance/{miles}", (IFlightProvider flightProvider, int miles) => flightProvider.GetFlightsUpToMileage(miles));
app.MapGet("/flights", (IFlightProvider flightProvider) => flightProvider.GetAllFlights());

app.Run();