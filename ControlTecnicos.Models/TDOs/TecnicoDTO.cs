using ControlTecnicos.Models.Entities;
namespace ControlTecnicos.Models.TDOs
{
    public class TecnicoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public decimal SueldoBase { get; set; }

        public int? SucursalId { get; set; }

        public DateTime? FechaDeCreacion { get; set; }

        public DateTime? FechaDeModificacion { get; set; }

        public virtual List<ElementosTecnicoDTO> ElementosTecnicos { get; set; } = new List<ElementosTecnicoDTO>();

        public virtual Sucursal? Sucursal { get; set; }
    }
}
