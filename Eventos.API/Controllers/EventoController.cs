using Eventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _eventos = new Evento[] {
        new Evento()
        {
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Rio das Ostras",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString()
                },
                new Evento()
        {
                EventoId = 2,
                Tema = "Angular 12 e .NET 6",
                Local = "São Paulo",
                Lote = "1º Lote",
                QtdPessoas = 500,
                DataEvento = DateTime.Now.AddDays(2).ToString()
                }
        };
        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _eventos.Where(_eventos => _eventos.EventoId == id);
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
