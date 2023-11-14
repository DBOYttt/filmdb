using filmdb;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class MoviesViewModel : INotifyPropertyChanged
{
    private TmdbService _tmdbService = new TmdbService();
    public ObservableCollection<Movie> Movies { get; private set; }
    public Movie SelectedMovie { get; set; }

    public Command<Movie> MovieSelectedCommand { get; }

    public MoviesViewModel()
    {
        Movies = new ObservableCollection<Movie>();
        MovieSelectedCommand = new Command<Movie>(OnMovieSelected);
        LoadMovies();
    }

    private async void OnMovieSelected(Movie movie)
    {
        if (movie != null)
        {
            await Shell.Current.GoToAsync(nameof(MovieDetailsPage), true, new Dictionary<string, object>
            {
                {"movie", movie}
            });
        }
    }

    private async void LoadMovies()
    {
        var response = await _tmdbService.GetPopularMoviesAsync();
        foreach (var movie in response.Results)
        {
            Movies.Add(movie);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
