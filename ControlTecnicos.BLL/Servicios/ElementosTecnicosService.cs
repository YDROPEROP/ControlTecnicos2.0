using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.TDOs;

namespace ControlTecnicos.BLL.Servicios
{
    public class ElementosTecnicosService : IElementosTecnicoService
    {
        private readonly IElementosTecnico _ElementosTecnicosRepository;

        public ElementosTecnicosService(IElementosTecnico genericRepository)
        {
            this._ElementosTecnicosRepository = genericRepository;
        }

        public Task<bool> Actualizar(List<ElementosTecnicoDTO> elementosTecnicoDTOs)
        {
            return this._ElementosTecnicosRepository.ActulizarListaET(elementosTecnicoDTOs);
        }

        public Task<bool> Eliminar(int tecnicoId)
        {
            return this._ElementosTecnicosRepository.Eliminar(tecnicoId);
        }

        public async Task<bool> Insertar(List<ElementosTecnicoDTO> elementosDTO)
        {
             await this._ElementosTecnicosRepository.InsertarTodosElelementosTec(elementosDTO);

            return true;
        }

        public Task<ElementosTecnicoDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ElementosTecnicoDTO> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
