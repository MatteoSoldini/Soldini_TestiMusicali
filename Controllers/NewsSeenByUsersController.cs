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
    public class NewsSeenByUsersController : ControllerBase
    {
        private readonly Soldini_TestiMusicaliContext _context;

        public NewsSeenByUsersController(Soldini_TestiMusicaliContext context)
        {
            _context = context;
        }

        // GET: api/NewsSeenByUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsSeenByUser>>> GetNewsSeenByUser()
        {
            return await _context.NewsSeenByUser.ToListAsync();
        }

        // GET: api/NewsSeenByUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsSeenByUser>> GetNewsSeenByUser(int id)
        {
            var newsSeenByUser = await _context.NewsSeenByUser.FindAsync(id);

            if (newsSeenByUser == null)
            {
                return NotFound();
            }

            return newsSeenByUser;
        }

        // PUT: api/NewsSeenByUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsSeenByUser(int id, NewsSeenByUser newsSeenByUser)
        {
            if (id != newsSeenByUser.id)
            {
                return BadRequest();
            }

            _context.Entry(newsSeenByUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsSeenByUserExists(id))
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

        // POST: api/NewsSeenByUsers
        [HttpPost]
        public async Task<ActionResult<NewsSeenByUser>> PostNewsSeenByUser(NewsSeenByUser newsSeenByUser)
        {
            _context.NewsSeenByUser.Add(newsSeenByUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsSeenByUser", new { id = newsSeenByUser.id }, newsSeenByUser);
        }

        // DELETE: api/NewsSeenByUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsSeenByUser>> DeleteNewsSeenByUser(int id)
        {
            var newsSeenByUser = await _context.NewsSeenByUser.FindAsync(id);
            if (newsSeenByUser == null)
            {
                return NotFound();
            }

            _context.NewsSeenByUser.Remove(newsSeenByUser);
            await _context.SaveChangesAsync();

            return newsSeenByUser;
        }

        private bool NewsSeenByUserExists(int id)
        {
            return _context.NewsSeenByUser.Any(e => e.id == id);
        }
    }
}
