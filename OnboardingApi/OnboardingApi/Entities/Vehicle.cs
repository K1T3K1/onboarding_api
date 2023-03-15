using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace OnboardingApi.Entities
{
    public class Vehicle
    {
        public int Id{get;set;}
        public int ProductionYear{get;set;}
        public int Mileage { get; set; }
        public string SerialNumber{get;set;}
    }
}