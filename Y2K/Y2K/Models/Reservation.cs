using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Y2K.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El E-mail es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]
        public string Email { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}