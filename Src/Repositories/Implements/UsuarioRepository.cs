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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AgregarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerificarRut(string rut)
        {
            var usuario = await _context.Usuarios.Where(u => u.rut == rut).FirstOrDefaultAsync();
            return usuario != null;
        }
    }
}