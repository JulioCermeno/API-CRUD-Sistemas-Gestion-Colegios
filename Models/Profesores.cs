using System;
using System.Collections.Generic;

namespace Api_Web_Crud.Models;

public partial class Profesores
{
    public int IdProfesor { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public string Materia { get; set; } = null!;

    public int AñosExperiencia { get; set; }
}
