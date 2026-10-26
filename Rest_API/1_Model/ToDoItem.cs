/*
public class ToDoItem()
{
    [System.ComponentModel.DataAnnotations.Key]
    public long Id {get; set;} //= GetNextId(); // fjern GetNextID() etter utviklingsfase
    public string Title {get; set;} = string.Empty;
    public string? Description {get; set;}
    public bool IsCompleted {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime? DueDate {get; set;}

    // ----------------------------------
    //temporary løsning for unik id
    private static int _nextId = 1;

    public static int GetNextId()
    {
        return _nextId++;
    }
    // --------------------------------
}
*/
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