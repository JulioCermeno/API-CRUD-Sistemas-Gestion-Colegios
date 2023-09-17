using Api_Web_Crud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Web_Crud.Data
{
    public class EstudianteContexto : DbContext
    {
        public EstudianteContexto(DbContextOptions<EstudianteContexto> options) : base(options) 
        { 
        }
       
        //crear nuestro dbset
        public DbSet<Estudiantes> EstudianteItems { get; set; }
    }
}
