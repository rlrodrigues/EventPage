using System;
using System.Threading.Tasks;
using ProEventos.Application.Interface;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            this._eventoRepository = eventoRepository;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _eventoRepository.Add(model);

                if(await _eventoRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
                
                if(evento == null) 
                    throw new Exception("Evento não encontrado");

                _eventoRepository.Delete(evento);

                if(await _eventoRepository.SaveChangesAsync())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante)
        {
            try
            {
                return await _eventoRepository.GetAllEventosAsync(incluirPalestrante);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrante)
        {
            try
            {
                return await _eventoRepository.GetEventoByIdAsync(eventoId, incluirPalestrante);
            }
            catch (Exception ex)
            {   
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante)
        {
            try
            {
                return await _eventoRepository.GetAllEventosByTemaAsync(tema, incluirPalestrante);
            }
            catch (Exception ex)
            {   
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEnvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);

                if(evento == null) 
                    throw new Exception("Evento não encontrado");
                    
                _eventoRepository.Update(evento);
                
                if(await _eventoRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }
    }
}