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
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Sex { get; set; }
        public int PubCount { get; set; }
        public int SubCount { get; set; }
        public int SubcribersCount { get; set; }       
    }
}
