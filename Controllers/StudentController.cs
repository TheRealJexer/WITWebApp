using Microsoft.AspNetCore.Mvc;
using WITWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WITWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Success");
            }
            return View(student);
        }

        public IActionResult Success() => View();
    }
}
