using ControlTecnicos.DAL.DataContext;
using ControlTecnicos.Models.Entities;
using ControlTecnicos.Models.TDOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControlTecnicos.DAL.Repository
{
    public class ElementosTecnicoRepository : IElementosTecnico
    {
        private readonly DbtecnicosV20Context _dbContext;

        public ElementosTecnicoRepository(DbtecnicosV20Context dbtecnicosV20Context)
        {
            _dbContext = dbtecnicosV20Context;
        }

        public async Task<bool> ActulizarListaET(List<ElementosTecnicoDTO> elementosTecnicoDTOs)
        {
            var elementosPrevios = await this._dbContext.ElementosTecnicos.Where(et => et.TecnicoId == elementosTecnicoDTOs[0].TecnicoId).ToListAsync();

            foreach (var ePrevios in elementosPrevios)
            {
                if (!elementosTecnicoDTOs.Any(et => et.Id == ePrevios.Id))
                {

                    this._dbContext.Remove(ePrevios);
                }
            }

            foreach (var en in elementosTecnicoDTOs)
            {
                if (elementosPrevios.Any(ep => ep.Id == en.Id))
                {

                    var itemAntiguo = elementosPrevios.First(ep => ep.Id == en.Id);

                    this._dbContext.Entry(itemAntiguo).CurrentValues.SetValues(en);
                }
                else
                {
                    var nuevoElemento = new ElementosTecnico()
                    {
                        TecnicoId = elementosPrevios[0].TecnicoId,
                        ElementoId = en.ElementoId,
                        Cantidad = en.Cantidad
                    };
                    this._dbContext.ElementosTecnicos.Add(nuevoElemento);
                }
            }            

            await this._dbContext.SaveChangesAsync();
            return true;
            
        }

        public async Task<bool> Actualizar(ElementosTecnicoDTO dto)
        {
            var elementosTecnicos = new ElementosTecnico()
            {
                Id = dto.Id,
                TecnicoId = dto.TecnicoId,
                ElementoId = dto.ElementoId,
                Cantidad = dto.Cantidad,
                FechaCreacion = dto.FechaCreacion,
                FechaModificacion = DateTime.Now
            };

            this._dbContext.ElementosTecnicos.Update(elementosTecnicos);
            await this._dbContext.SaveChangesAsync();

            return true;
        }      

        public async Task<bool> Eliminar(int TecnicoId)
        {
            /*var modelo = await this._dbContext.ElementosTecnicos.Where(et => et.Id == TecnicoId).ToArrayAsync();*/

            var modelo = await (from et in this._dbContext.ElementosTecnicos
                         where et.TecnicoId == TecnicoId
                                select et).ToListAsync();

            this._dbContext.ElementosTecnicos.RemoveRange(modelo);
            this._dbContext.SaveChanges();

            return true;
        }

        public async Task<ElementosTecnicoDTO> Insertar(ElementosTecnicoDTO dto)
        {
            var elementosTecnicos = new ElementosTecnico()
                                     {
                                         TecnicoId = dto.TecnicoId,
                                         ElementoId = dto.ElementoId,
                                         Cantidad = dto.Cantidad     
                                     };


            await this._dbContext.ElementosTecnicos.AddAsync(elementosTecnicos);
            await this._dbContext.SaveChangesAsync();
            return dto; 
        }

        public async Task<bool> InsertarTodosElelementosTec(List<ElementosTecnicoDTO> elementos)     

        {
            List<ElementosTecnico> listaEntidad = new List<ElementosTecnico>();

            foreach (var dto in elementos)
            {
                ElementosTecnico entidad = new ElementosTecnico
                {
                    TecnicoId = dto.TecnicoId,
                    ElementoId = dto.ElementoId,
                    Cantidad = dto.Cantidad
                };

                listaEntidad.Add(entidad);
            }

            await this._dbContext.ElementosTecnicos.AddRangeAsync(listaEntidad);
            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public Task<ElementosTecnicoDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ElementosTecnicoDTO>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

       
    }
}
