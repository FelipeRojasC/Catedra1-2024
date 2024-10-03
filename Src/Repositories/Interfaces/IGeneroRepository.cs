using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1_api.Src.Models;

namespace catedra1_api.Src.Repositories.Interfaces
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> GetGenero();

        Task<bool> VerificarGenero(int id);
    }
}