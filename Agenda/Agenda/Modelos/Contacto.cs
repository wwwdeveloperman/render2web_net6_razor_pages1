using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Modelos
{




    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de Contacto es obligatorio.")]
        [StringLength(30, ErrorMessage = "{0}nombre entre {2} y {1}", MinimumLength = 4)]
        public string nombre { get; set; }


        //[Required(ErrorMessage = "El nombre de Contacto es obligatorio.")]
        [StringLength(30, ErrorMessage = "{0}nombre entre {2} y {1}", MinimumLength = 4)]
        public string Email { get; set; }


        [StringLength(30, ErrorMessage = "{0}nombre entre {2} y {1}", MinimumLength = 4)]
        public string Telefono { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creacion")]
        public DateTime? FechaCreacion { get; set; }


        // Relacionar Id.Contacto con Id.Categorias :
        [Required]
        public int CategoriaId { get; set; }
        
        //Instanciar Categorias 
        public Categoria Categorias { get; set; }


    }// class Contacto
}
