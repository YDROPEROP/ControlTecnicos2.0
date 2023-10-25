using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.TDOs;

namespace ControlTecnicos.BLL.Servicios
{
    public class TecnicoService : ITecnicoService
    {
        private readonly IGenericRepository<TecnicoDTO> _tecnicoRepository;
        public TecnicoService(IGenericRepository<TecnicoDTO> tecnicoRepository)
        {
            this._tecnicoRepository = tecnicoRepository;
        }
                
        public async Task<bool> Actualizar(TecnicoDTO dto)
        {
            return await this._tecnicoRepository.Actualizar(dto);
        }

        public async Task<bool> Eliminar(int id)
        {
            await this._tecnicoRepository.Eliminar(id);

            return true;
        }

        public async Task<TecnicoDTO> Insertar(TecnicoDTO dto)
        {
            return await _tecnicoRepository.Insertar(dto);

        }

        public async Task<TecnicoDTO> Obtener(int id)
        {
            return await _tecnicoRepository.Obtener(id);
        }

        public async Task<List<TecnicoDTO>> ObtenerTodos()
        {
            return await this._tecnicoRepository.ObtenerTodos();
        }
    }
}
