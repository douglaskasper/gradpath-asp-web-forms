using System.Collections.Generic;
using GradPath.App_Code.Model.Support;

namespace GradPath.App_Code.Model
{
    public class GraduationPathSearch
    {
        public int Id { get; set; }
        public List<SearchOption> Options { get; set; }
        public Account Account { get; set; }
    }
}