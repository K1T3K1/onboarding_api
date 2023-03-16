namespace OnboardingApi.Models
{
    public class DriverDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseId { get; set; }
        public string SerialNumber { get; set; }
    }

    public class DriverOnlyDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenseId { get; set; }
    }

    public class AssignVehicleDto
    {
        public string SerialNumber{get;set;}
        public string LicenseId {get;set;}
    }
}