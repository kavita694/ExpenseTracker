using ExpenseTracker.Data;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ExpenseTrackerApp.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _service;
        private readonly AppDbContext _context;

        public ExpenseController(IExpenseService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

       
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            _service.Add(expense);
            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(_service.GetById(id));
        }

       
        [HttpPost]
        public IActionResult Edit(Expense expense)
        {
            _service.Update(expense);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
