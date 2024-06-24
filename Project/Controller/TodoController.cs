using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Project.Manager;

namespace Project.Controller
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoTaskManager _todoTaskManager;

        public TodoController(TodoTaskManager todoTaskManager)
        {
            _todoTaskManager = todoTaskManager;
        }

        // Add a new Task
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] Todo todo)
        {
            var newTodo = await _todoTaskManager.CreateTodo(todo);
            return CreatedAtAction(nameof(GetTodoById), new { id = newTodo.Id }, newTodo);
        }

        // Get all Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAllTodos()
        {
            return await _todoTaskManager.GetAllTodos();
        }

        // Get a Task by Id
        public async Task <ActionResult<Todo>> GetTodoById(int id)
        {
            var todo = await _todoTaskManager.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // Update a Task using Patch
        [HttpPatch("{id}")]
        public async Task<ActionResult<Todo>> UpdateTodo(int id, [FromBody] Todo todo)
        {
            var updatedTodo = await _todoTaskManager.UpdateTodo(id, todo);
            if (updatedTodo == null)
            {
                return NotFound();
            }
            return updatedTodo;
        }

        // Delete a Task
        public async Task <ActionResult> DeleteTodo(int id)
        {
            var result = await _todoTaskManager.DeleteTodo(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}