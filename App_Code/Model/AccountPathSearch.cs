using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradPath.App_Code.Model
{
    public class AccountPathSearch
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public string Value { get; set; }
        public Account Account { get; set; }
    }
}