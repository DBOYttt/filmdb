using Refit;
using System.Threading.Tasks;

public interface ITmdbApi
{
    [Get("/movie/popular?api_key={apiKey}")]
    Task<TmdbResponse> GetPopularMovies(string apiKey);
}

