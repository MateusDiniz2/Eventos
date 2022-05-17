using Eventos.Domain;
using Eventos.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Eventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly EventosContext _context;
        public EventosController(EventosContext context)
        {
            _context = context;
        }

        public EventosContext Context { get; }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _context.Eventos.Where(_eventos => _eventos.Id == id);
        }

        [HttpPost]
        public Evento Post(Evento evento)
        {
            return evento;
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }
    }
}
