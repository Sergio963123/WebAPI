using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVentas.Modelo
{
    public class Ventas
    {

        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}