using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using UseCases;

namespace TodoList.Controllers;

public class HomeController : Controller
{
    private readonly TodoListManager _listManager;
    private readonly ILogger<HomeController> _logger;

    public HomeController(TodoListManager listManager, ILogger<HomeController> logger)
    {
        _listManager = listManager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var todoItems = _listManager.getTodoItem();
        return View(new TodoListViewModel() { Items = todoItems });
    }

    [HttpPost]
    public IActionResult Add(string text)
    {
        _listManager.AddTodoItem(text);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Complete(int id)
    {
        _listManager.MarkComplete(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _listManager.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
