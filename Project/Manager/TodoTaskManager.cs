using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Project.Data;


namespace Project.Manager
{

    private readonly AppDbContext _context;
    public class TodoTaskManager
    {

        public TodoTaskManager(AppDbContext context)
        {
            _context = context;
        }
        
        // Get all Todos
        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        // Get a Todo by Id
        public async Task<Todo> GetTodoById(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> UpdateTodo(int id, Todo todo)
        {
            var oldTodo = await _context.Todos.FindAsync(id);
            if (oldTodo == null)
            {
                return null;
            }
            oldTodo.Title = todo.Title;
            oldTodo.Description = todo.Description;
            oldTodo.DueDate = todo.DueDate;
            await _context.SaveChangesAsync();
            return oldTodo;
        }

        public async Task<bool> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        

    }
}