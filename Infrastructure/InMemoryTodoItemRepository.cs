using Entities;
using UseCases;

namespace Infrastructure;

public class InMemoryTodoItemRepository : ITodoItemRepository
{
    private readonly List<TodoItem> _items = new();
    private int _nextId = 1;

    public void Add(TodoItem item)
    {
        item.Id = _nextId++;
        _items.Add(item);
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public TodoItem GetById(int id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public IEnumerable<TodoItem> GetItems()
    {
        return _items;
    }

    public void Update(TodoItem item)
    {
        var existingItem = GetById(item.Id);
        if (existingItem != null)
        {
            existingItem.Text = item.Text;
            existingItem.IsComplete = item.IsComplete;
        }
    }
}
