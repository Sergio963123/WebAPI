using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class IndexController : Controller
    {
      
        
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Indexs()
        {
            var httpiCliente = new HttpClient();
            var json = await httpiCliente.GetStringAsync("hhtp");
            var lista = JsonConvert.DeserializeObject<List<Ventas>>(json);

            return View(lista);
        }
    }
}
