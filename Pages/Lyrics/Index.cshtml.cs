using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soldini_TestiMusicali.Data;
using Soldini_TestiMusicali.Models;

namespace Soldini_TestiMusicali
{
    public class IndexModel : PageModel
    {
        private readonly Soldini_TestiMusicali.Data.Soldini_TestiMusicaliContext _context;

        public IndexModel(Soldini_TestiMusicali.Data.Soldini_TestiMusicaliContext context)
        {
            _context = context;
        }

        public IList<Lyric> Lyric { get;set; }

        public async Task OnGetAsync()
        {
            Lyric = await _context.Lyric.ToListAsync();
        }
    }
}
