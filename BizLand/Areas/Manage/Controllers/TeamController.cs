using BizLand.DAL;
using BizLand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizLand.Areas.Manage.Controllers
{


    


    [Area("Manage")]
    public class TeamController : Controller
    {
        readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
       
            return View(_context.Employees.ToList());
        }

        public IActionResult Delete(int? id)
        {
            if(id is null || id<=0) return BadRequest();
            Employee em = _context.Employees.Find(id);
            if (em == null)return NotFound();
            _context.Employees.Remove(em);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee em)
        {
            if (!ModelState.IsValid) return View();
            _context.Employees.Add(em);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? Id)
        {
            if (Id is null || Id<=0) return BadRequest();

            Employee em = _context.Employees.Find(Id);
            if (em is null) return NotFound();
            

            return View(em);
        }

        [HttpPost]
        public IActionResult Update(int? Id,Employee em)
        {
            if (Id is null || Id<=0 || Id != em.Id) return BadRequest();
            if (!ModelState.IsValid) return View();
            Employee existem = _context.Employees.Find(Id);
            if (existem is null) return NotFound();

            existem.Name = em.Name;
            existem.Surname = em.Surname;
            existem.Position = em.Position;
            existem.Image = em.Image;
            existem.Twitter = em.Twitter;
            existem.Facebook = em.Facebook;
            existem.Instagram = em.Instagram;
            existem.Linkedin = em.Linkedin;

            _context.Employees.Update(existem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
