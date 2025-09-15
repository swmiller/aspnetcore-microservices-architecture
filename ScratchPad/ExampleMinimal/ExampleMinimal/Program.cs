using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

// Import endpoints from another file
//app.MapWeatherEndpoints();
app.MapTodoEndpoints();

app.Run();
