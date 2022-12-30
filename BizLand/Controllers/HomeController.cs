using BizLand.DAL;
using BizLand.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BizLand.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
             _context = context;
        }

        public IActionResult Index()
        {
                 
            ViewBag.TopHero = _context.TopHero.First();
            ViewBag.Services = _context.Services.ToList();
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        
    }
}