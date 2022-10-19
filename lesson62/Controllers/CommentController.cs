using lesson62.Enums;
using lesson62.Models;
using lesson62.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index(int id, SortState sortOrder = SortState.DateAsc, int page = 1)
        {
            int pageSize = 4;
            List<Comment> comments = await _context.Comments.Include(c => c.User).Where(c => c.TopicId == id).OrderBy(c => c.WriteTime).ToListAsync();
            var count = comments.Count();
            var items = comments.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pvm = new PageViewModel(count, page, pageSize);
            var cvm = new CommentsViewModel
            {
                Comments = comments,
                pageViewModel = pvm
            };
            return PartialView("CommentsPartial", cvm);
        }

        public async Task<IActionResult> Details(int id)
        {
            Topic t = await _context.Topics.Include(t => t.User).Include(t => t.Comments).FirstOrDefaultAsync(t => t.Id == id);
            if (t != null)
                return View(t);
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Comment(string postId, string content)
        {
            Comment c = null;
            if (postId != null && content != null)
            {
                var user = await _userManager.GetUserAsync(User);
                c = new Comment()
                {
                    Body = content,
                    TopicId = Convert.ToInt32(postId),
                    UserId = user.Id,
                    WriteTime = DateTime.Now
                };
                var result = _context.Comments.AddAsync(c);
                if (result.IsCompleted)
                    await _context.SaveChangesAsync();
            }
            return Json(c);
        }
    }
}
