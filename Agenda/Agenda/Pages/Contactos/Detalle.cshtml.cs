using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//

namespace Agenda.Pages.Contactos
{
    public class DetalleModel : PageModel
    {   
        //1
        // using Agenda.Datos -> Db
        private readonly Db _contexto;


        //2. CONSTRUCTOR E INYECCION DE DEPENDENCIA contexto
        public DetalleModel(Db contexto)
        {   _contexto = contexto;     
        }


        //3.
        [BindProperty]
        public Contacto Contactos { get; set; }


        //4.
        public async void OnGet(int id)
        {
            // using Microsoft.EntityFrameworkCore; => .Include()
            Contactos = await _contexto.Contactos
                             .Where(c => c.Id == id)
                             .Include(c => c.Categorias)
                             .FirstOrDefaultAsync();
        }


    }// class DetalleModel
}
