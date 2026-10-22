public class ToDoItem(string title, string description, DateTime dueDate)
{
    [System.ComponentModel.DataAnnotations.Key]
    public int Id {get; init;}
    public string Title {get;} = title = string.Empty;
    public string? Description {get;} = description;
    public bool IsCompleted {get; set;} = false;
    public DateTime CreatedAt {get;} = DateTime.Now;
    public DateTime? DueDate {get; set;} = dueDate;
}