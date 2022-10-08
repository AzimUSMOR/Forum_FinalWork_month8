using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.Models
{
    public class User : IdentityUser<int>
    {
        public string Avatar { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
