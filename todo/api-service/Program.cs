// See https://aka.ms/new-console-template for more information

using todo.api_service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FileService>();

var app = builder.Build();

app.MapGet("/app/todo", (FileService fileService) =>
{
    var value = fileService.ReadFromFile();

    return results.ok(value);
});

//app.MapPost("/app/todo", (FileService fileService, string content) =>
//{
//    fileService.WriteToFile(content);
//    return Results.Ok("Content written to file successfully.");
            //});

app.Run();
