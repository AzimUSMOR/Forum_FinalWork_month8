using lesson62.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly UserContext _context;

        public CommentController(UserContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
