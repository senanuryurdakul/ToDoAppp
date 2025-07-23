using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using System.Linq;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private static List<ToDoItem> ToDos = new List<ToDoItem>();      //Görevleri Listele
        public IActionResult Index()
        {

            return View(ToDos);
        }
        [HttpPost]
        public IActionResult Add(string Tittle)
        {
            if (!string.IsNullOrWhiteSpace(Tittle))
            {
                ToDos.Add(new ToDoItem
                {
                    Id = ToDos.Count + 1,
                    Title = Tittle
                });
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item =ToDos.FirstOrDefault(t=> t.Id ==id);
            if (item != null)
            {
                ToDos.Remove(item);

                return
                    RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
