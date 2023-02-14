using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class PanelController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Panel()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ListarVentas()
        {
              var ventas = new List<Ventas> ();
              var url = "";
            using (var httpClient  = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                  var content = await response.Content.ReadAsStringAsync();
                  ventas = JsonSerializer.Deserialize<List<Ventas>>(content);    
                }
            }
            return Json(ventas);
        }

    }
}
