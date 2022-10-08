using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.Models
{
    public class UserContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public DbSet<Topic> Topics { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }        
    }
}
