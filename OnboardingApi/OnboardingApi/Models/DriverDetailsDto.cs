
namespace OnboardingApi.Models
{
    public class DriverDetailsDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SerialNumber { get; set; }
    }

    public class DriverDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class DriverVehicleDto : DriverDto
    {
        public DriverVehicleDto(){}
        public DriverVehicleDto(DriverDto model)
        {
            this.Name = model.Name;
            this.Surname = model.Surname;
        }
        public DriverVehicleDto(DriverDto model, int vehicleId)
        {
            this.Name = model.Name;
            this.Surname = model.Surname;
            this.VehicleId = vehicleId;
        }
        public int VehicleId {get;set;}
    }
}