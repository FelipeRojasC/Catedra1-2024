using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catedra1_api.Src.DTOs
{
    public class UsuarioDto
    {
        public string rut {get;set;}
        public string nombre {get;set;}
        public string correo {get;set;}
        public string fechaNachimiento {get;set;}
        public int generoId {get;set;}
    }
}