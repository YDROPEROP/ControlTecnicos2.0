namespace ControlTecnicos.Models.Entities;

public partial class Elemento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<ElementosTecnico> ElementosTecnicos { get; set; } = new List<ElementosTecnico>();
}
