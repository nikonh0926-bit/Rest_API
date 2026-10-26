using Microsoft.AspNetCore.Mvc;

[ApiController]

[Route("ToDoItem")]
public class ToDoItemsController(IToDoItemService _itemService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ToDoItem>>> GetAll() // Henter alle oppgaver og returnerer 200 OK.
    {
        try
        {
            var tasks = await _itemService.GetAllAsync();
            return Ok(tasks);
        }
        catch(Exception e)
        {
            Logger.LogCritical(e);
            return BadRequest();
        }
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ToDoItem?>> GetById(int id) // Henter én oppgave. Returnerer 404 Not Found hvis den ikke finnes.
    {
        try
        {
            var task = await _itemService.GetByIdAsync(id);

            if(task == null)
                return NotFound();
            return Ok(task);
        }
        catch(Exception e)
        {
            Logger.LogCritical(e);
            return BadRequest();
        }
    }
    [HttpPost]
    public async Task<ActionResult> Create(CreateToDoItemRequest request) // Validerer forespørselen, ber tjenesten opprette oppgaven og returnerer 201 Created.
    {

        var task = await _itemService.CreateAsync(request);
        if (task != null)
        {
            return CreatedAtAction(
            nameof(GetById),
            new { id = task.Id },
            task
            );
        }
        return BadRequest();
    }
}