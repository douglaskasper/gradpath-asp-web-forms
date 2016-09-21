using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradPath.App_Code.Model
{
    public class Building
    {
        public Campus Campus { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}