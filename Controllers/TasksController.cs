using API_Net.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Net.DataAccess;
using API_Net.Entities;

namespace API_Net.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ContextDB _context;

        public TaskController(ContextDB context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDTO taskDTO)
        {
            if (taskDTO == null)
                return BadRequest();

            var task = new Entities.Task
            {
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                IsCompleted = taskDTO.IsCompleted
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskDTO taskDTO)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            task.Title = taskDTO.Title;
            task.Description = taskDTO.Description;
            task.IsCompleted = taskDTO.IsCompleted;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }


}

