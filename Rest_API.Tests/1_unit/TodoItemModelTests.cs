namespace Rest_API.Tests;

public class ToDoItemModelTests
{
    [Fact]
    public void TestModelInheritance()
    {
        DateTime beforeCreation = DateTime.UtcNow;
        DateTime dueDate = new DateTime(2001, 9, 11);

        ToDoItem toDoItem = new ToDoItem("A Title", "A Description", dueDate);

        DateTime afterCreation = DateTime.UtcNow;

        Assert.InRange(
            toDoItem.CreatedAt,
            beforeCreation,
            afterCreation
        );
        
        Assert.Equal(toDoItem.DueDate, dueDate);
        Assert.Equal("A Title", toDoItem.Title);
        Assert.Equal("A Description", toDoItem.Description);
        Assert.True(toDoItem.Id > 0);
    }
}
