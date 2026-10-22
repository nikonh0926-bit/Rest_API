namespace Rest_API.Tests;

public class ToDoItemsApiTests
{
    [Fact]
    public void GetAll_ReturnsOK() // GET returnerer 200 ok
    {
        
    }
    [Fact]
    public void GetById_UnknownId_ReturnsNotFound() // GET med ukjent ID returnerer 404 Not Found.
    {

    }
    [Fact]
    public void Create_ValidRequest_ReturnsCreated() // POST returnerer 201 Created.
    {

    }
    [Fact]
    public void Create_EmptyTitle_ReturnsBadRequest() // POST med ugyldig tittel returnerer 400 Bad Request.
    {

    }
    [Fact]
    public void Create_ThenGet_ReturnsCreatedItem() // En opprettet oppgave kan hentes igjen.
    {

    }
}
