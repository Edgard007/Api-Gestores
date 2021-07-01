using apiGestores.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Context
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        // Representación de tabla DB
        public DbSet<Gestores_DB> gestores_db { get; set; } // Nombre Correcto de la base de datos
    }
}
