using System.Collections.Generic;

namespace EY.CabinCrew.Model.Entities
{
    public partial class Roster
    {
        public string EmpId { get; set; }
        public PersonalDetails PersonalDetails { get; set; }
        public string Dept { get; set; }
        public List<Plan> Plan { get; set; }
    }
}
