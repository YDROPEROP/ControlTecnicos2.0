﻿namespace ControlTecnicos.Models.Entities;

public partial class Sucursal
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tecnico> Tecnicos { get; set; } = new List<Tecnico>();
}
