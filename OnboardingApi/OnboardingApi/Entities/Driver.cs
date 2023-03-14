using System;

namespace OnboardingApi.Entities
{
    public class Driver
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string Surname{get;set;}
        public virtual Vehicle Vehicle{get;set;}
        public int VehicleId{get;set;}
    }
}