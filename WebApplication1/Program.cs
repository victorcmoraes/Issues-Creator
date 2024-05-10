using Microsoft.AspNetCore.Authentication.Negotiate;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Shirts

app.MapGet("/shirts", () =>
{
    return "Reading Shirts";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"Reading shirt with ID: {id}";
});

app.MapPost("/shirts", () =>
{
    return $"Creating a Shirt.";
});

app.MapPut("/shirts/{id}", (int id) =>
{
    return $"Updating shirt with ID: {id}";
});

app.MapDelete("/shirts/{id}", (int id) =>
{
    return $"Deleting shirt with ID: {id}";
});

app.Run();