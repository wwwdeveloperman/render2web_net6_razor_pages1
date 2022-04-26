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
    public class EditarModel : PageModel
    {

        // ------------------------------------------
        //  INCLUIR contexto:
        // using Agenda.Datos;
        private readonly Db _contexto;
        // Constructor:
        public EditarModel(Db contexto)
        {
            _contexto = contexto;

        }

        [BindProperty]
        // enlazar modelo Categoria con Tabla Categoria.
        //using Agenda.Modelos;
        public Categoria Categorias { get; set; }
        // ------------------------------------------

        
        // OnGet()   Funciona al tocar el boton [Editar] 
        //Modificar OnGet() para recibir lo q envia el form Editar.cshtml
        // <input type="hidden" asp-for="Categorias.Id" />  
        public async void OnGet(int Id)
        {
            Categorias = await _contexto.Categorias.FindAsync(Id);
        }

        
        // OnPost()    Funciona al tocar el boton [Aceptar] para grabar.
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)  // todas las validaciones estan correctas.
            {

                var CategFound = await _contexto.Categorias.FindAsync(Categorias.Id);
                CategFound.nombre = Categorias.nombre;   // desde el form ese nombre 
                CategFound.FechaCreacion = Categorias.FechaCreacion;

                // await _contexto.Categorias.AddAsync(Categorias);    estamos editando. esto NO
                // Save on Database:
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");             // (Pages\Index)

            }
            else
            {
                return RedirectToPage(); // ?
            }


        }// OnPost()


    }
}
