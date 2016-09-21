using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradPath.App_Code.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public string Role { get; set; }
    }
}