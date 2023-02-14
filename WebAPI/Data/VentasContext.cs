using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class VentasContext : DbContext
    {

        public VentasContext(DbContextOptions<VentasContext> options)
           : base(options) { }


        public DbSet<Ventas> _ventas { get; set; }
    }
}
