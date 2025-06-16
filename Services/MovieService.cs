using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineNote.Models;
using System.Text.Json;

namespace CineNote.Services
{
    public static class MovieService
    {
        private static readonly string filePath = "movies.json";

        public static List<Movie> LoadMovies()
        {
            if(!File.Exists(filePath))
                return new List<Movie>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        public static void SaveMovie(Movie movie)
        {
            var movies = LoadMovies();
            movies.Add(movie);
            string json = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(filePath, json);

        }

        public static void SaveAllMovies(List<Movie> movies)
        {
            var dir=Path.GetDirectoryName(Path.GetFullPath(filePath));
            
            Directory.CreateDirectory(dir);

            var json= JsonSerializer.Serialize(movies,new JsonSerializerOptions { WriteIndented = true });  
            File.WriteAllText(filePath, json);  
        }
    }
}
