using ControlTecnicos.BLL.Servicios;
using ControlTecnicos.DAL.Repository;
using ControlTecnicos.Models.TDOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ControlTecnicosUI_V2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {

        private readonly ITecnicoService _tecnicoService;
        private readonly ISucursalService _sucursalService;
        private readonly IElementoService _elementoService;
        private readonly IElementosTecnicoService _elementosTecnicoService;

        public TecnicosController(
            ITecnicoService tecnicoService,
            ISucursalService sucursalService,
            IElementoService elementoService,
            IElementosTecnicoService elementosTecnicoService            
            )
        {
            this._tecnicoService = tecnicoService;
            this._elementoService = elementoService;
            this._sucursalService = sucursalService;
            this._elementosTecnicoService = elementosTecnicoService;
        }

        [HttpGet]
        public async Task<List<TecnicoDTO>> ObtenerTecnicos()
        {
            return await _tecnicoService.ObtenerTodos();
        }

        [HttpGet("Elementos")]
        public async Task<List<ElementosDTO>> ObetnerElementos()
        {
            return await this._elementoService.ObtenerTodos();
        }
        [HttpGet("Sucursales")]
        public async Task<List<SucursalDTO>> ObtenerSucursales() {

            return await this._sucursalService.ObtenerTodos();
        }

        [HttpPost]
        public async Task<TecnicoDTO> Insertar(TecnicoDTO tecnicoDTO)
        {
            var tecnico= await this._tecnicoService.Insertar(tecnicoDTO);

            if (tecnico.Id > 0)
            {
                tecnicoDTO.ElementosTecnicos.ForEach(et => et.TecnicoId= tecnico.Id);
                await this._elementosTecnicoService.Insertar(tecnicoDTO.ElementosTecnicos);
            }   
            
            return tecnicoDTO;
        }
        [HttpDelete]
        public async Task<bool> Eliminar(int id)
        {
            await this._elementosTecnicoService.Eliminar(id);
            await this._tecnicoService.Eliminar(id);
            

            return true;
        }
        [HttpPut]
        public async Task<bool> Actualizar(TecnicoDTO tecnicoDTO)
        {
            await this._tecnicoService.Actualizar(tecnicoDTO);
            await this._elementosTecnicoService.Actualizar(tecnicoDTO.ElementosTecnicos);
            return true;
        }

    }
}
