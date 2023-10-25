using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.Models.TDOs
{
    public class SucursalDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Tecnico> Tecnicos { get; set; } = new List<Tecnico>();
    }
}
