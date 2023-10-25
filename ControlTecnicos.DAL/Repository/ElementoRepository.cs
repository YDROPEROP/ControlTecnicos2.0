using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models.Entities;
using ControlTecnicos.Models.TDOs;
using Microsoft.EntityFrameworkCore;

namespace ControlTecnicos.DAL.Repository
{
    public class ElementoRepository : IGenericRepository<ElementosDTO>
    {
        private readonly DbtecnicosV20Context _dbContext;

        public ElementoRepository(DbtecnicosV20Context dbtecnicosV20Context)
        {
            _dbContext = dbtecnicosV20Context;
        }
        public async Task<bool> Actualizar(ElementosDTO dto)
        {
            var elementos = await (from e in this._dbContext.Elementos
                             where e.Id == dto.Id
                             select new Elemento
                             {
                                 Id = dto.Id,
                                 Nombre = dto.Nombre
                             }).FirstOrDefaultAsync();
            this._dbContext.Elementos.Update(elementos);

            return true;
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ElementosDTO> Insertar(ElementosDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ElementosDTO> Obtener(int id)
        {
            var elemento = await (from e in this._dbContext.Elementos
                            where e.Id == id
                            select new ElementosDTO
                            {
                                Id = e.Id,
                                Nombre = e.Nombre
                            }).FirstOrDefaultAsync();
            return elemento; 
        }

        public async Task<List<ElementosDTO>> ObtenerTodos()
        {
            var elementos = await (from e in this._dbContext.Elementos
                                   select new ElementosDTO
                                   {
                                       Id = e.Id,
                                       Nombre = e.Nombre
                                   }).ToListAsync();

            return elementos;
        }


    }
}
