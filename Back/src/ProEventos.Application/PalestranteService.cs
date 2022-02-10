using System;
using System.Threading.Tasks;
using ProEventos.Application.Interface;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Application
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IPalestranteRepository _palestranteRepository;

        public PalestranteService(IPalestranteRepository palestranteRepository)
        {
            this._palestranteRepository = palestranteRepository;
        }

        public async Task<Palestrante> AddPalestrante(Palestrante model)
        {
            try
            {
                _palestranteRepository.Add(model);

                if(await _palestranteRepository.SaveChangesAsync())
                {
                    return await _palestranteRepository.GetPalestranteByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePalestrante(int palestranteId)
        {
            try
            {
                var palestrante = await _palestranteRepository.GetPalestranteByIdAsync(palestranteId, false);
                
                _palestranteRepository.Delete(palestrante);

                if(await _palestranteRepository.SaveChangesAsync())
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

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos)
        {
            try
            {
                return await _palestranteRepository.GetAllPalestrantesAsync(incluirEventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluirEventos)
        {
            try
            {
                return await _palestranteRepository.GetPalestranteByIdAsync(palestranteId, incluirEventos);
            }
            catch (Exception ex)
            {   
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos)
        {
            try
            {
                return await _palestranteRepository.GetAllPalestrantesByNomeAsync(nome, incluirEventos);
            }
            catch (Exception ex)
            {   
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model)
        {
            try
            {
                var evento = await _palestranteRepository.GetPalestranteByIdAsync(palestranteId, false);

                _palestranteRepository.Update(evento);
                
                if(await _palestranteRepository.SaveChangesAsync())
                {
                    return await _palestranteRepository.GetPalestranteByIdAsync(model.Id, false);
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