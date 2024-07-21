using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoList.Models;

namespace TodoList.Controllers;

public class HomeController : Controller
{
    
    public HomeController()
    {
    }

    [HttpGet]
    public IActionResult Index(string searchString,bool? categoryStatus)
    {
        var tasks = Repository.Tasks;
        if(!String.IsNullOrEmpty(searchString)){
            ViewBag.SearchString = searchString;
            tasks = tasks.Where(t => t.TaskName.ToLower().Contains(searchString)).ToList();
        }

        if (categoryStatus.HasValue)
            {
                ViewBag.CategoryStatus = categoryStatus;
                tasks = tasks.Where(t => t.Status == categoryStatus.Value).ToList();
                
            }
        return View(tasks);
    }


    [HttpGet]
    public IActionResult AddTask()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddTask(TodoList.Models.Task task)
    {
        if(ModelState.IsValid)
        {
            Repository.Tasks.Add(task);
            return RedirectToAction("Index");
        }

        return View();
    }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var entity = Repository.Tasks.FirstOrDefault(t => t.TaskId == id);
            if(entity == null){
                return NotFound();
            }
            Repository.DeleteTask(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = Repository.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoList.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                // Task'ı bul ve güncelle
                var existingTask = Repository.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);
                if (existingTask != null)
                {
                    existingTask.TaskName = task.TaskName;
                    existingTask.Status = task.Status;
                    existingTask.Deadline = task.Deadline;
                }
                
                return RedirectToAction("Index");
            }

            return View(task);
        }
}
