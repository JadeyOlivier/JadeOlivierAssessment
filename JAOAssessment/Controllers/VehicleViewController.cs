using JAOAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JAOAssessment.Controllers
{
    public class VehicleViewController : Controller
    {
        public IActionResult ViewIndex()
        {
            IEnumerable<Vehicle> vehicleObj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new System.Uri("https://localhost:44336/");
            var apiController = hc.GetAsync("Vehicle");
            apiController.Wait();
            var resultDisplay = apiController.Result;
            if (resultDisplay.IsSuccessStatusCode)
            {
                var readTable = resultDisplay.Content.ReadAsAsync<IList<Vehicle>>();
                readTable.Wait();
                vehicleObj = readTable.Result;
            }
            else
            {
                vehicleObj = null;
                ModelState.AddModelError(string.Empty, "No Records Found");
            }

            return View(vehicleObj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new System.Uri("https://localhost:44336/Vehicle/");
            var apiController = hc.GetAsync("Create");
            apiController.Wait();
            var resultDisplay = apiController.Result;
            if (resultDisplay.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ViewIndex));
            }
            return Ok(resultDisplay);
        }

    }
}