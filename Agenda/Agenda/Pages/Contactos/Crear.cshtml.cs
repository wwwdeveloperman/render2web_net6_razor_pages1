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

        //1. using Agenda.Datos -> Db
        private readonly Db _contexto;
        
        //2. CONSTRUCTOR
        public CrearModel(Db contexto)
        {
            _contexto = contexto; 

        }


        // 3.
        [BindProperty]
        // using Agenda.Modelos.ViewModels -> CrearContactoVM
        public CrearContactoVM ContactoVM { get; set; }

        
        //4.
        public async Task<IActionResult>  OnGet()
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categorias.ToListAsync(),
                Contactos = new Modelos.Contacto()
            };
            return Page();
        }


        //5.
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)  // todas las validaciones estan correctas.
            {
                await _contexto.Contactos.AddAsync(ContactoVM.Contactos);
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
