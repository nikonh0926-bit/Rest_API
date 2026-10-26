using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ToDoItemService(ToDoItemDbContext dbContext) : IToDoItemService
{
    
    public async Task<IReadOnlyList<ToDoItem>> GetAllAsync()
    {
        return await dbContext.Tasks.ToListAsync();
    }
    public async Task<ToDoItem?> GetByIdAsync(int id)
    {
        return await dbContext.Tasks.FindAsync(id);
    }
    public async Task<ToDoItem?> CreateAsync(CreateToDoItemRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.Title))
            return null;
        try
        {
            ToDoItem newItem = new ToDoItem(request.Title, request.Description, request.DueDate);
            dbContext.Tasks.Add(newItem);
            await dbContext.SaveChangesAsync();
            return newItem;
        }
        catch (Exception e)
        {
            Logger.LogCritical(e);
            return null;
        }
    }
}