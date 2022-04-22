using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class CrearModel : PageModel
    {
        // using Agenda.Datos -> Db
        private readonly Db _contexto;
        
        // CONSTRUCTOR
        public CrearModel(Db contexto)
        {
            _contexto = contexto; 

        }



        [BindProperty]
        // using Agenda.Modelos.ViewModels -> CrearContactoVM
        public CrearContactoVM ContactoVM { get; set; }

        public async Task<IActionResult>  OnGet()
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categorias.ToListAsync(),
                Contactos = new Modelos.Contacto()
            };
            return Page();
        }




    }
}
