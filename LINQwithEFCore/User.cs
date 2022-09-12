using System;
using System.Collections.Generic;

namespace LINQwithEFCore
{
    public partial class User
    {
        public User()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
