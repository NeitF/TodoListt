using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Context;
using TodoList.Core.Entities;

namespace TodoList.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodolistController : ControllerBase
{
    private readonly TodoListContext _context;

    public TodolistController(TodoListContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddNovoItem(TodoItem item)
    {
        _context.TodoItems.Add(item);
        _context.SaveChanges();
        return Ok(item);
    }

    [HttpGet]
    public IActionResult GetTodosOsItens() 
    {
        var todosOsItens = _context.TodoItems.ToList();

        if (todosOsItens == null)
            return NotFound();

        return Ok(todosOsItens);
    }

    [HttpGet("{id}")]
    public IActionResult GetItemPorId(int id)
    {
        var itemEncontrado = _context.TodoItems.Find(id);

        if (itemEncontrado == null)
            return NotFound();

        return Ok(itemEncontrado);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, TodoItem item)
    {
        var itemEncontrado = _context.TodoItems.Find(id);

        if (itemEncontrado == null)
            return NotFound();

        itemEncontrado.Descricao = item.Descricao;
        itemEncontrado.IsCompleto = item.IsCompleto;

        _context.TodoItems.Update(itemEncontrado);
        _context.SaveChanges();
    
        return Ok(item);
    }

    [HttpDelete]
    public IActionResult DeleteItem(int id)
    {
        var itemEncontrado = _context.TodoItems.Find(id);

        if(itemEncontrado == null)
            return NotFound();

        _context.TodoItems.Remove(itemEncontrado);
        return NoContent();
    }
}
