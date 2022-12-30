using BizLand.DAL;
using BizLand.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.Areas.Manage.Controllers
{
    [Area("Manage")]
	public class ServiceController : Controller
	{
        readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Services.ToList());
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            Service se = _context.Services.Find(id);
            if (se is null) return NotFound();
            _context.Services.Remove(se);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service se)
        {
            if (!ModelState.IsValid) return View();
            _context.Services.Add(se);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            if (Id is null || Id <= 0) return BadRequest();

            Service se = _context.Services.Find(Id);
            if (se is null) return NotFound();


            return View(se);
        }

        [HttpPost]
        public IActionResult Update(int? Id, Service se)
        {
            if (Id is null || Id <= 0 || Id != se.Id) return BadRequest();
            if (!ModelState.IsValid) return View();
            Service existse = _context.Services.Find(Id);
            if (existse is null) return NotFound();

            existse.Name = se.Name;
            existse.Title = se.Title;
           

            _context.Services.Update(existse);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
