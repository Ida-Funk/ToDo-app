// See https://aka.ms/new-console-template for more information

using todo.api_service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using todo.api_service.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<FileService>();
// builder.Services.AddDbContext<AppDBContext>(opts => opts.UseSqlite("Data Source=todos.db"));

var app = builder.Build();

// app.MapGet("/app/todo", (AppDBContext dbService) =>
app.MapGet("/app/todo", (FileService fileService) =>
{
    // var result = dbService.GetAllTodosFromDB();
    var result = fileService.ReadFromFile();

    return Results.Text(result);
    // return result;
});

app.MapPost("/app/todo", (FileService fileService, [FromBody] string content) =>
{
   fileService.WriteToFile(content);
   
   return Results.Ok("Content written to file successfully :D.");
});

// app.MapDelete("/app/todo", (DBService dbService, [FromBody] string content) =>
// {
//     dbService.DeleteItemFromDB(content);

//     return Results.Ok("Content deleted");   
// })

app.Run();
