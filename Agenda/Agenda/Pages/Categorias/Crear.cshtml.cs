using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda.Pages.Categorias
{
    public class CrearModel : PageModel
    {
        // ------------------------------------------
        //  INCLUIR contexto:
        // using Agenda.Datos;
        private readonly Db _contexto;

        public CrearModel(Db contexto)
        {
            _contexto = contexto;

        }

        [BindProperty]
        // enlazar modelo Categoria con Tabla Categoria.
        //using Agenda.Modelos;
        public Categoria Categorias { get; set; }
        // ------------------------------------------


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)  // todas las validaciones estan correctas.
            {
                await _contexto.Categorias.AddAsync(Categorias); 
                // Save on Database:
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }


        }// OnPost()



    }
}
