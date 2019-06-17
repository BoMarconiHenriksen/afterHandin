using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendNextGen.Models;

namespace R3NextGenBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public FormsController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Forms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Form>>> GetForm()
        {
            var list = _context.Form
                .Include(form => form.FormFields)
                    .ThenInclude(FormFields => FormFields.Component)
                .Include(c => c.CompletedForms)
                 .ToListAsync();
            return await list;
        }

         // GET: api/Forms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Form>> GetForm(long id)
        {
            var dd = _context.Form.ToList();
            var form = await _context.Form.FindAsync(id);

            if (form == null)
            {
                return NotFound();
            }

            return form;
        }

        // PUT: api/Forms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForm(long id, Form form)
        {

            if (id != form.Id)
            {
                return BadRequest();
            }


            // Edit Form table
            _context.Entry(form).State = EntityState.Modified;

            // Edit headline in FormFields
            foreach (var f in form.FormFields)
            {
                _context.Entry(f).State = EntityState.Modified;
            }

            // Edit date in CompletedForms
            foreach (var f in form.CompletedForms)
            {
                _context.Entry(f).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(id))
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

        // POST: api/Forms
        [HttpPost]
        public async Task<ActionResult<Form>> PostForm(Form form)
        {
            if (form.Name == null)
            {
                return BadRequest();
            }

            _context.Form.Add(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForm", new { id = form.Id }, form);
        }

        // DELETE: api/Forms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Form>> DeleteForm(long id)
        {
            var form = await _context.Form.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }

            _context.Form.Remove(form);
            await _context.SaveChangesAsync();

            return form;
        }

        private bool FormExists(long id)
        {
            return _context.Form.Any(e => e.Id == id);
        }
    }
}
