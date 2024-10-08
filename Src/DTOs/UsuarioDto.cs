using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catedra1_api.Src.DTOs
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "El campo rut es obligatorio.")]
        public string rut {get;set;}

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre tiene que tener al menos 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener mas de 100 caracteres.")]
        public string nombre {get;set;}

        [Required(ErrorMessage = "El campo email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email ingresado, no tiene formato válido.")]
        public string correo {get;set;}
        [Required(ErrorMessage = "El campo fecha de nacimiento es obligatorio.")]
        public string fechaNachimiento {get;set;}
        public int generoId {get;set;}
    }
}