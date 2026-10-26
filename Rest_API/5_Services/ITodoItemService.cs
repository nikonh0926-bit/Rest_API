using Microsoft.AspNetCore.Mvc;

public interface IToDoItemService
{
    Task<IReadOnlyList<ToDoItem>> GetAllAsync(); // Henter alle oppgavene.
    Task<ToDoItem?> GetByIdAsync(int id); // Henter oppgaven med den angitte ID-en.
    Task<ToDoItem?> CreateAsync(CreateToDoItemRequest request); // Oppretter en ny oppgave og returnerer den.
}