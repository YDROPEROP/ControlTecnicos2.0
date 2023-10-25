using ControlTecnicos.Models.Entities;
namespace ControlTecnicos.Models.TDOs
{
    public class ElementosDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<ElementosTecnico> ElementosTecnicos { get; set; } = new List<ElementosTecnico>();
    }
}
