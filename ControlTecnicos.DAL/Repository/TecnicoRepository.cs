using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models.Entities;
using ControlTecnicos.Models.TDOs;
using Microsoft.EntityFrameworkCore;

namespace ControlTecnicos.DAL.Repository
{
    public class TecnicoRepository : IGenericRepository<TecnicoDTO>
    {
        private readonly DbtecnicosV20Context _dbContext;

        public TecnicoRepository(DbtecnicosV20Context dbtecnicosV20Context)
        {
            this._dbContext = dbtecnicosV20Context;
        }

        public async Task<bool> Actualizar(TecnicoDTO dto)
        {
            var tecnico = new Tecnico()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Codigo = dto.Codigo,
                SueldoBase = dto.SueldoBase,
                SucursalId = dto.SucursalId,
                FechaDeCreacion = dto.FechaDeCreacion,
                FechaDeModificacion = DateTime.Now
            };

            this._dbContext.Tecnicos.Update(tecnico);
            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var tecnico = await this._dbContext.Tecnicos.FirstAsync(tecnico => tecnico.Id == id);

            this._dbContext.Tecnicos.Remove(tecnico);
            this._dbContext.SaveChanges();

            return true;
        }

        public async Task<TecnicoDTO> Insertar(TecnicoDTO dto)
        {
            var tecnico = new Tecnico()
            {
                Nombre = dto.Nombre,
                Codigo = dto.Codigo,
                SueldoBase = dto.SueldoBase,
                SucursalId = dto.SucursalId,

            };
            this._dbContext.Tecnicos.Add(tecnico);
            await this._dbContext.SaveChangesAsync();

            dto.Id = tecnico.Id;

            return dto;
        }

        public async Task<TecnicoDTO> Obtener(int id)
        {
            var tecnico = await (from t in this._dbContext.Tecnicos
                           join s in this._dbContext.Sucursales on t.SucursalId equals s.Id
                           where t.Id == id
                           select new TecnicoDTO
                           {
                               Id = t.Id,
                               Nombre = t.Nombre,
                               Codigo = t.Codigo,
                               SueldoBase = t.SueldoBase,
                               SucursalId = t.SucursalId,
                               FechaDeCreacion = t.FechaDeCreacion,
                               FechaDeModificacion = t.FechaDeModificacion,
                               Sucursal = s
                           }).FirstOrDefaultAsync();

            return tecnico;
        }

        public async Task<List<TecnicoDTO>> ObtenerTodos()
        {
            var tecnicos = await (from t in this._dbContext.Tecnicos
                           join s in this._dbContext.Sucursales on t.SucursalId equals s.Id
                           select new TecnicoDTO
                           {
                               Id = t.Id,
                               Nombre = t.Nombre,
                               Codigo = t.Codigo,
                               SueldoBase = t.SueldoBase,
                               SucursalId = t.SucursalId,
                               FechaDeCreacion = t.FechaDeCreacion,
                               FechaDeModificacion = t.FechaDeModificacion,
                               Sucursal = s
                           }).ToListAsync();
            var elementosTecnico = await (from et in this._dbContext.ElementosTecnicos
                                    join e in this._dbContext.Elementos on et.ElementoId equals e.Id
                                    select new ElementosTecnicoDTO
                                    {
                                        Id = et.Id,
                                        TecnicoId = et.TecnicoId,
                                        ElementoId = et.ElementoId,
                                        Cantidad = et.Cantidad,
                                        Elemento = e

                                    }).ToListAsync();
            foreach (var t in tecnicos)
            {
                t.ElementosTecnicos = elementosTecnico.Where(et => et.TecnicoId == t.Id).ToList();
            }
            return tecnicos;
        }
    }
}
