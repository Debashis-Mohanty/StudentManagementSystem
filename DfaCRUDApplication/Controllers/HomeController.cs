using System.Diagnostics;
using DfaCRUDApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DfaCRUDApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentInfoContext context;
        public HomeController(ILogger<HomeController> logger,StudentInfoContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var students = context.Students.ToList();
            return View(students);
        }
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Student stu = context.Students.FirstOrDefault(x => x.Sid == id);
                if (stu != null)
                {
                    return View(stu);
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(stu);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu);
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Student stu = context.Students.FirstOrDefault(x => x.Sid == id);
                if (stu != null)
                {
                    return View(stu);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Student stu)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(stu);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stu);
        }
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                Student stu = context.Students.FirstOrDefault(x => x.Sid == id);
                if (stu != null)
                {
                    return View(stu);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Student stu)
        {
            if (stu != null)
            {
                context.Students.Remove(stu);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
