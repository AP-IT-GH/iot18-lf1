using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    [Route("api/todo2")] // /api/todo2
    public class TodoController2 : ControllerBase
    {
        private readonly CollectionContext _context;

        public TodoController2(CollectionContext context)
        {
            _context = context;

        }

        [HttpGet] // /api/todo2
        public List<TodoItem2> GetAll()
        {
            return _context.TodoItems2.ToList();
        }

        [Route("{id}")] // /api/todo2/2
        [HttpGet]
        public ActionResult GetById(long id)
        {
            var item = _context.TodoItems2.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")] // /api/todo2/2 + body
        public IActionResult Update(long id, TodoItem2 item)
        {
            var todo = _context.TodoItems2.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Name =item.Name;

            _context.TodoItems2.Update(todo);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPost] // /api/todo2 + body
        public IActionResult Post([FromBody] TodoItem2 todo)
        {
            _context.TodoItems2.Add(todo);
            _context.SaveChanges();
            return Created("", todo);
        }

        [HttpDelete("{id}")] // /api/todo2/2
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems2.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems2.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}