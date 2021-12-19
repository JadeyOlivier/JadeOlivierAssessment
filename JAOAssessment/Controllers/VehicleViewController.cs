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

            var vehicles = await _context.Vehicles.ToListAsync();
            _context.Database.ExecuteSqlRaw("Exec [dbo].[PaintProcedure] PopulatePaint");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[EngineProcedure] PopulatePaint");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[InteriorProcedure] PopulatePaint");
            _context.Database.ExecuteSqlRaw("Exec [dbo].[BaseVehicleProcedure] PopulatePaint");
            if (vehicles.Count > 0)
            {
                return View(vehicles);
            }
            else
            {
                return Ok("No record found");
            }            
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

        //[Route("/[controller]/InsertNewVehicle")]
        //public async Task<IActionResult> InsertNewVehicle(Vehicle _vehicle)
        //{
        //    HttpClient hc = new HttpClient();
        //    hc.BaseAddress = new System.Uri("https://localhost:44336/");
        //    var apiController = hc.GetAsync("Vehicle/InsertVehicle");
        //    apiController.Wait();
        //    var resultDisplay = apiController.Result;
        //    if (resultDisplay.IsSuccessStatusCode)
        //    {
        //        return Ok(resultDisplay.Content);
        //        //return RedirectToAction(nameof(ViewIndex));
        //    }
        //    else
        //    {
        //        return Ok(resultDisplay);
        //    }           
        //}

    }
}