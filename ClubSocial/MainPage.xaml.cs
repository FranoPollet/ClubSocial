using ClubSocial.ViewModels;
using Microsoft.Maui.Controls;

namespace ClubSocial
{
    public partial class MainPage : ContentPage
    {
        public MainPage(SociosViewModel viewModel)
        {
            InitializeComponent();

            // La pantalla toma sus datos y comandos del ViewModel.
            BindingContext = viewModel;
        }
    }
}
