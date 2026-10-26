using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

public class ToDoItemService : IToDoItemService
{
    
    public async Task<IReadOnlyList<ToDoItem>> GetAllAsync()
    {
        return DeveloperTestData.MasterList;
    }
    public async Task<ToDoItem?> GetByIdAsync(int id)
    {
        foreach(ToDoItem task in DeveloperTestData.MasterList)
        {
            if(task.Id == id)
                return task;
        }
        return null;
    }
    public async Task<ToDoItem?> CreateAsync(CreateToDoItemRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.Title))
            return null;
        try
        {
            ToDoItem newItem = new ToDoItem(request.Title, request.Description, request.DueDate);
            DeveloperTestData.MasterList.Add(newItem);
            return newItem;
        }
        catch (Exception e)
        {
            Logger.LogCritical(e);
            return null;
        }
    }
}