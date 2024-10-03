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
            var rutAntiguo = await _context.Usuarios.FirstOrDefaultAsync(x => x.rut == usuario.rut);
            if(rutAntiguo != null)
            {
                throw new Exception(" El RUT ya existe.");
            }
            if(usuario.fechaNachimiento>= DateTime.Now)
            {
                throw new Exception("La fecha de nacimiento debe ser menor a la fecha actual.");
            }
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerificarRut(string rut)
        {
            var usuario = await _context.Usuarios.Where(u => u.rut == rut).FirstOrDefaultAsync();
            return usuario != null;
        }
        public async Task<List<Usuario>> ObtenerUsuario()
        {
            return await _context.Usuarios.Include(u => u.genero).ToListAsync();
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var eliminarUsuario = await _context.Usuarios.FindAsync(id);
            if(eliminarUsuario == null)
            {
                return false;
            }
            _context.Usuarios.Remove(eliminarUsuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditarUsuario(int id,Usuario usuario)
        {
           var usuariAntiguo = await _context.Usuarios.FindAsync(id);
           var rutAntiguo = await _context.Usuarios.FirstOrDefaultAsync(x => x.rut == usuario.rut && x.id != id);
            if(rutAntiguo != null)
            {
                throw new Exception(" El RUT ya existe.");
            }
            if(usuario.fechaNachimiento>= DateTime.Now)
            {
                throw new Exception("La fecha de nacimiento debe ser menor a la fecha actual.");
            }
            usuariAntiguo!.rut = usuario.rut;
            usuariAntiguo.nombre = usuario.nombre;
            usuariAntiguo.correo = usuario.correo;
            usuariAntiguo.fechaNachimiento = usuario.fechaNachimiento;
            usuariAntiguo.generoId = usuario.generoId;

            _context.Entry(usuariAntiguo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Usuario?> ObtenerUsuarioPorId(int id)
        {
           var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.id == id);
            return usuario!;
        }
    }
}