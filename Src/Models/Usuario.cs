using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catedra1_api.Src.Models
{
    public class Usuario
    {
        [Key]
        public int id {get;set;}
        public string rut {get;set;}
        public string nombre {get;set;}
        public string correo {get;set;}
        public DateTime fechaNachimiento {get;set;}

        //relaciones

        public int generoId {get;set;}
        public Genero genero {get;set;}
    }
}