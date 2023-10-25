using ControlTecnicos.Models.TDOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface ITecnicoService
    {
        Task<TecnicoDTO> Insertar(TecnicoDTO dto);
        Task<bool> Actualizar(TecnicoDTO dto);
        Task<bool> Eliminar(int id);
        Task<TecnicoDTO> Obtener(int id);
        Task<List<TecnicoDTO>> ObtenerTodos();       
    }
}
