using System;
using System.Collections.Generic;

namespace Api_Web_Crud.Models;

public partial class Cursos
{
    public int IdCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public int Nivel { get; set; }

    public int Capacidad { get; set; }

    public DateTime Horario { get; set; }
}
