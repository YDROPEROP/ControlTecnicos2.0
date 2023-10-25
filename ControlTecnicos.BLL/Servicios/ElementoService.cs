using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.TDOs;

namespace ControlTecnicos.BLL.Servicios
{
    public class ElementoService : IElementoService
    {
        private readonly IGenericRepository<ElementosDTO> _elementoRepository;

        public ElementoService(IGenericRepository<ElementosDTO> genericRepository)
        {
            this._elementoRepository = genericRepository;
        }

        public Task<bool> Actualizar(ElementosDTO elementosDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ElementosDTO> Insertar(ElementosDTO elementosDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ElementosDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ElementosDTO>> ObtenerTodos()
        {
            return await this._elementoRepository.ObtenerTodos();
        }
    }
}
