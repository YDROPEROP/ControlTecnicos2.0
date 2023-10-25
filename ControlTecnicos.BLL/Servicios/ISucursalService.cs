using ControlTecnicos.Models.TDOs;

namespace ControlTecnicos.BLL.Servicios
{
    public interface ISucursalService
    {
        Task<SucursalDTO> Insertar(SucursalDTO sucursal);
        Task<bool> Actualizar(SucursalDTO sucursal);
        Task<bool> Eliminar(int id);
        Task<SucursalDTO> Obtener(int id);
        Task<List<SucursalDTO>> ObtenerTodos();
    }
}
