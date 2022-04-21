using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//   cambiar en el html al inicio el modelo :
//  @model Agenda.Pages.Categorias.BorrarModel          // <--------    OJO


namespace Agenda.Pages.Categorias
{
    public class BorrarModel : PageModel
    {

        // ------------------------------------------
        //  INCLUIR contexto:
        // using Agenda.Datos;
        private readonly Db _contexto;
        // Constructor:
        public BorrarModel(Db contexto)
        {
            _contexto = contexto;
        }

        
        
        // VINCULAR
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
                // kitar validacion del modelo en el form.
                

                var CategFound = await _contexto.Categorias.FindAsync(Categorias.Id);

                if(CategFound == null)
                {
                    return NotFound();
                }

                _contexto.Categorias.Remove(CategFound);

                // await _contexto.Categorias.AddAsync(Categorias);    solo Display, esto NO.

                // Save on Database:
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");             // (Pages\Index)

          


        }// OnPost()


    }
}
