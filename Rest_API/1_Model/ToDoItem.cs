public class ToDoItem(string title, string? description, DateTime? dueDate)
{
    [System.ComponentModel.DataAnnotations.Key]
    public int Id {get; init;} = GetNextId(); // fjern GetNextID() etter utviklingsfase
    public string Title {get;} = title;
    public string? Description {get;} = description;
    public bool IsCompleted {get; set;} = false;
    public DateTime CreatedAt {get;} = DateTime.UtcNow;
    public DateTime? DueDate {get; set;} = dueDate;

    // ----------------------------------
    //temporary løsning for unik id
    private static int _nextId = 1;

    public static int GetNextId()
    {
        return _nextId++;
    }
    // ---------------------------------
}