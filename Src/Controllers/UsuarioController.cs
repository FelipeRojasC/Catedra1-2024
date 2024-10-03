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
                return TypedResults.BadRequest("Alguna validación no fue cumplida.");
            }
            var usuario = new Usuario {  
                        rut = usuarioDto.rut,
                        nombre = usuarioDto.nombre,
                        correo = usuarioDto.correo,
                        generoId = usuarioDto.generoId,
                        fechaNachimiento = DateTime.Parse(usuarioDto.fechaNachimiento)
                    };
            await _usuarioRepository.AgregarUsuario(usuario);
            return TypedResults.Ok("Usuario creado exitosamente.");
        }
        catch(Exception ex){


            return TypedResults.BadRequest("Alguna validación no fue cumplida.");
        }
    }
     [HttpGet("")]
    public async Task<IActionResult> ObtenerUsuario (){
         // Llamar al repositorio para obtener los usuarios
        var usuarios = await _usuarioRepository.ObtenerUsuario();
        
        // Retornar los productos como respuesta HTTP 200 OK
        return Ok(usuarios);
    }
    [HttpDelete("{id}")]
        public ActionResult<string> EliminarUsuario(int id)
        {
            try
            {
                var result = _usuarioRepository.EliminarUsuario(id).Result;
                if (result)
                {
                    return Ok("Usuario eliminado exitosamente.");
                }
                return NotFound("Usuario no encontrado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IResult> EditarUsuario(int id, UsuarioDto usuarioDto)
        {
            try
            {
                Usuario usuario = await _usuarioRepository.ObtenerUsuarioPorId(id);
                if(usuario == null){ 
                return TypedResults.NotFound("Usuario no encontrado");
                }
                if(!_generoRepository.VerificarGenero(usuarioDto.generoId).Result){
                return TypedResults.BadRequest("Alguna validación no fue cumplida.");
            }
            var usuarioEditado = new Usuario {  
                        rut = usuarioDto.rut,
                        nombre = usuarioDto.nombre,
                        correo = usuarioDto.correo,
                        generoId = usuarioDto.generoId,
                        fechaNachimiento = DateTime.Parse(usuarioDto.fechaNachimiento)
                    };
            await _usuarioRepository.EditarUsuario(id,usuarioEditado);
            return TypedResults.Ok("Usuario actualizado exitosamente.");
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e.Message);
            }
        }
}
}