using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InscripcionSuperHero.Models
{
    //crear clase libro previo coneccion a base de datos
    public class Hero
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre De Personaje")]
        public string NameHero { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Creación")]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "La fecha de Muertes es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Muerte")]
        public DateTime DeathDate { get; set; }

        [Required(ErrorMessage = "El Poder es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 5)]
        [Display(Name = "Super Poder")]
        public string Powers { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "¿Es Famoso?")]
        public int Famous { get; set; }
    }
}
