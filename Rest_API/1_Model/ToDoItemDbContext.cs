using Microsoft.EntityFrameworkCore;

public class ToDoItemDbContext(DbContextOptions<ToDoItemDbContext> options) : DbContext(options)
{
    public DbSet<ToDoItem> Tasks {get;set;}
}