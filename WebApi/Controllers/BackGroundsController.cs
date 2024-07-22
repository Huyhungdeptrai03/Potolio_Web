using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppApi.Model;
using nguyentienlink_api.Controllers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackGroundsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BackGroundsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BackGrounds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BackGround>>> GetBackGrounds()
        {
            return await _context.BackGrounds.ToListAsync();
        }

        // GET: api/BackGrounds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BackGround>> GetBackGround(int id)
        {
            var backGround = await _context.BackGrounds.FindAsync(id);

            if (backGround == null)
            {
                return NotFound();
            }

            return backGround;
        }

        // PUT: api/BackGrounds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBackGround(int id, BackGround backGround)
        {
            if (id != backGround.Id_BackGroud)
            {
                return BadRequest();
            }

            _context.Entry(backGround).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BackGroundExists(id))
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

        // POST: api/BackGrounds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BackGround>> PostBackGround(BackGround backGround,string path)
        {
            backGround = new BackGround();
            Xulyanh xl = new Xulyanh();
            backGround.BackGround_Image = xl.Xuly(path);
            _context.BackGrounds.Add(backGround);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBackGround", new { id = backGround.Id_BackGroud }, backGround);
        }

        // DELETE: api/BackGrounds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBackGround(int id)
        {
            var backGround = await _context.BackGrounds.FindAsync(id);
            if (backGround == null)
            {
                return NotFound();
            }

            _context.BackGrounds.Remove(backGround);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BackGroundExists(int id)
        {
            return _context.BackGrounds.Any(e => e.Id_BackGroud == id);
        }
    }
}
