using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.Models.TDOs
{
    public class ElementosTecnicoDTO
    {
        public int Id { get; set; }

        public int? TecnicoId { get; set; }

        public int? ElementoId { get; set; }

        public int Cantidad { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual Elemento? Elemento { get; set; }

        public virtual Tecnico? Tecnico { get; set; }
    }
}
