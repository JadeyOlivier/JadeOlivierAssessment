using JAOAssessment.Data;
using JAOAssessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JAOAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleContext _context;
        public VehicleController(VehicleContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> GetVehicles()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return Ok(vehicles);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GetVehicles));
            }

            return Ok(" boo");
        }

        [Route("api/[controller]/InsertVehicle")]
        [HttpPost]
        public Vehicle InsertVehicle(Vehicle _vehicle)
        {
            using (_context)
            {
                _context.Vehicles.Add(_vehicle);
                _context.SaveChanges();
            }

            return _vehicle;
        }


        //public async Task<IActionResult> Index()
        //{
        //    var vehicles = await _context.Vehicles.ToListAsync();
        //    return View(vehicles);
        //}

        // //GET: api/Cars
        //[HttpGet]
        // public async Task<ActionResult<IEnumerable<Vehicle>>> GetCar()
        // {
        //     //var vehicles?? = 
        //     var vehicles = _context.Vehicles.ToListAsync();
        //     return await _context.Vehicles.ToListAsync();
        // }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("Hello");
        //}

        // public

    }
}