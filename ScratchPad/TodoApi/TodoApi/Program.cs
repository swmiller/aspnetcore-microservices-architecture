using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add dependency injection for services
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

// Configure the HTTP request pipeline.

// Map endpoints for Todo operations
app.MapTodoEndpoints();

app.Run();
