using Microsoft.AspNetCore.Mvc;
using Buoi4.Models;
using System.Collections.Generic;
using System.Linq;

namespace Buoi4.Controllers
{
    public class TodoController : Controller
    {
        private static List<Todo> _todos = new List<Todo>
        {
            new Todo { Id = "1", Name = "Đi chợ", IsCompleted = true },
            new Todo { Id = "2", Name = "Chơi thể thao", IsCompleted = false },
            new Todo { Id = "3", Name = "Chơi game", IsCompleted = false },
            new Todo { Id = "4", Name = "Học bài", IsCompleted = true }
        };

        public IActionResult Index()
        {
            return View(_todos);
        }

        public IActionResult Details(string id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                if (_todos.Any(t => t.Id == todo.Id))
                {
                    ModelState.AddModelError("Id", "Mã công việc đã tồn tại.");
                    return View(todo);
                }
                _todos.Add(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Edit(string id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Todo todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
                if (existingTodo == null)
                {
                    return NotFound();
                }
                existingTodo.Name = todo.Name;
                existingTodo.IsCompleted = todo.IsCompleted;
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        public IActionResult Delete(string id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
