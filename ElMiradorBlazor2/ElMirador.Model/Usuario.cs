using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int IdRol { get; set; }

    public virtual ICollection<Asamblea> Asambleas { get; set; } = new List<Asamblea>();

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Votacion> Votaciones { get; set; } = new List<Votacion>();
}
