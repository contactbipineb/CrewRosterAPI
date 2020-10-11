using System;

namespace EY.CabinCrew.Model.Entities
{
    public partial class Plan
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public long WeekNumber { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTimeOffset Date { get; set; }
        public bool VacationPlan { get; set; }
        public DateTimeOffset VacationDate { get; set; }
        public bool IsDayOff { get; set; }
        public bool Halt { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public FlightDetails FlightDetails { get; set; }
        public string VacationReason { get; set; }

    }
}
