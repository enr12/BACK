using IES300.API.Domain.DTOs.Tema;
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
    public class TemaController : ControllerBase
    {
        private readonly ITemaService _temaService;

        public TemaController(ITemaService temaService)
        {
            _temaService = temaService;
        }

        [HttpGet]
        public IActionResult ObterTodosTemas()
        {
            try
            {
                var listatemasOutput = _temaService.ObterTodosTemas();

                return Ok(listatemasOutput);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterTemaPorId(int id)
        {
            try
            {
                var temaOutput = _temaService.ObterTemaPorId(id);

                return Ok(temaOutput);
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
        public IActionResult InserirTema([FromBody] TemaInsertDTO tema)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var response = _temaService.InserirTema(tema);

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
        public IActionResult AlterarTema([FromBody] TemaUpdateDTO tema)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var temaOutputRetorno = _temaService.AlterarTema(tema);

                return Ok(temaOutputRetorno);
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
        public IActionResult DeletarTema(int id)
        {
            try
            {
                _temaService.DeletarTema(id);

                return Ok(new { message = $"Tema de Id: {id} foi deletado com sucesso" });
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
        [Route("Fichas")]
        public IActionResult InserirTemaComFichas([FromBody] TemaFichasInsertDTO temaFichasDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var response = _temaService.InserirTemaComFichas(temaFichasDTO);

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
    }
}
