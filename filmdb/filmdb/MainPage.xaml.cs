namespace filmdb
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MoviesViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Movie movie)
            {
                await Shell.Current.GoToAsync(nameof(MovieDetailsPage), true, new Dictionary<string, object>
            {
                {"movie", movie}
            });
            }

            // Odznaczanie elementu
            ((ListView)sender).SelectedItem = null;
        }
    }


}