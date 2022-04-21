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
    public class DetalleModel : PageModel
    {

        // ------------------------------------------
        //  INCLUIR contexto:
        // using Agenda.Datos;
        private readonly Db _contexto;
        // Constructor:
        public DetalleModel(Db contexto)
        {
            _contexto = contexto;

        }

        [BindProperty]
        // enlazar modelo Categoria con Tabla Categoria.
        //using Agenda.Modelos;
        public Categoria Categorias { get; set; }
        // ------------------------------------------------------


        // OnGet()   Funciona al tocar el boton [Editar] 
        // Modificar OnGet() para recibir lo q envia el form Editar.cshtml
        // <input type="hidden" asp-for="Categorias.Id" />  
        public async void OnGet(int Id)
        {
            Categorias = await _contexto.Categorias.FindAsync(Id);
        }

        //  Aca no hay metodo OnPost(). por q es solo un display del record.
    }

}
