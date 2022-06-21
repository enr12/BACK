using IES300.API.Domain.DTOs.Ficha;
using IES300.API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace IES300.API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FichaController : ControllerBase
    {
        private readonly IFichaService _fichaService;

        public FichaController(IFichaService fichaService)
        {
            _fichaService = fichaService;
        }

        [HttpGet]
        public IActionResult ObterTodosFichas()
        {
            try
            {
                var listaFichasOutput = _fichaService.ObterTodosFichas();

                return Ok(listaFichasOutput);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterFichaPorId(int id)
        {
            try
            {
                var fichasOutput = _fichaService.ObterFichaPorId(id);

                return Ok(fichasOutput);
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
        public IActionResult InserirFicha([FromBody] FichaInsertDTO fichaInsert)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var fichaOutput = _fichaService.InserirFicha(fichaInsert);

                return StatusCode((int)HttpStatusCode.Created, fichaOutput);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult AlterarFicha([FromBody] FichaUpdateDTO fichaUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var fichaOutputRetorno = _fichaService.AlterarFicha(fichaUpdate);

                return Ok(fichaOutputRetorno);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarFicha(int id)
        {
            try
            {
                _fichaService.DeletarFicha(id);

                return Ok(new { message = $"Ficha de Id: {id} foi deletada com sucesso" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}