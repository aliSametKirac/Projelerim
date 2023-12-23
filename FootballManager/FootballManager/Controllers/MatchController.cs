using FootballManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Controllers
{
    public class MatchController : Controller
    {
        private readonly DataBase _context;

        public MatchController(DataBase context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var matches = _context.Matches
                .Include(m => m.Team)
                .ToList();
            return View(matches);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewData["Teams"] = new SelectList(_context.Teams, "Id", "Name");
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("HomeTeamID, AwayID, MatchDate")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Teams"] = new SelectList(_context.Teams, "Id", "Name", match.HomeTeamID);
            return View(match);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _context.Matches.Find(id);

            if (match == null)
            {
                return NotFound();
            }

            ViewData["Teams"] = new SelectList(_context.Teams, "Id", "Name", match.HomeTeamID);
            return View(match);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, HomeTeamID, AwayID, MatchDate")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Teams"] = new SelectList(_context.Teams, "Id", "Name", match.HomeTeamID);
            return View(match);
        }

        [HttpGet("Details/{id}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _context.Matches
                .Include(m => m.Team)
                .FirstOrDefault(m => m.Id == id);

            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _context.Matches
                .Include(m => m.Team)
                .FirstOrDefault(m => m.Id == id);

            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var match = _context.Matches.Find(id);
            _context.Matches.Remove(match);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
