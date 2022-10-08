using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.ViewModels
{
    public class CommentsViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
