using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyJob.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyJob.Controllers
{
    public class UsuarioController : Controller
    {

        [ApiController]
        [Route("api/[controller]")]
        public class UsuariosController : ControllerBase
        {
            private readonly MyJobDBContext _context; 

            public UsuariosController(MyJobDBContext context)
            {
                _context = context;
            }

            // GET: api/Usuarios
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
            {
                return await _context.Usuarios.ToListAsync();
            }

            // GET: api/Usuarios/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Usuario>> GetUsuario(int id)
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                return usuario;
            }

            // POST: api/Usuarios
            [HttpPost]
            public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
            }

            // PUT: api/Usuarios/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
            {
                if (id != usuario.Id)
                {
                    return BadRequest();
                }

                _context.Entry(usuario).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(id))
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

            // DELETE: api/Usuarios/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUsuario(int id)
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool UsuarioExists(int id)
            {
                return _context.Usuarios.Any(e => e.Id == id);
            }
        }
    }
}

