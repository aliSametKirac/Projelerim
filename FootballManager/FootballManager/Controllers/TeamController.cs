using FootballManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    public class TeamController : Controller
    {
        private readonly DataBase _context;

        public TeamController(DataBase context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
