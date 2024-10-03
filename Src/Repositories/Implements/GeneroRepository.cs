using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1_api.Src.Data;
using catedra1_api.Src.Models;
using catedra1_api.Src.Repositories.Interfaces;

namespace catedra1_api.Src.Repositories.Implements
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _context;

        public GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Genero>> GetGenero()
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerificarGenero(int id)
        {
            throw new NotImplementedException();
        }
    }
}