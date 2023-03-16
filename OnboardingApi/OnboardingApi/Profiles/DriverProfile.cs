using AutoMapper;
using OnboardingApi.Entities;
using OnboardingApi.Models;

namespace OnboardingApi
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<DriverDto, Driver>();
            CreateMap<Driver, DriverDto>().ForMember(d => d.SerialNumber, opt => opt.MapFrom(d => d.Vehicle.SerialNumber));
            CreateMap<DriverOnlyDto, Driver>();
        }
    }
}