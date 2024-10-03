using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1_api.Src.Models;

namespace catedra1_api.Src.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> AgregarUsuario(Usuario usuario);
        Task<bool> VerificarRut(string rut);
        Task<List<Usuario>> ObtenerUsuario();
    }
}