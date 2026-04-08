using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Tạm thời chỉ hiển thị lại dữ liệu nhận được
                return View("Details", student);
            }
            return View(student);
        }

        // GET: Student/Details
        public IActionResult Details(Student student)
        {
            return View(student);
        }
    }
}
