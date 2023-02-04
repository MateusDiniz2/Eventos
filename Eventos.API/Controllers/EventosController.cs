using Eventos.Application.Interfaces;
using Eventos.Domain;
using Eventos.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private ILogger<EventosController> _logger;
        public EventosController(IEventoService eventoService, ILogger<EventosController> logger)
        {
            _eventoService = eventoService;
            _logger = logger;
        }

        public EventosContext Context { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Start controller Get");
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos is null) return NotFound("Nenhum evento não encontrado.");

                return Ok(eventos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Start controller GetById -> Id: {0}", id);
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                if (evento is null) return NotFound("Nenhum evento por id não encontrado.");

                return Ok(evento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                _logger.LogInformation("Start controller GetByTema -> Tema: {0}", tema);
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento is null) return NotFound("Nenhum evento por tema não encontrado.");

                return Ok(evento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento model)
        {
            try
            {
                _logger.LogInformation("Start controller Post -> Evento: {0}", model.Tema);
                var evento = await _eventoService.AddEventos(model);
                if (evento is null) return BadRequest("Erro ao tentar adicionar um Evento");

                return Ok(evento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, Evento model)
        {
            try
            {
                _logger.LogInformation("Start controller Put -> Id: {0}, Evento: {1}", id, model.Tema);
                var evento = await _eventoService.UpdateEvento(id, model);
                if (evento is null) return BadRequest("Erro ao tentar alterar um Evento por id");

                return Ok(evento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Start controller Delete -> Id: {0}", id);
                return await _eventoService.DeleteEvento(id) ?
                    Ok("Deletado") : 
                    BadRequest("Evento não deletado");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
