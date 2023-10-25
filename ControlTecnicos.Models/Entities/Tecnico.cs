namespace ControlTecnicos.Models.Entities;

public partial class Tecnico
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public decimal SueldoBase { get; set; }

    public int? SucursalId { get; set; }

    public DateTime? FechaDeCreacion { get; set; }

    public DateTime? FechaDeModificacion { get; set; }

    public virtual ICollection<ElementosTecnico> ElementosTecnicos { get; set; } = new List<ElementosTecnico>();

    public virtual Sucursal? Sucursal { get; set; }
}
