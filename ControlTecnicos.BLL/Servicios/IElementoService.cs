using ControlTecnicos.Models.TDOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface IElementoService
    {
        Task<ElementosDTO> Insertar(ElementosDTO elementosDTO);
        Task<bool> Actualizar(ElementosDTO elementosDTO);
        Task<bool> Eliminar(int id);
        Task<ElementosDTO> Obtener(int id);
        Task<List<ElementosDTO>> ObtenerTodos();
    }
}
