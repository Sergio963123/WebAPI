using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VentasController : ControllerBase
    {

        private readonly VentasContext _context;
        public VentasController(VentasContext context)
            {
            _context = context;

            if (_context._ventas.Count() == 0)
            {
                List<Ventas> cliente = new List<Ventas>();
                cliente.Add(new Ventas { Id = 1, Cliente = "Sergio Melgarejo Berrio", Producto = "Jabon", Cantidad = 2, Total = 15.50, Fecha = DateTime.Now });
                cliente.Add(new Ventas { Id = 2, Cliente = "Juan Vetis Salas", Producto = "Hilo Dental", Cantidad = 2, Total = 30.00, Fecha = DateTime.Now });
                cliente.Add(new Ventas { Id = 3, Cliente = "Roberto Camacho Sivincha", Producto = "Shampoo", Cantidad = 1, Total = 8.00, Fecha = DateTime.Now });

                _context._ventas.AddRange(cliente);
                _context.SaveChanges();
            }
        }

        //Listar
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            var ventas = await _context._ventas.ToListAsync();

            return Ok(ventas);
        }

        ////Bsucar por id
        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetById(int id)
        //{

        //    var cliente = await _context._ventas.FirstOrDefaultAsync(x => x.Id == id);
        //    if (cliente == null)
        //    {
        //        var nf = NotFound("La Venta " + id.ToString() + " no existe.");
        //        return nf;
        //    }
        //    return Ok(cliente);
        //}

        //Agregar
        [HttpPost]
        public async Task<ActionResult> Post(Ventas x)
        {
            x.Fecha = DateTime.Now;
            _context._ventas.Add(x);
            await _context.SaveChangesAsync();
            var mensaje = "Se registro correctamente";

            return Ok(mensaje);
        }

        //Modificar

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Ventas ventas)
        {

            if (id == ventas.Id)
            {
                _context.Entry(ventas).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();

            }
            return BadRequest();

        }


        //Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var detalle = await _context._ventas.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }
            _context._ventas.Remove(detalle);
            await _context.SaveChangesAsync();
            return NoContent();

        }

    }






}