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
    public class EditarModel : PageModel
    {
        // 1. using Agenda.Datos -> Db
        private readonly Db _contexto;

        // 2. CONSTRUCTOR
        public EditarModel(Db contexto)
        {
            _contexto = contexto;

        }


        // 3. Bind
        [BindProperty]
        // using Agenda.Modelos.ViewModels -> CrearContactoVM
        public CrearContactoVM ContactoVM { get; set; }


        // 4. OnGet()
        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVM = new CrearContactoVM()
            {
                // using Microsoft.EntityFrameworkCore
                ListaCategorias = await _contexto.Categorias.ToListAsync(),

                Contactos = await _contexto.Contactos.FindAsync(id)

                //Contactos = new Modelos.Contacto()
            };
            return Page();
        }




        // 5. OnPost()
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)  // todas las validaciones estan correctas.
            {
                // var CategFound = await _contexto.Categorias.FindAsync(Categorias.Id);
                var ContactoFound = await _contexto.Contactos.FindAsync(ContactoVM.Contactos.Id);
                // Grabar datos de Edit.
                ContactoFound.nombre        = ContactoVM.Contactos.nombre;
                ContactoFound.Email         = ContactoVM.Contactos.Email;
                ContactoFound.Telefono      = ContactoVM.Contactos.Telefono;
                ContactoFound.CategoriaId   = ContactoVM.Contactos.CategoriaId;
                ContactoFound.FechaCreacion = ContactoVM.Contactos.FechaCreacion;



                //await _contexto.Contactos.AddAsync(ContactoVM.Contactos);

                // Save on Database:
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }
        }// OnPost()





    }// class EditarModel
}
