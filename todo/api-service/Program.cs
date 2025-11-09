// See https://aka.ms/new-console-template for more information

using todo.api_service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FileService>();

var app = builder.Build();

app.MapGet("/app/todo", (FileService fileService) =>
{
    var result = fileService.ReadFromFile();

    return Results.Text(result);
    // return result;
});

app.MapPost("/app/todo", (FileService fileService, [FromBody] string content) =>
{
   fileService.WriteToFile(content);
   
   return Results.Ok("Content written to file successfully :D.");
});

app.Run();
