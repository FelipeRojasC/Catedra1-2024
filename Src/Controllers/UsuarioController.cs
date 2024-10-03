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
                return TypedResults.BadRequest("Genero no valido.");
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


            return TypedResults.BadRequest("Datos invalidos.");
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
        public ActionResult<string> DeleteProduct(int id)
        {
            try
            {
                var result = _usuarioRepository.EliminarUsuario(id).Result;
                if (result)
                {
                    return Ok("Usuario eliminado con éxito");
                }
                return BadRequest("Usuario no encontrado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
}
}