using Microsoft.EntityFrameworkCore;

public static class TodoEndpoints
{
    public static void MapTodoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // GET /todos
        // Retrieves all todo items.
        endpoints.MapGet("/todos", async (TodoDbContext db, HttpContext context) =>
        {
            var todos = await db.Todos.ToListAsync();
            await context.Response.WriteAsJsonAsync(todos);
        });

        // GET /todos/completed
        // Retrieves all completed todo items.
        endpoints.MapGet("/todos/completed", async (TodoDbContext db, HttpContext context) =>
        {
            var completed = await db.Todos.Where(t => t.IsCompleted).ToListAsync();
            await context.Response.WriteAsJsonAsync(completed);
        });

        // GET /todos/{id:int}
        // Retrieves a todo item by its unique id.
        endpoints.MapGet("/todos/{id:int}", async (int id, TodoDbContext db, HttpContext context) =>
        {
            var todo = await db.Todos.FindAsync(id);
            if (todo == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Todo item not found.");
                return;
            }
            await context.Response.WriteAsJsonAsync(todo);
        });

        // POST /todos
        // Adds a new todo item.
        endpoints.MapPost("/todos", async (TodoItem item, TodoDbContext db, HttpContext context) =>
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Todo item Name cannot be null or empty.");
                return;
            }

            db.Todos.Add(item);
            await db.SaveChangesAsync();
            context.Response.StatusCode = StatusCodes.Status201Created;
            await context.Response.WriteAsJsonAsync(item);
        });

        // PUT /todos/{id:int}
        // Updates an existing todo item by id.
        endpoints.MapPut("/todos/{id:int}", async (int id, TodoItem item, TodoDbContext db, HttpContext context) =>
        {
            var todo = await db.Todos.FindAsync(id);
            if (todo == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Todo item not found.");
                return;
            }
            todo.Name = item.Name;
            todo.IsCompleted = item.IsCompleted;
            await db.SaveChangesAsync();
            await context.Response.WriteAsJsonAsync(todo);
        });

        // DELETE /todos/{id:int}
        // Deletes a todo item by id.
        endpoints.MapDelete("/todos/{id:int}", async (int id, TodoDbContext db, HttpContext context) =>
        {
            var todo = await db.Todos.FindAsync(id);
            if (todo == null)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Todo item not found.");
                return;
            }
            db.Todos.Remove(todo);
            await db.SaveChangesAsync();
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        });
    }
}
