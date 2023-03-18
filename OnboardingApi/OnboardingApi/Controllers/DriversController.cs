using Microsoft.AspNetCore.Mvc;
using OnboardingApi.Entities;
using OnboardingApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<DriverDto>> Get()
        {
            var drivers = _driversContext.Driver.Include(d => d.Vehicle).ToList();
            var returnDrivers = _mapper.Map<List<DriverDto>>(drivers);
            return returnDrivers;
        }

        [HttpGet("{licenseId}")]
        public ActionResult<DriverDto> Get(string licenseId)
        {
            var driver = GetDriver(licenseId);
            var returnDriver = _mapper.Map<DriverDto>(driver);
            return returnDriver;
        }

        [HttpPost]
        async public Task<ActionResult> Post([FromBody] DriverOnlyDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!IsValidLicenseID(model.LicenseId))
            {
                return BadRequest("Driver with Identical LicenseID already exists");
            }
            var driver = _mapper.Map<Driver>(model);
            _driversContext.Driver.Add(driver);
            await _driversContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("/assign-vehicle")]
        public ActionResult PutVehicle([FromBody]AssignVehicleDto model)
        {
            Vehicle? vehicle = GetVehicle(model.SerialNumber);
            Driver? driver = GetDriver(model.LicenseId);
            if (vehicle == null)
            {
                return NotFound("No such vehicle");
            }
            else if (driver == null)
            {
                return NotFound("No such driver");
            }
            driver.VehicleId = vehicle.Id;
            vehicle.DriverId = driver.Id;
            _driversContext.SaveChanges();
            return Ok();
        }

        [HttpPut("/{licenseId}/change-name/{name}")]
        public ActionResult PutName(string licenseId, string name)
        {
            Driver? driver = GetDriver(licenseId);
            if (driver == null)
            {
                return NotFound("No such driver");
            }
            driver.Name = name;
            _driversContext.SaveChanges();
            var key = driver.Name.ToLower()+ "-" + driver.Surname.ToLower();
            return Ok();
        }

        [HttpPut("/{licenseId}/change-surname/{surname}")]
        public ActionResult PutSurname(string licenseId, string surname)
        {
            Driver? driver = GetDriver(licenseId);
            if (driver == null)
            {
                return NotFound("No such driver");
            }
            driver.Surname = surname;
            _driversContext.SaveChanges();
            var key = driver.Name.ToLower()+ "-" + driver.Surname.ToLower();
            return Ok();
        }

        [HttpPut("/{oldLicenseId}/change-licenseid/{newLicenseId}")]
        public ActionResult PutLicenseId(string oldLicenseId, string newLicenseId)
        {
            Driver? driver = GetDriver(oldLicenseId);
            if (driver == null)
            {
                return NotFound("No such driver");
            }
            if(!IsValidLicenseID(newLicenseId))
            {
                return BadRequest("Driver with Identical LicenseID already exists");
            }
            driver.LicenseId = newLicenseId;
            _driversContext.SaveChanges();
            var key = driver.Name.ToLower()+ "-" + driver.Surname.ToLower();
            return Ok();
        }

        [HttpDelete("{licenseId}")]
        public ActionResult Delete(string licenseId)
        {
            var driver = GetDriver(licenseId);
            if(driver == null)
            {
                return NotFound("No such driver");
            }
            _driversContext.Remove(driver);
            _driversContext.SaveChanges();

            return NoContent();
        }

        private Driver? GetDriver(string licenseId)
        {
            var driver = _driversContext.Driver.Where(d => d.LicenseId.ToLower() == licenseId.ToLower()).ToList();
            if(driver.Any())
            {
                return driver.First();
            }
            else
            {
                return null;
            }
        }

        private Vehicle? GetVehicle(string serialNumber)
        {
            var vehicle = _driversContext.Vehicle.FirstOrDefault(v => v.SerialNumber.ToLower() == serialNumber.ToLower());
            if(vehicle != null)
            {
                return vehicle;
            }
            else
            {
                
                return null;
            }
        }

        private bool IsValidLicenseID(string licenseId)
        {
            if (_driversContext.Driver.FirstOrDefault(d => d.LicenseId.ToLower() == licenseId.ToLower()) != null)
            {
                return false;
            }
            return true;
        }
    }
}