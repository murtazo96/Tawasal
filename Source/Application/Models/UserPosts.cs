using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Owner
    {
        public string id { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string picture { get; set; }
    }

    public class Posts
    {
        public string id { get; set; }
        public string image { get; set; }
        public int likes { get; set; }
        public List<string> tags { get; set; }
        public string text { get; set; }
        public DateTime publishDate { get; set; }
        public Owner owner { get; set; }
    }

    public class UserPosts
    {
        public List<Posts> data { get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }

        public DateTime GotAt { get; set; }
    }
}
