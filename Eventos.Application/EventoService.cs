using Eventos.Application.Interfaces;
using Eventos.Domain;
using Eventos.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventosPersistence _eventosPersistence;
        public EventoService(IGeralPersistence geralPersistence, IEventosPersistence eventosPersistence)
        {
            _geralPersistence = geralPersistence;
            _eventosPersistence = eventosPersistence;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventosPersistence.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventosPersistence.GetEventoByIdAsync(eventoId, false);

                if (evento is null) throw new Exception("Evento para delete não foi encontrado");

                _geralPersistence.Delete(evento);

                return (await _geralPersistence.SaveChangesAsync());
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
               var evento = await _eventosPersistence.GetEventoByIdAsync(eventoId, false);

                if (evento is null) return null;

                model.Id = evento.Id;

                _geralPersistence.Update(model);
                
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventosPersistence.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventosPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos is null) return null;

                return eventos;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventosPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (eventos is null) return null;

                return eventos;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventosPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos is null) return null;

                return eventos;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

    }
}
