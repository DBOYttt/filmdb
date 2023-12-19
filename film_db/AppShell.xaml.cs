namespace film_db
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GuestPage), typeof(GuestPage));
            Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
        }
    }
}