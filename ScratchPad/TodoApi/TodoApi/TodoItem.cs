public class TodoItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }

    public TodoItem() { }
    public TodoItem(int id, string name, bool isCompleted)
    {
        Id = id;
        Name = name;
        IsCompleted = isCompleted;
    }
}
