using System;

namespace EY.CabinCrew.Model.Entities
{
    public partial class FlightDetails
    {
        public string Code { get; set; }
        public DateTimeOffset FlightStartDate { get; set; }
        public string Source { get; set; }
        public string SourceCode { get; set; }
        public string SourceFlightCode { get; set; }
        public string SourceCurrencyCode { get; set; }
        public string FlightDepartueTime { get; set; }
        public string Destination { get; set; }
        public string DestinationCode { get; set; }
        public string DestinationFlightCode { get; set; }
        public string DestinationCurrencyCode { get; set; }
        public DateTimeOffset FlightEndDate { get; set; }
        public string FlightArrivalTime { get; set; }
        public string LayOVer { get; set; }
        public string TravelDuraion { get; set; }
        public string GateNumber { get; set; }
        public string Blockhours { get; set; }
        public string AwayfromBase { get; set; }
        public string GateOpensAt { get; set; }
        public string AcType { get; set; }
        public string TailNo { get; set; }
    }
}
