using lesson62.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.Controllers
{
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
                await _context.Topics.AddAsync(t);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "User", new { name = _userManager.GetUserAsync(User).Result.Id });
            }
            else
            {
                return View(t);
            }
        }
    }
}
