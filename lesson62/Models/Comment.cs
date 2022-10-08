using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime WriteTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
