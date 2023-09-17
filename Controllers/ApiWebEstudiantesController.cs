using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Api_Web_Crud.Models;
using Microsoft.Build.Framework;
using NuGet.Protocol;
using Api_Web_Crud.Data;

namespace Api_Web_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiWebEstudiantesController : Controller
    {
        private readonly CrudApiWebContext _context;

        public ApiWebEstudiantesController(CrudApiWebContext context)
        {
            _context = context;
        }

        //Peticion tipo GET: api/estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiantes>>> GetEstudianteItems()
        {
            return await _context.EstudianteItems.ToListAsync();
        }

        //Peticion tipo GET: un solo registro: api/estudiantes/2
        [HttpGet("{IdEstudiante}")]
        public async Task<ActionResult<Estudiantes>> GetEstudianteItems(int IdEstudiante)
        {
            var EstudianteItem = await _context.EstudianteItems.FindAsync(IdEstudiante);

            if(EstudianteItem == null)

            {

                return NotFound();
            }

            return EstudianteItem;
            
        }

        ///Peticion de tipo POST: api/estudiantes
        [HttpPost]
        public async Task<ActionResult<Estudiantes>> PostEstudianteItem(Estudiantes item)
        {
            _context.EstudianteItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudianteItems), new { id = item.IdEstudiante }, item);
        }


        //Peticion de tipo PUT: api/estudiantes
        [HttpPut("{IdEstudiante}")]
        public async Task<IActionResult> PutEstudianteItem(int IdEstudiante, Estudiantes Item)
        {
            if (IdEstudiante != Item.IdEstudiante)
            {
                return BadRequest();
            }

            _context.Entry(Item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //peticion delete para borra: api/estudiantes
        [HttpDelete("{IdEstudiante}")]
        public async Task<IActionResult> DeleteEstudianteItem(int IdEstudiante)
        {
            var EstudianteItem = await _context.EstudianteItems.FindAsync(IdEstudiante);

            if (EstudianteItem == null)
            {
                return NotFound();
            }

            _context.EstudianteItems.Remove(EstudianteItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
