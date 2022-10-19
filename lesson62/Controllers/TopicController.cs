using lesson62.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly UserContext _context;

        public TopicController(UserContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        

        public async Task<IActionResult> Create()
        {
            User u = await _userManager.GetUserAsync(User);
            ViewBag.UserId = u.Id;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Topic t)
        {
            if (ModelState.IsValid)
            {
                t.MakeTime = DateTime.Now;
                t.User = await _userManager.GetUserAsync(User);
                await _context.Topics.AddAsync(t);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(t);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = _context.Topics
                .FirstOrDefault(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }
            return View(publication);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Topics.FindAsync(id);
            _context.Topics.Remove(publication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
