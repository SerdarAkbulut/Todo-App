using Crud_işlemleri.Data;
using Crud_işlemleri.Entity;
using Crud_işlemleri.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Crud_işlemleri.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly DataContext _context;
        public TodoController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TodoDTO model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { message = "Unauthorized access" });
            }
            var newTodo = new Todo
            {
                Task = model.Task,
                IsCompleted = false,
                UserId=userId
            };

            _context.Todos.Add(newTodo);
            await _context.SaveChangesAsync();
            return Ok(new {newTodo,message="Task is added"});
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { message = "Unauthorized access" });
            }

            var tasks = await _context.Todos
                .Where(i => i.UserId == userId)
                .ToListAsync();

            return Ok(tasks);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { message = "Unauthorized access" });
            }
            var task = await _context.Todos
         .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task==null)
            {
                return NotFound(new {message="Task is not found"});
            }
            _context.Todos.Remove(task);
            await _context.SaveChangesAsync();
            return Ok(new {task,message="Task is deleted"});
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] TodoDTO model, int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { message = "Unauthorized access" });
            }

            var task = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task == null)
            {
                return NotFound(new { message = "Task not found" });
            }

            task.Task = model.Task;

            _context.Todos.Update(task);
            await _context.SaveChangesAsync();

            return Ok(new { task, message = "Task is updated" });
        }

        [HttpPut("complete/{id}")]
        public async Task<IActionResult> CompleteTask( int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized(new { message = "Unauthorized access" });
            }

            var task = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task == null)
            {
                return NotFound(new { message = "Task not found" });
            }

            task.IsCompleted=true;

            _context.Todos.Update(task);
            await _context.SaveChangesAsync();

            return Ok(new { task, message = "Task is completed" });
        }
    }
}
