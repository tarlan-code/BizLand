using BizLand.DAL;
using BizLand.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TopHeroController : Controller
	{
        readonly AppDbContext _context;

        public TopHeroController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{

            return View(_context.TopHero.First());
		}

        [HttpPost]
        public IActionResult Index(Tophero th)
        {

            if (!ModelState.IsValid) return View();
            Tophero existth = _context.TopHero.First();
            if (existth is null) return NotFound();

            existth.Title = th.Title;
            existth.VideoUrl = th.VideoUrl;
            existth.GetStartedUrl = th.GetStartedUrl;
            _context.TopHero.Update(existth);
            _context.SaveChanges();
            TempData["Sucess"] = "Update success";
            return RedirectToAction(nameof(Index), TempData["Sucess"]);
        }
    }
}
