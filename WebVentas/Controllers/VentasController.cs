using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebVentas.Modelo;

namespace WebVentas.Controllers
{
    public class VentasController : Controller
    {

        public async Task<ActionResult> Ventas()
        {

            var lista = new List<Ventas>();
            string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI2MDA3NjcyMC02NDE4LTQzYWUtOWNmNC1lODZkZjA3NTNjMTgiLCJuYW1laWQiOiJiNWQyMzNmMC02ZWMyLTQ5NTAtOGNkNy1mNDRkMTZlYzg3OGYiLCJub21icmUiOiJOb21icmUgVXN1YXJpbyIsImFwZWxsaWRvcyI6IkFwZWxsaWRvcyBVc3VhcmlvIiwiZW1haWwiOiJzbWVsZ2FyZWpvQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluaXN0cmFkb3IiLCJuYmYiOjE2NzYzNTIwNjksImV4cCI6MTY3NjQzODQ2OSwiaXNzIjoic21lbGdhcmVqb0BnbWFpbC5jb20iLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0NDMwMi8ifQ.kOCkJ70kBUbygJlapX5Xk0HcLt7jsaq2I2qwz5PnogE";

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://localhost:44302/");
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync("api/ventas");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Ventas>>(json_respuesta);
           
            }

            return View(lista);

        }
    }
}