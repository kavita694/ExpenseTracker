using ExpenseTracker.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ExpenseTrackerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            var totalExpense = _context.Expenses.Sum(e => e.Amount);
            ViewBag.TotalExpense = totalExpense;
            return View();
        }
    }
}
