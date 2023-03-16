using System.ComponentModel.DataAnnotations;

namespace OnboardingApi.Entities
{
    public class Vehicle
    {
        public int Id{get;set;}
        public int ProductionYear{get;set;}
        public int Mileage { get; set; }
        [Required]
        public string SerialNumber{get;set;}
        public int? DriverId{get;set;}
        public virtual Driver? Driver{get;set;}
    }
}