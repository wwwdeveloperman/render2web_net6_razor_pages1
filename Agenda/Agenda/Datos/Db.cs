using Agenda.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Datos
{
    // Using EntityFrameworkCore -> DbContext
    public class Db : DbContext
    {
        public Db( DbContextOptions<Db> options ) : base(options)
        {
        }

        // DbSet:
        // using Agenda.Modelos; -> clase Categoria()
        // Darle nombre a la tabla para crearse con Migration, "Categorias"
        public DbSet<Categoria> Categorias { get; set; }

    }// class
}
