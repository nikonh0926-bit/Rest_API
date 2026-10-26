using Microsoft.EntityFrameworkCore;

namespace Rest_API.Tests;

public class ToDoItemServiceTests()
{
    private static ToDoItemDbContext CreateDbContext()
{
        var options = new DbContextOptionsBuilder<ToDoItemDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;

    return new ToDoItemDbContext(options);
}
    [Fact]
    public async Task GetAllAsync_ReturnsAllItems() // alle opprettede oppgaver returneres
    {
        using var dbContext = CreateDbContext();

        dbContext.Tasks.Add(new ToDoItem(
            "Testoppgave",
            "Beskrivelse",
            null
        ));

        IToDoItemService _itemService = new ToDoItemService(dbContext);

        var task = await _itemService.GetAllAsync();

        Assert.Equal(task.Count, dbContext.Tasks.Count());
    }
    [Fact]
    public async Task GetByIdAsync_ExistingId_ReturnsItem() // Riktig oppgave returneres for en eksisterende ID.
    {
        using var dbContext = CreateDbContext();

        IToDoItemService _itemService = new ToDoItemService(dbContext);
        CreateToDoItemRequest request = new CreateToDoItemRequest();
        request.Title = "A Title";

        var createTask = await _itemService.CreateAsync(request);
        Assert.NotNull(createTask);

        var getTask = await _itemService.GetByIdAsync(createTask.Id);
        Assert.NotNull(getTask);

        Assert.Equal("A Title", getTask.Title);
    }
    [Fact]
    public async Task GetByIdAsync_UnknownId_ReturnsNull() // En ukjent ID gir null.
    {
        using var dbContext = CreateDbContext();

        IToDoItemService _itemService = new ToDoItemService(dbContext);
        var task = await _itemService.GetByIdAsync(-1);

        Assert.Null(task);
    }
    [Fact]
    public async Task CreateAsync_ValidRequest_CreatesItem() // En gyldig forespørsel oppretter en oppgave med riktig innhold.
    {
        using var dbContext = CreateDbContext();

        IToDoItemService _itemService = new ToDoItemService(dbContext);
        CreateToDoItemRequest request = new CreateToDoItemRequest();
        request.Title = "A Title";

        var task = await _itemService.CreateAsync(request);

        Assert.IsType<ToDoItem>(task);
        Assert.Equal("A Title", task.Title);
        Assert.True(task.Id > 0);
        Assert.Null(task.Description);
    }
    [Fact]
    public async Task CreateAsync_AssignsUniqueIds() // To nye oppgaver får forskjellige ID-er.
    {
        using var dbContext = CreateDbContext();

        IToDoItemService _itemService = new ToDoItemService(dbContext);
        CreateToDoItemRequest request = new CreateToDoItemRequest();
        CreateToDoItemRequest request2 = new CreateToDoItemRequest();
        request.Title = "A Title";
        request2.Title = "A Title";

        var task = _itemService.CreateAsync(request);
        var task2 = _itemService.CreateAsync(request2);

        await Task.WhenAll(task, task2);

        Assert.NotNull(task);
        Assert.NotNull(task2);

        Assert.DoesNotMatch(task.Id.ToString(), task2.Id.ToString());
    }
    [Fact]
    public async Task CreateAsync_SetsCreatedAt() // Opprettelsestidspunktet settes av tjenesten.
    {
        using var dbContext = CreateDbContext();

        IToDoItemService _itemService = new ToDoItemService(dbContext);

        DateTime beforeCreation = DateTime.UtcNow;
        
        CreateToDoItemRequest request = new CreateToDoItemRequest();
        request.Title = "A Title";

        var task = await _itemService.CreateAsync(request);

        Assert.NotNull(task);

        DateTime afterCreation = DateTime.UtcNow;

        Assert.InRange(
            task.CreatedAt,
            beforeCreation,
            afterCreation
        );
    }
}
