
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingApi.Entities
{
    public class Driver
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string Surname{get;set;}
        public string LicenseId{get;set;}
        public int? VehicleId{get;set;}
        [ForeignKey("VehicleId")]
        public virtual Vehicle? Vehicle{get;set;}
    }
}