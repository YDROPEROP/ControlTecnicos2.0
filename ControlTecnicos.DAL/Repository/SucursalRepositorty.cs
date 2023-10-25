using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models.Entities;
using ControlTecnicos.Models.TDOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTecnicos.DAL.Repository
{
    public class SucursalRepositorty : IGenericRepository<SucursalDTO>
    {
        private readonly DbtecnicosV20Context _dbContext;
        public SucursalRepositorty(DbtecnicosV20Context dbtecnicosV20Context)
        {
            this._dbContext = dbtecnicosV20Context;
        }
        public async Task<bool> Actualizar(SucursalDTO dto)
        {
            var sucursal = new Sucursal()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
            };

            this._dbContext.Sucursales.Update(sucursal);
            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sucursal = await this._dbContext.Sucursales.FirstAsync(s => s.Id == id); 

            this._dbContext.Sucursales.Remove(sucursal);
            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<SucursalDTO> Insertar(SucursalDTO dto)
        {
            var sucursal = new Sucursal()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };

            await this._dbContext.Sucursales.AddAsync(sucursal);
            await this._dbContext.SaveChangesAsync();

            dto.Id = sucursal.Id;

            return dto;
        }

        public async Task<SucursalDTO> Obtener(int id)
        {
            var sucursal = await (from s in this._dbContext.Sucursales
                            where s.Id == id
                            select new SucursalDTO
                            {
                                Id = s.Id,
                                Nombre= s.Nombre,
                            }).FirstAsync();

            return sucursal;
        }

        public async Task<List<SucursalDTO>> ObtenerTodos()
        {
            var sucursales = await (from s in this._dbContext.Sucursales
                              select new SucursalDTO
                              {
                                  Id= s.Id,
                                  Nombre= s.Nombre
                              }).ToListAsync();

            return sucursales;
        }
    }
}
