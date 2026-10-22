using System.Text.Json;

public class ToDoItemsController
{
    public static Task<IReadOnlyList<ToDoItem>> GetAll() // Henter alle oppgaver og returnerer 200 OK.
    {
        try
        {
            
        }
        catch(JsonException e)
        {
            Logger.LogError(e);
        }
        catch(Exception e)
        {
            Logger.LogCritical(e);
        }
    }
    public static Task<ToDoItem> GetByInt(int id) // Henter én oppgave. Returnerer 404 Not Found hvis den ikke finnes.
    {
        
    }
    public static Task Create(CreateToDoItemRequest request) // Validerer forespørselen, ber tjenesten opprette oppgaven og returnerer 201 Created.
    {
        
    }
}