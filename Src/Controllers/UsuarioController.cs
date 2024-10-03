using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using catedra1_api.Src.DTOs;
using catedra1_api.Src.Models;
using catedra1_api.Src.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace catedra1_api.Src.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {

    private readonly IGeneroRepository _generoRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository,IGeneroRepository generoRepository){
        _usuarioRepository = usuarioRepository;
        _generoRepository = generoRepository;
    }
    [HttpPost("")]
    public async Task<IResult> CrearUsuario(UsuarioDto usuarioDto){
        try{
            if(await _usuarioRepository.VerificarRut(usuarioDto.rut)){ 
                return TypedResults.Conflict();
            }
            if(!_generoRepository.VerificarGenero(usuarioDto.generoId).Result){
                return TypedResults.BadRequest("No existe ese categoria.");
            }
            var usuario = new Usuario {  
                        rut = usuarioDto.rut,
                        nombre = usuarioDto.nombre,
                        correo = usuarioDto.correo,
                        generoId = usuarioDto.generoId,
                        fechaNachimiento = DateTime.Parse(usuarioDto.fechaNachimiento)
                    };
            await _usuarioRepository.AgregarUsuario(usuario);
            return TypedResults.Ok();
        }
        catch(Exception ex){


            return TypedResults.BadRequest("Esta todo mal.");
        }
    }
    }
}