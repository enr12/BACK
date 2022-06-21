using IES300.API.Domain.DTOs.Patrocinador;
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
    public class PatrocinadorController : ControllerBase
    {
        private readonly IPatrocinadorService _patrocinadorService;

        public PatrocinadorController(IPatrocinadorService patrocinadorService)
        {
            _patrocinadorService = patrocinadorService;
        }

        [HttpGet]       
        public IActionResult ObterTodosPatrocinadores()
        {
            try
            {
                var listaPatrocinadoresOutput = _patrocinadorService.ObterTodosPatrocinadores();
               
                return Ok(listaPatrocinadoresOutput);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterPatrocinadorPorId(int id)
        {
            try
            {
                var patrocinadoresOutput = _patrocinadorService.ObterPatrocinadorPorId(id);

                return Ok(patrocinadoresOutput);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { message = ex.Message } );
            }
        }

        [HttpPost]
        public IActionResult InserirPatrocinador([FromBody] PatrocinadorInsertDTO patrocinadorInsert)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var patrocinadorOutput = _patrocinadorService.InserirPatrocinador(patrocinadorInsert);

                return StatusCode((int)HttpStatusCode.Created, patrocinadorOutput);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(new { message = ex.Message });
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

        [HttpPut]
        public IActionResult AlterarPatrocinador([FromBody] PatrocinadorUpdatetDTO patrocinadorUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var patrocinadorOutputRetorno = _patrocinadorService.AlterarPatrocinador(patrocinadorUpdate);

                return Ok(patrocinadorOutputRetorno);
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
        public IActionResult DeletarPatrocinador(int id)
        {
            try
            {
                _patrocinadorService.DeletarPatrocinador(id);

                return Ok(new { message = $"Patrocinador de Id: {id} foi deletado com sucesso" });
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

        [HttpGet]
        [Route("/testeAleatorio")]
        public IActionResult TesteAleatorio()
        {
            return Ok(_patrocinadorService.ObterPatrocinadorComFichaseTemaAleatorio());
        }
    }
}
