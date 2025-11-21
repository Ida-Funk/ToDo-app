using Microsoft.EntityFrameworkCore;
using todo.api_service.Models;
using todo.api_service.Data;

namespace todo.api_service.Services;

public class DBService
{
    private readonly AppDBContext _db;

    public DBService(AppDBContext db) => _db = db;

    public async Task<List<Todo>> GetAllTodosFromDB() =>
        await _db.Todos.AsNoTracking().ToListAsync();


}
