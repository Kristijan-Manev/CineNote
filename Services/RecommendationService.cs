using CineNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineNote.Services
{
    public static class RecommendationService
    {
        private const int DesiredCount = 50;

        public static List<Movie> GetRecommendations()
        {
            List<Movie> allUserMovies = MovieService.LoadMovies();
            var watched = allUserMovies.Where(m => m.Watched).ToList();
            var watchlist = allUserMovies.Where(m => !m.Watched).ToList();

            string favGenre = watched
                              .GroupBy(m => m.Genre, StringComparer.OrdinalIgnoreCase)
                              .OrderByDescending(g => g.Count())
                              .Select(g => g.Key)
                              .FirstOrDefault();

            List<Movie> pool = MovieCatalog.All();

            var knownTitles = new HashSet<string>(
                watched.Select(m => m.Title)
                       .Concat(watchlist.Select(m => m.Title)),
                StringComparer.OrdinalIgnoreCase);

            pool = pool
                   .Where(m => !knownTitles.Contains(m.Title))
                   .ToList();

            if (!string.IsNullOrEmpty(favGenre))
            {
                pool = pool
                       .OrderByDescending(m => string.Equals(m.Genre, favGenre,
                                              StringComparison.OrdinalIgnoreCase))
                       .ThenBy(m => m.Title)  
                       .ToList();
            }

            if (pool.Count > DesiredCount)
                pool = pool.Take(DesiredCount).ToList();
            return pool;
        }
    }
}
