using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using catedra1_api.Src.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace catedra1_api.Src.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
    [HttpPost("")]
    public IResult CrearUsuario(UsuarioDto usuarioDto){
        return TypedResults.Ok();
    }
    }
}