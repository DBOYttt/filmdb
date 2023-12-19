using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace film_db
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        private string _posterPath;
        public string PosterPath
        {
            get { return _posterPath; }
            set { _posterPath = $"https://image.tmdb.org/t/p/w500{value}"; }
        }

        public string Description { get; set; }
    }




    public class TmdbService
    {
        private string apiKey = "dc29801f482a90d40ba5b75f9665f120";
        private string baseUrl = "https://api.themoviedb.org/3/movie/popular?api_key=";

        public async Task<List<Movie>> GetPopularMoviesAsync()
        {
            var url = $"{baseUrl}{apiKey}";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var movies = JsonConvert.DeserializeObject<MovieResponse>(json).Results;
                    return movies.Select(m => new Movie
                    {
                        Id = m.Id,
                        Title = m.Title,
                        PosterPath = m.PosterPath, // Tutaj używamy zaktualizowanej właściwości
                        Description = m.Overview
                    }).ToList();
                }
                else
                {
                    // Obsługa błędów, na przykład zwrócenie pustej listy
                    return new List<Movie>();
                }
            }
        }
    }

    public class MovieResponse
    {
        public List<MovieResult> Results { get; set; }
    }

    public class MovieResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
    }
}
