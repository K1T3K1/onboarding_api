using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnboardingApi.Entities;
using OnboardingApi.Models;
using AutoMapper;


namespace OnboardingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly DriversContext _driversContext;
        private readonly IMapper _mapper;

        public VehicleController(DriversContext driversContext, IMapper mapper)
        {
            _driversContext = driversContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            var vehicles = _driversContext.Vehicle.ToList();
            return vehicles;
        }

        [HttpPost]
        public ActionResult Post([FromBody]VehicleDto model)
        {
            var vehicle = _mapper.Map<Vehicle>(model);
            _driversContext.Vehicle.Add(vehicle);
            _driversContext.SaveChanges();

            var key = vehicle.SerialNumber.ToUpper();
            return Created("api/controller/" + key, null);
        }
    }
}