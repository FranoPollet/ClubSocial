using ClubSocial.Views;
using Microsoft.Maui.Controls;

namespace ClubSocial
{
    public partial class AppShell : Shell
    {
        public AppShell(MainPage mainPage, ClimaPage climaPage)
        {
            InitializeComponent();

            SociosContent.Content = mainPage;
            ClimaContent.Content = climaPage;

            Routing.RegisterRoute(
                "detalleClima",
                typeof(DetalleClimaPage));
        }
    }
}