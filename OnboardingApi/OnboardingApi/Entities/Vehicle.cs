using System;

namespace OnboardingApi.Entities
{
    public class Vehicle
    {
        public int Id{get;set;}
        public int ProductionYear{get;set;}
        public int Mileage { get; set; }
        public virtual Model Model{get;set;}
        public int ModelId{get;set;}
        
    }
}