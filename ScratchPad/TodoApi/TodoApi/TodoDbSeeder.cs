using System.Collections.Generic;

public static class TodoDbSeeder
{
    public static void Seed(TodoDbContext db)
    {
        var todos = new List<TodoItem>
        {
            new TodoItem { Name = "Buy groceries", IsCompleted = false },
            new TodoItem { Name = "Walk the dog", IsCompleted = true },
            new TodoItem { Name = "Read a book", IsCompleted = false },
            new TodoItem { Name = "Write blog post", IsCompleted = false },
            new TodoItem { Name = "Call mom", IsCompleted = true },
            new TodoItem { Name = "Clean the house", IsCompleted = false },
            new TodoItem { Name = "Pay bills", IsCompleted = true },
            new TodoItem { Name = "Finish project report", IsCompleted = false },
            new TodoItem { Name = "Exercise for 30 minutes", IsCompleted = true },
            new TodoItem { Name = "Plan weekend trip", IsCompleted = false },
            new TodoItem { Name = "Update resume", IsCompleted = false },
            new TodoItem { Name = "Schedule dentist appointment", IsCompleted = true },
            new TodoItem { Name = "Organize desk", IsCompleted = false },
            new TodoItem { Name = "Review pull requests", IsCompleted = true },
            new TodoItem { Name = "Backup laptop", IsCompleted = false },
            new TodoItem { Name = "Order new headphones", IsCompleted = false },
            new TodoItem { Name = "Prepare dinner", IsCompleted = true },
            new TodoItem { Name = "Watch tutorial video", IsCompleted = false },
            new TodoItem { Name = "Refactor codebase", IsCompleted = false },
            new TodoItem { Name = "Attend team meeting", IsCompleted = true },
            new TodoItem { Name = "Send thank you email", IsCompleted = false },
            new TodoItem { Name = "Check car oil", IsCompleted = false },
            new TodoItem { Name = "Buy birthday gift", IsCompleted = true },
            new TodoItem { Name = "Update budget spreadsheet", IsCompleted = false },
            new TodoItem { Name = "Read news articles", IsCompleted = true }
        };
        db.Todos.AddRange(todos);
        db.SaveChanges();
    }
}
