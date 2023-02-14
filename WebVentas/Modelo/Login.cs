using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVentas.Modelo
{
    public class Login
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}