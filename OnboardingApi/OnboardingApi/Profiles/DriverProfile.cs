using AutoMapper;
using OnboardingApi.Entities;
using OnboardingApi.Models;

namespace OnboardingApi
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverDetailsDto>()
                .ForMember(d => d.SerialNumber, map => map.MapFrom(driver => driver.Vehicle.SerialNumber));
            CreateMap<DriverDto, Driver>();
            CreateMap<DriverVehicleDto, Driver>().IncludeBase<DriverDto, Driver>();
        }
    }
}