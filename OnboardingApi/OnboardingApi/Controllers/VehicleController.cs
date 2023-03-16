using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnboardingApi.Entities;
using OnboardingApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<VehicleWithDriverDetailsDto>> Get()
        {
            var vehicles = _driversContext.Vehicle.Include(v => v.Driver).ToList();
            var return_vehicles = _mapper.Map<List<VehicleWithDriverDetailsDto>>(vehicles);
            return return_vehicles;
        }
        
        [HttpGet("/{serialNumber}")]
        public ActionResult<VehicleWithDriverDetailsDto> Get(string serialNumber)
        {
            var vehicle = GetVehicle(serialNumber);
            if(vehicle == null)
            {
                return NotFound("No such vehicle");
            }
            var return_vehicle = _mapper.Map<VehicleWithDriverDetailsDto>(vehicle);
            return return_vehicle;
        }

        [HttpPost]
        public ActionResult Post([FromBody] VehicleDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!IsValidSN(model.SerialNumber))
            {
                return BadRequest("Vehicle with identical SN already exists");
            }
            var vehicle = _mapper.Map<Vehicle>(model);
            _driversContext.Vehicle.Add(vehicle);
            _driversContext.SaveChanges();

            var key = vehicle.SerialNumber.ToUpper();
            return Created("api/controller/" + key, null);
        }

        [HttpPut("/{serialNumber}/change-year/{productionYear}")]
        public ActionResult PutProductionYear(string serialNumber, int productionYear)
        {
            var vehicle = GetVehicle(serialNumber);
            if (vehicle == null)
            {
                return NotFound("No such vehicle");
            }
            vehicle.ProductionYear = productionYear;
            _driversContext.SaveChanges();

            return Ok("api/[controller]/" + vehicle.SerialNumber);
        }

        [HttpPut("/{serialNumber}/change-mileage/{mileage}")]
        public ActionResult PutMileage(string serialNumber, int mileage)
        {
            var vehicle = GetVehicle(serialNumber);
            if (vehicle == null)
            {
                return NotFound("No such vehicle");
            }
            vehicle.Mileage = mileage;
            _driversContext.SaveChanges();

            return Ok("api/[controller]/" + vehicle.SerialNumber);
        }

        [HttpPut("/{oldSerialNumber}/change-sn/{newSerialNumber}")]
        public ActionResult PutSerialNumber(string oldSerialNumber, string newSerialNumber)
        {
            var vehicle = GetVehicle(oldSerialNumber);
            if (vehicle == null)
            {
                return NotFound("No such vehicle");
            }
            if(!IsValidSN(newSerialNumber))
            {
                return BadRequest("Vehicle with identical SN already exists");
            }
            vehicle.SerialNumber = newSerialNumber;
            _driversContext.SaveChanges();

            return Ok("api/[controller]/" + vehicle.SerialNumber);
        }

        [HttpDelete("{serialNumber}")]
        public ActionResult Delete(string serialNumber)
        {
            var vehicle = GetVehicle(serialNumber);
            if (vehicle == null)
            {
                return NotFound("No such vehicle");
            }
            _driversContext.Remove(vehicle);
            _driversContext.SaveChanges();

            return NoContent();
        }

        private Vehicle? GetVehicle(string serialNumber)
        {
            var vehicle = _driversContext.Vehicle.Where(v => v.SerialNumber.ToLower() == serialNumber.ToLower()).ToList();
            if (vehicle.Any())
            {
                return vehicle.First();
            }
            else
            {

                return null;
            }
        }

        private bool IsValidSN(string serialNumber)
        {
            if (_driversContext.Vehicle.Where(v => v.SerialNumber.ToLower() == serialNumber.ToLower()).ToList().Any() == true)
            {
                return false;
            }
            return true;
        }
    }
}