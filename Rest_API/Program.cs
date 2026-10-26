
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.WebHost.UseUrls("https://localhost:9001");

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddOpenApi();

    builder.Services.AddScoped<
        IToDoItemService,
        ToDoItemService>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
