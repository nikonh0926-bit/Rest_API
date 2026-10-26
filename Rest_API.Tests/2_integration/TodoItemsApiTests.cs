using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Rest_API.Tests;

public class ToDoItemsApiTests
{
    [Fact]
    public async Task GetAll_ReturnsOK() // GET returnerer 200 ok
    {
        IToDoItemService _itemService = new ToDoItemService();
        ToDoItemsController controller = new ToDoItemsController(_itemService);
        
        var task = await controller.GetAll();

        Assert.IsType<OkObjectResult>(task.Result);
    }
    [Fact]
    public async Task GetById_KnownId_ReturnsNotFound() // GET med ukjent ID returnerer 200 ok.
    {
        IToDoItemService _itemService = new ToDoItemService();
        ToDoItemsController controller = new ToDoItemsController(_itemService);
        
        var task = await controller.GetById(2);

        Assert.IsType<OkObjectResult>(task.Result);
    }
    [Fact]
    public async Task GetById_UnknownId_ReturnsNotFound() // GET med ukjent ID returnerer 404 Not Found.
    {
        IToDoItemService _itemService = new ToDoItemService();
        ToDoItemsController controller = new ToDoItemsController(_itemService);
        
        var task = await controller.GetById(10);

        Assert.IsType<NotFoundResult>(task.Result);
    }
    [Fact]
    public async Task Create_ValidRequest_ReturnsCreated() // POST returnerer 201 Created.
    {
        IToDoItemService _itemService = new ToDoItemService();
        ToDoItemsController controller = new ToDoItemsController(_itemService);
        CreateToDoItemRequest request = new CreateToDoItemRequest();
        request.Title = "A title";
        request.Description = "A description";

        var task = await controller.Create(request);

        Assert.IsType<CreatedAtActionResult>(task);
    }
    [Fact]
    public async Task Create_EmptyTitle_ReturnsBadRequest() // POST med ugyldig tittel returnerer 400 Bad Request.
    {
        IToDoItemService _itemService = new ToDoItemService();
        ToDoItemsController controller = new ToDoItemsController(_itemService);
        CreateToDoItemRequest request = new CreateToDoItemRequest();
        CreateToDoItemRequest request2 = new CreateToDoItemRequest();
        request.Title = "";
        request.Description = "A description";

        var task = await controller.Create(request); // name is empty, bad request
        var task2 = await controller.Create(request2); // name is null, bad request

        Assert.IsType<BadRequestResult>(task);
        Assert.IsType<BadRequestResult>(task2);
    }
    [Fact]
    public async Task Create_ThenGet_ReturnsCreatedItem() // En opprettet oppgave kan hentes igjen.
    {
        IToDoItemService _itemService = new ToDoItemService();
        ToDoItemsController controller = new ToDoItemsController(_itemService);
        CreateToDoItemRequest request = new CreateToDoItemRequest();
        request.Title = "A Title";
        request.Description = "A description";

        var response = await controller.Create(request);

        var result = Assert.IsType<CreatedAtActionResult>(
            response
        );

        var createdItem = Assert.IsType<ToDoItem>(result.Value);

        Assert.Equal("A Title", createdItem.Title);
        Assert.Equal("A description", createdItem.Description);
        Assert.True(createdItem.Id > 0);
    }
}
