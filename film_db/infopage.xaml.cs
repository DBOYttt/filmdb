namespace film_db;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // Powr�t do poprzedniej strony
    }
}