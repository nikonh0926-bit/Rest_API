namespace Rest_API.Tests;

public class ToDoItemServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsAllItems() // alle opprettede oppgaver returneres
    {
        IToDoItemService _itemService = new ToDoItemService();

        var task = await _itemService.GetAllAsync();

        Assert.Equal(task.Count, DeveloperTestData.MasterList.Count);
    }
    [Fact]
    public async Task GetByIdAsync_ExistingId_ReturnsItem() // Riktig oppgave returneres for en eksisterende ID.
    {
        IToDoItemService _itemService = new ToDoItemService();
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
        IToDoItemService _itemService = new ToDoItemService();
        var task = await _itemService.GetByIdAsync(-1);

        Assert.Null(task);
    }
    [Fact]
    public async Task CreateAsync_ValidRequest_CreatesItem() // En gyldig forespørsel oppretter en oppgave med riktig innhold.
    {
        IToDoItemService _itemService = new ToDoItemService();
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
        IToDoItemService _itemService = new ToDoItemService();
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
        IToDoItemService _itemService = new ToDoItemService();

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
