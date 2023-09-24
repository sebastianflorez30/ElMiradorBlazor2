using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Votacion
{
    public int IdVotacion { get; set; }

    public int IdUsuario { get; set; }

    public int IdAsamblea { get; set; }

    public string Preguntas { get; set; } = null!;

    public string Resultados { get; set; } = null!;

    public virtual Asamblea IdAsambleaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
