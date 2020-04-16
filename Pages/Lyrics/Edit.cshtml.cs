using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soldini_TestiMusicali.Data;
using Soldini_TestiMusicali.Models;

namespace Soldini_TestiMusicali
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Soldini_TestiMusicali.Data.Soldini_TestiMusicaliContext _context;

        public EditModel(Soldini_TestiMusicali.Data.Soldini_TestiMusicaliContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lyric Lyric { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lyric = await _context.Lyric.FirstOrDefaultAsync(m => m.id == id);

            if (Lyric == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lyric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LyricExists(Lyric.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }

        private bool LyricExists(int id)
        {
            return _context.Lyric.Any(e => e.id == id);
        }
    }
}
