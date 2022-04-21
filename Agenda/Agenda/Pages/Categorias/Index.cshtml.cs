using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        // using Agenda.Datos;
        private readonly Db _contexto;

        public IndexModel(Db contexto)
        {
            _contexto = contexto;

        }

        public IEnumerable<Categoria> Categorias { get; set; }

        public async Task OnGet()
        {
            // Microsoft.EntityFrameworkCore; ToListAsync()
            // Categorias es la tabla en la DB.
            //
            Categorias = await _contexto.Categorias.ToListAsync();

        }

    }
}
