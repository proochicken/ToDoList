using Entities;

namespace UseCases;

public class TodoListManager
{
    private readonly ITodoItemRepository repository;

    public TodoListManager(ITodoItemRepository repository)
    {
        this.repository = repository;
    }
    public IEnumerable<TodoItem> getTodoItem()
    {
        return repository.GetItems();
    }

    public void AddTodoItem(string text)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            repository.Add(new TodoItem { Text = text, IsComplete = false });
        }
    }

    public void MarkComplete(int id)
    {
        var item = repository.GetById(id);
        if (item != null)
        {
            item.IsComplete = true;
            repository.Update(item);
        }
    }
    public void Delete(int id)
    {
        repository.Delete(id);
    }
}
