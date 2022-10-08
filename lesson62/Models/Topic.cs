using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CommentCount { get; set; }
        public DateTime MakeTime { get; set; }        
        public int UserId { get; set; }
        public User User { get; set; }
        IEnumerable<Comment> Comments { get; set; }
    }
}
