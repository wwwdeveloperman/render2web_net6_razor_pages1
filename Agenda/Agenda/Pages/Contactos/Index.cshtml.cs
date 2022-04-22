using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class IndexModel : PageModel
    {

        // ------------------------------------------
        //  INCLUIR contexto:
        // using Agenda.Datos;
        private readonly Db _contexto;

        public IndexModel(Db contexto)
        {
            _contexto = contexto; 
        }
        // en el Startup.cs y esta en ConfigureServices

        
        //using System.Collections.Generic; (IEnumerable )
        // using Agenda.Modelos
        public IEnumerable<Contacto> Contactos { get; set; }


        public async Task OnGet()
        {
            // Agregar a Contactos su Categoria.
            Contactos = await _contexto.Contactos.Include(c => c.Categorias).ToListAsync();
        }


    }// class IndexModel
}
