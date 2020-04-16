using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Soldini_TestiMusicali.Models;

namespace Soldini_TestiMusicali.Data
{
    public class Soldini_TestiMusicaliContext : DbContext
    {
        public Soldini_TestiMusicaliContext (DbContextOptions<Soldini_TestiMusicaliContext> options)
            : base(options)
        {
        }

        public DbSet<Soldini_TestiMusicali.Models.Lyric> Lyric { get; set; }

        public DbSet<Soldini_TestiMusicali.Models.NewsSeenByUser> NewsSeenByUser { get; set; }
    }
}
