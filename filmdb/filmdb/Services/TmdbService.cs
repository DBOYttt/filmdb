using Refit;
using System.Threading.Tasks;

public class TmdbService
{
    private const string BaseUrl = "https://api.themoviedb.org/3";
    private const string ApiKey = "dc29801f482a90d40ba5b75f9665f120"; // Tutaj wpisz swój klucz

    public async Task<TmdbResponse> GetPopularMoviesAsync()
    {
        var tmdbApi = RestService.For<ITmdbApi>(BaseUrl);
        return await tmdbApi.GetPopularMovies(ApiKey);
    }
}

