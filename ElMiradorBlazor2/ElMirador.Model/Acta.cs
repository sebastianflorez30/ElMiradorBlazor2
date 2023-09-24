using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Acta
{
    public int IdActa { get; set; }

    public DateTime FechaAsamblea { get; set; }

    public TimeSpan HoraAsamblea { get; set; }

    public string Texto { get; set; } = null!;

    public virtual ICollection<Asamblea> Asambleas { get; set; } = new List<Asamblea>();
}
