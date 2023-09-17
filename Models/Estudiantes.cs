using System;
using System.Collections.Generic;

namespace Api_Web_Crud.Models;

public partial class Estudiantes
{
    public int IdEstudiante { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public string Grado { get; set; } = null!;

    public float? Promedio { get; set; }
}
