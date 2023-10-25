using ControlTecnicos.Models.TDOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface IElementosTecnicoService
    {
        Task<bool> Insertar(List<ElementosTecnicoDTO> elementosDTO);
        Task<bool> Actualizar(List<ElementosTecnicoDTO> elementosDTO);
        Task<bool> Eliminar(int tecnicoId);
        Task<ElementosTecnicoDTO> Obtener(int id);
        Task<ElementosTecnicoDTO> ObtenerTodos();
    }
}
