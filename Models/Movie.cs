using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNote.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime DateWatched { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public bool Watched { get; set; }

    }
}
