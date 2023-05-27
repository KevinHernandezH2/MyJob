using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyJob.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJob.Controllers
{
    public class EmpleoController : Controller
    {
 


    
        [ApiController]
        [Route("api/[controller]")]
        public class EmpleosController : ControllerBase
        {
            private readonly MyJobDBContext _context; // Reemplaza "YourDbContext" con el nombre de tu contexto de base de datos

            public EmpleosController(MyJobDBContext context)
            {
                _context = context;
            }

            // GET: api/Empleos
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Empleo>>> GetEmpleos()
            {
                return await _context.Empleos.ToListAsync();
            }

            // GET: api/Empleos/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Empleo>> GetEmpleo(int id)
            {
                var empleo = await _context.Empleos.FindAsync(id);

                if (empleo == null)
                {
                    return NotFound();
                }

                return empleo;
            }

            // POST: api/Empleos
            [HttpPost]
            public async Task<ActionResult<Empleo>> CreateEmpleo(Empleo empleo)
            {
                _context.Empleos.Add(empleo);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEmpleo), new { id = empleo.Id }, empleo);
            }

            // PUT: api/Empleos/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateEmpleo(int id, Empleo empleo)
            {
                if (id != empleo.Id)
                {
                    return BadRequest();
                }

                _context.Entry(empleo).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleoExists(id))
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

            // DELETE: api/Empleos/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEmpleo(int id)
            {
                var empleo = await _context.Empleos.FindAsync(id);
                if (empleo == null)
                {
                    return NotFound();
                }

                _context.Empleos.Remove(empleo);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool EmpleoExists(int id)
            {
                return _context.Empleos.Any(e => e.Id == id);
            }
        }
    }

}

