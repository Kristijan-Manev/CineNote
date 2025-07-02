using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNote.Services
{
    internal class GenreService
    {
        private static readonly HashSet<string> _known = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public static IEnumerable<string> LoadAllGenres() => _known.OrderBy(g => g);

        public static void EnsureGenreExists(string genre)
        {
            if (!string.IsNullOrWhiteSpace(genre))
                _known.Add(genre.Trim());
        }
    }
}
