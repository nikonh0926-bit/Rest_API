namespace Rest_API.Tests;
using Microsoft.EntityFrameworkCore;

public class ToDoItemModelTests
{
    private static ToDoItemDbContext CreateDbContext()
{
    var options = new DbContextOptionsBuilder<ToDoItemDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;

    return new ToDoItemDbContext(options);
}
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
    }
}
