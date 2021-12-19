using JAOAssessment.Data;
using JAOAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
            var vehiclesResult = await _context.Vehicles.FromSqlRaw<Vehicle>("Exec [dbo].[VehicleConfigProcedure] SELECT_ALL").ToListAsync();
            _context.Database.ExecuteSqlRaw("Exec [dbo].[PaintProcedure] PopulatePaint");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[EngineProcedure] PopulateEngine");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[InteriorProcedure] PopulateInterior");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[BaseVehicleProcedure] PopulateBaseVehicle");

            return View(vehiclesResult);          
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle _vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("Exec [dbo].[VehicleConfigProcedure] {0},{1},{2},{3},{4},{5},{6},{7}", "INSERT_NEW_VEH ", null, 
                    Int16.Parse(_vehicle.Model), Int16.Parse(_vehicle.Engine), Int16.Parse(_vehicle.Paint),
                    Int16.Parse(_vehicle.Interior), _vehicle.Quantity, _vehicle.Price);
                //_context.Vehicles.Add(vehicle);
                //await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ViewIndex));
            }
            return View(_vehicle);
        }  
        
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || id <= 0)
            {
                return BadRequest();
            }

            _context.Database.ExecuteSqlRaw("Exec [dbo].[VehicleConfigProcedure] {0},{1},{2},{3},{4},{5},{6},{7}", "DELETE_VEHICLE", 
                id, null, null,null,null,null,null);

            return RedirectToAction(nameof(ViewIndex));

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