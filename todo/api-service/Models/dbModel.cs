namespace todo.api_service.Models;

public class Todo
{
    public string Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}