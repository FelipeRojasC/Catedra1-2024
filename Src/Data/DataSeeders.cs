using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1_api.Src.Models;

namespace catedra1_api.Src.Data.Migrations
{
    public class DataSeeders
    {
       public static void Iniialize(IServiceProvider serviceProvider){
            using (var scope = serviceProvider.CreateScope()){
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();

                if(!context.Generos.Any()){
                    context.Generos.AddRange(
                        new Genero {tipo = "masculino"},
                        new Genero {tipo = "femenino"},
                        new Genero {tipo = "otro"},
                        new Genero {tipo = "prefiero no decirlo"}
                    );
                }
                context.SaveChanges();

                if(!context.Usuarios.Any())
                {
                    var usuario = new Usuario {  
                        rut = "192644259",
                        nombre = "Felipe",
                        correo = "correo1@gmail.com",
                        generoId = 1,
                        fechaNachimiento = new DateTime(2000,10,25)
                    };
                    context.Usuarios.Add(usuario);
                }
                context.SaveChanges();
            }
            
        }
    }
}