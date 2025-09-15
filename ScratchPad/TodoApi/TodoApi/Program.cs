var builder = WebApplication.CreateBuilder(args);

// Add dependency injection for services

var app = builder.Build();

// Configure the HTTP request pipeline.

// Map endpoints for Todo operations
app.MapTodoEndpoints();

app.Run();
