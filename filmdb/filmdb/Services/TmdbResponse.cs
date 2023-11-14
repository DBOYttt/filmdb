using System.Collections.Generic;
using filmdb;
using Newtonsoft.Json;

public class TmdbResponse
{
    [JsonProperty("results")]
    public List<Movie> Results { get; set; }

    // Dodaj inne pola z odpowiedzi API, takie jak 'page', 'total_pages', 'total_results' itp.
}

