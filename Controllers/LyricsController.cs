using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soldini_TestiMusicali.Data;
using Soldini_TestiMusicali.Models;

namespace Soldini_TestiMusicali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LyricsController : ControllerBase
    {
        private readonly Soldini_TestiMusicaliContext _context;

        public LyricsController(Soldini_TestiMusicaliContext context)
        {
            _context = context;
        }

        // GET: api/Lyrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lyric>>> GetLyric()
        {
            return await _context.Lyric.ToListAsync();
        }

        // GET: api/Lyrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lyric>> GetLyric(int id)
        {
            var lyric = await _context.Lyric.FindAsync(id);

            if (lyric == null)
            {
                return NotFound();
            }

            return lyric;
        }

        // PUT: api/Lyrics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLyric(int id, Lyric lyric)
        {
            if (id != lyric.id)
            {
                return BadRequest();
            }

            _context.Entry(lyric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LyricExists(id))
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

        // POST: api/Lyrics
        [HttpPost]
        public async Task<ActionResult<Lyric>> PostLyric(Lyric lyric)
        {
            _context.Lyric.Add(lyric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLyric", new { id = lyric.id }, lyric);
        }

        // DELETE: api/Lyrics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lyric>> DeleteLyric(int id)
        {
            var lyric = await _context.Lyric.FindAsync(id);
            if (lyric == null)
            {
                return NotFound();
            }

            _context.Lyric.Remove(lyric);
            await _context.SaveChangesAsync();

            return lyric;
        }

        private bool LyricExists(int id)
        {
            return _context.Lyric.Any(e => e.id == id);
        }
    }
}
