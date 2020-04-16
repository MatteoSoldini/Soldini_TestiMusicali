using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Soldini_TestiMusicali.Data;
using Soldini_TestiMusicali.Models;

namespace Soldini_TestiMusicali
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Soldini_TestiMusicali.Data.Soldini_TestiMusicaliContext _context;

        public CreateModel(Soldini_TestiMusicali.Data.Soldini_TestiMusicaliContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lyric Lyric { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Lyric.owner_id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _context.Lyric.Add(Lyric);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}