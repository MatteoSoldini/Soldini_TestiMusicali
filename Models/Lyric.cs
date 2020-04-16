using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soldini_TestiMusicali.Models
{
    public class Lyric
    {
        public int id { get; set; }
        public string owner_id { get; set; }
        public string song { get; set; }
        public string artist { get; set; }
        public string writer { get; set; }
        public DateTime release_date { get; set; }
        public string text { get; set; }
    }
}
