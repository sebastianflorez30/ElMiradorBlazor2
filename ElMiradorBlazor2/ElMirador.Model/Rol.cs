using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Administrador { get; set; }

    public string? Propietario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
