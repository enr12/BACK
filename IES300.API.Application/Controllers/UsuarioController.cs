using IES300.API.Domain.DTOs.Usuario;
using IES300.API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace IES300.API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult ObterTodosUsuarios()
        {
            try
            {
                var listausuariosOutput = _usuarioService.ObterTodosUsuarios();

                return Ok(listausuariosOutput);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterUsuarioPorId(int id)
        {
            try
            {
                var usuarioOutput = _usuarioService.ObterUsuarioPorId(id);

                return Ok(usuarioOutput);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }

        }

        [HttpPost]
        public IActionResult InserirUsuario([FromBody] UsuarioInsertDTO usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var response = _usuarioService.InserirUsuario(usuario);

                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult AlterarUsuario([FromBody] UsuarioUpdateDTO usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var usuarioOutputRetorno = _usuarioService.AlterarUsuario(usuario);

                return Ok(usuarioOutputRetorno);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _usuarioService.DeletarUsuario(id);

                return Ok(new { message = $"Usuario de Id: {id} foi deletado com sucesso" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("Validacao")]
        public IActionResult ValidarUsuario([FromBody] UsuarioValidateDTO usuarioValidate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var usuario = _usuarioService.ValidarUsuario(usuarioValidate);

                return Ok(usuario);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
