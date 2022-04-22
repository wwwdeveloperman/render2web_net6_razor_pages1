using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Modelos.ViewModels
{
    public class CrearContactoVM
    {
        // para el ViewList.
        // Categoria es el modelo, sin "s" al final.
        public List<Categoria> ListaCategorias { get; set; }

        public Contacto Contactos { get; set; }
    }
}
/* la clase CrearContactoVM contiene 2 tablas 1. una List<Categoria> y 
 *  2. la tabla Contactos.
 * Y es instanciada en el .cs como contactoVM.
  
   => public CrearContactoVM ContactoVM { get; set; }
  
* Luego en el .cshtml  el ContactoVM contien dos tablas, Contactos y la lista de Categorias 
  asi q se debe indicar a cual datasource acceder, si es a Contactos seria asi:

<label asp-for="ContactoVM.Contactos.nombre" class="col-form-label">    </label>

*/

