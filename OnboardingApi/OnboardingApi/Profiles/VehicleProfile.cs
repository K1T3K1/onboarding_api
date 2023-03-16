using AutoMapper;
using OnboardingApi.Entities;
using OnboardingApi.Models;

namespace OnboardingApi
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleDto, Vehicle>();
            CreateMap<Vehicle, VehicleWithDriverDetailsDto>()
                .ForMember(d => d.DriverName, opt => opt.MapFrom(v => v.Driver.Name))
                .ForMember(d => d.DriverName, opt => opt.MapFrom(v => v.Driver.Surname))
                .ForMember(d => d.LicenseId, opt => opt.MapFrom(v => v.Driver.LicenseId));
        }
    }
}