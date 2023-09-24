using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Asamblea
{
    public int IdAsamblea { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public string Lugar { get; set; } = null!;

    public string Agenda { get; set; } = null!;

    public int IdActa { get; set; }

    public int IdUsuario { get; set; }

    public virtual Acta IdActaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Votacion> Votaciones { get; set; } = new List<Votacion>();
}
