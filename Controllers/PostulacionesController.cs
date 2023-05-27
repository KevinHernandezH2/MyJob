using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyJob.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyJob.Controllers
{
    public class PostulacionesController : Controller
    
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PostulacionesSController : ControllerBase
        {
            private readonly MyJobDBContext _context; // Reemplaza "YourDbContext" con el nombre de tu contexto de base de datos

            public PostulacionesSController(MyJobDBContext context)
            {
                _context = context;
            }

            // GET: api/Postulaciones
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Postulaciones>>> GetPostulaciones()
            {
                return await _context.Postulaciones.ToListAsync();
            }

            // GET: api/Postulaciones/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Postulaciones>> GetPostulacion(int id)
            {
                var postulacion = await _context.Postulaciones.FindAsync(id);

                if (postulacion == null)
                {
                    return NotFound();
                }

                return postulacion;
            }

            // POST: api/Postulaciones
            [HttpPost]
            public async Task<ActionResult<Postulaciones>> CreatePostulacion(Postulaciones postulacion)
            {
                _context.Postulaciones.Add(postulacion);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPostulacion), new { id = postulacion.Id }, postulacion);
            }

            // PUT: api/Postulaciones/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePostulacion(int id, Postulaciones postulacion)
            {
                if (id != postulacion.Id)
                {
                    return BadRequest();
                }

                _context.Entry(postulacion).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostulacionExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // DELETE: api/Postulaciones/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePostulacion(int id)
            {
                var postulacion = await _context.Postulaciones.FindAsync(id);
                if (postulacion == null)
                {
                    return NotFound();
                }

                _context.Postulaciones.Remove(postulacion);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool PostulacionExists(int id)
            {
                return _context.Postulaciones.Any(e => e.Id == id);
            }
        }
    }


}
