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
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "19524884k",
                        nombre = "Oscar",
                        correo = "correo2@gmail.com",
                        generoId = 1,
                        fechaNachimiento = new DateTime(1990,09,14)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "219588471",
                        nombre = "Javiera",
                        correo = "correo3@gmail.com",
                        generoId = 2,
                        fechaNachimiento = new DateTime(2000,01,04)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "21454471k",
                        nombre = "Nicolas",
                        correo = "correo4@gmail.com",
                        generoId = 3,
                        fechaNachimiento = new DateTime(1986,12,31)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "94237483",
                        nombre = "Cristina",
                        correo = "correo5@gmail.com",
                        generoId = 2,
                        fechaNachimiento = new DateTime(1996,08,14)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "19544123k",
                        nombre = "Susana",
                        correo = "correo6@gmail.com",
                        generoId = 4,
                        fechaNachimiento = new DateTime(1978,04,05)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "195679756",
                        nombre = "Constanza",
                        correo = "correo7@gmail.com",
                        generoId = 2,
                        fechaNachimiento = new DateTime(1997,01,04)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "175900081",
                        nombre = "Jose",
                        correo = "correo8@gmail.com",
                        generoId = 4,
                        fechaNachimiento = new DateTime(1992,03,25)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "18542963k",
                        nombre = "Francisca",
                        correo = "correo9@gmail.com",
                        generoId = 1,
                        fechaNachimiento = new DateTime(2000,10,25)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    usuario = new Usuario {  
                        rut = "105200851",
                        nombre = "Marta",
                        correo = "correo10@gmail.com",
                        generoId = 1,
                        fechaNachimiento = new DateTime(2010,11,25)
                    };
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();
                }
            }
            
        }
    }
}