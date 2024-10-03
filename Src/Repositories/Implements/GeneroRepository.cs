using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1_api.Src.Data;
using catedra1_api.Src.Models;
using catedra1_api.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace catedra1_api.Src.Repositories.Implements
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _context;

        public GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Genero>> GetGenero()
        {
            var generos = await _context.Generos.ToListAsync();
            return generos;
        }

        public async Task<bool> VerificarGenero(int id)
        {
           var genero = await _context.Generos.FindAsync(id);
            return genero != null;
        }
    }
}