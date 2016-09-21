using System.Collections.Generic;

namespace GradPath.App_Code.Model
{
    public class Degree
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string College { get; set; }
        public string Concentration { get; set; }
        public string Description { get; set; }
        public List<DegreeRequirement> Requirements { get; set; }
    }
}