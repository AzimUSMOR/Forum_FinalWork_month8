using lesson62.Enums;
using lesson62.Models;
using lesson62.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, UserContext context, UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index(SortState sortOrder = SortState.DateDesc, int page = 1)
        {
            int pageSize = 2;
            IQueryable<Topic> topics = _context.Topics.Include(t => t.User);
            topics = topics.OrderByDescending(u => u.MakeTime);
            var count = topics.Count();
            var items = topics.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pvm = new PageViewModel(count, page, pageSize);
            var tvm = new TopicsViewModel
            {
                topics = items,
                pageViewModel = pvm
            };
            return View(tvm);
        }
    }
}
