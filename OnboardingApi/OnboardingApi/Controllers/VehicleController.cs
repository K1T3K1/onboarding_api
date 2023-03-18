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
            var returnVehicles = _mapper.Map<List<VehicleWithDriverDetailsDto>>(vehicles);
            return returnVehicles;
        }
        
        [HttpGet("/{serialNumber}")]
        public ActionResult<VehicleWithDriverDetailsDto> Get(string serialNumber)
        {
            var vehicle = GetVehicle(serialNumber);
            if(vehicle == null)
            {
                return NotFound("No such vehicle");
            }
            var returnVehicle = _mapper.Map<VehicleWithDriverDetailsDto>(vehicle);
            return returnVehicle;
        }

        [HttpPost]
        async public Task<ActionResult> Post([FromBody] VehicleDto model)
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
            await _driversContext.SaveChangesAsync();

            var key = vehicle.SerialNumber.ToUpper();
            return Ok();
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

            return Ok();
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

            return Ok();
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

            return Ok();
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
            var vehicle = _driversContext.Vehicle.FirstOrDefault(v => v.SerialNumber.ToLower() == serialNumber.ToLower());
            if (vehicle != null)
            {
                return vehicle;
            }
            else
            {

                return null;
            }
        }

        private bool IsValidSN(string serialNumber)
        {
            if (_driversContext.Vehicle.FirstOrDefault(v => v.SerialNumber.ToLower() == serialNumber.ToLower()) != null)
            {
                return false;
            }
            return true;
        }
    }
}