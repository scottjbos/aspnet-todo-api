using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TodoApi.Attributes;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    /// <summary>
    /// Provides API for managing Todo entities.
    /// </summary>
	[Route("api/todo")]
    public class TodoController : ApiController
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (!_context.TodoItems.Any())
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieve a list of Todo entities.
        /// </summary>
        /// <returns>Returns a a list of Todos</returns>
        [HttpGet]
        [ResponseCodes(HttpStatusCode.OK)]
        [ResponseType(typeof(List<TodoItem>))]
        public IHttpActionResult GetAll()
        {
            return Ok(_context.TodoItems.ToList());
        }

        /// <summary>
        /// Retrieves a Todo entity.
        /// </summary>
        /// <param name="id">todo item id</param>
        /// <returns>Returns a TodoItem</returns>
        [HttpGet]
        [Route("{id}")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotFound)]
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult GetById(long id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Create a Todo entity.
        /// </summary>
        /// <param name="item">todo item</param>
        /// <returns>A newly created TodoItem</returns>
        [HttpPost]
        [ResponseCodes(HttpStatusCode.Created)]
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return Content(HttpStatusCode.Created, item);
        }

        /// <summary>
        /// Updates a Todo entity.
        /// </summary>
        /// <param name="id">todo item id</param>
        /// <param name="item">todo item</param>
        /// <returns>An updated TodoItem.</returns>
        [HttpPut]
        [Route("{id}")]
        [ResponseCodes(HttpStatusCode.OK, HttpStatusCode.NotFound)]
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult Update(long id, TodoItem item)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.SaveChanges();
            return Ok(todo);
        }

        /// <summary>
        /// Deletes a Todo entity.
        /// </summary>
        /// <param name="id">todo item id</param>
        /// <returns>No Content</returns>
        [HttpDelete]
        [Route("{id}")]
        [ResponseCodes(HttpStatusCode.NoContent, HttpStatusCode.NotFound)]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return Content(HttpStatusCode.NoContent, "");
        }
    }
}