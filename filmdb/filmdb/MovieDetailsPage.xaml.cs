namespace filmdb;

public partial class MovieDetailsPage : ContentPage
{
    public MovieDetailsPage(Movie movie)
    {
        InitializeComponent();
        BindingContext = movie;
    }
}
