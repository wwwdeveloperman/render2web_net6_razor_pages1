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
    public class BorrarModel : PageModel
    {
        //1. using Agenda.Datos -> Db
        private readonly Db _contexto;

        //2. CONSTRUCTOR

        public BorrarModel(Db contexto)
        {
            _contexto = contexto;

        }


        // 3.
        [BindProperty]
        // using Agenda.Modelos.ViewModels -> CrearContactoVM
        public CrearContactoVM ContactoVM { get; set; }


        //4. OnGet()
        public async Task<IActionResult> OnGet(int id)  // <---- Recibe  "id"
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categorias.ToListAsync(),
                //Contactos = new Modelos.Contacto()
                Contactos = await _contexto.Contactos.FindAsync(id) //  <---- Find(id)
            };
            return Page();
        }



        // OnPost()    Funciona al tocar el boton [Aceptar] para grabar.
        public async Task<IActionResult> OnPost()
        {
            // kitar validacion del modelo en el form.


            var ContactoFound = await _contexto.Contactos.FindAsync(ContactoVM.Contactos.Id);

            if (ContactoFound == null)
            {
                return NotFound();
            }
            else { 

                _contexto.Contactos.Remove(ContactoFound);
                
                // await _contexto.Categorias.AddAsync(Categorias);    solo Display, esto NO.

                // Save on Database:
                await _contexto.SaveChangesAsync();
            }

            return RedirectToPage("Index");             // (Pages\Index)




        }// OnPost()

    }// class BorrarModel
}
