using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.TDOs;

namespace ControlTecnicos.BLL.Servicios
{
    public class SucursalService : ISucursalService
    {
        private readonly IGenericRepository<SucursalDTO> _sucursalRepository;
        public SucursalService(IGenericRepository<SucursalDTO> genericRepository)
        {
            this._sucursalRepository = genericRepository;
        }

        public async Task<bool> Actualizar(SucursalDTO sucursal)
        {
            await this._sucursalRepository.Actualizar(sucursal);

            return true;
        }

        public async Task<SucursalDTO> Insertar(SucursalDTO sucursal)
        {
            return await this._sucursalRepository.Insertar(sucursal);

        }

        public async Task<bool> Eliminar(int id)
        {
            await this._sucursalRepository.Eliminar(id);

            return true;
        }

        public async Task<SucursalDTO> Obtener(int id)
        {
            return await this._sucursalRepository.Obtener(id);            
        }

        public async Task<List<SucursalDTO>> ObtenerTodos()
        {
            return await this._sucursalRepository.ObtenerTodos();
        }
    }
}
