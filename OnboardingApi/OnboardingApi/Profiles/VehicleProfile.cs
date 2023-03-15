using AutoMapper;
using OnboardingApi.Entities;
using OnboardingApi.Models;

namespace  OnboardingApi
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
           CreateMap<VehicleDto, Vehicle>();
        }
    }
}