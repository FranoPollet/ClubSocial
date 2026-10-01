using Microsoft.Maui.Controls;

namespace ClubSocial
{
    public partial class AppShell : Shell
    {
        public AppShell(MainPage mainPage)
        {
            InitializeComponent();
            // Esta página ya viene con su ViewModel.
            SociosContent.Content = mainPage;
        }
    }
}
