using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;
using APIConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIConsume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string url = "https://localhost:44379/api/Student/";
        HttpClient client = new HttpClient();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var stu = JsonConvert.DeserializeObject<List<Student>>(data);
                if (stu != null)
                {
                    students = stu;
                }
                else
                {
                    return NotFound();
                }
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Student student = new Student();
                var response = client.GetAsync(url + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var stu = JsonConvert.DeserializeObject<Student>(data);
                    if (stu != null)
                    {
                        student = stu;
                        return View(student);
                    }
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(student);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response= client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Student student = new Student();
                var response= client.GetAsync(url + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var stu = JsonConvert.DeserializeObject<Student>(data);
                    if (stu != null)
                    {
                        student = stu;
                        return View(student);
                    }
                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(student);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url + student.StuId, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Student student = new Student();
                var response = client.GetAsync(url + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var stu = JsonConvert.DeserializeObject<Student>(data);
                    if (stu != null)
                    {
                        student = stu;
                        return View(student);
                    }
                }
            }
            return NotFound();
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int? id)
        {
            if (id != null)
            {
                HttpResponseMessage response = client.DeleteAsync(url + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
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
