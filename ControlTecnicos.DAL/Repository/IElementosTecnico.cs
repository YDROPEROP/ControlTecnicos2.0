using ControlTecnicos.Models.TDOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTecnicos.DAL.Repository
{
    public interface IElementosTecnico: IGenericRepository<ElementosTecnicoDTO>
    {
        Task<bool> InsertarTodosElelementosTec(List<ElementosTecnicoDTO> elementosTecnicos);
        Task<bool> ActulizarListaET(List<ElementosTecnicoDTO> elementosTecnicoDTOs);
    }
}
