public class ToDoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DueDate { get; set; }

    // EF Core kan bruke denne konstruktøren.
    public ToDoItem()
    {
    }

    // Brukes når du oppretter oppgaver fra API-et.
    public ToDoItem(string title, string? description, DateTime? dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        CreatedAt = DateTime.UtcNow;
        IsCompleted = false;
    }
}