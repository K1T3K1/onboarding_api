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
    public class DriversController : ControllerBase
    {
        private readonly DriversContext _driversContext;
        private readonly IMapper _mapper;
        public DriversController(DriversContext driversContext, IMapper mapper)
        {
            _driversContext = driversContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Driver>> Get()
        {
            var drivers = _driversContext.Driver.ToList();
            drivers = _mapper.Map<List<Driver>>(drivers);
            return drivers;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Driver>> Get(int id)
        {
            var driver = _driversContext.Driver.Where(d => d.Id == id).ToList();
            driver = _mapper.Map<List<Driver>>(driver);
            return driver;
        }

        [HttpPost]
        public ActionResult Post([FromBody] DriverDto model)
        {
            var driver = _mapper.Map<Driver>(model);
            _driversContext.Driver.Add(driver);
            _driversContext.SaveChanges();

            var key = driver.Name.ToLower() + "-" + driver.Surname.ToLower();
            return Created("api/[controller]/" + key, null);
        }

        [HttpPut("assignVehicle/{id}")]
        public ActionResult Put(string serialNumber, [FromBody]DriverDto model)
        {
            if(!_driversContext.Vehicle.Any(v => v.SerialNumber.ToLower() == serialNumber.ToLower()))
            {
                return NotFound("No such vehicle");
            }
            try
            {
                var driver = _driversContext.Driver.First(d => (d.Name.ToLower() + d.Surname.ToLower()) == (model.Name.ToLower() + model.Surname.ToLower()));
            }
            driver.VehicleId = _driversContext.Vehicle.First();
            _driversContext.SaveChanges();
            var key = driver.Name.ToLower() + "-" + driver.Surname.ToLower();
            return Ok("api/[controller]/" + key);
        }
    }
}