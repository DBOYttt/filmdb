namespace film_db
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            // Logika logowania
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            // Logika rejestracji
        }

        private async void OnContinueAsGuestClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(GuestPage));
        }

    }
}