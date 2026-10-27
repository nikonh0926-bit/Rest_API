using Microsoft.EntityFrameworkCore;

public class ToDoItemService(ToDoItemDbContext dbContext) : IToDoItemService
{
    
    public async Task<IReadOnlyList<ToDoItem>> GetAllAsync() // Henter alle oppgaver fra databasen
    {
        return await dbContext.Tasks.ToListAsync();
    }
    public async Task<ToDoItem?> GetByIdAsync(int id) // Henter oppgave fra databasen basert på Id
    {
        return await dbContext.Tasks.FindAsync(id);
    }
    public async Task<ToDoItem?> CreateAsync(CreateToDoItemRequest request) // lager en ny og legger i databasen
    {
        
        try
        {
            if(string.IsNullOrWhiteSpace(request.Title))
            return null;

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