namespace EY.CabinCrew.Model.Entities
{
    public partial class PersonalDetails
    {
        public string Name { get; set; }
        public string Rank { get; set; }
        public string CrewType { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
        public long WorkExperience { get; set; }
        public bool Compliant { get; set; }
        public string LicenceNumber { get; set; }
        public string IssueDate { get; set; }
        public string ExpiryDate { get; set; }
        public long LicencePoints { get; set; }
    }
}
