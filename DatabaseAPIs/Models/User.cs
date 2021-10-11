using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseAPIs.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}