using JAOAssessment.Data;
using JAOAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JAOAssessment.Controllers
{
    public class VehicleViewController : Controller
    {
        private readonly VehicleContext _context;
        public VehicleViewController(VehicleContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ViewIndex()
        {
            //IEnumerable<Vehicle> vehicleObj = null;
            //HttpClient hc = new HttpClient();
            //hc.BaseAddress = new System.Uri("https://localhost:44336/");
            //var apiController = hc.GetAsync("Vehicle");
            //apiController.Wait();
            //var resultDisplay = apiController.Result;
            //if (resultDisplay.IsSuccessStatusCode)
            //{
            //    var readTable = resultDisplay.Content.ReadAsAsync<IList<Vehicle>>();
            //    readTable.Wait();
            //    vehicleObj = readTable.Result;
            //    return View(vehicleObj);

            //}
            //else
            //{
            //    vehicleObj = null;
            //    ModelState.AddModelError(string.Empty, "No Records Found");
            //    return Ok(resultDisplay.Content);
            //}

            //var vehicles = await _context.Vehicles.ToListAsync();
            //var vehiclesResult = await _context.Database.ExecuteSqlRaw("Exec [dbo].[VehicleConfigProcedure] SELECT ALL").ToL;
            var vehiclesResult = await _context.Vehicles.FromSqlRaw<Vehicle>("Exec [dbo].[VehicleConfigProcedure] SELECT_ALL").ToListAsync();
            _context.Database.ExecuteSqlRaw("Exec [dbo].[PaintProcedure] PopulatePaint");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[EngineProcedure] PopulateEngine");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[InteriorProcedure] PopulateInterior");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[BaseVehicleProcedure] PopulateBaseVehicle");

            return View(vehiclesResult);

            ////if (vehicles.Count > 0)
            ////{
            ////    return View(vehiclesResult);
            ////}
            ////else
            ////{
            ////    return Ok("No record found");
            ////}            
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ViewIndex));
            }
            return View(vehicle);
        }

        public async Task<IActionResult> GetBaseVehicles()
        {
            var baseVehicleResult = await _context.BaseVehicles.FromSqlRaw("Exec [dbo].[VehicleConfigProcedure] GET_BASE_VEHICLES").ToListAsync();
            return Ok(baseVehicleResult);
        }
        public async Task<IActionResult> GetEngines()
        {
            var engineResult = await _context.Engines.FromSqlRaw("Exec [dbo].[VehicleConfigProcedure] GET_ENGINES").ToListAsync();
            return Ok(engineResult);
        }
        public async Task<IActionResult> GetPaints()
        {
            var paintResult = await _context.Paints.FromSqlRaw("Exec [dbo].[VehicleConfigProcedure] GET_PAINTS").ToListAsync();
            return Ok(paintResult);
        }
        public async Task<IActionResult> GetInteriors()
        {
            var interiorResult = await _context.Interiors.FromSqlRaw("Exec [dbo].[VehicleConfigProcedure] GET_INTERIORS").ToListAsync();
            return Ok(interiorResult);
        }

    }
}