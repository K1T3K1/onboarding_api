namespace OnboardingApi.Models
{
    public class VehicleDto
    {
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public string SerialNumber { get; set; }
    }

    public class VehicleDriverDto : VehicleDto
    {
        public int DriverId { get; set; }
    }

    public class VehicleDriverDetailsDto : VehicleDto
    {
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
    }

}