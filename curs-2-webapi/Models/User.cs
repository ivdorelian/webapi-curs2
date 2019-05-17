using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.Models
{
    public class UserPostModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
