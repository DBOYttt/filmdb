namespace film_db;

public partial class GuestPage : ContentPage
{
    private TmdbService tmdbService;

    public GuestPage()
    {
        InitializeComponent();
        tmdbService = new TmdbService();
        LoadMovies();
    }

    private async void LoadMovies()
    {
        var movieItems = await tmdbService.GetPopularMoviesAsync();
        var listItems = movieItems.Select(m => new ListItem
        {
            Id = m.Id,
            ImageUrl = m.PosterPath,
            Title = m.Title,
            Description = m.Description
        }).ToList();

        ItemsCollectionView.ItemsSource = listItems;
    }
    public class ListItem
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // Powrót do poprzedniej strony
    }

    private async void OnInfoButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Microsoft.Maui.Controls.Button;
        if (button != null)
        {
            var itemId = (int)button.CommandParameter;
            // Mo¿esz przekazaæ ID do strony InfoPage, jeœli jest potrzebne
            await Shell.Current.GoToAsync(nameof(InfoPage));
        }
    }
}