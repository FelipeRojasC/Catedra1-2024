using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1_api.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace catedra1_api.Src.Data
{
    public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Usuario> Usuarios {get; set;} = null;
        public DbSet<Genero> Generos {get; set;} = null;
    }
}