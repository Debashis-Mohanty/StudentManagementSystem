using System.Diagnostics;
using CRUDApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CrudapplicationContext context;
        public HomeController(ILogger<HomeController> logger,CrudapplicationContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Student> students = context.Students.ToList();
            return View(students);
        }
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Student stu = context.Students.FirstOrDefault(x => x.Roll == id);
                if (stu != null)
                {
                    return View(stu);
                }
                TempData["Message"] = "Please enter valid id";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Please provide any id to search";
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
                try
                {
                    context.Students.Add(stu);
                    context.SaveChanges();
                    TempData["success"] = "New Student Added Sucessfully..";
                }
                catch(Exception ex)
                {
                    TempData["message"] = "Please Check the Enter Data Properly.";
                }
                return RedirectToAction("Index");
            }
            return View(stu);
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Student stu = context.Students.FirstOrDefault(x => x.Roll == id);
                if (stu != null)
                {
                    return View(stu);
                }
                else
                {
                    TempData["message"] = "Something Went Wrong..";
                    return RedirectToAction("Index");
                }
            }
            TempData["message"] = "Please enter valid id." + id;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Student stu)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(stu);
                context.SaveChanges();
                TempData["success"] = "Student Data Updated Successfully.";
                return RedirectToAction("Index");
            }
            return View(stu);
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Student stu = context.Students.FirstOrDefault(x => x.Roll == id);
                if (stu != null)
                {
                    return View(stu);
                }
                else
                {
                    TempData["message"] = "Something Went Wrong..";
                    return RedirectToAction("Index");
                }
            }
            TempData["message"] = "Please enter valid id ";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Student stu)
        {
            if (stu != null)
            {
                context.Students.Remove(stu);
                context.SaveChanges();
                TempData["success"] = "Student Data Deleted Successfully";
                return RedirectToAction("Index");
            }
            TempData["message"] = "Unable to Delete delete record";
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
