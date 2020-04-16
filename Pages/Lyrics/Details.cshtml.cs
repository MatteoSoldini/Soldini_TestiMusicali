using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soldini_TestiMusicali.Data;
using Soldini_TestiMusicali.Models;

namespace Soldini_TestiMusicali
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Soldini_TestiMusicali.Data.Soldini_TestiMusicaliContext _context;

        public DetailsModel(Soldini_TestiMusicali.Data.Soldini_TestiMusicaliContext context)
        {
            _context = context;
        }

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
    }
}
