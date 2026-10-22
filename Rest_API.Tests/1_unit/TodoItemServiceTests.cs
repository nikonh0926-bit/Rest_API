namespace Rest_API.Tests;

public class ToDoItemServiceTests
{
    [Fact]
    public void GetAllAsync_ReturnsAllItems() // alle opprettede oppgaver returneres
    {
        
    }
    [Fact]
    public void GetByIdAsync_ExistingId_ReturnsItem() // Riktig oppgave returneres for en eksisterende ID.
    {
        
    }
    [Fact]
    public void GetByIdAsync_UnknownId_ReturnsNull() // En ukjent ID gir null.
    {
        
    }
    [Fact]
    public void CreateAsync_ValidRequest_CreatesItem() // En gyldig forespørsel oppretter en oppgave med riktig innhold.
    {
        
    }
    [Fact]
    public void CreateAsync_AssignsUniqueIds() // To nye oppgaver får forskjellige ID-er.
    {
        
    }
    [Fact]
    public void CreateAsync_SetsCreatedAt() // Opprettelsestidspunktet settes av tjenesten.
    {
        
    }
}
