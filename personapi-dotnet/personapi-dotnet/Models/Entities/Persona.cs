using System;
using System.Collections.Generic;

namespace personapi_dotnet.Models.Entities;

public partial class Persona
{
    public int Cc { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int? Edad { get; set; }

    public virtual ICollection<Estudios> Estudios { get; set; } = new List<Estudios>();

    public virtual ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
}
